﻿using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class UpdateBazaarController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Index(BazaarModel bazaarModel)
        {
            /*
            if (MallServiceClient.Instance.Authenticate(ConfigurationManager.AppSettings["MasterAuthKey"]))
            {
                string worldGroup = CommunicationServiceClient.Instance.RetrieveOriginWorldId(bazaarModel.AccountId);
                CommunicationServiceClient.Instance.UpdateBazaar(worldGroup, bazaarModel.BazaarItemId);
                return Ok("Bazaar succefull updated");
            }
            */

            return BadRequest();
        }
    }
}
