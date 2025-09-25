using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCooperativa
{
    public class SocioDAL
    {
        public static int AgregarSocio(Socio Socio)
        {
            int retorna = 0;
            using (SqlConnection conexion = BDGeneral.ObtenerConexion())
            {
                string query = " insert into Socio (Nombre_Completo, Telefono, Email, Fecha_Nacimiento, IdUsuario) values ('" + Socio.Nombre_Completo + "' , '" + Socio.Telefono + "','" + Socio.Email + "' , '" + Socio.Fecha_Nacimiento + "', '"+Socio.IdUsuario+"')";
                SqlCommand comando = new SqlCommand(query, conexion);

                retorna = comando.ExecuteNonQuery();
            }
            return retorna;
        }
        public static List<Socio> PresentarSocio()
        {
            List<Socio> Lista = new List<Socio>();
            using (SqlConnection conexion = BDGeneral.ObtenerConexion())
            {
                String query = "select * from Socio";
                SqlCommand comando = new SqlCommand(query, conexion);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    Socio Socio = new Socio();
                    Socio.IdSocio = reader.GetInt32(0);
                    Socio.Nombre_Completo = reader.GetString(1);
                    Socio.Telefono = reader.GetString(2);
                    Socio.Email = reader.GetString(3);
                    Socio.Fecha_Nacimiento = reader.GetDateTime(4);
                    Socio.IdUsuario = reader.GetInt32(5);


                    Lista.Add(Socio);
                }
                conexion.Close();
                return Lista;
            }
        } 
        public static int EliminarSocio(int IdSocio)
        {
            int retorna = 0;
            using (SqlConnection conexion = BDGeneral.ObtenerConexion())
            {
                string query = "Delete from Socio where IdSocio= " + IdSocio + "";
                SqlCommand comando = new SqlCommand(query, conexion);

                retorna = comando.ExecuteNonQuery();
            }
            return retorna;
        }

    }
}
