using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.Classes
{
    public class Producto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int EAN { get; set; }
        public Boolean LogicDelete { get; set; }
        public int Cantidad { get; set; }
    }
}