using Microsoft.EntityFrameworkCore;

namespace SingleLayerArchitecture
{
    public class ThreeLayerAtchitectureDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<TransferRecord> TransferRecords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ThreeLayerArchitecture;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
