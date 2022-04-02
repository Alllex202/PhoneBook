using MediatR;

namespace PhoneBook.Application.PhoneBook.Commands.UpdatePhoneNote;

public class UpdatePhoneNoteCommand : IRequest
{
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; }
    public string PhoneOwner { get; set; }
}