using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;

namespace AnagramRepository
{
    public class AnagramRepository : IAnagramRepository
    {
        public AnagramRepository() { }
        public List<String> ReadData()
        {
            String path = AppDomain.CurrentDomain.BaseDirectory + @"bin\wordlist.txt";

            System.IO.StreamReader dictionaryFile = new System.IO.StreamReader(path);
            String newLine;

            List<String> dictionaryInList = new List<string>();

            while((newLine = dictionaryFile.ReadLine()) != null)
            {
                if(newLine.Length > 2)
                {
                    dictionaryInList.Add(newLine);
                }
            }
            return dictionaryInList;
        }
       
    }
}
