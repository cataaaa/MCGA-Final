﻿using System;
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
    public class AgendaController : Controller
    {
        private MedicureContextt db = new MedicureContextt();

        // GET: Agenda
        public ActionResult Index()
        {
            var agenda = db.Agenda.Include(a => a.EspecialidadesProfesional).Include(a => a.TipoDia);
            return View(agenda.ToList());
        }

        // GET: Agenda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agenda.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // GET: Agenda/Create
        public ActionResult Create()
        {
            ViewBag.EspecialidadProfesionalId = new SelectList(db.EspecialidadesProfesional, "Id", "createdby");
            ViewBag.TipoDiaId = new SelectList(db.TipoDia, "Id", "descripcion");
            return View();
        }

        // POST: Agenda/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EspecialidadProfesionalId,TipoDiaId,fecha_desde,fecha_hasta,hora_desde,hora_hasta,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                db.Agenda.Add(agenda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EspecialidadProfesionalId = new SelectList(db.EspecialidadesProfesional, "Id", "createdby", agenda.EspecialidadProfesionalId);
            ViewBag.TipoDiaId = new SelectList(db.TipoDia, "Id", "descripcion", agenda.TipoDiaId);
            return View(agenda);
        }

        // GET: Agenda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agenda.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            ViewBag.EspecialidadProfesionalId = new SelectList(db.EspecialidadesProfesional, "Id", "createdby", agenda.EspecialidadProfesionalId);
            ViewBag.TipoDiaId = new SelectList(db.TipoDia, "Id", "descripcion", agenda.TipoDiaId);
            return View(agenda);
        }

        // POST: Agenda/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EspecialidadProfesionalId,TipoDiaId,fecha_desde,fecha_hasta,hora_desde,hora_hasta,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agenda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EspecialidadProfesionalId = new SelectList(db.EspecialidadesProfesional, "Id", "createdby", agenda.EspecialidadProfesionalId);
            ViewBag.TipoDiaId = new SelectList(db.TipoDia, "Id", "descripcion", agenda.TipoDiaId);
            return View(agenda);
        }

        // GET: Agenda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agenda agenda = db.Agenda.Find(id);
            if (agenda == null)
            {
                return HttpNotFound();
            }
            return View(agenda);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agenda agenda = db.Agenda.Find(id);
            db.Agenda.Remove(agenda);
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
