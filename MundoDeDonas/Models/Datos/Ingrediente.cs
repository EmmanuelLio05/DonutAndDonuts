using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MundoDeDonas.Models.Datos {
    public class Ingrediente {
        public Object Add(MundoDeDonas.Models.Entidades.Ingrediente oIngrediente) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Ingrediente_Insert";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@I_Nombre", oIngrediente.Nombre);
                    oComm.Parameters.AddWithValue("@I_Tipo", oIngrediente.Tipo);
                    oComm.Parameters.AddWithValue("@I_Disponible", oIngrediente.Disponible);
                    return Convert.ToInt32(oComm.ExecuteScalar());
                }
            }
        }

        public Object Update(MundoDeDonas.Models.Entidades.Ingrediente oIngrediente) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Ingrediente_Update";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@I_Id", oIngrediente.Id);
                    oComm.Parameters.AddWithValue("@I_Nombre", oIngrediente.Nombre);
                    oComm.Parameters.AddWithValue("@I_Tipo", oIngrediente.Tipo);
                    oComm.Parameters.AddWithValue("@I_Disponible", oIngrediente.Disponible);
                    return oComm.ExecuteScalar();
                }
            }
        }

        public void Delete(Int32 I_Id) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Ingredientes_Delete";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@I_Id", I_Id);
                    oComm.ExecuteScalar();
                }
            }
        }

        public bool Verificar(Int32 I_Id) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Ingredientes_SelectOne";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@I_Id", I_Id);
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
                    oComm.CommandText = "Ingredientes_SelectMaxId";
                    oComm.CommandType = CommandType.StoredProcedure;
                    return oComm.ExecuteScalar();
                }
            }
        }

        public Entidades.Ingrediente GetOne(Int32 I_Id) {
            var oEGeneral = new General();
            SqlDataReader drIngrediente;
            Entidades.Ingrediente oIngrediente = new Entidades.Ingrediente();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Ingredientes_SelectOne";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@I_Id", I_Id);
                    drIngrediente = oComm.ExecuteReader();
                    if (drIngrediente.Read()) {
                        LlenaEntidad(ref oIngrediente, drIngrediente);
                        return oIngrediente;
                    } else return null;
                }
            }
        }

        public Entidades.Ingredientes GetAll(int nHoja, int nNoRegistros = 50) {
            var oEGeneral = new General();
            SqlDataReader drIngrediente;
            Entidades.Ingrediente oIngrediente = new Entidades.Ingrediente();
            Entidades.Ingredientes oIngredientes = new Entidades.Ingredientes();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Ingredientes_SelectAll";
                    oComm.Parameters.AddWithValue("@I_pagina", nHoja);
                    oComm.Parameters.AddWithValue("@I_NoRegistros", nNoRegistros);
                    oComm.CommandType = CommandType.StoredProcedure;
                    drIngrediente = oComm.ExecuteReader();
                    while (drIngrediente.Read()) {
                        oIngrediente = new Entidades.Ingrediente();
                        LlenaEntidad(ref oIngrediente, drIngrediente);
                        oIngredientes.Add(oIngrediente);
                    }
                    return oIngredientes;
                }
            }
        }

        public Entidades.Ingredientes Busqueda(String sSql) {
            var oEGeneral = new General();
            SqlDataReader drIngrediente;
            Entidades.Ingrediente oIngrediente = new Entidades.Ingrediente();
            Entidades.Ingredientes oIngredientes = new Entidades.Ingredientes();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Ejecuta_SQL";
                    oComm.Parameters.AddWithValue("@sql", sSql);
                    oComm.CommandType = CommandType.StoredProcedure;
                    drIngrediente = oComm.ExecuteReader();
                    while (drIngrediente.Read()) {
                        oIngrediente = new Entidades.Ingrediente();
                        LlenaEntidad(ref oIngrediente, drIngrediente);
                        oIngredientes.Add(oIngrediente);
                    }
                    return oIngredientes;
                }
            }
        }

        public Entidades.Ingredientes GetAll() {
            var oEGeneral = new General();
            SqlDataReader drIngrediente;
            Entidades.Ingrediente oIngrediente = new Entidades.Ingrediente();
            Entidades.Ingredientes oIngredientes = new Entidades.Ingredientes();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Ingredientes_SelectAll";
                    oComm.Parameters.AddWithValue("@I_pagina", 1);
                    oComm.Parameters.AddWithValue("@I_NoRegistros", 2000);
                    oComm.CommandType = CommandType.StoredProcedure;
                    drIngrediente = oComm.ExecuteReader();
                    while (drIngrediente.Read()) {
                        oIngrediente = new Entidades.Ingrediente();
                        LlenaEntidad(ref oIngrediente, drIngrediente);
                        oIngredientes.Add(oIngrediente);
                    }
                    return oIngredientes;
                }
            }
        }

        public object CountPaginas(int nLogitud = 50) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Ingredientes_SelectNoHojas";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@I_NoRegistros", nLogitud);
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

        private void LlenaEntidad(ref Entidades.Ingrediente oIngrediente, SqlDataReader drIngrediente) {
            oIngrediente.Id = Convert.IsDBNull(drIngrediente["I_Id"]) ? 0 : Convert.ToInt32(drIngrediente["I_Id"]);
            oIngrediente.Nombre = Convert.IsDBNull(drIngrediente["I_Nombre"]) ? "" : Convert.ToString(drIngrediente["I_Nombre"]).Trim();
            oIngrediente.Tipo = Convert.IsDBNull(drIngrediente["I_Tipo"]) ? "" : Convert.ToString(drIngrediente["I_Tipo"]).Trim();
            oIngrediente.Disponible = Convert.IsDBNull(drIngrediente["I_Disponible"]) ? false : Convert.ToBoolean(drIngrediente["I_Disponible"]);
        }
    }
}