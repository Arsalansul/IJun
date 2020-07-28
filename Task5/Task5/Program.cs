using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            Commands_handler c_handler = new Commands_handler();
            string result = "";
            Console.Write("Enter command: ");
            while (result != "exit")
            {
                var receivedReply = c_handler.Request(Console.ReadLine());
                switch (receivedReply)
                {
                    case Int32.MaxValue:
                        result = "exit";
                        break;
                    case Int32.MinValue:
                        if(result.Length > 0)
                            result = result.Remove(result.Length - 1);
                        Console.WriteLine(result);
                        break;
                    case -1:
                        Console.WriteLine("Wrong command");
                        break;
                    default:
                        result += (receivedReply + 1).ToString();
                        Console.WriteLine(result);
                        break;
                }
            }
        }
    }

    class Commands_handler
    {
        readonly string[] COMMANDS = { "one", "two", "three", "four", "undo", "exit" };
        public int Request(string command)
        {
            if (CheckValidCommand(command))
            {
                return ProcessCommand(command);
            }
            return -1;
        }

        private int ProcessCommand(string command)
        {
            if (command == COMMANDS[4])
                return Int32.MinValue;
            if (command == COMMANDS[5])
                return Int32.MaxValue;
            return Array.IndexOf(COMMANDS, command);
        }

        private bool CheckValidCommand(string command)
        {
            return COMMANDS.Contains(command.ToLower());
        }
    }
}
