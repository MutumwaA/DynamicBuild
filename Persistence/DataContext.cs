using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<WordType> WordTypes { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Sentence> Sentences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>()
                .HasOne(w => w.WordType)
                .WithMany(wt => wt.Words)
                .HasForeignKey(w => w.WordTypeId);
        }
    }
}
