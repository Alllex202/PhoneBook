using MediatR;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain;

namespace PhoneBook.Application.PhoneBook.Commands.CreatePhoneNote;

public class CreatePhoneNoteCommandHandler : IRequestHandler<CreatePhoneNoteCommand, Guid>
{
    private readonly IPhoneBookDBContext _dbContext;

    public CreatePhoneNoteCommandHandler(IPhoneBookDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreatePhoneNoteCommand request, CancellationToken cancellationToken)
    {
        var phoneNote = new PhoneNote
        {
            Id = Guid.NewGuid(),
            PhoneNumber = request.PhoneNumber,
            PhoneOwner = request.PhoneOwner,
            CreationDate = DateTime.Now,
            EditDate = null
        };

        await _dbContext.PhoneNotes.AddAsync(phoneNote, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return phoneNote.Id;
    }
}