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
        public Button current;
        public Button previous { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new Home();
            Data.AddNoteContent();
            Data.AddToDoItems();
        }

        private void HomeBTN_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Home());
            changeBG(sender);
            previous = sender as Button;
        }

        private void ToDoBTN_Click(object sender, RoutedEventArgs e)
        {
            Data.todo = new To_Do();
            MainFrame.Navigate(Data.todo);
            changeBG(sender);
            previous = sender as Button;

        }

        private void NotesBTN_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new NotePad());
            changeBG(sender);
            previous = sender as Button;

        }

        private void ResoucesBTN_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Resource());
            changeBG(sender);
            previous = sender as Button;

        }

        private void MediaBTN_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Media());
            changeBG(sender);
            previous = sender as Button;

        }

        private void changeBG(object sender)
        {
            current = sender as Button;
            current.Background = (Brush)new BrushConverter().ConvertFrom("#FF648139");

            if (previous != null)
            {
                previous.Background = (Brush)new BrushConverter().ConvertFrom("#FFB5C6B1");
            }
        }
    }
}
