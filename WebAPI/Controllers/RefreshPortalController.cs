using OpenNos.Master.Library.Client;
using System;
using System.Configuration;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class RefreshPortalController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Index([FromBody] PortalRefreshModel portalRefreshEvent)
        {
            try
            {
                if (CommunicationServiceClient.Instance.Authenticate(ConfigurationManager.AppSettings["MasterAuthKey"]))
                {
                    CommunicationServiceClient.Instance.RefreshPortal(portalRefreshEvent.MapId, portalRefreshEvent.mapInstanceType);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[INFO] {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} - Portal on the map {portalRefreshEvent.MapId} has been refreshed");
                    Console.ResetColor();
                    return Ok("Portal has been refreshed");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return BadRequest();
        }
    }
}
