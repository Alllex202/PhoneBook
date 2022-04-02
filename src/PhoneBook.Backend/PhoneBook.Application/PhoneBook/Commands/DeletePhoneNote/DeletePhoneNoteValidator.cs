using FluentValidation;

namespace PhoneBook.Application.PhoneBook.Commands.DeletePhoneNote;

public class DeletePhoneNoteValidator : AbstractValidator<DeletePhoneNoteCommand>
{
    public DeletePhoneNoteValidator()
    {
        RuleFor(deletePhoneNoteCommand => deletePhoneNoteCommand.Id)
            .NotEqual(Guid.Empty);
    }
}