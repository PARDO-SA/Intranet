using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Intranet.Models.Clases.Consultas;
using Intranet.Models.Contexto;

namespace Intranet.Controllers
{
    public class ViewComisionesController : Controller
    {
        private CentralDBContexto db = new CentralDBContexto();

        // GET: ViewComisiones
        public ActionResult Index()
        {

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("anio", "2018");
            parameters[1] = new SqlParameter("mes", "04");
            var lista = db.Database.SqlQuery<ViewComisiones>("EXEC PAR_ViewComisiones @anio, @mes", parameters);

            return View(lista.ToList());
        }

        // GET: ViewComisiones/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewComisiones viewComisiones = db.ViewComisiones.Find(id);
            if (viewComisiones == null)
            {
                return HttpNotFound();
            }
            return View(viewComisiones);
        }

        // GET: ViewComisiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ViewComisiones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Sucursal,SucursalNombre,Funcion,Cobrado,ComisionVen,ComisionSuc,ACobrar,RestaCobrar")] ViewComisiones viewComisiones)
        {
            if (ModelState.IsValid)
            {
                db.ViewComisiones.Add(viewComisiones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(viewComisiones);
        }

        // GET: ViewComisiones/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewComisiones viewComisiones = db.ViewComisiones.Find(id);
            if (viewComisiones == null)
            {
                return HttpNotFound();
            }
            return View(viewComisiones);
        }

        // POST: ViewComisiones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nombre,Sucursal,SucursalNombre,Funcion,Cobrado,ComisionVen,ComisionSuc,ACobrar,RestaCobrar")] ViewComisiones viewComisiones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewComisiones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewComisiones);
        }

        // GET: ViewComisiones/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewComisiones viewComisiones = db.ViewComisiones.Find(id);
            if (viewComisiones == null)
            {
                return HttpNotFound();
            }
            return View(viewComisiones);
        }

        // POST: ViewComisiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ViewComisiones viewComisiones = db.ViewComisiones.Find(id);
            db.ViewComisiones.Remove(viewComisiones);
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
