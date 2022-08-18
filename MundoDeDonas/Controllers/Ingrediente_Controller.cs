using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades = MundoDeDonas.Models.Entidades;
using Datos = MundoDeDonas.Models.Datos;
using System.Web.Mvc;

namespace MundoDeDonas.Controllers
{
    public class Ingrediente_Controller : Controller
    {
        // GET: Ingrediente_
        public ActionResult Index()
        {
            return View();
        }
    }
}