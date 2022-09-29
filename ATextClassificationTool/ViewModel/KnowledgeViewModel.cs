using ATextClassificationTool.Controller;
using ATextClassificationTool.Domain;
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
	public class KnowledgeViewModel : NotifyPropertyChangedHandler
	{
		public KnowledgeViewModel()
		{
			KnowledgeBuilder knowledgeBuilder = KnowledgeBuilderSingleton.Instance;

			this.showListA = new ObservableCollection<string>();
			this.showListB = new ObservableCollection<string>();

			try
			{
				List<string> listA = knowledgeBuilder.GetKnowledge().GetFileLists().GetA();
				if (listA != null)
				{
					foreach (var item in listA)
					{
						this.ShowListA.Add(StringOperations.getFileName(item));
					}
				}
			}
			catch (Exception)
			{
				this.ShowListA.Add("No Entries");
			}

			try
			{
				List<string> listB = knowledgeBuilder.GetKnowledge().GetFileLists().GetB();
				if (listB != null)
				{
					foreach (var item in listB)
					{
						this.ShowListB.Add(StringOperations.getFileName(item));
					}
				}
			}
			catch (Exception)
			{
				this.ShowListB.Add("No Entries");
			}
		}

		private ObservableCollection<string> showListA;
		public ObservableCollection<string> ShowListA
		{
			get { return showListA; }
			set { showListA = value; }
		}
		private ObservableCollection<string> showListB;
		public ObservableCollection<string> ShowListB
		{
			get { return showListB; }
			set { showListB = value; }
		}

	}
}
