using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades = MundoDeDonas.Models.Entidades;
using System.Web.Mvc;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace MundoDeDonas.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> TienesAntojo() {
            var apiKey = "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";
            var sTempleteID = "d-81501a793bbb4f8db1099454f1f4fb57";
            var oClient = new SendGridClient(apiKey);
            var oFrom = new EmailAddress("18240248@leon.tecnm.mx", "Mundo De donas");
            var oSubject = "";
            var oTo = new EmailAddress("hernandezpadillaemilioemmanuel@gmail.com");
            var oMailHelper = MailHelper.CreateSingleTemplateEmail(oFrom, oTo, sTempleteID, null);

            var r = await oClient.SendEmailAsync(oMailHelper);
            if (!r.IsSuccessStatusCode)
                return View();
            return View("Index"); 
        }

        //public async Task<ActionResult> TienesAntojo(Entidades.Usuario oUsuario) {
        //    var apiKey = "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";
        //    var sTempleteID = "d-81501a793bbb4f8db1099454f1f4fb57";
        //    var oClient = new SendGridClient(apiKey);
        //    var oFrom = new EmailAddress("bboylio05@gmail.com", "Mundo De donas");
        //    var oSubject = "";
        //    var oTo = new EmailAddress("hernandezpadillaemilioemmanuel@gmail.com");
        //    var oMailHelper = MailHelper.CreateSingleTemplateEmail(oFrom,oTo, sTempleteID,null);

        //    var r = await oClient.SendEmailAsync(oMailHelper);
        //    if (!r.IsSuccessStatusCode)
        //        return View();
        //    return View("Index");
        //}
    }
}