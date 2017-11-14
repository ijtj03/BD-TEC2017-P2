using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Proyecto2DataAccess;

namespace Proyecto2.Controllers
{
    public class ProductosController : ApiController
    {
        public IEnumerable<productos> GetAllProductos()
        {
            using (Proyecto2Entities entities = new Proyecto2Entities())
            {
                entities.Configuration.LazyLoadingEnabled = false;
                return entities.productos.ToList();
            }
        }

        public productos GetProducto(int id)
        {
            using (Proyecto2Entities entities = new Proyecto2Entities())
            {
                entities.Configuration.LazyLoadingEnabled = false;
                return entities.productos.FirstOrDefault(e => e.idproducto == id);
            }
        }


    }
}
