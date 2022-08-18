using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MundoDeDonas.Models.Entidades {
    public class Ingrediente {
        #region Atributos 
        private Int32 I_Id;
        private String I_Nombre;
        private String I_Tipo;
        private bool I_Disponible;
        #endregion

        #region Propiedades 

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public Int32 Id {
            get { return I_Id; }
            set { I_Id = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public String Nombre {
            get { return I_Nombre; }
            set { I_Nombre = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public String Tipo {
            get { return I_Tipo; }
            set { I_Tipo = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public bool Disponible {
            get { return I_Disponible; }
            set { I_Disponible = value; }
        }

        #endregion

        #region Metodos 
        public Ingrediente() {
            I_Id = 0;
            I_Nombre = "";
            I_Tipo = "";
            I_Disponible = false;
        }
        #endregion
    }
}