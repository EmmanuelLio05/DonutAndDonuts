using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MundoDeDonas.Models.Entidades {
    public class Pedido {
        #region Atributos 
        private Int32 P_Id;
        private Int32 P_IdUsuario;
        private Int32 P_MetodoPago;
        private DateTime P_FechaPedido;
        private DateTime P_FechaEntrega;
        private Int16 P_Estatus;
        private Int16 P_EstatusPago;
        private String P_DireccionEntrega;
        private Decimal P_Decenas;
        #endregion

        #region Propiedades 

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public Int32 Id {
            get { return P_Id; }
            set { P_Id = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public Int32 IdUsuario {
            get { return P_IdUsuario; }
            set { P_IdUsuario = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public Int32 MetodoPago {
            get { return P_MetodoPago; }
            set { P_MetodoPago = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public DateTime FechaPedido {
            get { return P_FechaPedido; }
            set { P_FechaPedido = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public DateTime FechaEntrega {
            get { return P_FechaEntrega; }
            set { P_FechaEntrega = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public Int16 Estatus {
            get { return P_Estatus; }
            set { P_Estatus = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public Int16 EstatusPago {
            get { return P_EstatusPago; }
            set { P_EstatusPago = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public String DireccionEntrega {
            get { return P_DireccionEntrega; }
            set { P_DireccionEntrega = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public Decimal Decenas {
            get { return P_Decenas; }
            set { P_Decenas = value; }
        }

        #endregion

        #region Metodos 
        public Pedido() {
            P_Id = 0;
            P_IdUsuario = 0;
            P_MetodoPago = 0;
            P_FechaPedido = new DateTime(1900, 01, 01);
            P_FechaEntrega = new DateTime(1900, 01, 01);
            P_Estatus = (short)0;
            P_EstatusPago = (short)0;
            P_DireccionEntrega = "";
            P_Decenas = 0.0m;
        }
        #endregion
    }
}