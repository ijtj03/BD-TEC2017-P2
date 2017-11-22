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
        [Route("SucursalCajero")]
        public IHttpActionResult SucursalCajero(int id)
        {
            PersonaService con = new PersonaService();
            return Ok(con.sucursalcajero(id));
        }
        [HttpGet]
        [Route("DeleteClient")]
        public Boolean DeleteClient(int id)
        {
            PersonaService con = new PersonaService();
            return con.DeleteClient(id);
        }
        [HttpGet]
        [Route("DeleteEmpleado")]
        public Boolean DeleteEmpleado(int id)
        {
            PersonaService con = new PersonaService();
            return con.DeleteEmpleado(id);
        }
        [HttpGet]
        [Route("ValidCajero")]
        public IHttpActionResult ValidCajero(int id, string contrasena,int money)
        {
            PersonaService con = new PersonaService();
            return Ok(con.ValidCajero(id, contrasena, money));
        }
        [HttpGet]
        [Route("ValidSupervisor")]
        public IHttpActionResult ValidSupervisor(int id,string contrasena)
        {
            PersonaService con = new PersonaService();
            return Ok(con.validSupervisor(id, contrasena));
        }
        [HttpPost]
        [Route("CrearCliente")]
        public Boolean CrearCliente([FromBody] Persona persona )
        {
            PersonaService con = new PersonaService();
            return con.CrearCliente(persona);
        }

        [HttpPost]
        [Route("CrearEmpleado")]
        public Boolean CrearEmpleado([FromBody] Persona empleado)
        {
            PersonaService con = new PersonaService();
            return con.CrearEmpleado(empleado);
        }
        [HttpGet]
        [Route("UpdateProveedor")]
        public Boolean UpdateProveedor(int id, string nombre,string des)
        {
            PersonaService con = new PersonaService();
            return con.UpdateProveedor( id,  nombre,  des);
        }
        [HttpPost]
        [Route("CrearProveedor")]
        public Boolean CrearProveedor([FromBody] Proveedor proveedor)
        {
            PersonaService con = new PersonaService();
            return con.CrearProveedor(proveedor);
        }


        [HttpGet]
        [Route("VerificarCliente")]
        public IHttpActionResult VerificarCliente(int id)
        {
            PersonaService con = new PersonaService();
            return Ok(con.VerificarCliente(id));
        }
        [HttpGet]
        [Route("DeleteProveedor")]
        public Boolean DeleteProveedor(int id)
        {
            PersonaService con = new PersonaService();
            return con.DeleteProveedor(id);
        }
    }
}
