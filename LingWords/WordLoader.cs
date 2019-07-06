using System;
using System.Collections.Generic;
using System.IO;

namespace LingWords
{
    class WordLoader
    {
        string appPath = @"C:\LingWords\";
        List<TranslatePair> wordPairs = new List<TranslatePair>();

        public WordLoader()
        {

        }

        public List<TranslatePair> Load(string collectionName)
        {
            string fullPath = appPath + collectionName + ".txt";

            if (!CheckFile(fullPath))
            {
                
                return null;
            }

            using (FileStream fstream = File.OpenRead(fullPath))
            {
                byte[] array = new byte[fstream.Length];

                fstream.Read(array, 0, array.Length);

                string textFromFile = System.Text.Encoding.Default.GetString(array);

                string[] pairs = textFromFile.Split('\n');

                int length = pairs.Length;

                for (int i = 0; i < length; i++)
                {
                    string[] vs = pairs[i].Split('-');

                    wordPairs.Add(new TranslatePair(vs[0], vs[1]));
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
