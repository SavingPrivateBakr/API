
using Akram.Models.DTO;
using Akram.Models.Entity;
using AutoMapper;

namespace Akram.Models.Automapper
{
    public class AuttoMapperInjector : Profile
    {

        public AuttoMapperInjector() {
        /*  var rr= new  MapperConfiguration(f =>
            {
                f.CreateMap<Account, AccountDTO>();
            });*/
            CreateMap<Account, AccountDTO>();
           
        }
    }
}
