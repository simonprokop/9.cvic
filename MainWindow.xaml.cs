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

namespace _9.cviceni
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private Calculator calculator = new Calculator();
		public MainWindow()
		{
			InitializeComponent();
			display.Content = calculator.Display;
			MemoryDisplay.Content = calculator.Memory;

		}

		private void ButtonHandler(object sender, RoutedEventArgs e)
		{
			calculator.ButtonClicked((sender as Button).Content.ToString());
			display.Content = calculator.Display;
			MemoryDisplay.Content = calculator.Memory;

		}

	}
}