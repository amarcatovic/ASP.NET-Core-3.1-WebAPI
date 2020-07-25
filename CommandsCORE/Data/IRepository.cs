using CommandsCORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsCORE.Data
{
    public interface IRepository
    {
        bool Done();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void AddCommand(Command command);
        void UpdateCommand(Command command);
        void DeleteCommand(Command command);
    }
}
