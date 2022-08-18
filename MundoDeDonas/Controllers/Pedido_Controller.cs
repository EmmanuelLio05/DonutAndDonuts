using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades = MundoDeDonas.Models.Entidades;
using Datos = MundoDeDonas.Models.Datos;
using System.Web.Mvc;
using System.IO;

namespace MundoDeDonas.Controllers {
    public class Pedido_Controller : Controller {
        // GET: Pedido_
        public ActionResult Pedido() {
            return View();
        }

        public JsonResult RealizarPedido(FormCollection form) {
            var oDPedido = new Datos.Pedido();
            var oEPedido = new Entidades.Pedido();
            var oDIngrediente = new Datos.Pedido_Ingrediente();
            var oEIngrediente = new Entidades.Pedido_Ingrediente();
            var oEIngredientes = new Entidades.Pedido_Ingredientes();

            string method = form["payment-method-checker"].ToString();
            string num_tarjeta = form["num_tarjeta"].ToString();
            string fecha_venc = form["fecha_venc"].ToString();
            string titular = form["titular"].ToString();
            string ccv = form["ccv"].ToString();
            int cantidad = Convert.ToInt32(form["cantidad"]);
            int cover_option = Convert.ToInt32(form["cover-option"]);
            int glass_option = Convert.ToInt32(form["glass-option"]);
            int fill_option = Convert.ToInt32(form["fill-option"]);

            try {
                if(/*false*/System.Web.HttpContext.Current.Session["Id"] == null) {
                    //return View("Login", "Usuario_");
                    return Json(new { result = false, message = "No ha iniciado sesión" }, JsonRequestBehavior.AllowGet);
                } else {
                    oEPedido.Decenas = cantidad;
                    oEPedido.MetodoPago = (method == "cash") ? 1 : (method == "credit") ? 2 : 0;
                    oEPedido.IdUsuario = /*1;*/ (int) System.Web.HttpContext.Current.Session["Id"];
                    var lastID = oDPedido.Add(oEPedido);
                    oEIngrediente.IdPedido = lastID;
                    oEIngrediente.Ingrediente = cover_option;
                    oEIngredientes.Add(oEIngrediente);
                    oEIngrediente = new Entidades.Pedido_Ingrediente();
                    oEIngrediente.IdPedido = lastID;
                    oEIngrediente.Ingrediente = glass_option;
                    oEIngredientes.Add(oEIngrediente);
                    oEIngrediente = new Entidades.Pedido_Ingrediente();
                    oEIngrediente.IdPedido = lastID;
                    oEIngrediente.Ingrediente = fill_option;
                    oEIngredientes.Add(oEIngrediente);
                    foreach (Entidades.Pedido_Ingrediente ingrediente in oEIngredientes) {
                        oDIngrediente.Add(ingrediente);

                    }
                    return Json(new { result = true }, JsonRequestBehavior.AllowGet);
                }
            } catch(Exception e) {
                using(StreamWriter writer = new StreamWriter(Server.MapPath("/log.txt"))) {
                    writer.WriteLine("----------------" + e.Message);
                }
                return Json(new { result = false, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}