using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PatchListController : ApiController
    {
        public List<string> checkIfGenerated = new List<string>();

        [HttpPost]
        public IHttpActionResult Index([FromBody] PatchlistModel patchListModel)
        {
            if (patchListModel == null) return BadRequest();

            StringBuilder stringBuilder = new StringBuilder();
            int count = patchListModel.FileName.Length == 1 ? patchListModel.FileName.Length - 1 : patchListModel.FileName.Length;
            int count1 = 0;
            foreach (string names in patchListModel.FileName)
            {
                string name = names.Contains("/") ? names.Split('/').Last() : names;
                string folder = names.Contains("/") ? names.Remove(names.LastIndexOf('/')) : string.Empty;

                if (checkIfGenerated.Contains(name)) continue;
                count1++; // increment the line counter
                var client = new WebClient();
                if (!string.IsNullOrEmpty(folder))
                {
                    client.DownloadFile($"http://localhost/web/launcher/client_{patchListModel.ClientLanguage}/{folder}/{name}", name);
                }
                else
                {
                    client.DownloadFile($"http://localhost/web/launcher/client_{patchListModel.ClientLanguage}/{name}", name);
                }
                string directory = name;
                var fileInfo = new FileInfo(directory);

                string[] filePathSegments = directory.Split(Path.DirectorySeparatorChar);
                string fileName = filePathSegments[filePathSegments.Length - 1];

                using (FileStream fileStream = File.OpenRead(directory))
                {
                    byte[] buffer = new byte[fileStream.Length];
                    fileStream.Read(buffer, 0, (int)fileStream.Length);
                    MD5 md5 = new MD5CryptoServiceProvider();
                    byte[] checkSum = md5.ComputeHash(buffer);
                    if (!string.IsNullOrEmpty(folder))
                    {
                        stringBuilder.Append($"./{folder}/{fileName} {BitConverter.ToString(checkSum).Replace("-", string.Empty)} {fileInfo.Length}");
                    }
                    else
                    {
                        stringBuilder.Append($"{fileName} {BitConverter.ToString(checkSum).Replace("-", string.Empty)} {fileInfo.Length}");
                    }
                    if (count != count1) // If it's not the last line
                    {
                        stringBuilder.AppendFormat("{0}{1}", "  ", Environment.NewLine);
                    }
                    checkIfGenerated.Add(fileName);
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[INFO] {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} - Patchlist succeffully created");
            Console.ResetColor();
            return Ok(stringBuilder.ToString());
        }
    }
}