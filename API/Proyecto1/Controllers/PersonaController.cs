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
    [RoutePrefix("api/Personas")]
    public class PersonaController : ApiController
    {
        [HttpGet]
        [Route("ValidCajero")]
        public IHttpActionResult ValidCajero(int id, string contrasena,int money)
        {
            PersonaService con = new PersonaService();
            return Ok(con.ValidCajero(id, contrasena, money));
        }        
            
    }
}
