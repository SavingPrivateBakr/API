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
        Db L;

        public AccountNavigation(Db l  )
        {
            L = l;
        }
        public Account? CheckAccount(Guid id)
        {
            Account? w = L.Accounts.FirstOrDefault(w => w.ID == id);
            if (w == null)
            {
                return  null;
            }
            return w ;
        }
        public List<Account> GetAll()
        {


           List<Account> accounts = L.Accounts.ToList();

            return accounts;

        }
        public Account? GetAccount(Guid id)
        {


           if (CheckAccount(id) == null)
            {
                return null;
            }
            
                return L.Accounts.FirstOrDefault(w => w.ID == id);
                

        }


        }
}
