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
    [RoutePrefix("api/Direccion")]
    public class DireccionController : ApiController
    {
        [HttpGet]
        [Route("GetAllProvincias")]
        public IHttpActionResult GetAllProvincias()
        {
            ProvinciaService con = new ProvinciaService();
            return Ok(con.GetAllProvincias());
        }
        
        [HttpGet]
        [Route("GetDistritosxCanton")]
        public IHttpActionResult GetDistritosxCantones(string id)
        {
            ProvinciaService con = new ProvinciaService();
            return Ok(con.GetDistritosxCantones(id));
        }

        [HttpGet]
        [Route("GetCantonesxProvincia")]
        public IHttpActionResult GetCantonesxProvincia(string id)
        {
            ProvinciaService con = new ProvinciaService();
            return Ok(con.GetCantonesxProvincia(id));
        }

        [HttpGet]
        [Route("GetDirPersona")]
        public IHttpActionResult GetDirPersona(int id)
        {
            ProvinciaService con = new ProvinciaService();
            return Ok(con.GetDirPersona(id));
        }
    }
}
