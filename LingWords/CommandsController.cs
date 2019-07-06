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
            "/help"
        };

        Dictionary<string, Delegate> keyValuePairs = new Dictionary<string, Delegate>();

        public CommandsController()
        {
            keyValuePairs.Add("/start", new Action( () => StartCommand()));
            keyValuePairs.Add("/help", new Action( () => HelpCommand()));
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

        public void HelpCommand()
        {
            int length = CommandString.Length;

            for (int i = 0; i < length; i++)
                Console.WriteLine(CommandString[i]);
        }

        public void StartCommand()
        {
            Console.WriteLine("Enter the word collection name:");
            string collectionName = Console.ReadLine();

            WordLoader wordLoader = new WordLoader();

            List<TranslatePair> translatePairs = wordLoader.Load(collectionName);
        }
    }
}
