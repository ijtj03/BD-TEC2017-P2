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
        [Route("UpdateProducto")]
        public Boolean UpdateProducto(int id, string nombre, string des)
        {
            ProductoService con = new ProductoService();
            return con.UpdateProducto(id, nombre, des);
        }

        [HttpGet]
        [Route("AgregarProducto")]
        public IHttpActionResult AgregarProducto(int idfactura, int idproducto, int cantidad)
        {
            ProductoService con = new ProductoService();
            return Ok(con.AgregarProducto(idfactura, idproducto, cantidad));
        }

        [HttpGet]
        [Route("ProductosxFactura")]
        public IHttpActionResult ProductosxFactura(int idfactura,string sucursal)
        {
            ProductoService con = new ProductoService();
            return Ok(con.ProductosxFactura(idfactura,sucursal));
        }

        [HttpGet]
        [Route("BorrarProducto")]
        public IHttpActionResult BorrarProducto(int idfactura, int idproducto)
        {
            ProductoService con = new ProductoService();
            return Ok(con.BorrarProducto(idfactura, idproducto));
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

        [HttpPost]
        [Route("CrearFactura")]
        public IHttpActionResult CrearFactura([FromBody]Factura factura)
        {
            ProductoService con = new ProductoService();
            return Ok(con.CrearFactura(factura));
        }


    }
}
