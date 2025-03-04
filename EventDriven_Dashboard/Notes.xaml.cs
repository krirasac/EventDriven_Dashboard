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
    /// Interaction logic for NotePad.xaml
    /// </summary>
    public partial class NotePad : Page
    {
        public ObservableCollection<NotePreview> Notes { get; set; } = new ObservableCollection<NotePreview>();
        public ObservableCollection<NotePreview> Filtered { get; set; } = new ObservableCollection<NotePreview> { };

        public NotePad()
        {
            InitializeComponent();
            Notes = Data.AddNoteContent();
            Filtered = Notes;
            NoteList.ItemsSource = Filtered;
        }

        private void NoteList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (NoteList.SelectedItem is NotePreview temp)
            {
                if (temp.Title.Content.ToString() != "Untitled")
                {
                    NoteTitle.Text = temp.Title.Content.ToString();
                }
                else
                {
                    NoteTitle.Text = "Title";
                }

                Note.Text = temp.ContentPrev.Content.ToString();

            }
        }

        private void NoteSaveBTN_Click(object sender, RoutedEventArgs e)
        {
            if (NoteList.SelectedItem is NotePreview temp)
            {
                int index;

                if (Notes.Contains(temp))
                { 
                    index = Notes.IndexOf(temp);
                    Notes.RemoveAt(index);
                }

                temp.ContentPrev.Content = Note.Text;
               
                if (NoteTitle.Text != string.Empty || NoteTitle.Text != "Title")
                { temp.Title.Content = NoteTitle.Text; }

                temp.Date.Content = DateTime.Today.ToString("yyyy-MM-dd");

                Notes.Insert(0,temp);
                Filtered = Notes;
                MessageBox.Show("Your note has been saved!");
            }
        }

        private void ReturnDefaultText(object sender, MouseEventArgs e)
        {
            if (NoteTitle.Text == string.Empty)
            {
                NoteTitle.Text = "Title";
                NoteTitle.Foreground = Brushes.Gray;
            }
        }

        private void ClearText(object sender, MouseEventArgs e)
        {
            if (NoteTitle.Text == "Title")
            {
                NoteTitle.Text = string.Empty;
            }
        }

        private void NoteSearchBTN_Click(object sender, RoutedEventArgs e)
        {
            Filtered = Data.FilterNotes(Notes,NoteSearch.Text);
            NoteList.ItemsSource = Filtered;
        }

        private void NewNoteBTN_Click(object sender, RoutedEventArgs e)
        {
            NotePreview temp = new NotePreview();

            temp.Title.Content = "Untitled";
            temp.ContentPrev.Content = string.Empty;

            NoteTitle.Text = temp.Title.Content.ToString();
            Note.Text = temp.ContentPrev.Content.ToString();

            Filtered.Insert(0, temp);
            Notes.Insert(0, temp);

            NoteList.SelectedIndex = 0;
        }

        private void NoteDeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            NotePreview temp = NoteList.SelectedItem as NotePreview;

            if (Notes.Contains(temp)) { Notes.Remove(temp); }
            Filtered.RemoveAt(NoteList.SelectedIndex);

            NoteTitle.Text = string.Empty;
            Note.Text = string.Empty;
        }
    }
}
