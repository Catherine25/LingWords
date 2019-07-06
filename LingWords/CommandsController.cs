using System;
using System.Collections.Generic;

namespace LingWords
{
    class CommandsController
    {
        private string[] CommandString = new string[]
        {
            "/start",
            "/end",
            "/help",
        };

        Dictionary<string, Delegate> keyValuePairs = new Dictionary<string, Delegate>();

        public CommandsController()
        {
            keyValuePairs.Add("/help",
                new Action( () => WriteCommands()));
        }

        public void ReadCommand(string s)
        {
            int length = CommandString.Length;

            for (int i = 0; i < length; i++)
                if (CommandString[i] == s)
                {
                    Console.WriteLine();

                    keyValuePairs[s].DynamicInvoke();

                    Console.WriteLine();
                }
        }

        public void WriteCommands()
        {
            int length = CommandString.Length;

            for (int i = 0; i < length; i++)
                Console.WriteLine(CommandString[i]);
        }        
    }
}
