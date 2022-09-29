using ATextClassificationTool.Controller;
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
	/// Interaction logic for TokensView.xaml
	/// </summary>
	public partial class TokensView : UserControl
	{
		public TokensView(string chosenFileName)
		{
			InitializeComponent();
			this.DataContext = new TokensViewModel(chosenFileName);
		}
	}
}
