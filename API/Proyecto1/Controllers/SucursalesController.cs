using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Proyecto1.Services;
using Proyecto1.Classes;

namespace Proyecto1.Controllers
{
    [RoutePrefix("api/Sucursales")]
    public class SucursalesController : ApiController
    {
        [HttpGet]
        [Route("GetAllSucursales")]
        public IHttpActionResult GetAllSucursales()
        {
            SucursalesService con = new SucursalesService();
            return Ok(con.GetAllSucursales());
        }

        [HttpPost]
        [Route("CrearSucursal")]
        public Boolean CrearSucursal([FromBody] Sucursal sucursal)
        {
            SucursalesService con = new SucursalesService();
            return con.CrearSucursal(sucursal);
        }
    }
}
