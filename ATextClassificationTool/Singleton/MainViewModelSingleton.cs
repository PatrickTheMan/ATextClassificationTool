using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATextClassificationTool.Singleton
{
	public class MainViewModelSingleton : MainViewModel
	{
		private MainViewModelSingleton() { }
		private static MainViewModelSingleton instance = null;
		public static MainViewModelSingleton Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new MainViewModelSingleton();
				}
				return instance;
			}
		}
	}
}
