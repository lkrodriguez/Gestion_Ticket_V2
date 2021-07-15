using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using S_Tickets.Models;

namespace S_Tickets.Controllers
{
    public class ResposablesController : Controller
    {
        private TicketsDB db = new TicketsDB();

        // GET: Resposables
        public ActionResult Index()
        {
            return View(db.Resposable.ToList());
        }

        // GET: Resposables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resposable resposable = db.Resposable.Find(id);
            if (resposable == null)
            {
                return HttpNotFound();
            }
            return View(resposable);
        }

        // GET: Resposables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Resposables/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellidos,Email,Cargo,Activo")] Resposable resposable)
        {
            if (ModelState.IsValid)
            {
                db.Resposable.Add(resposable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resposable);
        }

        // GET: Resposables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resposable resposable = db.Resposable.Find(id);
            if (resposable == null)
            {
                return HttpNotFound();
            }
            return View(resposable);
        }

        // POST: Resposables/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellidos,Email,Cargo,Activo")] Resposable resposable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resposable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resposable);
        }

        // GET: Resposables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resposable resposable = db.Resposable.Find(id);
            if (resposable == null)
            {
                return HttpNotFound();
            }
            return View(resposable);
        }

        // POST: Resposables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Resposable resposable = db.Resposable.Find(id);
            db.Resposable.Remove(resposable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
