using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class PatchListController : ApiController
    {

        [HttpPost]
        public IHttpActionResult Index([FromBody] PatchlistModel patchListModel)
        {
            if (patchListModel == null) return BadRequest();

            StringBuilder stringBuilder = new StringBuilder();
            int count = patchListModel.FileName.Length;
            int count1 = 0;
            foreach (string name in patchListModel.FileName)
            {
                count1++; // increment the line counter
                var client = new WebClient();
                client.DownloadFile($"http://localhost/launcher/client_en/{name}", name); // TODO : Send the client_lang via the website
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
                    stringBuilder.Append($"{fileName} {BitConverter.ToString(checkSum).Replace("-", string.Empty)} {fileInfo.Length}");
                    if (count != count1) // If it's not the last line
                    {
                        stringBuilder.AppendFormat("{0}{1}", "  ", Environment.NewLine);
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[INFO] {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} - Patchlist succeffully created");
            Console.ResetColor();
            return Ok(stringBuilder.ToString());
        }
    }
}