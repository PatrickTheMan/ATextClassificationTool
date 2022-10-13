using ATextClassificationTool.Foundation;
using ATextClassificationTool.PropertyChanged;
using ATextClassificationTool.Singleton;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATextClassificationTool.ViewModel
{
	public class PredictionViewModel : NotifyPropertyChangedHandler
	{
		private IDictionary<string, double> orderedSimilaritiesDictionary = new Dictionary<string, double>();


		public PredictionViewModel(string text)
		{
			IDictionary<string, double> similaritiesDictionary = KnowledgeBuilderSingleton.Instance.GetKnowledge().GetKNN().GetListOfSimilarities(text);

			SortedList<double, string> tempSortList = new SortedList<double, string>();
			foreach (var item in similaritiesDictionary)
			{
				if (tempSortList.ContainsKey(item.Value))
				{
					tempSortList.Add(item.Value + 0.000000001, item.Key);
				} else
				{
					tempSortList.Add(item.Value, item.Key);
				}
			}
			foreach (var item in tempSortList.Reverse())
			{
				orderedSimilaritiesDictionary.Add(item.Value,item.Key);
			}

			this.Kmax = orderedSimilaritiesDictionary.Count;
		}

		#region Propertyes

		private string predictionLabel = "PREDICTIONHERE";

		public string PredictionLabel
		{
			get { return predictionLabel; }
			set { predictionLabel = value; NotifyPropertyChanged(); }
		}

		private double classASimilarity;

		public double ClassASimilarity
		{
			get { return classASimilarity; }
			set { classASimilarity = value; NotifyPropertyChanged(); }
		}

		private double classBSimilarity;

		public double ClassBSimilarity
		{
			get { return classBSimilarity; }
			set { classBSimilarity =  value; NotifyPropertyChanged(); }
		}

		private double Kmax;

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

		private double kValue;

		public double KValue
		{
			get { return kValue; }
			set { kValue = value; NotifyPropertyChanged(); UpdatePercentages(); UpdatePrediction(); }
		}

		#endregion Propertyes

		#region Functionality

		private void UpdatePrediction()
		{
			if (ClassASimilarity > ClassBSimilarity)
			{
				PredictionLabel = "ESport";
			} else
			{
				PredictionLabel = "Plot";
			}
		}

		private void UpdatePercentages()
		{
			double totalA = 0.0;
			double totalB = 0.0;

			int count = 0;
			foreach (var item in orderedSimilaritiesDictionary)
			{
				if (kValue > count) {
					foreach (var filePath in KnowledgeBuilderSingleton.Instance.GetKnowledge().GetFileLists().GetA())
					{
						if (StringOperations.getFileName(filePath).Equals(item.Key))
						{
							totalA += item.Value;
							Debug.WriteLine("A ++ " + item.Value + item.Key);
							break;
						}
					}
					foreach (var filePath in KnowledgeBuilderSingleton.Instance.GetKnowledge().GetFileLists().GetB())
					{
						if (StringOperations.getFileName(filePath).Equals(item.Key))
						{
							totalB += item.Value;
							Debug.WriteLine("B ++ " + item.Value + item.Key);
							break;
						}
					}
				} else
				{
					break;
				}
				count++;
			}

			double totalAB = totalA + totalB;

			double percentA = Math.Round((totalA / totalAB)*100,2);
			double percentB = Math.Round((totalB / totalAB)*100,2);

			Debug.WriteLine("Percent A: "+percentA);
			Debug.WriteLine("Percent B: " + percentB);

			this.ClassASimilarity = percentA;
			this.ClassBSimilarity = percentB;
		}

		#endregion Functionality

	}
}
