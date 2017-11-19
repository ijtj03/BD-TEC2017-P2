﻿using System;
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
        public IHttpActionResult SucursalCajero(string nombre,string apellido1,string apellido2)
        {
            PersonaService con = new PersonaService();
            return Ok(con.sucursalcajero(nombre, apellido1, apellido2));
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
        public void CrearCliente([FromBody] Persona persona )
        {
            PersonaService con = new PersonaService();
            con.CrearCliente(persona);
        }
        [HttpPost]
        [Route("CrearEmpleado")]
        public Boolean CrearEmpleado([FromBody] Persona empleado)
        {
            PersonaService con = new PersonaService();
            return con.CrearEmpleado(empleado);
        }

        [HttpPost]
        [Route("CrearProveedor")]
        public Boolean CrearProveedor([FromBody] Proveedor proveedor)
        {
            PersonaService con = new PersonaService();
            return con.CrearProveedor(proveedor);
        }



    }
}
