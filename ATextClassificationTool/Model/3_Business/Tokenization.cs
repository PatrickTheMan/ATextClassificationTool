using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATextClassificationTool.Business
{

    public class Tokenization
    {
        private const int SMALLESTWORDLENGTH = 3;

        public static List<string> Tokenize(string originalText)
        {
            List<string> words = new List<string>();
            String [] tokens = originalText.Split(' ');

            
            foreach (string token in tokens)
            {
                
                if (!IsAShortWord(token))
                {
                    string cleanWord = RemovePunctuation(token);
                    words.Add(cleanWord);
                }
            }
            return words;
        }
        private static bool IsAShortWord(string token)
        {
            if (token.Length < SMALLESTWORDLENGTH)
            {
                return true;
            }
            return false;
        }

		public static string RemovePunctuation(string token)
		{
			token = token.Trim();
			StringBuilder sb = new StringBuilder();

			foreach (char c in token)
			{
				if (!char.IsPunctuation(c))
				{
					sb.Append(c);
				}
			}

			return sb.ToString().ToLower();
		}

		public static string RemovePunctuationOLD(string token)
		{
			// Doesn't work

			// Missing Punctuation check in the middle part
			// Uppercase is a part of Punctuation


			token = token.Trim();
			char[] punctuations = { '.', ',', '"', '?', '\n' };

			for (int i = 0; i < punctuations.Length; i++)
			{
				string ch = punctuations[i].ToString();
				if (token.StartsWith(ch))
				{
					return token.Substring(1);
				}
				else if (token.EndsWith(ch))
				{
					return token.Substring(0, token.Length - 1);
				}
			}
			return token.ToLower();
		}

	}
}
