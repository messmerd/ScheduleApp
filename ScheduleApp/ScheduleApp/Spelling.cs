using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SpellingCorrector
{
    /// <summary>
    /// Conversion from http://norvig.com/spell-correct.html by C.Small. 
    /// Modified by Dalton Messmer. 
    /// </summary>
    /// 

    public class Spelling
    {
        private readonly Dictionary<String, List<int>> _dictionary = new Dictionary<String, List<int>>();
        private static readonly Regex _wordRegex = new Regex("[a-z]+", RegexOptions.Compiled);
        private List<string> fileContentLines; 

        public Spelling(string dictionary_filename)
        {
            string fileContent = "";
            try
            {
                fileContent = File.ReadAllText(dictionary_filename);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n");
                return;
            }

            fileContentLines = fileContent.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            int i = 0;

            foreach (var word in fileContentLines)
            {
                foreach (var word2 in word.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string trimmedWord = word2.Trim().ToLower();
                    if (true) // (_wordRegex.IsMatch(trimmedWord))  // Assuming every word in the dictionary file is good data to use 
                    {
                        if (_dictionary.ContainsKey(trimmedWord))
                        {
                            _dictionary[trimmedWord][0]++;
                            if (_dictionary[trimmedWord].Last() != i)  // So duplicates are not added 
                                _dictionary[trimmedWord].Add(i);
                        }
                        else
                        {
                            _dictionary.Add(trimmedWord, new List<int> { 1, i });
                        }
                    }
                }
                i++;
            }
        }

        public List<string> getDictionaryFileContents()
        {
            return fileContentLines;
        }

        public string CorrectSentence(string sentence)
        {
            if (string.IsNullOrEmpty(sentence))
                return sentence;

            var corrections = new List<string>();
            foreach (string word in sentence.Split(' '))
            {
                corrections.Add(Correct(word));
            }

            return string.Join(" ", corrections);
        }

        public string Correct(string word)
        {
            return CorrectExt(word, true).Key;
        }

        public KeyValuePair<string, List<int>> CorrectExt(string word, bool useCorrection)
        {
            if (word != null)
                word = word.ToLower();

            KeyValuePair<string, List<int>> wordPair;
            if (_dictionary.ContainsKey(word))
            {
                wordPair = new KeyValuePair<string, List<int>>(word, _dictionary[word]);
            }
            else
            {
                wordPair = new KeyValuePair<string, List<int>>(word, new List<int>());
                wordPair.Value.Add(0);
            }

            if (useCorrection == false)
                return wordPair;

            if (string.IsNullOrEmpty(word))
                return wordPair;

            // known()
            if (_dictionary.ContainsKey(word))
                return wordPair;

            List<String> list = Edits(word);
            Dictionary<string, List<int>> candidates = new Dictionary<string, List<int>>();

            foreach (string wordVariation in list)
            {
                if (_dictionary.ContainsKey(wordVariation) && !candidates.ContainsKey(wordVariation))
                    candidates.Add(wordVariation, _dictionary[wordVariation]);
            }

            if (candidates.Count > 0)
            {
                return candidates.OrderByDescending(x => x.Value[0]).First();
            }
            // known_edits2()
            foreach (string item in list)
            {
                foreach (string wordVariation in Edits(item))
                {
                    if (_dictionary.ContainsKey(wordVariation) && !candidates.ContainsKey(wordVariation))
                        candidates.Add(wordVariation, _dictionary[wordVariation]);
                }
            }

            return (candidates.Count > 0) ? candidates.OrderByDescending(x => x.Value[0]).First() : wordPair;
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
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        replaces.Add(a + c + b.Substring(1));
                    }
                    for (char c = '0'; c <= '9'; c++)
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
                for (char c = 'a'; c <= 'z'; c++)
                {
                    inserts.Add(a + c + b);
                }
                for (char c = '0'; c <= '9'; c++)
                {
                    inserts.Add(a + c + b);
                }
            }

            return deletes.Union(transposes).Union(replaces).Union(inserts).ToList();
        }
    }
}
