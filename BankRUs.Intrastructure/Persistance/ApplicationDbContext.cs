using BankRUs.Domain.Entities;
using BankRUs.Intrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BankRUs.Intrastructure.Persistance;

public sealed class ApplicationDbContext
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<BankAccount> BankAccounts => Set<BankAccount>();
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // BankAccount decimal precision        
        builder.Entity<BankAccount>(entity =>
        {
            entity.Property(e => e.Balance)
                  .HasPrecision(18, 2); // 💰 Decimal precision for monetary values
            entity
                .HasIndex(b => b.AccountNumber)
                .IsUnique();
        });

        builder.Entity<BankAccount>().
            HasOne<ApplicationUser>().
            WithMany().
            HasForeignKey(b => b.UserId);

        // Ensure SocialSecurityNumber is unique
        builder.Entity<ApplicationUser>()
            .HasIndex(u => u.SocialSecurityNumber)
            .IsUnique();

        // Ensure Email is unique
        builder.Entity<ApplicationUser>()
           .HasIndex(u => u.Email)
           .IsUnique();

        //builder.Entity<BankAccount>()
        //    .Property(b => b.Balance)
        //    .HasPrecision(18, 2);
    }
}

