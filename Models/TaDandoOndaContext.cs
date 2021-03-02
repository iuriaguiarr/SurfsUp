using Microsoft.EntityFrameworkCore;

namespace TaDandoOnda.Models
{
    public class TaDandoOndaContext : DbContext
    {
        public TaDandoOndaContext(DbContextOptions<TaDandoOndaContext> options) : base(options){}
        public DbSet<Surfista> Surfistas { get; set; }
        public DbSet<Manobra> Manobras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Surfista>()
                .HasMany(c => c.Manobras)
                .WithOne(e => e.Surfista)
                .OnDelete(DeleteBehavior.SetNull);

        }

    }
}