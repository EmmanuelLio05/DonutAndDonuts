using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades = MundoDeDonas.Models.Entidades;
using Datos = MundoDeDonas.Models.Datos;
using System.Web.Mvc;

namespace MundoDeDonas.Controllers
{
    public class Metodo_Pago_Controller : Controller
    {
        // GET: Metodo_Pago_
        public ActionResult Index()
        {
            return View();
        }
    }
}