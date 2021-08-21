using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using DailySimpleNotes.UWP;

[assembly: Dependency(typeof(SQLite_UWP))]
namespace DailySimpleNotes.UWP
{
    public class SQLite_UWP : ISQLite
    {
        public SQLite_UWP() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            // for access to files API Windows.Storage
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            return path;
        }
    }
}
