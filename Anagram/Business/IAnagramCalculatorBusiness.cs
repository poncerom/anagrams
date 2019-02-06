using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Anagram.Models;

namespace Anagram.Business
{
    public interface IAnagramCalculatorBusiness
    {
         AnagramDataModel GetFormattedAnagrams(String phrase);
    }
}
