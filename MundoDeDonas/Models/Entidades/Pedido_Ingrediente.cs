using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MundoDeDonas.Models.Entidades {
    public class Pedido_Ingrediente {
        #region Atributos 
        private Int32 PI_IdPedido;
        private Int32 PI_Ingrediente;
        #endregion

        #region Propiedades 

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public Int32 IdPedido {
            get { return PI_IdPedido; }
            set { PI_IdPedido = value; }
        }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Display(Name = " ")]
        public Int32 Ingrediente {
            get { return PI_Ingrediente; }
            set { PI_Ingrediente = value; }
        }

        #endregion

        #region Metodos 
        public Pedido_Ingrediente() {
            PI_IdPedido = 0;
            PI_Ingrediente = 0;
        }
        #endregion
    }
}