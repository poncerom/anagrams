using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anagram.Business
{
    public class LetterValues
    {
        public Int32[] letterValues = new Int32[26];

        

        public LetterValues(String phrase)
        {
            phrase = phrase.ToLowerInvariant();
            char[] letters = phrase.Trim().ToCharArray();

            foreach (var letter in letters)
            {
                if (char.IsLetter(letter))
                {
                    if (((int)letter - (int)'a') <= 25)
                    {
                        letterValues[(int)letter - (int)'a']++;
                    }
                }
            }
        }

        public Int32 GetLetterCount(Char letter)
        {
            if (!Char.IsLetter(letter))
            {
                throw new ArgumentOutOfRangeException();
            }

            return letterValues.Where(x => x == ((int)letter - (int)'a')).Count();
        }

        public LetterValues GetWordFromPhrase(LetterValues newWordValues)
        {
            LetterValues result = new LetterValues(String.Empty);
            Int32[] original = letterValues;
            Int32[] checkedValue = newWordValues.letterValues;

            for(int i = 0; i < result.letterValues.Length; i++)
            {
                result.letterValues[i] = original[i] - checkedValue[i];

                if(result.letterValues[i] < 0)
                {
                    return null;
                }
            }
            return result;
        }
    }
}