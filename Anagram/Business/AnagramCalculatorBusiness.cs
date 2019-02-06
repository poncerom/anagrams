using System;
using System.Collections.Generic;
using AnagramRepository;
using Accord.Math;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Anagram.Business
{
    public class AnagramCalculatorBusiness : IAnagramCalculatorBusiness
    {
        private readonly IAnagramRepository _repository;

        public List<String> Inventory { get; private set; }
        public List<String> Anagrams { get; private set; }
        public List<String> WordDictionary { get; private set; }
        public List<String> AnagramsFormattedResults { get; set; }
        

        public AnagramCalculatorBusiness(IAnagramRepository repo)
        {
            Inventory = new List<string>();
            Anagrams = new List<string>();
            AnagramsFormattedResults = new List<string>();
            _repository = repo;
        }

        public Anagram.Models.AnagramDataModel GetFormattedAnagrams(String phrase)
        {
            String [] resultsArray = GetAnagrams(phrase).ToArray();
            
            var phraseLetterValues = new LetterValues(phrase);

            if(resultsArray.Length >= 2)
            {
                var watch = Stopwatch.StartNew();


                Parallel.ForEach(Combinatorics.Combinations<String>(resultsArray, 2, false), (combination) =>
                {
                    if (CheckIfStringsHaveTheSameFrequency(combination, phrase))
                    {
                        AnagramsFormattedResults.Add(ComposeAnagramsStrings(combination));
                    }
                });

                watch.Stop();

                return new Models.AnagramDataModel(AnagramsFormattedResults, watch.ElapsedMilliseconds);
            }
            return new Models.AnagramDataModel(new List<string>(), 0);
            
            
            
        }

        private Boolean CheckIfStringsHaveTheSameFrequency(string[] strings, string originalString)
        {
            var composedString = String.Empty;
            if(strings.Length > 1)
            {
                for(int i = 0; i < strings.Length; i++)
                {
                    composedString += strings[i];
                }

            }
            return (CheckIfValuesArraysAreEquals(new LetterValues(composedString.Replace(" ", String.Empty)).letterValues,
                new LetterValues(originalString.Replace(" ", String.Empty)).letterValues));
        }

        private static Boolean CheckIfValuesArraysAreEquals(Int32[] originalArray, Int32[] newArray)
        {
            if(originalArray.Length == newArray.Length)
            {
                for(int i = 0; i < originalArray.Length; i++)
                {
                    if(originalArray[i] != newArray[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        private static String ComposeAnagramsStrings(string[] strings)
        {
            String resultString = String.Empty;
            foreach (var miniString in strings)
            {
                resultString += " " + miniString;
            }

            return resultString;
        }

        private  List<String> GetAnagrams(String phrase)
        {             
            if(string.IsNullOrWhiteSpace(phrase))
            {
                throw new ArgumentNullException();
            }

            WordDictionary = _repository.ReadData();

            var phraseValues = new LetterValues(phrase);

            foreach (var word in WordDictionary)
            {
                var newWord = new LetterValues(word);

                if(phraseValues.GetWordFromPhrase(newWord) != null)
                {
                    Anagrams.Add(word);
                }
            }
            return Anagrams;
        }
    }
}