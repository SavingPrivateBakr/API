using Akram.Models.DBc;
using Akram.Models.Entity;
using Akram.Models.Navigator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Schema;

namespace Akram.Controllers
{
    [Route("api/AccountController")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly Db L;
        private readonly IAccountNavigation AccN;
        public AccountController(Db l, IAccountNavigation AccN)
        {
            L = l;
            this.AccN = AccN;
        }
        [HttpGet]
        public IActionResult GetALLID()
        {
            List<Account> accounts = L.Accounts.ToList();
            
            return Ok(accounts);

        }

       [HttpGet("{id}")]
        public IActionResult GetID(Guid id)
        {
            
            return (AccN.GetAccount(id)==null?BadRequest():Ok(AccN.GetAccount(id)));
            
        }
        [HttpPost]
        public IActionResult PostAccount(Account idd)
        {
            if (ModelState.IsValid)
            {
                L.Accounts.Add(idd);
                L.SaveChanges();
                var url = Url.Action(nameof(PostAccount),idd.ID);
                return CreatedAtAction(url, idd);
            }

            return BadRequest("Wrong");
        }

        [HttpPut("{id:Guid}")]

        public IActionResult PutAccount([FromBody]Account idd,[FromRoute]Guid id)
        {

            Account? old = AccN.GetAccount(id);


            if (old == null)
            {

                if (ModelState.IsValid)
                {
                    old.ID = idd.ID;
                    old.Number = idd.Number;
                    old.JournalDetails = idd.JournalDetails;
                    old.CanEdit = idd.CanEdit;
                    old.Note = idd.Note;
                    old.Name = idd.Name;

                    L.SaveChanges();

                    return Ok();
                }
            }

                return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteAccount(Guid id)
        {
            Account check = AccN.GetAccount(id);


            if (check != null)
            {
                L.Accounts.Remove(check);
                L.SaveChanges();
                return Ok(check);
            }
            return BadRequest();
        }
    }
}
