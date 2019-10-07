using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videojuegos_PereraA.Models;
using System.Data.Entity;
using Videojuegos_PereraA.Security;
using System.Web.Security;

namespace Videojuegos_PereraA.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                Usuario authUser = null;
                using (VideoJuegosEntities videojuegosDAL = new VideoJuegosEntities())
                {
                    string hashedPass = ShaUtils.GenerateSHA256String(usuario.Password);
                    authUser = videojuegosDAL.Usuarios.Include(usu => usu.UsuarioGrupos.Select(y => y.Grupo)).
                        FirstOrDefault(u => u.Login == usuario.Login && u.Password == hashedPass);
                }

                if (authUser != null)
                {
                    FormsAuthentication.SetAuthCookie(authUser.Login, false);
                    Session["USUARIO"] = authUser;
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ModelState.AddModelError("CredentialError", "Usuario o contraseña incorrectos");
                    return View();
                }
            }
            else
                return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}