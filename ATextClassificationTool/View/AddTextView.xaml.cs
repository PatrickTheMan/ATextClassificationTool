using ATextClassificationTool.Singleton;
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
	/// Interaction logic for AddTextView.xaml
	/// </summary>
	public partial class AddTextView : UserControl
	{
		public AddTextView()
		{
			InitializeComponent();
			this.DataContext = new AddTextViewModel();
		}

		private void AddPlotText_Btn_Click(object sender, RoutedEventArgs e)
		{

		}

		private void AddESportText_Btn_Click(object sender, RoutedEventArgs e)
		{

		}

		private void Prediction_Btn_Click(object sender, RoutedEventArgs e)
		{
			//KnowledgeBuilderSingleton.Instance.GetKnowledge().GetKNN().GetListOfDistances("ESport Heroic henter stortalent");
			
			this.SubCControl.Content = new PredictionView(this.TextContainer_TextBox.Text);
		}
	}
}
