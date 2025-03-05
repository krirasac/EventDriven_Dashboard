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
        //for notes
        static public ObservableCollection<NotePreview> AddNoteContent()
        {
            ObservableCollection<NotePreview> notes = new ObservableCollection<NotePreview>();

            for (int x = 0; x < 3; x++)
            { 
                notes.Add(new NotePreview());
                notes[x].ContentPrev.Content = "Lorem ipsum dolor sit amet. ";
                notes[x].Date.Content = DateTime.Today.ToString("yyyy-MM-dd");
            }

            return notes;
        }
        static public ObservableCollection<NotePreview> FilterNotes(ObservableCollection<NotePreview> notes, string find)
        {
            ObservableCollection<NotePreview> temp = new ObservableCollection<NotePreview>();
            find = find.ToLower();
            bool found = false;

            foreach (NotePreview note in notes)
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
            {
                return notes;
            }

            return temp;
        }


        //for to-do
        static public ObservableCollection<TaskDetails> AddToDoItems()
        { 
            ObservableCollection<TaskDetails> items = new ObservableCollection<TaskDetails>();

            for (int x = 0; x < 3; x++)
            {
                items.Add(new TaskDetails("Shopping",DateTime.Today.ToString("yyyy-MM-dd"), "Low"));
            }

            return items;
        
        }

        static private bool CheckItem(string select, string find)
        {
            bool check = false;

            if (select.Length >= find.Length)
            {
                for (int x = 0; x < select.Length; x++)
                {
                    for (int y = 0; y < find.Length; y++)
                    {
                        if (select[x + y] == find[y])
                        {
                            check = true;
                        }
                        else
                        {
                            check = false;
                            break;
                        }
                    }

                    if (check) { return check; }
                }
            }

            return check;
        }
    }
}
