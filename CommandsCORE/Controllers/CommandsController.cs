using AutoMapper;
using CommandsCORE.Data;
using CommandsCORE.Dtos;
using CommandsCORE.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsCORE.Controllers
{
    [Route("api/Commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public CommandsController(IRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commands = _repo.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var command = _repo.GetCommandById(id);

            if (command == null)
                return NotFound();

            return Ok(_mapper.Map<CommandReadDto>(command));
        }

        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto newCommand)
        {
            var command = _mapper.Map<Command>(newCommand);
            _repo.AddCommand(command);
            _repo.Done();

            var commandReadDto = _mapper.Map<CommandReadDto>(command);

            return CreatedAtRoute(nameof(GetCommandById), new { id = commandReadDto.Id}, commandReadDto);
        }

        [HttpPut("{id}", Name = "UpdateCommand")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto command)
        {
            var commandWillUpdate = _repo.GetCommandById(id);

            if (commandWillUpdate == null)
                return NotFound();

            _mapper.Map(command, commandWillUpdate);

            _repo.UpdateCommand(commandWillUpdate);
            _repo.Done();

            return NoContent();
        }

        [HttpPatch("{id}", Name = "PatchUpdate")]
        public ActionResult PatchUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchArray)
        {
            var commandFromDb = _repo.GetCommandById(id);

            if (commandFromDb == null)
                return NotFound();

            var patchCommand = _mapper.Map<CommandUpdateDto>(commandFromDb);
            patchArray.ApplyTo(patchCommand, ModelState);

            if (!TryValidateModel(patchCommand))
                return ValidationProblem(ModelState);

            _mapper.Map(patchCommand, commandFromDb);

            _repo.UpdateCommand(commandFromDb);
            _repo.Done();

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteCommand(int id)
        {
            var command = _repo.GetCommandById(id);

            if (command == null)
                BadRequest();

            _repo.DeleteCommand(command);
            _repo.Done();

            return NoContent();
        }
    }
}
