using ATextClassificationTool.Controller;
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
	/// Interaction logic for KnowledgeView.xaml
	/// </summary>
	public partial class KnowledgeView : UserControl
	{
		public KnowledgeView()
		{
			InitializeComponent();
			this.DataContext = new KnowledgeViewModel();
		}

		private void ListViewItem_Click(object sender, MouseButtonEventArgs e)
		{
			var item = sender as ListViewItem;
			if (item != null && item.IsSelected)
			{
				SubCControl.Content = new TokensView(item.Content.ToString());
			}
			
		}
	}
}
