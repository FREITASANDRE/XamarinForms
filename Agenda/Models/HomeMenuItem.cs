using System;
using System.Collections.Generic;
using System.Text;

namespace Agenda.Models
{
    public enum MenuItemType
    {
        Agenda,
        Eventos
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
