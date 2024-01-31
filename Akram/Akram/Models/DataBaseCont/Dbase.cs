

using Akram.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Akram.Models.DBc
{
    public class Dbase : DbContext
    {
        public Dbase(DbContextOptions<Dbase> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          //  optionsBuilder.UseSqlServer("Data Source=LAPTOP-HD9LIS85;Initial Catalog=Akram;Integrated Security=True;Encrypt=False;Trust Server Certificate=True");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Journal>().HasMany(w => w.JournalDetails).WithOne(g => g.Journal).HasForeignKey(w => w.JournalID);
            modelBuilder.Entity<Account>().HasMany(w => w.JournalDetails).WithOne(w => w.Account).HasForeignKey(w => w.AccountID);

        }
        public DbSet<Journal> Journals { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<JournalDetail> JournalDetails { get; set; }
    }
}
