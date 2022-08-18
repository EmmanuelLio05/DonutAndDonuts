using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MundoDeDonas.Models.Entidades {
    public class Metodo_Pago {
        #region Atributos 
        private Int32 MP_Id;
        private String MP_Nombre;
        private bool MP_Valido;
        #endregion

        #region Propiedades 

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public Int32 Id {
            get { return MP_Id; }
            set { MP_Id = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public String Nombre {
            get { return MP_Nombre; }
            set { MP_Nombre = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public bool Valido {
            get { return MP_Valido; }
            set { MP_Valido = value; }
        }

        #endregion

        #region Metodos 
        public Metodo_Pago() {
            MP_Id = 0;
            MP_Nombre = "";
            MP_Valido = false;
        }
        #endregion
    }
}