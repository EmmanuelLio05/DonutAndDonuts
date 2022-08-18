using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MundoDeDonas.Models.Datos {
    public class Usuario {
        public Object Add(Entidades.Usuario oUsuario) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Usuario_Insert";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@U_Nombre", oUsuario.Nombre);
                    oComm.Parameters.AddWithValue("@U_Apellido", oUsuario.Apellido);
                    oComm.Parameters.AddWithValue("@U_Email", oUsuario.Email);
                    oComm.Parameters.AddWithValue("@U_Contrasenia", oUsuario.Contrasenia);
                    oComm.Parameters.AddWithValue("@U_FechaRegistro", oUsuario.FechaRegistro);
                    return Convert.ToInt32(oComm.ExecuteScalar());
                }
            }
        }

        public Object Update(Entidades.Usuario oUsuario) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Usuario_Update";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@U_Id", oUsuario.Id);
                    oComm.Parameters.AddWithValue("@U_Nombre", oUsuario.Nombre);
                    oComm.Parameters.AddWithValue("@U_Apellido", oUsuario.Apellido);
                    oComm.Parameters.AddWithValue("@U_Email", oUsuario.Email);
                    oComm.Parameters.AddWithValue("@U_Contrasenia", oUsuario.Contrasenia);
                    oComm.Parameters.AddWithValue("@U_FechaRegistro", oUsuario.FechaRegistro);
                    return oComm.ExecuteScalar();
                }
            }
        }

        public Entidades.Usuario VerificaLogin(string sEmail, string sContrasenia) {
            var oEGeneral = new General();
            Entidades.Usuario oUsuario = new Entidades.Usuario();
            SqlDataReader drUsuario;

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Usuario_VerificaLogin";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@U_Email", sEmail);
                    oComm.Parameters.AddWithValue("@U_Contrasenia", sContrasenia);
                    drUsuario = oComm.ExecuteReader();
                    if (drUsuario.Read()) {
                        LlenaEntidad(ref oUsuario, drUsuario);
                        return oUsuario;
                    } else return null;
                }
            }
        }

        public bool VerificaEmail(string sEmail) {
            var oEGeneral = new General();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Usuario_VerificaEmail";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@U_Email", sEmail);
                    return oComm.ExecuteReader().HasRows;
                }
            }
        }

        public Entidades.Usuario GetOne(Int32 U_Id) {
            var oEGeneral = new General();
            SqlDataReader drUsuario;
            Entidades.Usuario oUsuario = new Entidades.Usuario();

            using (var oCon = oEGeneral.Conectar()) {
                oCon.Open();
                using (var oComm = new SqlCommand()) {
                    oComm.Connection = oCon;
                    oComm.CommandText = "Usuarios_SelectOne";
                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.Parameters.AddWithValue("@U_Id", U_Id);
                    drUsuario = oComm.ExecuteReader();
                    if (drUsuario.Read()) {
                        LlenaEntidad(ref oUsuario, drUsuario);
                        return oUsuario;
                    } else return null;
                }
            }
        }

        private void LlenaEntidad(ref Entidades.Usuario oUsuario, SqlDataReader drUsuario) {
            oUsuario.Id = Convert.IsDBNull(drUsuario["U_Id"]) ? 0 : Convert.ToInt32(drUsuario["U_Id"]);
            oUsuario.Nombre = Convert.IsDBNull(drUsuario["U_Nombre"]) ? "" : Convert.ToString(drUsuario["U_Nombre"]).Trim();
            oUsuario.Apellido = Convert.IsDBNull(drUsuario["U_Apellido"]) ? "" : Convert.ToString(drUsuario["U_Apellido"]).Trim();
            oUsuario.Email = Convert.IsDBNull(drUsuario["U_Email"]) ? "" : Convert.ToString(drUsuario["U_Email"]).Trim();
            oUsuario.Contrasenia = Convert.IsDBNull(drUsuario["U_Contrasenia"]) ? "" : Convert.ToString(drUsuario["U_Contrasenia"]).Trim();
            oUsuario.FechaRegistro = Convert.IsDBNull(drUsuario["U_FechaRegistro"]) ? new DateTime(1900, 01, 01) : Convert.ToDateTime(drUsuario["U_FechaRegistro"]);
        }
    }
}