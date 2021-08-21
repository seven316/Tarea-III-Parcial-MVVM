using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using DailySimpleNotes.Models;

namespace DailySimpleNotes.Repository
{
    public class NoteRepository
    {
        SQLiteConnection database;
        public NoteRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<Note>();
        }

        public IEnumerable<Note> GetItems()
        {
            return database.Table<Note>().ToList();
        }
        public Note GetItem(int id)
        {
            return database.Get<Note>(id);
        }
        public int DeleteItem(int id)
        {
            return database.Delete<Note>(id);
        }
        public int SaveItem(Note item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public bool DropBase()
        {
            database.DropTable<Note>();
            return true;
        }

        public bool TableExists()
        {
            if (database.Table<Note>() != null)
            {
                return true;
            }
            else
                return false;
        }
    }
}
