using Akram.Models.DBc;
using Akram.Models.Entity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;

namespace Akram.Models.Navigator
{
    public class AccountNavigation : IAccountNavigation
    {
        Dbase L;

        public AccountNavigation(Dbase l  )
        {
            L = l;
        }
        public bool CheckAccount(Guid id)
        {
            Account? w = L.Accounts.FirstOrDefault(w => w.ID == id);
            if (w == null)
            {
                return  false;
            }
            return true;
        }
        public List<Account> GetAll()
        {

           List<Account> accounts = L.Accounts.ToList();
            return accounts;
        }
        public Account? GetAccount(Guid id)
        {

 
           if (CheckAccount(id) == false)
            {
                return null;
            }
            
                return L.Accounts.FirstOrDefault(w => w.ID == id);
                

        }


        }
}
