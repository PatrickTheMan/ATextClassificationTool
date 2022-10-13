using ATextClassificationTool.Controller;
using ATextClassificationTool.Domain;
using ATextClassificationTool.Foundation;
using ATextClassificationTool.Singleton;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ATextClassificationTool.Domain
{
	public class KNN
	{

		readonly IDictionary<string, double> _classASimilarities;
		readonly IDictionary<string, double> _classBSimilarities;

		public KNN()
		{
			this._classASimilarities = new Dictionary<string, double>();
			this._classBSimilarities = new Dictionary<string, double>();
		}

		public IDictionary<string, double> GetListOfSimilarities(string fileName)
		{
			Dictionary<string, double> results = new Dictionary<string, double>();

			double distance = 0.0;

			foreach (var classASim in _classASimilarities)
			{
				if (!classASim.Key.Equals(fileName))
				{
					distance = Math.Sqrt(
							Math.Pow(_classASimilarities[fileName] - _classBSimilarities[classASim.Key], 2) +
							Math.Pow(classASim.Value - _classBSimilarities[fileName], 2)
						);

					results.Add(classASim.Key, distance);
				}
			}

			return results;
		}
		public void InsertEntryA(string filePath)
		{
			if (filePath.Length == 0)
			{
				return;
			}

			int countT = 0;
			foreach (var b in KnowledgeBuilderSingleton.Instance.GetVectorsFromFile(filePath, "ClassA"))
			{
				if (b)
				{
					countT++;
				}
			}
            _classASimilarities[StringOperations.getFileName(filePath)] = ((double)countT / KnowledgeBuilderSingleton.Instance.GetDictionaryFromFile(StringOperations.getFileName(filePath)).Count);

            Debug.WriteLine("ClassA-Sim: "+_classASimilarities[StringOperations.getFileName(filePath)]);
        }
		public void InsertEntryB(string filePath)
		{
			if (filePath.Length == 0)
			{
				return;
			}

			int countT = 0;
			foreach (var b in KnowledgeBuilderSingleton.Instance.GetVectorsFromFile(filePath, "ClassB"))
			{
				if (b)
				{
					countT++;
				}
			}
            _classBSimilarities[StringOperations.getFileName(filePath)] = ((double)countT / KnowledgeBuilderSingleton.Instance.GetDictionaryFromFile(StringOperations.getFileName(filePath)).Count);

			Debug.WriteLine("ClassB-Sim: " + _classBSimilarities[StringOperations.getFileName(filePath)]);
        }

		public double GetClassASimilarities(string fileName)
		{
			return _classASimilarities[fileName];
		}
		public double GetClassBSimilarities(string fileName)
		{
			return _classBSimilarities[fileName];
		}

	}
}
