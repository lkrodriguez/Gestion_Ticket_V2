using S_Tickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace S_Tickets.ViewModels
{
    //TicketViewModels este es el Models General o Principal
    public class TicketViewModels
    {
        //Crear un solo Model
        public  Ticket Ticket { get; set; }
        public List<Resposable>  Resposables { get; set; }
        public List<Usuario> Usuarios { get; set; }
        public List<Estado> Estados { get; set; }

    }
}