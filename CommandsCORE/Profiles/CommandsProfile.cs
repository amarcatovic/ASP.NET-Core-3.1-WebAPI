using AutoMapper;
using CommandsCORE.Dtos;
using CommandsCORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsCORE.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDto>();
            CreateMap<CommandCreateDto, Command>();
            CreateMap<Command, CommandUpdateDto>();
            CreateMap<CommandUpdateDto, Command>();
        }
    }
}
