using AutoMapper;
using PhoneBook.Application.Common.Mapping;
using PhoneBook.Domain;

namespace PhoneBook.Application.PhoneBook.Queries.GetPhoneNoteList;

public class PhoneNoteLookupDto : IMapWith<PhoneNote>
{
    public Guid Id { get; set; }
    public string PhoneNumber { get; set; }
    public string PhoneOwner { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<PhoneNote, PhoneNoteLookupDto>()
            .ForMember(phoneNoteDto => phoneNoteDto.Id,
                opt => opt.MapFrom((phoneNote => phoneNote.Id)))
            .ForMember(phoneNoteDto => phoneNoteDto.PhoneNumber,
                opt => opt.MapFrom(phoneNote => phoneNote.PhoneNumber))
            .ForMember(phoneNoteDto => phoneNoteDto.PhoneOwner,
                opt => opt.MapFrom(phoneNote => phoneNote.PhoneOwner));

    }
}