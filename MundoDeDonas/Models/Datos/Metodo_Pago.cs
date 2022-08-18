using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MundoDeDonas.Models.Datos {
    public class Metodo_Pago {
        public Object Add(Entidades.Metodo_Pago oMetodo_Pago) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Metodo_Pago_Insert";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@MP_Nombre", oMetodo_Pago.Nombre);
                    oComm.Parameters.AddWithValue("@MP_Valido", oMetodo_Pago.Valido);
                    return Convert.ToInt32(oComm.ExecuteScalar());
                }
            }
        }

        public Object Update(Entidades.Metodo_Pago oMetodo_Pago) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Metodo_Pago_Update";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@MP_Id", oMetodo_Pago.Id);
                    oComm.Parameters.AddWithValue("@MP_Nombre", oMetodo_Pago.Nombre);
                    oComm.Parameters.AddWithValue("@MP_Valido", oMetodo_Pago.Valido);
                    return oComm.ExecuteScalar();
                }
            }
        }

        public void Delete(Int32 MP_Id) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Metodos_Pago_Delete";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@MP_Id", MP_Id);
                    oComm.ExecuteScalar();
                }
            }
        }

        public bool Verificar(Int32 MP_Id) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Metodos_Pago_SelectOne";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@MP_Id", MP_Id);
                    return oComm.ExecuteReader().HasRows;
                }
            }
        }

        public object SelectMaxId() {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Metodos_Pago_SelectMaxId";
                    oComm.CommandType = CommandType.StoredProcedure;
                    return oComm.ExecuteScalar();
                }
            }
        }

        public Entidades.Metodo_Pago GetOne(Int32 MP_Id) {
            var oEGeneral = new General();
            SqlDataReader drMetodo_Pago;
            Entidades.Metodo_Pago oMetodo_Pago = new Entidades.Metodo_Pago();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Metodos_Pago_SelectOne";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@MP_Id", MP_Id);
                    drMetodo_Pago = oComm.ExecuteReader();
                    if (drMetodo_Pago.Read()) {
                        LlenaEntidad(ref oMetodo_Pago, drMetodo_Pago);
                        return oMetodo_Pago;
                    } else return null;
                }
            }
        }

        public Entidades.Metodos_Pago GetAll(int nHoja, int nNoRegistros = 50) {
            var oEGeneral = new General();
            SqlDataReader drMetodo_Pago;
            Entidades.Metodo_Pago oMetodo_Pago = new Entidades.Metodo_Pago();
            Entidades.Metodos_Pago oMetodos_Pago = new Entidades.Metodos_Pago();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Metodos_Pago_SelectAll";
                    oComm.Parameters.AddWithValue("@MP_pagina", nHoja);
                    oComm.Parameters.AddWithValue("@MP_NoRegistros", nNoRegistros);
                    oComm.CommandType = CommandType.StoredProcedure;
                    drMetodo_Pago = oComm.ExecuteReader();
                    while (drMetodo_Pago.Read()) {
                        oMetodo_Pago = new Entidades.Metodo_Pago();
                        LlenaEntidad(ref oMetodo_Pago, drMetodo_Pago);
                        oMetodos_Pago.Add(oMetodo_Pago);
                    }
                    return oMetodos_Pago;
                }
            }
        }

        public Entidades.Metodos_Pago Busqueda(String sSql) {
            var oEGeneral = new General();
            SqlDataReader drMetodo_Pago;
            Entidades.Metodo_Pago oMetodo_Pago = new Entidades.Metodo_Pago();
            Entidades.Metodos_Pago oMetodos_Pago = new Entidades.Metodos_Pago();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Ejecuta_SQL";
                    oComm.Parameters.AddWithValue("@sql", sSql);
                    oComm.CommandType = CommandType.StoredProcedure;
                    drMetodo_Pago = oComm.ExecuteReader();
                    while (drMetodo_Pago.Read()) {
                        oMetodo_Pago = new Entidades.Metodo_Pago();
                        LlenaEntidad(ref oMetodo_Pago, drMetodo_Pago);
                        oMetodos_Pago.Add(oMetodo_Pago);
                    }
                    return oMetodos_Pago;
                }
            }
        }

        public Entidades.Metodos_Pago GetAll() {
            var oEGeneral = new General();
            SqlDataReader drMetodo_Pago;
            Entidades.Metodo_Pago oMetodo_Pago = new Entidades.Metodo_Pago();
            Entidades.Metodos_Pago oMetodos_Pago = new Entidades.Metodos_Pago();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Metodos_Pago_SelectAll";
                    oComm.Parameters.AddWithValue("@MP_pagina", 1);
                    oComm.Parameters.AddWithValue("@MP_NoRegistros", 2000);
                    oComm.CommandType = CommandType.StoredProcedure;
                    drMetodo_Pago = oComm.ExecuteReader();
                    while (drMetodo_Pago.Read()) {
                        oMetodo_Pago = new Entidades.Metodo_Pago();
                        LlenaEntidad(ref oMetodo_Pago, drMetodo_Pago);
                        oMetodos_Pago.Add(oMetodo_Pago);
                    }
                    return oMetodos_Pago;
                }
            }
        }

        public object CountPaginas(int nLogitud = 50) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Metodos_Pago_SelectNoHojas";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@MP_NoRegistros", nLogitud);
                    return oComm.ExecuteScalar();
                }
            }
        }

        public object CountPaginas(String sSql) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Ejecuta_SQL";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@sql", sSql);
                    return oComm.ExecuteScalar();
                }
            }
        }

        private void LlenaEntidad(ref Entidades.Metodo_Pago oMetodo_Pago, SqlDataReader drMetodo_Pago) {
            oMetodo_Pago.Id = Convert.IsDBNull(drMetodo_Pago["MP_Id"]) ? 0 : Convert.ToInt32(drMetodo_Pago["MP_Id"]);
            oMetodo_Pago.Nombre = Convert.IsDBNull(drMetodo_Pago["MP_Nombre"]) ? "" : Convert.ToString(drMetodo_Pago["MP_Nombre"]).Trim();
            oMetodo_Pago.Valido = Convert.IsDBNull(drMetodo_Pago["MP_Valido"]) ? false : Convert.ToBoolean(drMetodo_Pago["MP_Valido"]);
        }
    }
}