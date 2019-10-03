using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videojuegos_PereraA.Models;

namespace Videojuegos_PereraA.Controllers
{
    public class ClientesController : Controller
    {
        // GET: Clientes
        public ActionResult Index()
        {
            return RedirectToAction("GetClientes");
        }

        public ActionResult GetClientes()
        {
            List<Cliente> clientes;

            using (var context = new VideoJuegosEntities())
            {
                clientes = context.Cliente.ToList();
            }
            return View(clientes);
        }

        public ActionResult GetPuntuaciones(int id)
        {
            List<Puntuacion> puntuaciones;

            using(var context = new VideoJuegosEntities())
            {
                puntuaciones = context.Puntuacion.Where(p => p.Idcliente == id).ToList();
            }
            return View(puntuaciones);
        }
    }
}