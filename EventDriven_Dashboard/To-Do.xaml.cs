using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for To_Do.xaml
    /// </summary>
    public partial class To_Do : Page
    {
        private ObservableCollection<TaskDetails> Items { get; set; } = new ObservableCollection<TaskDetails>();
        private ObservableCollection<TaskDetails> Incomplete { get; set; } = new ObservableCollection<TaskDetails>();

        public To_Do()
        {
            InitializeComponent();
            Items = Data.AddToDoItems();
            Incomplete = Items;
            Checklist.ItemsSource = Incomplete;
        }

        private void Checklist_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
