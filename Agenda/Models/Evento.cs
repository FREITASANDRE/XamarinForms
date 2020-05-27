using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Models
{
    [Table("Eventos")]
    public class Evento
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
    }
}
