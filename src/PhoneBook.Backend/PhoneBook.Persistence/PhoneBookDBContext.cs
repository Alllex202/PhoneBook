using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain;
using PhoneBook.Persistence.EntityTypeConfigurations;

namespace PhoneBook.Persistence;

public class PhoneBookDBContext : DbContext, IPhoneBookDBContext
{
    public DbSet<PhoneNote> PhoneNotes { get; set; }

    public PhoneBookDBContext(DbContextOptions<PhoneBookDBContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new PhoneNoteConfiguration());
        base.OnModelCreating(builder);
    }
}