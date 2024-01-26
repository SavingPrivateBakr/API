namespace Akram.Models.Entity
{
    public class Journal
    {
        public Guid ID { get; set; }

        public DateTime EntryDate { get; set; }

        public int SourceID { get; set; }

        public string Notes { get; set; }

        public List<JournalDetail> JournalDetails { get; set; }


    }
}
