using System.Collections.Generic;
using System.IO;

namespace LingWords
{
    class WordLoader
    {
        string appPath = @"C:\LingWords\";
        Dictionary<string, string> wordPairs = new Dictionary<string, string>();

        public WordLoader()
        {

        }

        public Dictionary<string, string> Load(string collectionName)
        {
            if (!CheckFile(appPath + collectionName))
                return null;

            using (FileStream fstream = File.OpenRead(appPath + collectionName))
            {
                byte[] array = new byte[fstream.Length];

                fstream.Read(array, 0, array.Length);

                string textFromFile = System.Text.Encoding.Default.GetString(array);

                string[] pairs = textFromFile.Split('\n');

                int length = pairs.Length;

                for (int i = 0; i < length; i++)
                {
                    string[] vs = pairs[i].Split('-');

                    wordPairs[vs[0]] = vs[1];
                }
            }

            return wordPairs;
        }

        public bool CheckFile(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            if (fileInfo.Exists)
                return true;
            else
                return false;
        }
    }
}
