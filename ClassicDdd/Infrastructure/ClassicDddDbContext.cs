using ClassicDdd.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassicDdd.Infrastructure
{
    public class ClassicDddDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ClassicDdd;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(action => CreateAccountMapping(action));
            //modelBuilder.Entity<TransferRecord>(action => CreateTransferRecordMapping(action));
        }

        private void CreateAccountMapping(EntityTypeBuilder<Account> entityType)
        {
            //entityType.HasKey(a => a.AccountId.BankNo);
            entityType.OwnsOne(a => a.AccountId);
            entityType.OwnsOne(a => a.Person);
            entityType.OwnsOne(a => a.Phone);
            entityType.OwnsOne(a => a.Balance);
        }

        private void CreateTransferRecordMapping(EntityTypeBuilder<TransferRecord> entityType)
        {
            //entityType.HasKey(t => t.Id.Id);
            entityType.HasNoKey();
            entityType.OwnsOne(t => t.FromAccountId);
            entityType.OwnsOne(t => t.ToAccountId);
            entityType.OwnsOne(t => t.TransferMoney);
        }
    }
}
