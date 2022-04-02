using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Application.Interfaces;

namespace PhoneBook.Application.PhoneBook.Queries.GetPhoneNoteList;

public class GetPhoneNoteListQueryHandler : IRequestHandler<GetPhoneNoteListQuery, PhoneNoteListVm>
{
    private readonly IPhoneBookDBContext _dbContext;
    private readonly IMapper _mapper;

    public GetPhoneNoteListQueryHandler(IPhoneBookDBContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PhoneNoteListVm> Handle(GetPhoneNoteListQuery request, CancellationToken cancellationToken)
    {
        var notesQuery = await _dbContext.PhoneNotes
            // .Where(el => true)
            .ProjectTo<PhoneNoteLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new PhoneNoteListVm { PhoneNotes = notesQuery };
    }
}