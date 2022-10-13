using ATextClassificationTool.Foundation;
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
		AddTextViewModel addTextViewModel = new AddTextViewModel();
		public AddTextView()
		{
			InitializeComponent();
			this.DataContext = new AddTextViewModel();
		}

		private void AddPlotText_Btn_Click(object sender, RoutedEventArgs e)
		{
			this.addTextViewModel.AddToFolderB(this.FileNameContainer_TextBox.Text,this.TextContainer_TextBox.Text);
            this.FileNameContainer_TextBox.Text = "New Text";
            this.TextContainer_TextBox.Text = "Content here";
        }

		private void AddESportText_Btn_Click(object sender, RoutedEventArgs e)
		{
			this.addTextViewModel.AddToFolderA(this.FileNameContainer_TextBox.Text, this.TextContainer_TextBox.Text);
			this.FileNameContainer_TextBox.Text = "New Text";
			this.TextContainer_TextBox.Text = "Content here";
        }

		private void Prediction_Btn_Click(object sender, RoutedEventArgs e)
		{
            this.addTextViewModel.AddToFolderA(this.FileNameContainer_TextBox.Text, this.TextContainer_TextBox.Text);
			this.addTextViewModel.AddKNN(this.FileNameContainer_TextBox.Text);
            this.SubCControl.Content = new PredictionView(this.FileNameContainer_TextBox.Text);
			this.addTextViewModel.DeleteFromFolderA(this.FileNameContainer_TextBox.Text);
		}
	}
}
