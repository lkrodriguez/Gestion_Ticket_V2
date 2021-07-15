using S_Tickets.Models;
using S_Tickets.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S_Tickets.Controllers
{
    public class TicketsController : Controller
    {
        //private TicketsDB context = new TicketsDB(); llama los datos de las tablas relacionadas
        private TicketsDB context = new TicketsDB();
        // GET: Tickets
        public ActionResult Index()
        {
            var listado = context.Ticket;
            return View(listado);
        }

        [HttpGet]
        //Mostrar los Listados
        public ActionResult Nuevo()
        {
            var viewmodel = new TicketViewModels();
            viewmodel.Resposables = context.Resposable.ToList();
            viewmodel.Estados = context.Estado.ToList();
            viewmodel.Usuarios = context.Usuario.ToList();
            return View(viewmodel);
        }

        [HttpPost]
        //Guardar DB
        public ActionResult Nuevo(Ticket ticket)
        {
            context.Ticket.Add(ticket);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        //Muestra Detalles
        public ActionResult Detalle(int id)
        {
            var viewModel = new TicketViewModels();
            viewModel.Ticket = context.Ticket.FirstOrDefault(x=> x.id == id);
            return View(viewModel);
        }

        
        [HttpGet]
        public ActionResult Actualizar(int id)
        {
            var viewModel = new TicketViewModels();
            viewModel.Ticket = context.Ticket.FirstOrDefault(x => x.id == id);
            viewModel.Resposables = context.Resposable.ToList();
            viewModel.Estados = context.Estado.ToList();
            viewModel.Usuarios = context.Usuario.ToList();
            return View(viewModel);
        }



        [HttpPost]
        public ActionResult Actualizar(Ticket ticket)
        {
            context.Entry(ticket).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            var ticket = context.Ticket.FirstOrDefault(x => x.id == id);
            context.Ticket.Remove(ticket);
            context.SaveChanges()
;           return RedirectToAction ("Index");
        }
    }
}