using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MundoDeDonas.Models.Datos {
    public class Usuario_Metodo_Pago {
        public Object Add(Entidades.Usuario_Metodo_Pago oUsuario_Metodo_Pago) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Usuario_Metodo_Pago_Insert";
                    oComm.CommandType = CommandType.StoredProcedure;
                    //oComm.Parameters.AddWithValue("@UMP_Id", oUsuario_Metodo_Pago.Id);
                    oComm.Parameters.AddWithValue("@UMP_IdUsuario", oUsuario_Metodo_Pago.IdUsuario);
                    oComm.Parameters.AddWithValue("@UMP_IdMetodoPago", oUsuario_Metodo_Pago.IdMetodoPago);
                    oComm.Parameters.AddWithValue("@UMP_Clabe", oUsuario_Metodo_Pago.Clabe);
                    oComm.Parameters.AddWithValue("@UMP_Referencia", oUsuario_Metodo_Pago.Referencia);
                    oComm.Parameters.AddWithValue("@UMP_Numero", oUsuario_Metodo_Pago.Numero);
                    oComm.Parameters.AddWithValue("@UMP_Banco", oUsuario_Metodo_Pago.Banco);
                    oComm.Parameters.AddWithValue("@UMP_Estatus", oUsuario_Metodo_Pago.Estatus);
                    return Convert.ToInt32(oComm.ExecuteScalar());
                }
            }
        }

        public Object Update(Entidades.Usuario_Metodo_Pago oUsuario_Metodo_Pago) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Usuario_Metodo_Pago_Update";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@UMP_Id", oUsuario_Metodo_Pago.Id);
                    oComm.Parameters.AddWithValue("@UMP_IdUsuario", oUsuario_Metodo_Pago.IdUsuario);
                    oComm.Parameters.AddWithValue("@UMP_IdMetodoPago", oUsuario_Metodo_Pago.IdMetodoPago);
                    oComm.Parameters.AddWithValue("@UMP_Clabe", oUsuario_Metodo_Pago.Clabe);
                    oComm.Parameters.AddWithValue("@UMP_Referencia", oUsuario_Metodo_Pago.Referencia);
                    oComm.Parameters.AddWithValue("@UMP_Numero", oUsuario_Metodo_Pago.Numero);
                    oComm.Parameters.AddWithValue("@UMP_Banco", oUsuario_Metodo_Pago.Banco);
                    oComm.Parameters.AddWithValue("@UMP_Estatus", oUsuario_Metodo_Pago.Estatus);
                    return oComm.ExecuteScalar();
                }
            }
        }

        public void Delete(Int32 UMP_Id) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Usuario_Metodos_Pago_Delete";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@UMP_Id", UMP_Id);
                    oComm.ExecuteScalar();
                }
            }
        }

        public bool Verificar(Int32 UMP_Id) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Usuario_Metodos_Pago_SelectOne";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@UMP_Id", UMP_Id);
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
                    oComm.CommandText = "Usuario_Metodos_Pago_SelectMaxId";
                    oComm.CommandType = CommandType.StoredProcedure;
                    return oComm.ExecuteScalar();
                }
            }
        }

        public Entidades.Usuario_Metodo_Pago GetOne(Int32 UMP_Id) {
            var oEGeneral = new General();
            SqlDataReader drUsuario_Metodo_Pago;
            Entidades.Usuario_Metodo_Pago oUsuario_Metodo_Pago = new Entidades.Usuario_Metodo_Pago();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Usuario_Metodos_Pago_SelectOne";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@UMP_Id", UMP_Id);
                    drUsuario_Metodo_Pago = oComm.ExecuteReader();
                    if (drUsuario_Metodo_Pago.Read()) {
                        LlenaEntidad(ref oUsuario_Metodo_Pago, drUsuario_Metodo_Pago);
                        return oUsuario_Metodo_Pago;
                    } else return null;
                }
            }
        }

        public Entidades.Usuario_Metodos_Pago GetAll(int nHoja, int nNoRegistros = 50) {
            var oEGeneral = new General();
            SqlDataReader drUsuario_Metodo_Pago;
            Entidades.Usuario_Metodo_Pago oUsuario_Metodo_Pago = new Entidades.Usuario_Metodo_Pago();
            Entidades.Usuario_Metodos_Pago oUsuario_Metodos_Pago = new Entidades.Usuario_Metodos_Pago();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Usuario_Metodos_Pago_SelectAll";
                    oComm.Parameters.AddWithValue("@UMP_pagina", nHoja);
                    oComm.Parameters.AddWithValue("@UMP_NoRegistros", nNoRegistros);
                    oComm.CommandType = CommandType.StoredProcedure;
                    drUsuario_Metodo_Pago = oComm.ExecuteReader();
                    while (drUsuario_Metodo_Pago.Read()) {
                        oUsuario_Metodo_Pago = new Entidades.Usuario_Metodo_Pago();
                        LlenaEntidad(ref oUsuario_Metodo_Pago, drUsuario_Metodo_Pago);
                        oUsuario_Metodos_Pago.Add(oUsuario_Metodo_Pago);
                    }
                    return oUsuario_Metodos_Pago;
                }
            }
        }

        public Entidades.Usuario_Metodos_Pago Busqueda(String sSql) {
            var oEGeneral = new General();
            SqlDataReader drUsuario_Metodo_Pago;
            Entidades.Usuario_Metodo_Pago oUsuario_Metodo_Pago = new Entidades.Usuario_Metodo_Pago();
            Entidades.Usuario_Metodos_Pago oUsuario_Metodos_Pago = new Entidades.Usuario_Metodos_Pago();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Ejecuta_SQL";
                    oComm.Parameters.AddWithValue("@sql", sSql);
                    oComm.CommandType = CommandType.StoredProcedure;
                    drUsuario_Metodo_Pago = oComm.ExecuteReader();
                    while (drUsuario_Metodo_Pago.Read()) {
                        oUsuario_Metodo_Pago = new Entidades.Usuario_Metodo_Pago();
                        LlenaEntidad(ref oUsuario_Metodo_Pago, drUsuario_Metodo_Pago);
                        oUsuario_Metodos_Pago.Add(oUsuario_Metodo_Pago);
                    }
                    return oUsuario_Metodos_Pago;
                }
            }
        }

        public Entidades.Usuario_Metodos_Pago GetAll() {
            var oEGeneral = new General();
            SqlDataReader drUsuario_Metodo_Pago;
            Entidades.Usuario_Metodo_Pago oUsuario_Metodo_Pago = new Entidades.Usuario_Metodo_Pago();
            Entidades.Usuario_Metodos_Pago oUsuario_Metodos_Pago = new Entidades.Usuario_Metodos_Pago();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Usuario_Metodos_Pago_SelectAll";
                    oComm.Parameters.AddWithValue("@UMP_pagina", 1);
                    oComm.Parameters.AddWithValue("@UMP_NoRegistros", 2000);
                    oComm.CommandType = CommandType.StoredProcedure;
                    drUsuario_Metodo_Pago = oComm.ExecuteReader();
                    while (drUsuario_Metodo_Pago.Read()) {
                        oUsuario_Metodo_Pago = new Entidades.Usuario_Metodo_Pago();
                        LlenaEntidad(ref oUsuario_Metodo_Pago, drUsuario_Metodo_Pago);
                        oUsuario_Metodos_Pago.Add(oUsuario_Metodo_Pago);
                    }
                    return oUsuario_Metodos_Pago;
                }
            }
        }

        public object CountPaginas(int nLogitud = 50) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Usuario_Metodos_Pago_SelectNoHojas";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@UMP_NoRegistros", nLogitud);
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

        private void LlenaEntidad(ref Entidades.Usuario_Metodo_Pago oUsuario_Metodo_Pago, SqlDataReader drUsuario_Metodo_Pago) {
            oUsuario_Metodo_Pago.Id = Convert.IsDBNull(drUsuario_Metodo_Pago["UMP_Id"]) ? 0 : Convert.ToInt32(drUsuario_Metodo_Pago["UMP_Id"]);
            oUsuario_Metodo_Pago.IdUsuario = Convert.IsDBNull(drUsuario_Metodo_Pago["UMP_IdUsuario"]) ? 0 : Convert.ToInt32(drUsuario_Metodo_Pago["UMP_IdUsuario"]);
            oUsuario_Metodo_Pago.IdMetodoPago = Convert.IsDBNull(drUsuario_Metodo_Pago["UMP_IdMetodoPago"]) ? 0 : Convert.ToInt32(drUsuario_Metodo_Pago["UMP_IdMetodoPago"]);
            oUsuario_Metodo_Pago.Clabe = Convert.IsDBNull(drUsuario_Metodo_Pago["UMP_Clabe"]) ? "" : Convert.ToString(drUsuario_Metodo_Pago["UMP_Clabe"]).Trim();
            oUsuario_Metodo_Pago.Referencia = Convert.IsDBNull(drUsuario_Metodo_Pago["UMP_Referencia"]) ? "" : Convert.ToString(drUsuario_Metodo_Pago["UMP_Referencia"]).Trim();
            oUsuario_Metodo_Pago.Numero = Convert.IsDBNull(drUsuario_Metodo_Pago["UMP_Numero"]) ? "" : Convert.ToString(drUsuario_Metodo_Pago["UMP_Numero"]).Trim();
            oUsuario_Metodo_Pago.Banco = Convert.IsDBNull(drUsuario_Metodo_Pago["UMP_Banco"]) ? "" : Convert.ToString(drUsuario_Metodo_Pago["UMP_Banco"]).Trim();
            oUsuario_Metodo_Pago.Estatus = Convert.IsDBNull(drUsuario_Metodo_Pago["UMP_Estatus"]) ? false : Convert.ToBoolean(drUsuario_Metodo_Pago["UMP_Estatus"]);
        }
    }
}