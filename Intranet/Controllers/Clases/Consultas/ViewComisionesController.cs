using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Intranet.Models.Clases.Consultas;
using Intranet.Models.Clases;
using Intranet.Models.Contexto;
using System.Data.SqlClient;

namespace Intranet.Controllers.Clases.Consultas
{
    public class ViewComisionesController : Controller
    {
        private CentralDBContexto db = new CentralDBContexto();

        // GET: ViewComisiones
        public ActionResult Index()
        {
            ViewBag.Zona = 41;
            var anio = "2028";
            var mes = "04";
            //var lects = new List<ViewComisiones>();

            /*
            var lects = db.Database.SqlQuery<ViewComisiones>("PAR_ViewComisiones {0}, {1}",
                    //new SqlParameter("anio", anio),
                    //new SqlParameter("mes", mes)
                    new object[] { anio, mes }
                    ).ToList();
            */
            var lects = db.Database.SqlQuery<ViewComisiones>(
    "PAR_ViewComisiones @param1, @param2",
    new SqlParameter("param1", anio),
    new SqlParameter("param2", mes)
);
            return View(lects.ToList());
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
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
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
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
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
