using System;
using Microsoft.Data.SqlClient;

namespace SistemaCooperativa
{
    public class BDGeneral
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection("Server=.;Database=CoopCostaRica;Integrated Security=true;TrustServerCertificate=true;");
            conexion.Open();
            return conexion;
        }
    }
}