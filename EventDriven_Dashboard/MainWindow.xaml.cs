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

namespace EventDriven_Dashboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new Home();
        }

        private void HomeBTN_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Home());
        }

        private void ToDoBTN_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new To_Do());
        }

        private void NotesBTN_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new NotePad());

        }

        private void ResoucesBTN_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Resource());
        }

        private void MediaBTN_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Media());

        }
    }
}
