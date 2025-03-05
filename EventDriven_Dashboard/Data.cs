using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace EventDriven_Dashboard
{
    static internal class Data
    {
        static public To_Do todo { get; set; }
        static public int Index { get; set; }

        //for todo
        static public ObservableCollection<TaskDetails> Incomplete { get; set; } = new ObservableCollection<TaskDetails>();
        static public ObservableCollection<TaskDetails> Completed { get; set; } = new ObservableCollection<TaskDetails>();
        static public void AddToDoItems()
        {
            ObservableCollection<TaskDetails> items = new ObservableCollection<TaskDetails>();

            for (int x = 0; x < 3; x++)
            {
                items.Add(new TaskDetails("Shopping", DateTime.Today.ToString("yyyy-MM-dd"), "Low"));
            }

            Incomplete = items;
        }
       
        //for notes
        static public ObservableCollection<NotePreview> Notes { get; set; } = new ObservableCollection<NotePreview>();
        static public ObservableCollection<NotePreview> Filtered { get; set; } = new ObservableCollection<NotePreview>();
        static public void AddNoteContent()
        {
            ObservableCollection<NotePreview> pages = new ObservableCollection<NotePreview>();

            for (int x = 0; x < 3; x++)
            { 
                pages.Add(new NotePreview());
                pages[x].ContentPrev.Content = "Lorem ipsum dolor sit amet. ";
                pages[x].Date.Content = DateTime.Today.ToString("yyyy-MM-dd");
            }

            Notes = pages;
        }
        static public ObservableCollection<NotePreview> FilterNotes(string find)
        {
            ObservableCollection<NotePreview> temp = new ObservableCollection<NotePreview>();
            find = find.ToLower();
            bool found = false;

            foreach (NotePreview note in Notes)
            {
                string selectTitle = note.Title.Content.ToString().ToLower();
                string selectContent = note.ContentPrev.Content.ToString().ToLower();

                if (CheckItem(selectTitle, find) || CheckItem(selectContent, find))
                {
                    temp.Add(note);
                    found = true;
                }
            }

            if (!found && find == string.Empty)
                Filtered = Notes;
            else
                Filtered = temp;

            return Filtered;
        }
        static private bool CheckItem(string select, string find)
        {
            bool check = false;

            if (select.Length >= find.Length)
            {
                for (int x = 0; x < select.Length - 1; x++)
                {
                    for (int y = 0; y < find.Length; y++)
                    {
                        if (select[x + y] == find[y] )
                            check = true;
                        else
                            check = false;
                            break;
                    }

                    if (check)
                    return check;
                }
            }

            return check;
        }
    }
}
