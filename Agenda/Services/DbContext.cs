using Agenda.Messages;
using Agenda.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Services
{
    public class DbContext
    {
        private SQLiteConnection _connection;
        public string StatusMessage { get; set; }

        public DbContext(string dbPath)
        {
            if (string.IsNullOrEmpty(dbPath))
                dbPath = App.DbPath;

            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<Evento>();
        }

        public bool Save(Evento evento)
        {
            try
            {
                if (evento.Id <= 0)
                {
                    _connection.Insert(evento);
                    this.StatusMessage = GenericMessages.INSERTSUCESSFUL;
                    return true;
                }
                else
                {
                    _connection.Update(evento);
                    this.StatusMessage = GenericMessages.UPDATESUCESSFUL;
                    return true;
                }
            }
            catch (Exception ex)
            {
                this.StatusMessage = GenericMessages.ERROR;
                return false;
            }
        }

        public bool Delete(Evento evento)
        {
            try
            {
                _connection.Delete(evento);
                this.StatusMessage = GenericMessages.DELETESUCESSFUL;
                return true;
            }
            catch (Exception ex)
            {
                this.StatusMessage = GenericMessages.ERROR;
                return false;
            }
        }

        public List<Evento> Listar()
        {

            try
            {
                var lista = _connection.Table<Evento>().ToList();
                return lista;
            }
            catch (Exception)
            {
                this.StatusMessage = GenericMessages.ERROR;
                return null;
            }
        }
    }
}
