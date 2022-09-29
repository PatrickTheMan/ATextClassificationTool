using ATextClassificationTool.Controller;
using ATextClassificationTool.PropertyChanged;
using ATextClassificationTool.Singleton;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ATextClassificationTool.ViewModel
{
	public class LearningViewModel : NotifyPropertyChangedHandler
	{
		KnowledgeBuilder knowledgeBuilder = KnowledgeBuilderSingleton.Instance;
		public LearningViewModel()
		{
			this.knowledgeBuilder.GetKnowledge().GetVectors();
		}

		#region Properties

		private string learningTime = "Non";

		public string LearningTime
		{
			get { return learningTime; }
			set { if (learningTime != value) { learningTime = value; NotifyPropertyChanged(); }; }
		}

		#endregion Properties

		#region Methods

		public void newLearning()
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			// initiate the learning process
			this.knowledgeBuilder.Train();

			stopwatch.Stop();
			LearningTime = ""+Math.Round((double)stopwatch.ElapsedMilliseconds / 1000, 3)+" sec elapsed";
		}

		#endregion Methods

	}
}
