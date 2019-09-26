using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videojuegos_PereraA.Models;

namespace Videojuegos_PereraA.Controllers
{
    public class JuegosController : Controller
    {
        // GET: Juegos
        public ActionResult Index()
        {
            return RedirectToAction("GetJuegos");
        }
        public ActionResult GetJuegos1(int? page)
        {
            if (page == null) { page = 1; }
            List<Juego> juegos;

            VideoJuegosEntities context = new VideoJuegosEntities();
            juegos = context.Juego.ToList();
            int pageSize = 10;
            int pageNumber = page ?? 1;
            return View(juegos/*.ToPagedList(pageNumber, pageSize)*/);
        }

        public ActionResult GetJuegos()
        {
            List<Juego> juegos;
            VideoJuegosEntities context = new VideoJuegosEntities();
            juegos = context.Juego.OrderByDescending(p => p.IdJuego).ToList();
            return View(juegos);
        }
    }
}