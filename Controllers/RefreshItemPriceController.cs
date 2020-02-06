using OpenNos.Master.Library.Client;
using System;
using System.Configuration;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class RefreshItemPriceController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Index([FromBody] RefreshItemPriceModel itemPriceRefreshEvent)
        {
            try
            {
                if (CommunicationServiceClient.Instance.Authenticate(ConfigurationManager.AppSettings["MasterAuthKey"]))
                {
                    CommunicationServiceClient.Instance.RefreshItemPrice(itemPriceRefreshEvent.MapId);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[INFO] {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} - ShopItem on map {itemPriceRefreshEvent.MapId} has been refreshed");
                    Console.ResetColor();
                    return Ok("Portal has been refreshed");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return BadRequest();
        }
    }
}
