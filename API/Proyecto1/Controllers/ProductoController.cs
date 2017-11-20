using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Proyecto1.Classes;
using Proyecto1.Services;

namespace Proyecto1.Controllers
{
    [RoutePrefix("api/Productos")]
    public class ProductoController : ApiController
    {

        [HttpGet]
        [Route("AgregarProducto")]
        public IHttpActionResult AgregarProducto(int idfactura, int ean, int cantidad)
        {
            ProductoService con = new ProductoService();
            return Ok(con.AgregarProducto(idfactura,ean,cantidad));
        }

        [HttpGet]
        [Route("BorrarProducto")]
        public IHttpActionResult BorrarProducto(int idfactura, int ean, int cantidad)
        {
            ProductoService con = new ProductoService();
            return Ok(con.BorrarProducto(idfactura, ean, cantidad));
        }

        [HttpGet]
        [Route("MasVendidosCajero")]
        public IHttpActionResult MasVendidosCajero(string compania)
        {
            ProductoService con = new ProductoService();
            return Ok(con.MasVendidosCajero(compania));
        }

        [HttpGet]
        [Route("MasVendidosSucursal")]
        public IHttpActionResult MasVendidosSucursal(string sucursal)
        {
            ProductoService con = new ProductoService();
            return Ok(con.MasVendidosCajero(sucursal));
        }




    }
}
