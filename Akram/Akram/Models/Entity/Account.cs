using System.ComponentModel.DataAnnotations.Schema;

namespace Akram.Models.Entity
{
    public class Account
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public string Number { get; set; }



        public string Note { get; set; }

        public bool CanEdit { get; set; }


        public List<JournalDetail> JournalDetails { get; set; }
    }
}
