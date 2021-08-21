using System;
using Xamarin.Forms;
using System.IO;
using DailySimpleNotes.iOS;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace DailySimpleNotes.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            // path to DataBase
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // library folder
            var path = Path.Combine(libraryPath, sqliteFilename);

            return path;
        }
    }
}
