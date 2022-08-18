using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades = MundoDeDonas.Models.Entidades;
using Datos = MundoDeDonas.Models.Datos;
using System.Web.Mvc;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace MundoDeDonas.Controllers {
    public class Usuario_Controller : Controller {
        public ActionResult RegistrarUsuario() {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AllowAnonymous]
        public ActionResult RegistrarUsuario(Entidades.Usuario oUsuario) {
            var oDUsuario = new Datos.Usuario();
            var apiKey = "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";
            var sTempleteID = "d-81501a793bbb4f8db1099454f1f4fb57";
            var oClient = new SendGridClient(apiKey);
            var oFrom = new EmailAddress("18240248@leon.tecnm.mx", "Mundo De donas");
            var oTo = new EmailAddress(oUsuario.Email);
            var oMailHelper = MailHelper.CreateSingleTemplateEmail(oFrom, oTo, sTempleteID, null);

            oClient.SendEmailAsync(oMailHelper);
            oUsuario.FechaRegistro = DateTime.Today;
            oDUsuario.Add(oUsuario);
            System.Web.HttpContext.Current.Session["Nombre"] = oUsuario.Nombre;
            System.Web.HttpContext.Current.Session["Email"] = oUsuario.Email;
            System.Web.HttpContext.Current.Session["Id"] = oDUsuario.VerificaLogin(oUsuario.Email, oUsuario.Contrasenia).Id;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login() {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AllowAnonymous]
        public ActionResult Login(Entidades.Usuario oUsuario) {
            Datos.Usuario oDUsuario = new Datos.Usuario();

            try {
                oUsuario = oDUsuario.VerificaLogin(oUsuario.Email, oUsuario.Contrasenia);
                if (oUsuario == null) {
                    return View();
                } else {
                    System.Web.HttpContext.Current.Session["Nombre"] = oUsuario.Nombre;
                    System.Web.HttpContext.Current.Session["Email"] = oUsuario.Email;
                    System.Web.HttpContext.Current.Session["Id"] = oUsuario.Id;
                    return RedirectToAction("Index", "Home");
                }
            } catch (Exception ex) {
                return View();
            }
        }

        public ActionResult Logout() {
            if (System.Web.HttpContext.Current.Session["Id"] != null) 
                System.Web.HttpContext.Current.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public JsonResult ObtenerUsuario(int clave) {
            var oUsuario = new Entidades.Usuario();
            var oDUsuario = new Datos.Usuario();
            oUsuario = oDUsuario.GetOne(clave);
            return new JsonResult() { Data = oUsuario, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

    }
}