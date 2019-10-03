using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using Videojuegos_PereraA.Models;
using PagedList;

namespace Videojuegos_PereraA.Controllers
{
    public class PlataformasController : Controller
    {
        private VideoJuegosEntities db = new VideoJuegosEntities(); //Atributo private para acceder a las tablas de la base de datos desde cualquier método
        // GET: Plataformas
        public ActionResult Index()
        {
            return RedirectToAction("GetPlataformas");
        }

        public ActionResult GetPlataformas(string sortOrder, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            List<Plataforma> plataformas;

            VideoJuegosEntities context = new VideoJuegosEntities();
            plataformas = context.Plataforma.ToList();
            int pageSize = 15;
            int pageNumber = (page ?? 1);
            return View(plataformas.ToPagedList(pageNumber, pageSize));
        }
    }
}