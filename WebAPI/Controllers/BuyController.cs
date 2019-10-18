using OpenNos.Master.Library.Client;
using OpenNos.Master.Library.Data;
using System;
using System.Linq;
using System.Web.Http;
using WebAPI.Context;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class BuyController : ApiController
    {
        public DatabaseContext _context;

        public BuyController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IHttpActionResult Index(ItemModel model)
        {
            try
            {
                var account = _context.Account.FirstOrDefault(s => s.VerificationToken == model.VerificationToken);
                var item = _context.NosmalllItem.FirstOrDefault(s => s.VNum == model.ItemVNum);
                if (account == null || item == null)
                {
                    return BadRequest();
                }

                if(account.Coins - item.Price < 0)
                {
                    return BadRequest();
                }

                if (MallServiceClient.Instance.Authenticate(model.MallAuthKey))
                {
                    MallServiceClient.Instance.SendItem(model.CharacterId, new MallItem()
                    {
                        ItemVNum = model.ItemVNum,
                        Amount = model.Amount,
                        Rare = model.Rare,
                        Upgrade = model.Upgrade,
                        Level = model.Level
                    });
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"[INFO] {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second} - Item send to the CharacterId : {model.CharacterId}");
                    account.Coins -= (int)item.Price;
                    _context.SaveChanges();
                    return Ok($"Item succeffuly send to the character {model.CharacterId}");
                }

                return BadRequest();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
