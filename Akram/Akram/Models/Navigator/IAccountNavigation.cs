using Akram.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Akram.Models.Navigator
{
    public interface IAccountNavigation
    {

        public bool CheckAccount(Guid id);

        public List<Account> GetAll();

        public Account? GetAccount(Guid id);
    }

   }
