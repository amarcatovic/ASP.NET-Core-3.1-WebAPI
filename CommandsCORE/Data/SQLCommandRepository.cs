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

        public void AddCommand(Command command)
        {
            if (command == null)
                throw new ArgumentNullException();

            _context.Add(command);
        }

        public void DeleteCommand(Command command)
        {
            if (command == null)
                throw new ArgumentNullException();

            _context.Remove(command);
        }

        public bool Done()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.SingleOrDefault(c => c.Id == id);
        }

        public void UpdateCommand(Command command)
        {
            
        }
    }
}
