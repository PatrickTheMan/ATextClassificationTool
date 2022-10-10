using ATextClassificationTool.ViewModel;
using System;
using System.Collections.Generic;
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
	/// Interaction logic for PredictionView.xaml
	/// </summary>
	public partial class PredictionView : UserControl
	{
		PredictionViewModel predictionViewModel;
		public PredictionView(string text)
		{
			InitializeComponent();
			predictionViewModel = new PredictionViewModel(text);
			this.DataContext = predictionViewModel;
		}

		private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			predictionViewModel.KValue = e.NewValue;

			predictionViewModel.UpdatePercentages();
		}
	}
}
