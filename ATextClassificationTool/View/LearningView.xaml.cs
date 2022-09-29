using ATextClassificationTool.Controller;
using ATextClassificationTool.Singleton;
using ATextClassificationTool.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ATextClassificationTool.View
{
	/// <summary>
	/// Interaction logic for LearningView.xaml
	/// </summary>
	public partial class LearningView : UserControl
	{
		LearningViewModel learningViewModel;
		public LearningView()
		{
			InitializeComponent();
			this.learningViewModel = new LearningViewModel();
			this.DataContext = learningViewModel;
		}

		private void Learn_Btn_Click(object sender, RoutedEventArgs e)
		{
			learningViewModel.newLearning();
			MainViewModelSingleton.Instance.hasLearned();
		}
	}
}
