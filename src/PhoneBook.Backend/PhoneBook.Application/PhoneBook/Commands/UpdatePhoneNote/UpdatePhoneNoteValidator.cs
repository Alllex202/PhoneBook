using FluentValidation;

namespace PhoneBook.Application.PhoneBook.Commands.UpdatePhoneNote;

public class UpdatePhoneNoteValidator : AbstractValidator<UpdatePhoneNoteCommand>
{
    public UpdatePhoneNoteValidator()
    {
        RuleFor(updatePhoneNoteCommand => updatePhoneNoteCommand.Id)
            .NotEqual(Guid.Empty);

        RuleFor(updatePhoneNoteCommand => updatePhoneNoteCommand.PhoneNumber)
            .NotEmpty()
            .MaximumLength(25)
            .MinimumLength(1);

        RuleFor(updatePhoneNoteCommand => updatePhoneNoteCommand.PhoneOwner)
            .NotEmpty()
            .MaximumLength(250);
    }
}