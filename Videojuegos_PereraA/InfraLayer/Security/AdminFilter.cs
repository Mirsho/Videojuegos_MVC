using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Videojuegos_PereraA.Models;

namespace Videojuegos_PereraA.InfraLayer.Security
{
    public class AdminFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Usuario u = null;

            if (filterContext.HttpContext.Session["USUARIO"] is Usuario)
                u = filterContext.HttpContext.Session["USUARIO"] as Usuario;

            if (u == null || !u.UsuarioGrupos.Any(g => g.Grupo.Nombre == "admin"))
            {
                filterContext.Result = new ViewResult()
                {
                    ViewName = "AuthError"
                };
            }
        }
    }
}