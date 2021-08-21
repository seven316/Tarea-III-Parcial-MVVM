using DailySimpleNotes.Repository;
using DailySimpleNotes.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailySimpleNotes
{
    public partial class App : Application
    {
        public const string DATABASE_NAME = "notes.db";
        public static NoteRepository database;

        public static NoteRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new NoteRepository(
                        Path.Combine(
                            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new NotesListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
