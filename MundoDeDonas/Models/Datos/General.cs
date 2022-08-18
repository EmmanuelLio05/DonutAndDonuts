using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MundoDeDonas.Models.Datos {
    public class General {
        public SqlConnection Conectar() {
            SqlConnection sConnect = new SqlConnection();
            string sServidor;
            string sBD;

            try { 
                sServidor = "AFRODITA";           
                sBD = "MundoDeDonas";
                sConnect = new SqlConnection(@"Data Source=" + sServidor + ";Initial Catalog=" + sBD + ";Persist Security Info=True;User ID=sa;Password=bboylio05");
        } catch (Exception ex) { 

            }
            return sConnect;
        }
    }
}