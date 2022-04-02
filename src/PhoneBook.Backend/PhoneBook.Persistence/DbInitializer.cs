namespace PhoneBook.Persistence;

public class DbInitializer
{
    public static void Initialize(PhoneBookDBContext context)
    {
        context.Database.EnsureCreated();
    }
}