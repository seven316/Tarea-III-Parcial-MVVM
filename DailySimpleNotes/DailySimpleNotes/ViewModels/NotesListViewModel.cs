using DailySimpleNotes.Models;
using DailySimpleNotes.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DailySimpleNotes.ViewModels
{
    public class NotesListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<NoteViewModel> Notes { get; set; }

        public NoteViewModel NoteView { get; set; }

        NoteViewModel selectedNote;

        public ICommand CreateNoteCommand { protected set; get; }

        public ICommand EditNoteCommand { protected set; get; }

        public ICommand GoBackCommand { protected set; get; }

        public ICommand DeleteNoteCommand { protected set; get; }


        public ICommand PickColorRedCommand { protected set; get; }

        public ICommand PickColorGreenCommand { protected set; get; }
        public ICommand PickColorYellowCommand { protected set; get; }

        public INavigation Navigation { get; set; }

        public NotesListViewModel()
        {
            // App.Database.GetItems() to my NotesViewModel;
            Notes = new ObservableCollection<NoteViewModel>();
            this.GetCollection();

            CreateNoteCommand = new Command(CreateNote);
            EditNoteCommand = new Command(EditNote);
            GoBackCommand = new Command(GoBack);
            DeleteNoteCommand = new Command(DeleteNote); 
            
            PickColorRedCommand = new Command(PickColorRed);
            PickColorGreenCommand = new Command(PickColorGreen);
            PickColorYellowCommand = new Command(PickColorYellow);
        }

        public NoteViewModel SelectedNote
        {
            get { return selectedNote; }
            set
            {
                if (selectedNote != value)
                {
                    NoteViewModel tempNote = value;
                    selectedNote = null;
                    OnPropertyChanged("SelectedNote");
                    NoteView = new NoteViewModel();
                    NoteView.ListViewModel = this;
                    NoteView.Title = tempNote.Title;
                    NoteView.Monto = tempNote.Monto;
                    NoteView.Direccion = tempNote.Direccion;
                    NoteView.Puesto = tempNote.Puesto;
                    NoteView.Id = tempNote.Id;
                    NoteView.Text = tempNote.Text;
                    NoteView.Color = tempNote.Color;
                    NoteView.CreationData = tempNote.CreationData;
                    Navigation.PushAsync(new NoteTextPage(NoteView));
                }
            }
        }

        protected void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void CreateNote()
        {
            NoteViewModel nv = new NoteViewModel();
            NoteView = nv;
            DateTime date = DateTime.Now;
            string dateString = $"Created: {date.Day}/{date.Month}/{date.Year} {date.Hour}:{date.Minute}";
            NoteView.CreationData = dateString;
            Notes.Add(nv);
            NoteView.ListViewModel = this;
            Navigation.PushAsync(new NotePage(NoteView));
        }

        private void EditNote(object obj) 
        {
            NoteView = (NoteViewModel)obj;
            DateTime date = DateTime.Now;
            string dateString = $"Created: {date.Day}/{date.Month}/{date.Year} {date.Hour}:{date.Minute}";
            NoteView.CreationData = dateString;
            NoteView.ListViewModel = this;
            Navigation.PushAsync(new NotePage(NoteView));
        }

        private void DeleteNote(object obj)
        {
            NoteView = (NoteViewModel)obj;
            var id = NoteView.Id;
            App.Database.DeleteItem(id);
            Notes.Remove(NoteView);
        }

        private void GoBack(object obj)
        {
            if (obj != null)
            {
                NoteView = (NoteViewModel)obj;
                Note note = new Note() { Id = NoteView.Id, Title = NoteView.Title, Puesto = NoteView.Puesto, Direccion = NoteView.Direccion, Text = NoteView.Text, Monto = NoteView.Monto, Color = NoteView.Color, CreationData = NoteView.CreationData };

                App.Database.SaveItem(note);

                Notes.Clear();
                this.GetCollection();
            }
            Navigation.PopAsync();
        }

        private void PickColorRed(object obj)
        {
            NoteViewModel noteViev = (NoteViewModel)obj;
            noteViev.Color = "Red";
        }
        private void PickColorGreen(object obj)
        {
            NoteViewModel noteViev = (NoteViewModel)obj;
            noteViev.Color = "Green";
        }
        private void PickColorYellow(object obj)
        {
            NoteViewModel noteViev = (NoteViewModel)obj;
            noteViev.Color = "Yellow";
        }

        private void GetCollection()
        {
            if (App.Database.TableExists())
            {
                var notesCollection = App.Database.GetItems();

                foreach (var n in notesCollection)
                {
                    Notes.Add(new NoteViewModel() { Id = n.Id, Title = n.Title, Text = n.Text, Monto= n.Monto , Color = n.Color, CreationData = n.CreationData, Puesto = n.Puesto, Direccion = n.Direccion });
                }
            }
        }
    }
}
