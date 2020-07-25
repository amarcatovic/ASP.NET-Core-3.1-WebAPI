using CommandsCORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandsCORE.Data
{
    public class MockRepository : IRepository
    {
        public void AddCommand(Command command)
        {
            throw new NotImplementedException();
        }

        public bool Done()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>()
            {
                new Command() {Id = 1, HowTo = "Create variable", CommandLine = "let NAME", Platform = "JavaScript"},
                new Command() {Id = 2, HowTo = "Create function", CommandLine = "public RETURN TYPE NAME (params)", Platform = "C#"},
                new Command() {Id = 3, HowTo = "Console write", CommandLine = "std::cout << ", Platform = "C++"},
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command() { Id = 0, 
                                    HowTo = "Select all data from table in SQL", 
                                    CommandLine = "SELECT * FROM [TABLE NAME]", 
                                    Platform = "T-SQL" 
                                  };
        }

        public void UpdateCommand(Command command)
        {
           
        }
    }
}
