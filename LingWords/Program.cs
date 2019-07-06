using System;

namespace LingWords
{
    class Program
    {
        static void Main(string[] args)
        {
            CommandsController commandsController = new CommandsController();
            Console.WriteLine("Hello!");

            string input = "";

            while (input != "/exit")
            {
                input = Console.ReadLine();

                if (input.StartsWith('/'))
                    commandsController.ReadCommand(input);
            }
        }
    }
}
