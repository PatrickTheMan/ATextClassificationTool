using ATextClassificationTool.PropertyChanged;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATextClassificationTool
{
	public class MainViewModel : NotifyPropertyChangedHandler
	{

		private bool learnedAtLeastOnce = false;
		public bool LearnedAtLeastOnce
		{
			get { return learnedAtLeastOnce; }
			set { learnedAtLeastOnce = value; NotifyPropertyChanged(); }
		}

	}
}
