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
        public NotePad()
        {
            InitializeComponent();
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
                if (Data.Notes.Contains(temp))
                { 
                    Data.Notes.Remove(temp);
                }

                temp.ContentPrev.Content = Note.Text;
               
                if (NoteTitle.Text != string.Empty || NoteTitle.Text != "Title")
                { temp.Title.Content = NoteTitle.Text; }

                temp.Date.Content = DateTime.Today.ToString("yyyy-MM-dd");

                Data.Notes.Insert(0,temp);
                Data.Filtered = Data.Notes;
                MessageBox.Show("Your note has been saved!");

                NoteTitle.Text = string.Empty;
                Note.Text = string.Empty;

            }
        }
        private void ReturnDefaultText(object sender, MouseEventArgs e)
        {
            if (NoteTitle.Text == string.Empty && NoteList.SelectedIndex != -1)
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
            NoteList.ItemsSource = Data.FilterNotes(NoteSearch.Text);
            NoteCounter.Content = $"{Data.Filtered.Count} Notes";
        }
        private void NewNoteBTN_Click(object sender, RoutedEventArgs e)
        {
            NotePreview temp = new NotePreview();

            temp.Title.Content = "Untitled";
            temp.Date.Content = DateTime.Today.ToString("yyyy-MM-dd");
            temp.ContentPrev.Content = string.Empty;

            NoteTitle.Text = temp.Title.Content.ToString();
            Note.Text = temp.ContentPrev.Content.ToString();

            Data.Filtered.Insert(0, temp);
            Data.Notes.Insert(0, temp);

            NoteList.SelectedIndex = 0;
        }
        private void NoteDeleteBTN_Click(object sender, RoutedEventArgs e)
        {
            if (NoteList.SelectedIndex != -1)
            {
                NotePreview temp = NoteList.SelectedItem as NotePreview;

                if (Data.Notes.Contains(temp)) { Data.Notes.Remove(temp); }
                Data.Filtered.RemoveAt(NoteList.SelectedIndex);

                NoteTitle.Text = string.Empty;
                Note.Text = string.Empty;
            }
        }
        private void RetrieveData(object sender, RoutedEventArgs e)
        {
            Data.Filtered = Data.Notes;
            NoteList.ItemsSource = Data.Filtered;
            NoteCounter.Content = $"{Data.Filtered.Count} Notes";
        }
    }
}
