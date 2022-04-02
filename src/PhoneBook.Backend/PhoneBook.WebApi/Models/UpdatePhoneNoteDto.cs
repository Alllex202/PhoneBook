using System.ComponentModel.DataAnnotations;
using AutoMapper;
using PhoneBook.Application.Common.Mapping;
using PhoneBook.Application.PhoneBook.Commands.UpdatePhoneNote;


namespace PhoneBook.WebApi.Models;

public class UpdatePhoneNoteDto : IMapWith<UpdatePhoneNoteCommand>
{
    [Required] public Guid Id { get; set; }
    [Required] public string PhoneNumber { get; set; }
    [Required] public string PhoneOwner { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdatePhoneNoteDto, UpdatePhoneNoteCommand>()
            .ForMember(phoneNoteCommand => phoneNoteCommand.Id,
                opt => opt.MapFrom(phoneNoteDto => phoneNoteDto.Id))
            .ForMember(phoneNoteCommand => phoneNoteCommand.PhoneNumber,
                opt => opt.MapFrom(phoneNoteDto => phoneNoteDto.PhoneNumber))
            .ForMember(phoneNoteCommand => phoneNoteCommand.PhoneOwner,
                opt => opt.MapFrom(phoneNoteDto => phoneNoteDto.PhoneOwner));
    }
}