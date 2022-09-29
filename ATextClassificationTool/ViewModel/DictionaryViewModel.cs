using ATextClassificationTool.Controller;
using ATextClassificationTool.PropertyChanged;
using ATextClassificationTool.Singleton;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATextClassificationTool.ViewModel
{
	public class DictionaryViewModel : NotifyPropertyChangedHandler
	{
		public DictionaryViewModel()
		{
			this.ShowListDictionaryWords = new ObservableCollection<string>();

			ICollection<string> dictionary = KnowledgeBuilderSingleton.Instance.GetKnowledge().GetBagOfWords().GetAllWordsInDictionary();

			foreach (var item in dictionary)
			{
				this.ShowListDictionaryWords.Add(item);
			}

			this.AmountOfWords = dictionary.Count;

			this.DictionaryText = "Dictionary - ( " + AmountOfWords + " total entries )";
		}

		private int amountOfWords;
		public int AmountOfWords
		{
			get { return amountOfWords; }
			set { amountOfWords = value; NotifyPropertyChanged(); }
		}

		private string dictionaryText = "";
		public string DictionaryText
		{
			get { return dictionaryText; }
			set { dictionaryText = value; NotifyPropertyChanged(); }
		}

		private ObservableCollection<string> showListDictionaryWords;
		public ObservableCollection<string> ShowListDictionaryWords
		{
			get { return showListDictionaryWords; }
			set { showListDictionaryWords = value; }
		}

	}
}
