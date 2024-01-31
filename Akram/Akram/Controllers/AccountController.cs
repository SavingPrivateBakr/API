using Akram.Models.Automapper;
using Akram.Models.DBc;
using Akram.Models.DTO;
using Akram.Models.Entity;
using Akram.Models.Navigator;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Schema;

namespace Akram.Controllers
{
    [Route("api/AccountController")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly Dbase L;
        private readonly IAccountNavigation AccN;
        private readonly IMapper Maper;
        private readonly IConfiguration config;
        public AccountController(Dbase l, IAccountNavigation AccN, IMapper Maper,IConfiguration config)
        {
            L = l;
            this.AccN = AccN;
            this.Maper = Maper;
            this.config=config;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetALLAccounts()
        {
            List<Account> accounts = L.Accounts.ToList();
            return Ok(accounts);

        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
       [HttpGet("{id}")]
        public IActionResult GetAccountByID([FromRoute]Guid id)
        {
            
            return (AccN.GetAccount(id)==null?NotFound():Ok(AccN.GetAccount(id)));
            
        }
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult PostAccount([FromBody]Account idd)
        {
            if (ModelState.IsValid)
            {
                L.Accounts.Add(idd);
                L.SaveChanges();
                var url = Url.Action(nameof(PostAccount),idd.ID);
                return CreatedAtAction(url, idd);
            }

            return BadRequest();
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAccountDetails([FromRoute]Guid id)
        {

            Account? old = AccN.GetAccount(id);


            if (old == null)
                return NotFound();

                   AccountDTO SaveChanger= Maper.Map<AccountDTO>(old);
                    L.SaveChanges();
                    return Ok(SaveChanger);

        }
        [HttpPut("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult PutAccount([FromBody]Account idd,[FromRoute] Guid id)
        {

            Account? old = AccN.GetAccount(id);


            if (old == null)
                return NotFound();

             Maper.Map(idd,old);
            L.SaveChanges();
            return Ok(old);

        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteAccount([FromHeader]Guid id)
        {
            Account check = AccN.GetAccount(id);

            if (check == null) 
                return NotFound();
      
                L.Accounts.Remove(check);
                L.SaveChanges();
                return Ok(check);
             
        }
    }
}
