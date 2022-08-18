using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MundoDeDonas.Models.Entidades {
    public class Usuario_Metodo_Pago {
        #region Atributos 
        private Int32 UMP_Id;
        private Int32 UMP_IdUsuario;
        private Int32 UMP_IdMetodoPago;
        private String UMP_Clabe;
        private String UMP_Referencia;
        private String UMP_Numero;
        private String UMP_Banco;
        private bool UMP_Estatus;
        #endregion

        #region Propiedades 

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public Int32 Id {
            get { return UMP_Id; }
            set { UMP_Id = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public Int32 IdUsuario {
            get { return UMP_IdUsuario; }
            set { UMP_IdUsuario = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public Int32 IdMetodoPago {
            get { return UMP_IdMetodoPago; }
            set { UMP_IdMetodoPago = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public String Clabe {
            get { return UMP_Clabe; }
            set { UMP_Clabe = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public String Referencia {
            get { return UMP_Referencia; }
            set { UMP_Referencia = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public String Numero {
            get { return UMP_Numero; }
            set { UMP_Numero = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public String Banco {
            get { return UMP_Banco; }
            set { UMP_Banco = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public bool Estatus {
            get { return UMP_Estatus; }
            set { UMP_Estatus = value; }
        }

        #endregion

        #region Metodos 
        public Usuario_Metodo_Pago() {
            UMP_Id = 0;
            UMP_IdUsuario = 0;
            UMP_IdMetodoPago = 0;
            UMP_Clabe = "";
            UMP_Referencia = "";
            UMP_Numero = "";
            UMP_Banco = "";
            UMP_Estatus = false;
        }
        #endregion
    }
}