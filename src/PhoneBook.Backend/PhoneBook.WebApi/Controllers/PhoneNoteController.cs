using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.PhoneBook.Commands.CreatePhoneNote;
using PhoneBook.Application.PhoneBook.Commands.DeletePhoneNote;
using PhoneBook.Application.PhoneBook.Commands.UpdatePhoneNote;
using PhoneBook.Application.PhoneBook.Queries.GetPhoneNoteList;
using PhoneBook.WebApi.Models;

namespace PhoneBook.WebApi.Controllers;

[Produces("application/json")]
[Route("api/v1/[controller]")]
public class PhoneNoteController : BaseController
{
    private readonly IMapper _mapper;

    public PhoneNoteController(IMapper mapper)
    {
        _mapper = mapper;
    }

    /// <summary>
    /// Получить список телефонных номеров
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// GET /phonenote
    /// </remarks>
    /// <returns>Return PhoneNoteListVm</returns>
    /// <response code="200">Success</response>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<PhoneNoteListVm>> GetAll()
    {
        var query = new GetPhoneNoteListQuery { };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Создать новую запись в телефонной книге
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// POST /phonenote
    /// {
    ///     phoneNumber: "8-800-555-35-35",
    ///     phoneOwner: "Быстрый займ"
    /// }
    /// </remarks>
    /// <param name="createPhoneNoteDto">createPhoneNoteDto object</param>
    /// <returns>Return id (guid)</returns>
    /// <response code="201">Success</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<PhoneNoteListVm>> Create([FromBody] CreatePhoneNoteDto createPhoneNoteDto)
    {
        var command = _mapper.Map<CreatePhoneNoteCommand>(createPhoneNoteDto);
        var phoneNoteId = await Mediator.Send(command);
        return Ok(phoneNoteId);
    }

    /// <summary>
    /// Изменить запись в телефонной книге
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// PUT /phonenote
    /// {
    ///     phoneNumber: "+7-777-777-77-77",
    ///     phoneOwner: "Одинадцать топоров"
    /// }
    /// </remarks>
    /// <param name="updatePhoneNoteDto">updatePhoneNoteDto object</param>
    /// <returns>Return No Content</returns>
    /// <response code="204">No Content</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<PhoneNoteListVm>> Update([FromBody] UpdatePhoneNoteDto updatePhoneNoteDto)
    {
        var command = _mapper.Map<UpdatePhoneNoteCommand>(updatePhoneNoteDto);
        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Удалить запись в телефонной книге
    /// </summary>
    /// <remarks>
    /// Sample request:
    /// DELETE /phonenote/3fa85f64-5717-4562-b3fc-2c963f66afa6
    /// </remarks>
    /// <param name="id">Id of the phoneNote (guid)</param>
    /// <returns>Return No Content</returns>
    /// <response code="204">No Content</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<PhoneNoteListVm>> Delete(Guid id)
    {
        var command = new DeletePhoneNoteCommand
        {
            Id = id
        };
        await Mediator.Send(command);
        return NoContent();
    }
}