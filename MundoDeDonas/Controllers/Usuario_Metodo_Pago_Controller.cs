using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entidades = MundoDeDonas.Models.Entidades;
using Datos = MundoDeDonas.Models.Datos;
using System.Web.Mvc;

namespace MundoDeDonas.Controllers {
    public class Usuario_Metodos_PagoController : Controller {
        public String sSql = "", sSql2 = "", sSort = "";
        #region Métodos
        /// <summary>
        /// Construye un arreglo de arreglos string que se usara para construir un archivo de excel (el equivalente a un grid en los demas proyectos de Valcom).
        /// </summary>
        /// <returns></returns>
        public String[][] GridParaExcel(String sCuales) {
            var oEUsuario_Metodos_Pago = new Entidades.Usuario_Metodos_Pago();
            var oDUsuario_Metodo_Pago = new Datos.Usuario_Metodo_Pago();
            String[][] grid;
            int nAux = 0; int nHojas = 0;

            if(Session["sSql"] != null)
                sSql = Session["sSql"].ToString();
            switch(sCuales) {
                case "ACTUAL":
                    if(sSql != "")
                        oEUsuario_Metodos_Pago = oDUsuario_Metodo_Pago.Busqueda(sSql + " OFFSET(" + Session["hoja"] + " - 1) * " + "50" + " ROWS FETCH Next " + "50" + " ROWS ONLY; ");
                    else
                        oEUsuario_Metodos_Pago = oDUsuario_Metodo_Pago.GetAll(int.Parse(Session["hoja"].ToString()));
                    break;
                case "TODO":
                    if(sSql != "")
                        oEUsuario_Metodos_Pago = oDUsuario_Metodo_Pago.Busqueda(sSql);
                    else {
                        nHojas = int.Parse(oDUsuario_Metodo_Pago.CountPaginas("Select (COUNT(*)/50) As hojas FROM clientes WHERE cte_cve > 0 ").ToString());
                        for(int i = 0; i < nHojas; i++)
                            foreach(Entidades.Usuario_Metodo_Pago Usuario_Metodo_Pago in oDUsuario_Metodo_Pago.GetAll())
                                oEUsuario_Metodos_Pago.Add(Usuario_Metodo_Pago);
                    }
                    break;
            }
            grid = new String[oEUsuario_Metodos_Pago.Count][];
            foreach(Entidades.Usuario_Metodo_Pago Usuario_Metodo_Pago in oEUsuario_Metodos_Pago) {
                grid[nAux] = new String[] { Usuario_Metodo_Pago.Id.ToString(), Usuario_Metodo_Pago.IdUsuario.ToString(), Usuario_Metodo_Pago.IdMetodoPago.ToString(), Usuario_Metodo_Pago.Clabe, Usuario_Metodo_Pago.Referencia, Usuario_Metodo_Pago.Numero, Usuario_Metodo_Pago.Banco, Usuario_Metodo_Pago.Estatus.ToString() };
                nAux += 1;
            }
            return grid;
        }

        /// <summary>
        /// Método que envía al ViewBag las listas utilizadas para los combobox de la vista Catalogo y la vista RegistroUsuario
        /// </summary>
        public void cargarCombos() {
            //var oUnidades = new Models.Entidades.Unidades();
            //var oDUnidades = new Models.Datos.Unidad();
            //Obtenemos las listas
            //oUnidades = oDUnidades.GetAll();
            //Manda al viewbag las listas para los combobox
            //ViewBag.Unidades = oUnidades.Select(x => new SelectListItem { Text = x.modelo, Value = x.cve.ToString() });
        }
        #endregion
        #region Results
        public ActionResult Catalogo(int nHoja = 1) {
            var oEUsuario_Metodos_Pago = new Entidades.Usuario_Metodos_Pago();
            var oDUsuario_Metodo_Pago = new Models.Datos.Usuario_Metodo_Pago();

            if(System.Web.HttpContext.Current.Session["UserName"] == null)
                return RedirectToAction("Login", "Usuario");
            if(Session["sSql"] != null) {
                sSql = Session["sSql"].ToString();
                sSql2 = Session["sSql2"].ToString();
            }
            if(sSql != "") {
                ViewBag.nHojas = oDUsuario_Metodo_Pago.CountPaginas(sSql2);
            } else {
                ViewBag.nHojas = oDUsuario_Metodo_Pago.CountPaginas();
            }
            if(ViewBag.nHojas == 0)
                ViewBag.nHojas++;
            if(nHoja > ViewBag.nHojas)
                nHoja = ViewBag.nHojas;
            else if(nHoja < 1)
                nHoja = 1;
            if(Session["Hoja"] != null) {
                if(Convert.ToInt32(Session["Hoja"]) != nHoja)
                    Session["Hoja"] = nHoja;
            } else
                Session["Hoja"] = nHoja;
            if(sSql != "") {
                oEUsuario_Metodos_Pago = oDUsuario_Metodo_Pago.Busqueda(sSql + " OFFSET(" + nHoja + " - 1) * " + "50" + " ROWS FETCH Next " + "50" + " ROWS ONLY; ");
            } else {
                oEUsuario_Metodos_Pago = oDUsuario_Metodo_Pago.GetAll(nHoja);
            }
            cargarCombos();
            //GeneralController.cargarFiltros(this);
            ViewBag.nHoja = nHoja;
            return View(oEUsuario_Metodos_Pago);
        }

