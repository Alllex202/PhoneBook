using MediatR;

namespace PhoneBook.Application.PhoneBook.Commands.CreatePhoneNote;

public class CreatePhoneNoteCommand : IRequest<Guid>
{
    public string PhoneNumber { get; set; }
    public string PhoneOwner { get; set; }
}