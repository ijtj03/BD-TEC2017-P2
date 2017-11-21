using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Proyecto1.Services;

using Proyecto1.Classes;

using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using Npgsql;
using System.IO;
using System.Net.Mail;
using CrystalDecisions.Shared;


namespace Proyecto1.Controllers
{
    [RoutePrefix("api/Sucursales")]
    public class SucursalesController : ApiController
    {

        [HttpGet]
        [Route("UpdateSucursal")]
        public Boolean UpdateSucursal(int id, string nombre, int admin)
        {
            SucursalesService con = new SucursalesService();
            return con.UpdateSucursal(id, nombre, admin);
        }
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
        [AllowAnonymous]
        [HttpGet]
        [Route("Report/SendReport")]
        public HttpResponseMessage GetReporte()
        {
            ReportDocument rd = new ReportDocument();
            NpgsqlConnection conn;
            NpgsqlCommand command;
            Reportes ds = new Reportes();
            conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
            command = new NpgsqlCommand("select * from cantones", conn);

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
            adapter.Fill(ds, "Cantones");
            rd.Load("C:\\Users\\Jeison\\Documents\\Git\\BD-TEC2017-P2\\API\\Proyecto1\\CrystalReport1.rpt");
            rd.SetDataSource(ds);
            using (var stream = rd.ExportToStream(ExportFormatType.PortableDocFormat))
            {
                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("jey9608@hotmail.com", "naranja97");
                var message = new System.Net.Mail.MailMessage("jey9608@hotmail.com", "jey9608@hotmail.com", "User Registration Details", "Hi Please check your Mail  and find the attachement.");
                message.Attachments.Add(new Attachment(stream, "UsersRegistration.pdf"));

                smtp.Send(message);
            }

            var Message = string.Format("Report Created and sended to your Mail.");
            HttpResponseMessage response1 = Request.CreateResponse(HttpStatusCode.OK, Message);
            return response1;

        }
    }
}
