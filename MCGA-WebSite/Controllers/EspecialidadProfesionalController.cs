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
    public class EspecialidadProfesionalController : Controller
    {
        private MedicureContextt db = new MedicureContextt();

        // GET: EspecialidadProfesional
        public ActionResult Index()
        {
            var especialidadesProfesional = db.EspecialidadesProfesional.Include(e => e.Especialidad).Include(e => e.Profesional);
            return View(especialidadesProfesional.ToList());
        }

        // GET: EspecialidadProfesional/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecialidadesProfesional especialidadesProfesional = db.EspecialidadesProfesional.Find(id);
            if (especialidadesProfesional == null)
            {
                return HttpNotFound();
            }
            return View(especialidadesProfesional);
        }

        // GET: EspecialidadProfesional/Create
        public ActionResult Create()
        {
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "Id", "descripcion");
            ViewBag.ProfesionalId = new SelectList(db.Profesional, "Id", "Nombre");
            return View();
        }

        // POST: EspecialidadProfesional/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EspecialidadId,ProfesionalId,createdon,createdby,changedon,changedby")] EspecialidadesProfesional especialidadesProfesional)
        {
            if (ModelState.IsValid)
            {
                db.EspecialidadesProfesional.Add(especialidadesProfesional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "Id", "descripcion", especialidadesProfesional.EspecialidadId);
            ViewBag.ProfesionalId = new SelectList(db.Profesional, "Id", "Nombre", especialidadesProfesional.ProfesionalId);
            return View(especialidadesProfesional);
        }

        // GET: EspecialidadProfesional/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecialidadesProfesional especialidadesProfesional = db.EspecialidadesProfesional.Find(id);
            if (especialidadesProfesional == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "Id", "descripcion", especialidadesProfesional.EspecialidadId);
            ViewBag.ProfesionalId = new SelectList(db.Profesional, "Id", "Nombre", especialidadesProfesional.ProfesionalId);
            return View(especialidadesProfesional);
        }

        // POST: EspecialidadProfesional/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EspecialidadId,ProfesionalId,createdon,createdby,changedon,changedby")] EspecialidadesProfesional especialidadesProfesional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(especialidadesProfesional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EspecialidadId = new SelectList(db.Especialidad, "Id", "descripcion", especialidadesProfesional.EspecialidadId);
            ViewBag.ProfesionalId = new SelectList(db.Profesional, "Id", "Nombre", especialidadesProfesional.ProfesionalId);
            return View(especialidadesProfesional);
        }

        // GET: EspecialidadProfesional/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EspecialidadesProfesional especialidadesProfesional = db.EspecialidadesProfesional.Find(id);
            if (especialidadesProfesional == null)
            {
                return HttpNotFound();
            }
            return View(especialidadesProfesional);
        }

        // POST: EspecialidadProfesional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EspecialidadesProfesional especialidadesProfesional = db.EspecialidadesProfesional.Find(id);
            db.EspecialidadesProfesional.Remove(especialidadesProfesional);
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
