using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCooperativa
{
    public class Socio
    {
        public int IdSocio { get; set; }

        public string Nombre_Completo { get; set; }
        public string Telefono {  get; set; }
        public string Email { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public int IdUsuario { get; set; }

        public Socio() { }

        public Socio (int IdSocio, string Nombre_Completo, string Telefono, string Email, DateTime Fecha_Nacimiento , int IdUsuario)
        {   
            this.IdSocio = IdSocio;
            this.Nombre_Completo = Nombre_Completo;
            this.Telefono = Telefono;
            this.Email = Email;
            this.Fecha_Nacimiento = Fecha_Nacimiento;  
            this.IdUsuario = IdUsuario;
        }
    }
}