        /// <summary>
        /// Método que concatena dos consultas sql según los filtros seleccionados, la manda a traves de TempData y redirecciona al método Catalogo
        /// </summary>
        /// <param name="form">formulario de filtros de búsqueda</param>
        /// <returns></returns>
        [System.Web.Mvc.AllowAnonymous]
        public ActionResult Busqueda(FormCollection form = null) {
            if(System.Web.HttpContext.Current.Session["UserName"] == null)
                return RedirectToAction("Login", "Usuario");
            sSql = "Select UMP.* FROM dbo.Usuario_Metodos_Pago UMP WHERE UMP.UMP_Id > 0 ";
            sSql2 = "Select ((COUNT(*)/50) + Case (COUNT(*)%50) When 0 Then 0 Else 1 End) As hojas FROM Usuario_Metodos_Pago UMP WHERE UMP.UMP_Id > 0 ";
            if(form.Count > 0) {
                //Filtros
                if(form["txtFiltros"].Trim().Length > 0) {
                    sSql += "  ";
                    sSql2 += "  ";
                }
            }
            sSql += " ORDER BY " + ((Session["sSort"] == null) ? "UMP_Id" : "" + Session["sSort"]);
            //GeneralController.guardarFiltros(form);
            Session["sSql"] = sSql;
            Session["sSql2"] = sSql2;
            return RedirectToAction("Catalogo");
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.AllowAnonymous]
        public ActionResult RegistrarUsuario_Metodo_Pago(Entidades.Usuario_Metodo_Pago oUsuario_Metodo_Pago) {
            var oDUsuario_Metodo_Pago = new Datos.Usuario_Metodo_Pago();
            if(System.Web.HttpContext.Current.Session["UserName"] == null)
                return RedirectToAction("Login", "Usuario");
            if(oUsuario_Metodo_Pago.Id == 0) {
                int Id = int.Parse(oDUsuario_Metodo_Pago.SelectMaxId().ToString());
                oUsuario_Metodo_Pago.Id = Id + 1;
                oDUsuario_Metodo_Pago.Add(oUsuario_Metodo_Pago);
                //GeneralController.LogAction("Registro [Usuario_Metodos_Pago] " + oUsuario_Metodo_Pago.Id + ".", this);
            } else {
                oDUsuario_Metodo_Pago.Update(oUsuario_Metodo_Pago);
                //GeneralController.LogAction("Actualizó [Usuario_Metodos_Pago] " + oUsuario_Metodo_Pago.Id + ".", this);
            }
            return RedirectToAction("Catalogo");
        }

        public JsonResult ObtenerUsuario_Metodo_Pago(int clave) {
            var oUsuario_Metodo_Pago = new Entidades.Usuario_Metodo_Pago();
            var oDUsuario_Metodo_Pago = new Datos.Usuario_Metodo_Pago();
            oUsuario_Metodo_Pago = oDUsuario_Metodo_Pago.GetOne(clave);
            return new JsonResult() { Data = oUsuario_Metodo_Pago, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        /// <summary>
        /// Método para eliminar un objeto. Retorna la vista Catalogo
        /// </summary>
        /// <param name="Clave">Clave del objeto a eliminar</param>
        /// <returns></returns>
        public ActionResult EliminarUsuario_Metodo_Pago(int Clave) {
            var oDatos = new Datos.Usuario_Metodo_Pago();
            if(System.Web.HttpContext.Current.Session["UserName"] == null)
                return RedirectToAction("Login", "Usuario");
            oDatos.Delete(Clave);
            //GeneralController.LogAction("Elimino [Usuario_Metodos_Pago] " + Clave.ToString() + ".", this);
            return RedirectToAction("Catalogo");
        }

        [System.Web.Mvc.AllowAnonymous]
        public ActionResult Orden(String sColumna) {
            if(System.Web.HttpContext.Current.Session["UserName"] == null)
                return RedirectToAction("Login", "Usuario");
            if(Session["sSort"] != null) {
                if(Session["sSort"].ToString().Contains(sColumna)) {
                    if(Session["sSort"].ToString().Contains("DESC"))
                        sSort = sColumna + " ASC";
                    else
                        sSort = sColumna + " DESC";
                } else
                    sSort = sColumna + " ASC";
            } else
                sSort = sColumna + " ASC";
            Session["sSort"] = sSort;
            return RedirectToAction("Busqueda", "Usuario_Metodos_Pago");
        }

        /// <summary>
        /// EEHP Función de exportar catalogo a Excel.
        /// </summary>
        /// <returns>Retorna un objeto de tipo FileResult</returns>
        //public FileResult ExportarExcel(String sCuales = "ACTUAL") {
        //    var MS = new System.IO.MemoryStream();
        //    System.IO.FileStream fs;
        //    String[][] sGrid = GridParaExcel(sCuales);

        //    fs = GeneralArchivos.ExportToExcel(sGrid, new String[] { "Id", "IdUsuario", "IdMetodoPago", "Clabe", "Referencia", "Numero", "Banco", "Estatus" });
        //    return File(fs, GeneralArchivos.MimeTypes[".xlsx"], "CATALOGO DE [Usuario_Metodos_Pago].xlsx");
        //}
        #endregion
    }
}