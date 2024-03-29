﻿using System;
using System.Collections.Generic;

namespace LingWords
{
    class CommandsController
    {
        private string[] CommandString = new string[]
        {
            "/open",
            "/end",
            "/help"
        };

        Dictionary<string, Delegate> keyValuePairs = new Dictionary<string, Delegate>();

        public CommandsController()
        {
            keyValuePairs.Add("/open", new Action( () => OpenCommand()));
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

        public void OpenCommand()
        {
            Console.WriteLine("Enter the word collection name:");
            string collectionName = Console.ReadLine();

            WordLoader wordLoader = new WordLoader();

            IList<TranslatePair> translatePairs = wordLoader.Load(collectionName);

            if (translatePairs != null)
            {
                int[] vs = Algorithm.CountNumbers(translatePairs);

                int length = vs.Length;

                for (int i = 0; i < length; i++)
                    Console.Write("[" + i + "* - " + vs[i] + "] ");

                Console.WriteLine();
            }
        }
    }
}
