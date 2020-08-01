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
            Response_Handler r_handler = new Response_Handler();

            Console.WriteLine("Available commands:");
            Console.WriteLine(c_handler.CommandsToString());

            string result = "";

            while (result != "exit")
            {
                Console.Write("\nEnter command: ");
                var response = c_handler.Request(Console.ReadLine());
                result = r_handler.Process_response(response);
                Console.WriteLine(result);
            }
        }
    }

    class Response_Handler
    {
        private Stack<int[]> prev_responses;
        List<Account> accounts = new List<Account>();
        public Response_Handler()
        {
            prev_responses = new Stack<int[]>();
        }

        public string Process_response(int[] response)
        {
            switch (response[0])
            {
                case Int32.MaxValue:
                    return "exit";
                case Int32.MinValue:
                    if (prev_responses.Count == 0)
                    {
                        return "No commands in stack";
                    }
                    return Undo(prev_responses.Pop());
                case (int)EXCEPTION.WRONG_COMMAND:
                    return "Wrong command";
                case (int)EXCEPTION.WRONG_ARGUMENT:
                    return "Wrong argument";
                case 0:
                    var account = new Account(accounts.Count);
                    accounts.Add(account);
                    prev_responses.Push(response);
                    return "Account created " + account.ID;
                case 1:
                    account = accounts.Find(i => i.ID == response[1]);

                    if (account == null)
                    {
                        response[0] = (int)EXCEPTION.WRONG_ARGUMENT;
                        return Process_response(response);
                    }
                    if (account.IsClosed())
                        return "Account closed";

                    account.AddMoney(response[2]);
                    prev_responses.Push(response);
                    return "Add money";
                case 2:
                    var account0 = accounts.Find(i => i.ID == response[1]);
                    var account1 = accounts.Find(i => i.ID == response[2]);

                    if (account0 == null || account1 == null)
                    {
                        response[0] = (int)EXCEPTION.WRONG_ARGUMENT;
                        return Process_response(response);
                    }

                    if (account0.IsClosed() || account1.IsClosed())
                        return "One or two accounts are closed";

                    account0.AddMoney(-response[3]);
                    account1.AddMoney(response[3]);
                    prev_responses.Push(response);
                    return "Transfer";
                case 3:
                    account = accounts.Find(i => i.ID == response[1]);
                    account.Close();
                    prev_responses.Push(response);
                    return "Close";
                case 4:
                    foreach (var acc in accounts)
                    {
                        Console.WriteLine(acc);
                    }

                    return "";
            }
            return "";
        }

        private string Undo(int[] last_respone)
        {
            switch (last_respone[0])
            {
                case 0:
                    accounts.Remove(accounts.Last());
                    return "Account removed";
                case 1:
                    var account = accounts.Find(i => i.ID == last_respone[1]);
                    account.AddMoney(-last_respone[2]);
                    return "took money";
                case 2:
                    var account0 = accounts.Find(i => i.ID == last_respone[1]);
                    var account1 = accounts.Find(i => i.ID == last_respone[2]);
                    account0.AddMoney(last_respone[3]);
                    account1.AddMoney(-last_respone[3]);
                    return "undo Transfer";
                case 3:
                    account = accounts.Find(i => i.ID == last_respone[1]);
                    account.Open();
                    return "Open";
            }
            return "";
        }
    }
    class Account
    {
        public readonly int ID;
        private int _money = 0;
        private bool _closed = false;
        public int Money => _money;

        public Account(int id)
        {
            ID = id;
        }

        public void AddMoney(int value)
        {
            if (_closed)
                return;
            _money += value;
            if (_money < 0)
                _money = 0;
        }

        public void Close()
        {
            _closed = true;
        }

        public void Open()
        {
            _closed = false;
        }

        public bool IsClosed()
        {
            return _closed;
        }

        public override string ToString()
        {
            return "ID " + ID + "\n" + "Money " + Money;
        }
    }
}
