using Microsoft.EntityFrameworkCore;
using PhoneBook.Domain;

namespace PhoneBook.Application.Interfaces;

public interface IPhoneBookDBContext
{
    DbSet<PhoneNote> PhoneNotes { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}