using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videojuegos_PereraA.Models;
using PagedList;    //Declaramos este using para poder paginar la lista de juegos
using System.Data;
using System.Net;
using System.Data.Entity;   //Recordar ponerlo siempre

namespace Videojuegos_PereraA.Controllers
{
    public class JuegosController : Controller
    {
        private VideoJuegosEntities db = new VideoJuegosEntities(); //Atributo private para acceder a las tablas de la base de datos desde cualquier método
        // GET: Juegos
        public ActionResult Index()
        {
            return RedirectToAction("GetJuegos");
        }
        public ActionResult GetJuegos(string sortOrder, int? page)  //Método para mostrar la lista paginada
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (page == null) { page = 1; }
            List<Juego> juegos;

            VideoJuegosEntities context = new VideoJuegosEntities();    //Instanciar el contexto cuando llamamos al método.
            juegos = context.Juego.ToList();
            int pageSize = 20;
            int pageNumber = (page ?? 1);
            return View(juegos.ToPagedList(pageNumber, pageSize));
        }

        /*  Método de prueba inicial para mostrar lista no paginada:
        public ActionResult GetJuegos()
        {
            List<Juego> juegos;
            VideoJuegosEntities context = new VideoJuegosEntities();
            juegos = context.Juego.OrderByDescending(p => p.IdJuego).ToList();
            return View(juegos);
        }
        */

        // GET: Crear
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.IdTipo = new SelectList(db.Tipo, "IdTipo", "Tipo1");
            return View();
        }

        //Al pulsar submit enviamos los datos por POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind (Include = "Juego1, IdTipo")] Juego newJuego)  //Método POST para crear juego y añadirlo a la DB
        {
            ViewBag.IdTipo = new SelectList(db.Tipo, "IdTipo", "Tipo1");

            try    //Ya que estamos trabajando con DBs de servidores, hacemos un try catch para controlar posibles excepciones
            {
                if (ModelState.IsValid)
                {
                    VideoJuegosEntities context = new VideoJuegosEntities();
                    newJuego.IdJuego = context.Juego.Count() + 1;   //Contamos el total de IdJuegos y le sumamos 1 para generar el Id del nuevo juego.
                    context.Juego.Add(newJuego);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /*dex*/)
            {
                //Si quisiera mostrar el mensaje de error del compilador, descomentamos la variable dex y agregamos una orden para mostrarla.
                ModelState.AddModelError("", "No se pudieron guardar los datos. Intentelo de nuevo, o consulte con su administrador");
            }
            return View(newJuego);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoJuegosEntities context = new VideoJuegosEntities();
            Juego juego = context.Juego.Find(id);
            if (juego == null)
            {
                return HttpNotFound();
            }
            return View(juego);
        }

        // GET: Editar
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoJuegosEntities context = new VideoJuegosEntities();
            Juego juego = context.Juego.Find(id);
            if (juego == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTipo = new SelectList(db.Tipo, "IdTipo", "Tipo1", juego.IdTipo);
            return View(juego);
        }

        // Esta acción la realiza cuando le das al botón de Guardar ( el submit )
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdJuego,Juego1,IdTipo")] Juego juego)
        {
            if (ModelState.IsValid)
            {
                VideoJuegosEntities context = new VideoJuegosEntities();
                context.Entry(juego).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTipo = new SelectList(db.Tipo, "IdTipo", "Tipo1", juego.IdTipo);
            return View(juego);
        }

        // GET: Eliminar
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoJuegosEntities context = new VideoJuegosEntities();
            Juego juego = context.Juego.Find(id);
            if (juego == null)
            {
                return HttpNotFound();
            }
            return View(juego);
        }

        // La eliminación se realiza al pulsar submit.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoJuegosEntities context = new VideoJuegosEntities();
            Juego juego = context.Juego.Find(id);
            context.Juego.Remove(juego);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}