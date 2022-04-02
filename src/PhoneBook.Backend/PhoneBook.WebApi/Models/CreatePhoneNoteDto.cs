using System.ComponentModel.DataAnnotations;
using AutoMapper;
using PhoneBook.Application.Common.Mapping;
using PhoneBook.Application.PhoneBook.Commands.CreatePhoneNote;

namespace PhoneBook.WebApi.Models;

public class CreatePhoneNoteDto : IMapWith<CreatePhoneNoteCommand>
{
    [Required] public string PhoneNumber { get; set; }
    [Required] public string PhoneOwner { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreatePhoneNoteDto, CreatePhoneNoteCommand>()
            .ForMember(phoneNoteCommand => phoneNoteCommand.PhoneNumber,
                opt => opt.MapFrom(phoneNoteDto => phoneNoteDto.PhoneNumber))
            .ForMember(phoneNoteCommand => phoneNoteCommand.PhoneOwner,
                opt => opt.MapFrom(phoneNoteDto => phoneNoteDto.PhoneOwner));
    }
}