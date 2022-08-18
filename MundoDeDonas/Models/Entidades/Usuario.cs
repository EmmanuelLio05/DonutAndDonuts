using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MundoDeDonas.Models.Entidades {
    public class Usuario {
        #region Atributos 
        private Int32 U_Id;
        private String U_Nombre;
        private String U_Apellido;
        private String U_Email;
        private String U_Contrasenia;
        private DateTime U_FechaRegistro;
        #endregion

        #region Propiedades 

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public Int32 Id {
            get { return U_Id; }
            set { U_Id = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public String Nombre {
            get { return U_Nombre; }
            set { U_Nombre = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public String Apellido {
            get { return U_Apellido; }
            set { U_Apellido = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public String Email {
            get { return U_Email; }
            set { U_Email = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public String Contrasenia {
            get { return U_Contrasenia; }
            set { U_Contrasenia = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public DateTime FechaRegistro {
            get { return U_FechaRegistro; }
            set { U_FechaRegistro = value; }
        }

        #endregion

        #region Metodos 
        public Usuario() {
            U_Id = 0;
            U_Nombre = "";
            U_Apellido = "";
            U_Email = "";
            U_Contrasenia = "";
            U_FechaRegistro = new DateTime(1900, 01, 01);
        }
        #endregion
    }
}