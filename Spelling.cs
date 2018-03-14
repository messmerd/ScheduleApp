﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SpellingCorrector
{
    /// <summary>
    /// Conversion from http://norvig.com/spell-correct.html by C.Small
    /// </summary>
    public class Spelling
    {
        private Dictionary<String, int> _dictionary = new Dictionary<String, int>();
        private static Regex _wordRegex = new Regex("([a-{]|[/-:])+", RegexOptions.Compiled);

        public Spelling()
        {
            string fileContent = File.ReadAllText("course_dictionary.txt");  
            //string fileContent = File.ReadAllText("big.txt");  
            List<string> wordList = fileContent.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var word in wordList)
            {
                foreach (var word2 in word.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string trimmedWord = word2.Trim().ToLower();
                    if (_wordRegex.IsMatch(trimmedWord))  // if (true) 
                    {
                        if (_dictionary.ContainsKey(trimmedWord))
                            _dictionary[trimmedWord]++;
                        else
                        {
                            _dictionary.Add(trimmedWord, 1);
                            //Console.WriteLine("{0}", trimmedWord);
                        }
                    }
                }
            
            }
        }

        public string Correct(string word)
        {
            word = word.Replace(" ", "{"); //Added by Dalton

            if (string.IsNullOrEmpty(word))
                return word;

            word = word.ToLower();

            // known()
            if (_dictionary.ContainsKey(word))
            {
                //Console.WriteLine("Exact match."); 
                return word.Replace("{", " ");

            }

            List<String> list = Edits(word);
            Dictionary<string, int> candidates = new Dictionary<string, int>();

            foreach (string wordVariation in list)
            {
                if (_dictionary.ContainsKey(wordVariation) && !candidates.ContainsKey(wordVariation))
                    candidates.Add(wordVariation, _dictionary[wordVariation]);
            }

            if (candidates.Count > 0)
                return candidates.OrderByDescending(x => x.Value).First().Key.Replace("{", " ");

            // known_edits2()
            foreach (string item in list)
            {
                foreach (string wordVariation in Edits(item))
                {
                    if (_dictionary.ContainsKey(wordVariation) && !candidates.ContainsKey(wordVariation))
                        candidates.Add(wordVariation, _dictionary[wordVariation]);
                }
            }

            return (candidates.Count > 0) ? candidates.OrderByDescending(x => x.Value).First().Key.Replace("{", " ") : "<Unable to correct>";  // was word.Replace("{", " ") instead of "<Unable to correct>"
        }

        private List<string> Edits(string word)
        {
            var splits = new List<Tuple<string, string>>();
            var transposes = new List<string>();
            var deletes = new List<string>();
            var replaces = new List<string>();
            var inserts = new List<string>();

            // Splits
            for (int i = 0; i < word.Length; i++)
            {
                var tuple = new Tuple<string, string>(word.Substring(0, i), word.Substring(i));
                splits.Add(tuple);
            }

            // Deletes
            for (int i = 0; i < splits.Count; i++)
            {
                string a = splits[i].Item1;
                string b = splits[i].Item2;
                if (!string.IsNullOrEmpty(b))
                {
                    deletes.Add(a + b.Substring(1));
                }
            }

            // Transposes
            for (int i = 0; i < splits.Count; i++)
            {
                string a = splits[i].Item1;
                string b = splits[i].Item2;
                if (b.Length > 1)
                {
                    transposes.Add(a + b[1] + b[0] + b.Substring(2));
                }
            }

            // Replaces
            for (int i = 0; i < splits.Count; i++)
            {
                string a = splits[i].Item1;
                string b = splits[i].Item2;
                if (!string.IsNullOrEmpty(b))
                {
                    for (char c = 'a'; c <= '{'; c++)
                    {
                        replaces.Add(a + c + b.Substring(1));
                    }
                    for (char c = '/'; c <= ':'; c++)   // Includes all the numbers as well 
                    {
                        replaces.Add(a + c + b.Substring(1));
                    }
                }
            }

            // Inserts
            for (int i = 0; i < splits.Count; i++)
            {
                string a = splits[i].Item1;
                string b = splits[i].Item2;
                for (char c = 'a'; c <= '{'; c++)
                {
                    inserts.Add(a + c + b);
                }
                for (char c = '/'; c <= ':'; c++)  // Includes all the numbers as well
                {
                    inserts.Add(a + c + b);
                }
            }

            return deletes.Union(transposes).Union(replaces).Union(inserts).ToList();
        }
    }
}