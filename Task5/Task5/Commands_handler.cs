using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Commands_handler
    {
        private string[] COMMANDS = { "create", "add", "transfer", "close", "list"};
        private readonly string UNDO = "undo";
        private readonly string EXIT = "exit";
        public int[] Request(string command)
        {
            string[] words = command.Split(' ');
            var result = new int[words.Length];

            if (CheckValidCommand(words[0]))
            {
                result[0] = ProcessCommand(words[0]);
            }
            else
            {
                result[0] = (int)EXCEPTION.WRONG_COMMAND;
            }

            for (int i = 1; i < words.Length; i++)
            {
                try
                {
                    result[i] = Convert.ToInt32(words[i]);
                }
                catch (Exception e)
                {
                    result[0] = (int)EXCEPTION.WRONG_ARGUMENT;
                }
            }
            return result;
        }

        private int ProcessCommand(string command)
        {
            if (command == UNDO)
                return Int32.MinValue;
            if (command == EXIT)
                return Int32.MaxValue;
            return Array.IndexOf(COMMANDS, command);
        }

        private bool CheckValidCommand(string command)
        {
            return COMMANDS.Contains(command.ToLower()) || command == UNDO || command == EXIT;
        }

        public string CommandsToString()
        {
            var result = "";
            foreach (var command in COMMANDS)
            {
                result += command;
                result += " ";
            }
            return result + UNDO + " " + EXIT;
        }
    }
}
