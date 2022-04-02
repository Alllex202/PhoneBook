using MediatR;

namespace PhoneBook.Application.PhoneBook.Commands.DeletePhoneNote;

public class DeletePhoneNoteCommand : IRequest
{
    public Guid Id { get; set; }
}