using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videojuegos_PereraA.InfraLayer.Security;

namespace Videojuegos_PereraA.Controllers
{
    [Authorize]
    [AdminFilter]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }


}