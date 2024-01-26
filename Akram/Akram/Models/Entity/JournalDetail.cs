namespace Akram.Models.Entity
{
    public class JournalDetail
    {
        public Guid Id { get; set; }
        public double Debit { get; set; }

        public double Credit { get; set; }

        public Guid JournalID { get; set; }

        public Guid AccountID { get; set; }

        public string Notes { get; set; }

        public Account Account { get; set; }

        public Journal Journal { get; set; }


    }
}
