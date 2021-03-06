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
    public class AfiliadoController : Controller
    {
        private MedicureContextt db = new MedicureContextt();

        // GET: Afiliado
        public ActionResult Index()
        {
            var afiliado = db.Afiliado.Include(a => a.EstadoCivil).Include(a => a.Plan).Include(a => a.TipoDocumento).Include(a => a.TipoSexo);
            return View(afiliado.ToList());
        }

        // GET: Afiliado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = db.Afiliado.Find(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            return View(afiliado);
        }

        // GET: Afiliado/Create
        public ActionResult Create()
        {
            ViewBag.EstadoCivilId = new SelectList(db.EstadoCivil, "Id", "descripcion");
            ViewBag.PlanId = new SelectList(db.Plan, "Id", "descripcion");
            ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumento, "Id", "descripcion");
            ViewBag.TipoSexoId = new SelectList(db.TipoSexo, "Id", "descripcion");
            return View();
        }

        // POST: Afiliado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,TipoSexoId,FechaNacimiento,EstadoCivilId,NumeroAfiliado,PlanId,Foto,Habilitado,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {
                db.Afiliado.Add(afiliado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EstadoCivilId = new SelectList(db.EstadoCivil, "Id", "descripcion", afiliado.EstadoCivilId);
            ViewBag.PlanId = new SelectList(db.Plan, "Id", "descripcion", afiliado.PlanId);
            ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumento, "Id", "descripcion", afiliado.TipoDocumentoId);
            ViewBag.TipoSexoId = new SelectList(db.TipoSexo, "Id", "descripcion", afiliado.TipoSexoId);
            return View(afiliado);
        }

        // GET: Afiliado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = db.Afiliado.Find(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            ViewBag.EstadoCivilId = new SelectList(db.EstadoCivil, "Id", "descripcion", afiliado.EstadoCivilId);
            ViewBag.PlanId = new SelectList(db.Plan, "Id", "descripcion", afiliado.PlanId);
            ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumento, "Id", "descripcion", afiliado.TipoDocumentoId);
            ViewBag.TipoSexoId = new SelectList(db.TipoSexo, "Id", "descripcion", afiliado.TipoSexoId);
            return View(afiliado);
        }

        // POST: Afiliado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,TipoDocumentoId,Numero,Direccion,Telefono,Email,TipoSexoId,FechaNacimiento,EstadoCivilId,NumeroAfiliado,PlanId,Foto,Habilitado,createdon,createdby,changedon,changedby,deletedon,deletedby,isdeleted")] Afiliado afiliado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(afiliado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EstadoCivilId = new SelectList(db.EstadoCivil, "Id", "descripcion", afiliado.EstadoCivilId);
            ViewBag.PlanId = new SelectList(db.Plan, "Id", "descripcion", afiliado.PlanId);
            ViewBag.TipoDocumentoId = new SelectList(db.TipoDocumento, "Id", "descripcion", afiliado.TipoDocumentoId);
            ViewBag.TipoSexoId = new SelectList(db.TipoSexo, "Id", "descripcion", afiliado.TipoSexoId);
            return View(afiliado);
        }

        // GET: Afiliado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afiliado afiliado = db.Afiliado.Find(id);
            if (afiliado == null)
            {
                return HttpNotFound();
            }
            return View(afiliado);
        }

        // POST: Afiliado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Afiliado afiliado = db.Afiliado.Find(id);
            db.Afiliado.Remove(afiliado);
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
