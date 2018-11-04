using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MCGA.Data;
using MCGA.Entities;

namespace MCGA_WebSite.Controllers
{
    public class TipoSexoController : Controller
    {
        private MedicureContextt db = new MedicureContextt();

        // GET: TipoSexo
        public ActionResult Index()
        {
            return View(db.TipoSexo.ToList());
        }

        // GET: TipoSexo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSexo tipoSexo = db.TipoSexo.Find(id);
            if (tipoSexo == null)
            {
                return HttpNotFound();
            }
            return View(tipoSexo);
        }

        // GET: TipoSexo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoSexo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,descripcion")] TipoSexo tipoSexo)
        {
            if (ModelState.IsValid)
            {
                db.TipoSexo.Add(tipoSexo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoSexo);
        }

        // GET: TipoSexo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSexo tipoSexo = db.TipoSexo.Find(id);
            if (tipoSexo == null)
            {
                return HttpNotFound();
            }
            return View(tipoSexo);
        }

        // POST: TipoSexo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,descripcion")] TipoSexo tipoSexo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoSexo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoSexo);
        }

        // GET: TipoSexo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoSexo tipoSexo = db.TipoSexo.Find(id);
            if (tipoSexo == null)
            {
                return HttpNotFound();
            }
            return View(tipoSexo);
        }

        // POST: TipoSexo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoSexo tipoSexo = db.TipoSexo.Find(id);
            db.TipoSexo.Remove(tipoSexo);
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
