using OpenNos.Master.Library.Client;
using System;
using System.Configuration;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class LaunchEventController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Index([FromBody] LaunchEventModel launchEventModel)
        {
            if (launchEventModel.VerificationToken != ConfigurationManager.AppSettings["VerificationToken"]) return BadRequest();

            // At least not necessary but just to check
            if (MallServiceClient.Instance.Authenticate(ConfigurationManager.AppSettings["MasterAuthKey"]))
            {
                ServerServiceClient.Instance.LaunchEvent(launchEventModel.EventName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Event {launchEventModel.EventName} have been started !");
                Console.ResetColor();
                return Ok();
            }

            return BadRequest();
        }
    }
}
