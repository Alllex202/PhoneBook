using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Common.Exceptions;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain;

namespace PhoneBook.Application.PhoneBook.Commands.UpdatePhoneNote;

public class UpdatePhoneNoteCommandHandler : IRequestHandler<UpdatePhoneNoteCommand>
{
    private readonly IPhoneBookDBContext _dbContext;

    public UpdatePhoneNoteCommandHandler(IPhoneBookDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UpdatePhoneNoteCommand request, CancellationToken cancellationToken)
    {
        var entity =
            await _dbContext.PhoneNotes.FirstOrDefaultAsync(phoneNote => phoneNote.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(PhoneNote), request.Id);
        }

        entity.PhoneNumber = request.PhoneNumber;
        entity.PhoneOwner = request.PhoneOwner;
        entity.EditDate = DateTime.Now;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}