using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MundoDeDonas.Models.Datos {
    public class Pedido_Ingrediente {
        public Object Add(Entidades.Pedido_Ingrediente oPedido_Ingrediente) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Pedido_Ingrediente_Insert";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@PI_IdPedido", oPedido_Ingrediente.IdPedido);
                    oComm.Parameters.AddWithValue("@PI_Ingrediente", oPedido_Ingrediente.Ingrediente);
                    return oComm.ExecuteScalar();
                }
            }
        }


        public void DeleteOne(Int32 PI_IdPedido, Int32 PI_Ingrediente) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Pedido_Ingrediente_DeleteOne";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@PI_IdPedido", PI_IdPedido);
                    oComm.Parameters.AddWithValue("@PI_Ingrediente", PI_Ingrediente);
                    oComm.ExecuteScalar();
                }
            }
        }

        public void DeleteAll(Int32 PI_IdPedido) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Pedido_Ingrediente_DeleteAll";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@PI_IdPedido", PI_IdPedido);
                    oComm.ExecuteScalar();
                }
            }
        }

        public bool Verificar(Int32 PI_IdPedido, Int32 PI_Ingrediente) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Pedido_Ingredientes_SelectOne";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@PI_IdPedido", PI_IdPedido);
                    oComm.Parameters.AddWithValue("@PI_Ingrediente", PI_Ingrediente);
                    return oComm.ExecuteReader().HasRows;
                }
            }
        }

        public Entidades.Pedido_Ingrediente GetOne(Int32 PI_IdPedido, Int32 PI_Ingrediente) {
            var oEGeneral = new General();
            SqlDataReader drPedido_Ingrediente;
            Entidades.Pedido_Ingrediente oPedido_Ingrediente = new Entidades.Pedido_Ingrediente();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Pedido_Ingredientes_SelectOne";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@PI_IdPedido", PI_IdPedido);
                    oComm.Parameters.AddWithValue("@PI_Ingrediente", PI_Ingrediente);
                    drPedido_Ingrediente = oComm.ExecuteReader();
                    if (drPedido_Ingrediente.Read()) {
                        LlenaEntidad(ref oPedido_Ingrediente, drPedido_Ingrediente);
                        return oPedido_Ingrediente;
                    } else return null;
                }
            }
        }

        public Entidades.Pedido_Ingredientes GetAll(int nHoja, int nNoRegistros = 50) {
            var oEGeneral = new General();
            SqlDataReader drPedido_Ingrediente;
            Entidades.Pedido_Ingrediente oPedido_Ingrediente = new Entidades.Pedido_Ingrediente();
            Entidades.Pedido_Ingredientes oPedido_Ingredientes = new Entidades.Pedido_Ingredientes();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Pedido_Ingredientes_SelectAll";
                    oComm.Parameters.AddWithValue("@PI_pagina", nHoja);
                    oComm.Parameters.AddWithValue("@PI_NoRegistros", nNoRegistros);
                    oComm.CommandType = CommandType.StoredProcedure;
                    drPedido_Ingrediente = oComm.ExecuteReader();
                    while (drPedido_Ingrediente.Read()) {
                        oPedido_Ingrediente = new Entidades.Pedido_Ingrediente();
                        LlenaEntidad(ref oPedido_Ingrediente, drPedido_Ingrediente);
                        oPedido_Ingredientes.Add(oPedido_Ingrediente);
                    }
                    return oPedido_Ingredientes;
                }
            }
        }

        public Entidades.Pedido_Ingredientes Busqueda(String sSql) {
            var oEGeneral = new General();
            SqlDataReader drPedido_Ingrediente;
            Entidades.Pedido_Ingrediente oPedido_Ingrediente = new Entidades.Pedido_Ingrediente();
            Entidades.Pedido_Ingredientes oPedido_Ingredientes = new Entidades.Pedido_Ingredientes();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Ejecuta_SQL";
                    oComm.Parameters.AddWithValue("@sql", sSql);
                    oComm.CommandType = CommandType.StoredProcedure;
                    drPedido_Ingrediente = oComm.ExecuteReader();
                    while (drPedido_Ingrediente.Read()) {
                        oPedido_Ingrediente = new Entidades.Pedido_Ingrediente();
                        LlenaEntidad(ref oPedido_Ingrediente, drPedido_Ingrediente);
                        oPedido_Ingredientes.Add(oPedido_Ingrediente);
                    }
                    return oPedido_Ingredientes;
                }
            }
        }

        public Entidades.Pedido_Ingredientes GetAll() {
            var oEGeneral = new General();
            SqlDataReader drPedido_Ingrediente;
            Entidades.Pedido_Ingrediente oPedido_Ingrediente = new Entidades.Pedido_Ingrediente();
            Entidades.Pedido_Ingredientes oPedido_Ingredientes = new Entidades.Pedido_Ingredientes();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Pedido_Ingredientes_SelectAll";
                    oComm.Parameters.AddWithValue("@PI_pagina", 1);
                    oComm.Parameters.AddWithValue("@PI_NoRegistros", 2000);
                    oComm.CommandType = CommandType.StoredProcedure;
                    drPedido_Ingrediente = oComm.ExecuteReader();
                    while (drPedido_Ingrediente.Read()) {
                        oPedido_Ingrediente = new Entidades.Pedido_Ingrediente();
                        LlenaEntidad(ref oPedido_Ingrediente, drPedido_Ingrediente);
                        oPedido_Ingredientes.Add(oPedido_Ingrediente);
                    }
                    return oPedido_Ingredientes;
                }
            }
        }

        public object CountPaginas(int nLogitud = 50) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Pedido_Ingredientes_SelectNoHojas";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@PI_NoRegistros", nLogitud);
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

        private void LlenaEntidad(ref Entidades.Pedido_Ingrediente oPedido_Ingrediente, SqlDataReader drPedido_Ingrediente) {
            oPedido_Ingrediente.IdPedido = Convert.IsDBNull(drPedido_Ingrediente["PI_IdPedido"]) ? 0 : Convert.ToInt32(drPedido_Ingrediente["PI_IdPedido"]);
            oPedido_Ingrediente.Ingrediente = Convert.IsDBNull(drPedido_Ingrediente["PI_Ingrediente"]) ? 0 : Convert.ToInt32(drPedido_Ingrediente["PI_Ingrediente"]);
        }
    }
}