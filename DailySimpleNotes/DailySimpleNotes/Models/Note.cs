using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailySimpleNotes.Models
{
    [Table("Notes")]
    public class Note
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Title{ get; set; }
        public string Text { get; set; }
        public string Direccion { get; set; }
        public string Puesto { get; set; }
        public Double Monto { get; set; }
        public string fecha { get; set; }
        public string CreationData { get; set; }

        public string Color { get; set; }
    }
}
