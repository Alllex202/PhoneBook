using FluentValidation;

namespace PhoneBook.Application.PhoneBook.Commands.CreatePhoneNote;

public class CreatePhoneNoteValidator : AbstractValidator<CreatePhoneNoteCommand>
{
    public CreatePhoneNoteValidator()
    {
        RuleFor(createPhoneNoteCommand => createPhoneNoteCommand.PhoneNumber)
            .NotEmpty()
            .MaximumLength(25)
            .MinimumLength(1);
        
        RuleFor(createPhoneNoteCommand => createPhoneNoteCommand.PhoneOwner)
            .NotEmpty()
            .MaximumLength(250);
    }
}