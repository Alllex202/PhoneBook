using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PhoneBook.Domain;

namespace PhoneBook.Persistence.EntityTypeConfigurations;

public class PhoneNoteConfiguration : IEntityTypeConfiguration<PhoneNote>
{
    public void Configure(EntityTypeBuilder<PhoneNote> builder)
    {
        builder.HasKey(phoneNote => phoneNote.Id);
        builder.HasIndex(phoneNote => phoneNote.Id).IsUnique();
        builder.Property(phoneNote => phoneNote.PhoneNumber).HasMaxLength(20);
        builder.Property(phoneNote => phoneNote.PhoneOwner).HasMaxLength(200);
    }
}