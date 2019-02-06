using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnagramWeb.Models
{
    public class AnagramsViewModel
    {
        public List<String> Anagrams
        {
            get;
            set;
        }

        public string EllapsedTime
        {
            get;
            set;
        }

        public AnagramsViewModel(List<string> anagrams, long milliseconds)
        {
            Anagrams = anagrams;
            EllapsedTime = milliseconds.ToString();
        }
    }
}