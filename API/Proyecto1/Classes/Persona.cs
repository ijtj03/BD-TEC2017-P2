using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.Classes
{
    public class Persona
    {
        public int IdCedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int Telefono { get; set; }
        public string Contrasena { get; set; }
        public string Distrito { get; set; }
        public string Direccion { get; set; }
        public string FechaNacimiento { get; set; }
        public string Rol { get; set; }
        public string Sucursal { get; set; }
        public bool LogicDelete { get; set; }
    }
}