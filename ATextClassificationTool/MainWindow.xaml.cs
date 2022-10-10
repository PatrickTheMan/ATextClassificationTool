using ATextClassificationTool.Controller;
using ATextClassificationTool.Singleton;
using ATextClassificationTool.View;
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

namespace ATextClassificationTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		LearningView learningView = new LearningView();

		public MainWindow()
        {
            InitializeComponent();
            this.DataContext = MainViewModelSingleton.Instance;
        }

        private void Learning_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.CControl.Content = learningView;
        }

        private void Knowledge_Btn_Click(object sender, RoutedEventArgs e)
        {
			this.CControl.Content = new KnowledgeView();
		}

		private void Dictionary_Btn_Click(object sender, RoutedEventArgs e)
		{
			this.CControl.Content = new DictionaryView();
		}

        private void NewText_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.CControl.Content = new AddTextView();
        }
    }
}
