﻿using System;
using System.Collections.Generic;
using System.IO;

namespace LingWords
{
    class WordLoader
    {
        string appPath = @"C:\LingWords\";
        List<TranslatePair> wordPairs = new List<TranslatePair>();

        public WordLoader() { }

        public List<TranslatePair> Load(string collectionName)
        {
            string fullPath = appPath + collectionName + ".txt";

            if (!CheckFile(fullPath))
                return null;

            using (FileStream fstream = File.OpenRead(fullPath))
            {
                byte[] array = new byte[fstream.Length];

                fstream.Read(array, 0, array.Length);

                string textFromFile = System.Text.Encoding.Default.GetString(array);

                string[] pairs = textFromFile.Split('\n');

                for (int i = 0; i < pairs.Length; i++)
                {
                    string[] vs = pairs[i].Split(' ');

                    wordPairs.Add(new TranslatePair());

                    int counter = 0;

                    for (int j = 0; j < vs.Length; j++)
                    {
                        int cur = wordPairs.Count - 1;

                        if (vs[j] == "-")
                        {
                            counter++;
                            continue;
                        }

                        if (counter == 0)
                        {
                            wordPairs[cur].foreign += vs[j];
                            wordPairs[cur].foreign += ' ';
                        }
                        else if(counter == 1)
                        {
                            wordPairs[cur].native += vs[j];
                            wordPairs[cur].native += ' ';
                        }
                        else if(counter == 2)
                            wordPairs[cur].studyRating = int.Parse(vs[j]);
                    }
                }
            }

            return wordPairs;
        }

        public bool CheckFile(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            if (fileInfo.Exists)
            {
                if (fileInfo.Length == 0)
                    Console.WriteLine("The collection is empty!");

                else return true;
            }
            else
                Console.WriteLine("No such collection!");

            return false;
        }
    }
}
