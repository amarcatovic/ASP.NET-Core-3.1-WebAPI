using CommandsCORE.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsCORE.Data
{
    public class CommandsContext : DbContext
    {
        public CommandsContext(DbContextOptions<CommandsContext> opt) : base(opt)
        {

        }

        public DbSet<Command> Commands { get; set; }
    }
}
