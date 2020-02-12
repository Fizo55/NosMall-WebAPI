using System.Configuration;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class LeavePlayerController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Index([FromBody] LeavePlayerModel leavePlayerModel)
        {
            if (leavePlayerModel.VerificationToken != ConfigurationManager.AppSettings["VerificationToken"]) return BadRequest();
            
            if (CommunicationServiceClient.Instance.Authenticate(ConfigurationManager.AppSettings["MasterAuthKey"]))
            {
                CommunicationServiceClient.Instance.DisconnectAccount(leavePlayerModel.AccountId);
                return Ok();
            }

            return BadRequest();
        }
    }
}