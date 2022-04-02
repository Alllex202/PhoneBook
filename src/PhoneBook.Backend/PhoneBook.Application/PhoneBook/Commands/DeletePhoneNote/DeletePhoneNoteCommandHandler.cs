using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Common.Exceptions;
using PhoneBook.Application.Interfaces;
using PhoneBook.Domain;

namespace PhoneBook.Application.PhoneBook.Commands.DeletePhoneNote;

public class DeletePhoneNoteCommandHandler : IRequestHandler<DeletePhoneNoteCommand>
{
    private readonly IPhoneBookDBContext _dbContext;

    public DeletePhoneNoteCommandHandler(IPhoneBookDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(DeletePhoneNoteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.PhoneNotes.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(PhoneNote), request.Id);
        }

        _dbContext.PhoneNotes.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}