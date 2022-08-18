using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MundoDeDonas.Models.Datos {
    public class Pedido {
        public int Add(Entidades.Pedido oPedido) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Pedido_Insert";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@P_IdUsuario", oPedido.IdUsuario);
                    oComm.Parameters.AddWithValue("@P_MetodoPago", oPedido.MetodoPago);
                    oComm.Parameters.AddWithValue("@P_FechaPedido", oPedido.FechaPedido);
                    oComm.Parameters.AddWithValue("@P_FechaEntrega", oPedido.FechaEntrega);
                    oComm.Parameters.AddWithValue("@P_Estatus", oPedido.Estatus);
                    oComm.Parameters.AddWithValue("@P_EstatusPago", oPedido.EstatusPago);
                    oComm.Parameters.AddWithValue("@P_DireccionEntrega", oPedido.DireccionEntrega);
                    oComm.Parameters.AddWithValue("@P_Decenas", oPedido.Decenas);
                    return Convert.ToInt32(oComm.ExecuteScalar());
                }
            }
        }

        public Object Update(Entidades.Pedido oPedido) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Pedido_Update";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@P_Id", oPedido.Id);
                    oComm.Parameters.AddWithValue("@P_IdUsuario", oPedido.IdUsuario);
                    oComm.Parameters.AddWithValue("@P_MetodoPago", oPedido.MetodoPago);
                    oComm.Parameters.AddWithValue("@P_FechaPedido", oPedido.FechaPedido);
                    oComm.Parameters.AddWithValue("@P_FechaEntrega", oPedido.FechaEntrega);
                    oComm.Parameters.AddWithValue("@P_Estatus", oPedido.Estatus);
                    oComm.Parameters.AddWithValue("@P_EstatusPago", oPedido.EstatusPago);
                    oComm.Parameters.AddWithValue("@P_DireccionEntrega", oPedido.DireccionEntrega);
                    oComm.Parameters.AddWithValue("@P_Decenas", oPedido.Decenas);
                    return oComm.ExecuteScalar();
                }
            }
        }

        public void Delete(Int32 P_Id) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Pedidos_Delete";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@P_Id", P_Id);
                    oComm.ExecuteScalar();
                }
            }
        }

        public bool Verificar(Int32 P_Id) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Pedidos_SelectOne";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@P_Id", P_Id);
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
                    oComm.CommandText = "Pedidos_SelectMaxId";
                    oComm.CommandType = CommandType.StoredProcedure;
                    return oComm.ExecuteScalar();
                }
            }
        }

        public Entidades.Pedido GetOne(Int32 P_Id) {
            var oEGeneral = new General();
            SqlDataReader drPedido;
            Entidades.Pedido oPedido = new Entidades.Pedido();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Pedidos_SelectOne";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@P_Id", P_Id);
                    drPedido = oComm.ExecuteReader();
                    if (drPedido.Read()) {
                        LlenaEntidad(ref oPedido, drPedido);
                        return oPedido;
                    } else return null;
                }
            }
        }

        public Entidades.Pedidos GetAll(int nHoja, int nNoRegistros = 50) {
            var oEGeneral = new General();
            SqlDataReader drPedido;
            Entidades.Pedido oPedido = new Entidades.Pedido();
            Entidades.Pedidos oPedidos = new Entidades.Pedidos();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Pedidos_SelectAll";
                    oComm.Parameters.AddWithValue("@P_pagina", nHoja);
                    oComm.Parameters.AddWithValue("@P_NoRegistros", nNoRegistros);
                    oComm.CommandType = CommandType.StoredProcedure;
                    drPedido = oComm.ExecuteReader();
                    while (drPedido.Read()) {
                        oPedido = new Entidades.Pedido();
                        LlenaEntidad(ref oPedido, drPedido);
                        oPedidos.Add(oPedido);
                    }
                    return oPedidos;
                }
            }
        }

        public Entidades.Pedidos Busqueda(String sSql) {
            var oEGeneral = new General();
            SqlDataReader drPedido;
            Entidades.Pedido oPedido = new Entidades.Pedido();
            Entidades.Pedidos oPedidos = new Entidades.Pedidos();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Ejecuta_SQL";
                    oComm.Parameters.AddWithValue("@sql", sSql);
                    oComm.CommandType = CommandType.StoredProcedure;
                    drPedido = oComm.ExecuteReader();
                    while (drPedido.Read()) {
                        oPedido = new Entidades.Pedido();
                        LlenaEntidad(ref oPedido, drPedido);
                        oPedidos.Add(oPedido);
                    }
                    return oPedidos;
                }
            }
        }

        public Entidades.Pedidos GetAll() {
            var oEGeneral = new General();
            SqlDataReader drPedido;
            Entidades.Pedido oPedido = new Entidades.Pedido();
            Entidades.Pedidos oPedidos = new Entidades.Pedidos();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Pedidos_SelectAll";
                    oComm.Parameters.AddWithValue("@P_pagina", 1);
                    oComm.Parameters.AddWithValue("@P_NoRegistros", 2000);
                    oComm.CommandType = CommandType.StoredProcedure;
                    drPedido = oComm.ExecuteReader();
                    while (drPedido.Read()) {
                        oPedido = new Entidades.Pedido();
                        LlenaEntidad(ref oPedido, drPedido);
                        oPedidos.Add(oPedido);
                    }
                    return oPedidos;
                }
            }
        }

        public object CountPaginas(int nLogitud = 50) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Pedidos_SelectNoHojas";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@P_NoRegistros", nLogitud);
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

        private void LlenaEntidad(ref Entidades.Pedido oPedido, SqlDataReader drPedido) {
            oPedido.Id = Convert.IsDBNull(drPedido["P_Id"]) ? 0 : Convert.ToInt32(drPedido["P_Id"]);
            oPedido.IdUsuario = Convert.IsDBNull(drPedido["P_IdUsuario"]) ? 0 : Convert.ToInt32(drPedido["P_IdUsuario"]);
            oPedido.MetodoPago = Convert.IsDBNull(drPedido["P_MetodoPago"]) ? 0 : Convert.ToInt32(drPedido["P_MetodoPago"]);
            oPedido.FechaPedido = Convert.IsDBNull(drPedido["P_FechaPedido"]) ? new DateTime(1900, 01, 01) : Convert.ToDateTime(drPedido["P_FechaPedido"]);
            oPedido.FechaEntrega = Convert.IsDBNull(drPedido["P_FechaEntrega"]) ? new DateTime(1900, 01, 01) : Convert.ToDateTime(drPedido["P_FechaEntrega"]);
            oPedido.Estatus = Convert.IsDBNull(drPedido["P_Estatus"]) ? (short)0 : Convert.ToInt16(drPedido["P_Estatus"]);
            oPedido.EstatusPago = Convert.IsDBNull(drPedido["P_EstatusPago"]) ? (short)0 : Convert.ToInt16(drPedido["P_EstatusPago"]);
            oPedido.DireccionEntrega = Convert.IsDBNull(drPedido["P_DireccionEntrega"]) ? "" : Convert.ToString(drPedido["P_DireccionEntrega"]).Trim();
            oPedido.Decenas = Convert.IsDBNull(drPedido["P_Decenas"]) ? 0.0m : Convert.ToDecimal(drPedido["P_Decenas"]);
        }
    }
}