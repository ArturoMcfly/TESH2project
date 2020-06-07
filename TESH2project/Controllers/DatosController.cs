using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TESH2project.Data;
using TESH2project.Models;

namespace TESH2project.Controllers
{
    public class DatosController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Datos
        public ActionResult Index()
        {
            return View(db.Datos.ToList());//aqui se manda a llamar toda la lista de datos
        }

        // GET: Datos/Details/5
        public ActionResult Details(int? id)//Este sirve para hacer busquedas especificas
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datos datos = db.Datos.Find(id);//este busca solo un registro en ves de toda una lista
            if (datos == null)
            {
                return HttpNotFound();
            }
            return View(datos);
        }

        // GET: Datos/Create
        public ActionResult Create()
        {
            return View();// carga la pagina de create
        }

        // POST: Datos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]//aqui se define el metodo si es get o post
        [ValidateAntiForgeryToken]//son atributos en c# estan disponibles en entity framework
        public ActionResult Create([Bind(Include = "Id,Nombre,Compania,Empleados")] Datos datos)//este se activa en el submit y conecta con la base de datos es parecido al insert en php
        {
            if (ModelState.IsValid)
            {
                db.Datos.Add(datos);//esto es el insert
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(datos);
        }

        // GET: Datos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datos datos = db.Datos.Find(id);
            if (datos == null)
            {
                return HttpNotFound();
            }
            return View(datos);
        }

        // POST: Datos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Compania,Empleados")] Datos datos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datos).State = EntityState.Modified;//Para modificar los datos en ves de crear

                db.SaveChanges();//Pasa al siguiente registro
                return RedirectToAction("Index");
            }
            return View(datos);
        }

        // GET: Datos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Datos datos = db.Datos.Find(id);
            if (datos == null)
            {
                return HttpNotFound();
            }
            return View(datos);
        }

        // POST: Datos/Delete/5
        [HttpPost, ActionName("Delete")]//Action name sirve para borrar reistros 
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Datos datos = db.Datos.Find(id);
            db.Datos.Remove(datos);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)//cierra las ventanas y se usa en auditorias, libera recursos.
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
