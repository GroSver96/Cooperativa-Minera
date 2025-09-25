using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCooperativa
{ 




}
/*   public class usuario
    {
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }

        public usuario() { }


        public usuario(int IdUsuario, string Usuario, string Contraseña, string Rol)
        {
            this.IdUsuario = IdUsuario;
            this.Usuario = Usuario;
            this.Contraseña = Contraseña;
            this.Rol = Rol;

        }
  }*/






      /*  public static Autenticacion ValidarUsuario (string usuario, string contraseña)
        {

            int retorna = 0;
            using (SqlConnection conexion = BDGeneral.ObtenerConexion())
            {
                conexion.Open();
                string query = "select Usuario, Contraseña, Rol from InicioSesion where Usuario=@Username and Contraseña=@Password";
                SqlCommand cmd = conexion.CreateCommand ();
                {
                    cmd.Parameters.AddWithValue("Username", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("Password", txtContraseña.Text);


                }



            }




        }*/

