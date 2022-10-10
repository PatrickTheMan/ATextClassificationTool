using ATextClassificationTool.Business;
using ATextClassificationTool.Controller;
using ATextClassificationTool.FileIO;
using ATextClassificationTool.Foundation;
using ATextClassificationTool.PropertyChanged;
using ATextClassificationTool.Singleton;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATextClassificationTool.ViewModel
{
	public class TokensViewModel : NotifyPropertyChangedHandler
	{
		public TokensViewModel(string chosenFileName)
		{
			
			KnowledgeBuilder knowledgeBuilder = KnowledgeBuilderSingleton.Instance;

			this.ShowListTokens = knowledgeBuilder.GetDictionaryFromFile(chosenFileName);

			this.AmountOfWords = ShowListTokens.Count;

			this.CurrentFileName = chosenFileName+" - ( "+AmountOfWords+" total entries )";
		}

		private int amountOfWords;
		public int AmountOfWords
		{
			get { return amountOfWords; }
			set { amountOfWords = value; NotifyPropertyChanged(); }
		}

		private string currentFileName = "";

		public string CurrentFileName
		{
			get { return currentFileName; }
			set { currentFileName = value; NotifyPropertyChanged(); }
		}

		private ObservableCollection<string> showListTokens;

		public ObservableCollection<string> ShowListTokens
		{
			get { return showListTokens; }
			set { showListTokens = value; }
		}

	}
}
