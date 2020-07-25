using CommandsCORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsCORE.Data
{
    public class SQLCommandRepository : IRepository
    {
        private readonly CommandsContext _context;

        public SQLCommandRepository(CommandsContext context)
        {
            _context = context;
        }
        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.SingleOrDefault(c => c.Id == id);
        }
    }
}
