using ATextClassificationTool.Foundation;
using ATextClassificationTool.PropertyChanged;
using ATextClassificationTool.Singleton;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATextClassificationTool.ViewModel
{
	public class PredictionViewModel : NotifyPropertyChangedHandler
	{
		private IDictionary<string, double> distanceDictionary;



		public PredictionViewModel(string text)
		{
			//TODO - FIX DESTINATION CAL
			distanceDictionary = KnowledgeBuilderSingleton.Instance.GetKnowledge().GetKNN().GetListOfDistances("ESport Det ikoniske FIFA-spil får nyt navn");
		}

		#region Propertyes

		private string predictionLabel = "PHERE";

		public string PredictionLabel
		{
			get { return predictionLabel; }
			set { predictionLabel = value; NotifyPropertyChanged(); }
		}

		private double classASimilarity = 50;

		public double ClassASimilarity
		{
			get { return classASimilarity; }
			set { classASimilarity = value; NotifyPropertyChanged(); }
		}

		private double classBSimilarity = 50;

		public double ClassBSimilarity
		{
			get { return classBSimilarity; }
			set { classBSimilarity =  value; NotifyPropertyChanged(); }
		}

		private double Kmax = 10;

		public double KMax
		{
			get { return Kmax; }
			set { Kmax = value; NotifyPropertyChanged(); }
		}

		private double Kmin = 1;

		public double KMin
		{
			get { return Kmin; }
			set { Kmin = value; NotifyPropertyChanged(); }
		}

		private double Kvalue = 3;

		public double KValue
		{
			get { return Kvalue; }
			set { Kvalue = value; NotifyPropertyChanged(); }
		}

		#endregion Propertyes

		public void UpdatePercentages()
		{
			double totalA = 0.0;
			double totalB = 0.0;

			foreach (var item in distanceDictionary)
			{
				foreach (var filePath in KnowledgeBuilderSingleton.Instance.GetKnowledge().GetFileLists().GetA())
				{
					if (StringOperations.getFileName(filePath).Equals(item.Key))
					{
						totalA += item.Value;
						Debug.WriteLine("A ++ "+ item.Value);
						break;
					}
				}
				foreach (var filePath in KnowledgeBuilderSingleton.Instance.GetKnowledge().GetFileLists().GetB())
				{
					if (StringOperations.getFileName(filePath).Equals(item.Key))
					{
						totalB += item.Value;
						Debug.WriteLine("B ++ " + item.Value);
						break;
					}
				}
			}

			double totalAB = totalA + totalB;

			double percentA = Math.Round(100-(totalA / totalAB)*100,2);
			double percentB = Math.Round(100-(totalB / totalAB)*100,2);

			Debug.WriteLine("Percent A: "+percentA);
			Debug.WriteLine("Percent B: " + percentB);

			this.ClassASimilarity = percentA;
			this.ClassBSimilarity = percentB;
		}

	}
}
