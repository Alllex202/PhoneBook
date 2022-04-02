namespace PhoneBook.Domain;

public class PhoneNote
{
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; }
    public string PhoneOwner { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? EditDate { get; set; }
}