using Microsoft.EntityFrameworkCore;

namespace RosariumBackEnd.Entities.Entities
{
    public class MyApplicationDbContext : DbContext
    {

        public MyApplicationDbContext(DbContextOptions<MyApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Evangelho> Evangelho { get; set; }
        public DbSet<Salmo> Salmo { get; set; }
        public DbSet<Liturgia> Liturgia { get; set; }
        public DbSet<PrimeiraLeitura> PrimeiraLeitura { get; set; }
    }
}