using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATextClassificationTool.Domain
{
    public class BagOfWords
    {
        readonly IDictionary<string, int> bagOfWords;

		readonly IDictionary<string, int> bagOfWordsA;
		readonly IDictionary<string, int> bagOfWordsB;

		public BagOfWords()
        {
            bagOfWords = new SortedDictionary<string, int>();

			bagOfWordsA = new SortedDictionary<string, int>();
			bagOfWordsB = new SortedDictionary<string, int>();
		}

        public void InsertEntryA(string word)
        {
            word = word.Trim();
            if (word.Length == 0){
                return;
            }

			// Add to bagA
			if (bagOfWordsA.ContainsKey(word))
			{
				int countA = bagOfWordsA[word];
				countA++;
				bagOfWordsA[word] = countA;
			}
			else
			{
				bagOfWordsA.Add(word, 1);
			}
			// Add to bag total
			if (bagOfWords.ContainsKey(word))
            {
                
				int count = bagOfWords[word];
				count++;
				bagOfWords[word] = count;
            }
            else
            {
				bagOfWords.Add(word, 1);
			}
        }
		public void InsertEntryB(string word)
		{
			word = word.Trim();
			if (word.Length == 0)
			{
				return;
			}

			// Add to bagB
			if (bagOfWordsB.ContainsKey(word))
			{
				int countB = bagOfWordsB[word];
				countB++;
				bagOfWordsB[word] = countB;
			}
			else
			{
				bagOfWordsB.Add(word, 1);
			}
			// Add to bag total
			if (bagOfWords.ContainsKey(word))
			{
				int count = bagOfWords[word];
				count++;
				bagOfWords[word] = count;
			}
			else
			{
				bagOfWords.Add(word, 1);
			}
		}

		public ICollection<string> GetAllWordsInDictionary()
        {
            return bagOfWords.Keys;
        }

		public ICollection<string> GetAWordsInDictionary()
		{
			return bagOfWordsA.Keys;
		}

		public ICollection<string> GetBWordsInDictionary()
		{
			return bagOfWordsB.Keys;
		}

		public List<string> GetEntriesInDictionary()
        {
            List<string> entries = new List<string>();
            foreach(string key in bagOfWords.Keys)
            {
                entries.Add(key +" "+ bagOfWords[key]);
            }
            return entries;
        }
    }
}
