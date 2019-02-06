using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace Anagram.Models
{
    public class AnagramDataModel
    {
        public List<string> Anagrams { get; set; }
        public long EllapsedTime { get; set; }

        public AnagramDataModel(List<string> anagrams, long ellapsedTime)
        {
            Anagrams = anagrams;
            EllapsedTime = ellapsedTime;
        }
    }
}