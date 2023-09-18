using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Money_Manager.Models
{
    // repository context
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Currency> Currencies { get; set; } = null!;
        public DbSet<AccountGroup> AccountGroups { get; set; } = null!;
        public DbSet<OperationType> OperationTypes { get; set; } = null!;
        public DbSet<Operation> Operations { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>()
                .HasData(
                new Currency() { CurrencyName = "Euro" },
                new Currency() { CurrencyName = "Hryvnia" },
                new Currency() { CurrencyName = "Rupi" },
                new Currency() { CurrencyName = "Dollar" },
                new Currency() { CurrencyName = "Zloti" });

            modelBuilder.Entity<AccountGroup>()
                .HasData(
                new AccountGroup() { Name = "Card" },
                new AccountGroup() { Name = "Cash" },
                new AccountGroup() { Name = "Investments" },
                new AccountGroup() { Name = "Insurance" },
                new AccountGroup() { Name = "Debit Card" },
                new AccountGroup() { Name = "Other" },
                new AccountGroup() { Name = "Savings" },
                new AccountGroup() { Name = "Loan" },
                new AccountGroup() { Name = "Overdraft" },
                new AccountGroup() { Name = "Accounts" });
            modelBuilder.Entity<OperationType>()
                .HasData(
                new OperationType() { OperationName = DefaultOperationTypes.Expence },
                new OperationType() { OperationName = DefaultOperationTypes.Income },
                new OperationType() { OperationName = DefaultOperationTypes.Transfer });
            modelBuilder.Entity<Category>()
                .HasData(
                new Category() { Name = "Food" },
                new Category() { Name = "Social Life" },
                new Category() { Name = "Self-development" },
                new Category() { Name = "Transportation" },
                new Category() { Name = "Culture" },
                new Category() { Name = "Beauty" },
                new Category() { Name = "Health" },
                new Category() { Name = "Education" },
                new Category() { Name = "Gift" },
                new Category() { Name = "Subscriotions" },
                new Category() { Name = "Other" }
                );
        }
    }
}
