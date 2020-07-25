using AutoMapper;
using CommandsCORE.Data;
using CommandsCORE.Dtos;
using CommandsCORE.Models;
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
    }
}
