using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;
using Npgsql;
using System.Data;

using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;

namespace Proyecto1.Services
{
    public class SucursalesService
    {
        public List<Sucursal> GetAllSucursales()
        {
            List<Sucursal> ans = new List<Sucursal>();
            try
            {
                NpgsqlConnection conn;
                NpgsqlCommand command;
                NpgsqlDataReader read;

                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

                command = new NpgsqlCommand("select * from getsucursales()", conn);
                command.CommandType = CommandType.Text;

                read = command.ExecuteReader();

                while (read.Read())
                {
                    Sucursal sucursal = new Sucursal();
                    sucursal.Nombre = Convert.ToString(read["snombre"]);
                    sucursal.Provincia= Convert.ToString(read["sprovincia"]);
                    sucursal.Canton= Convert.ToString(read["scanton"]);
                    sucursal.Distrito= Convert.ToString(read["sdistrito"]);
                    sucursal.Direccion=Convert.ToString(read["sdireccion"]);
                    ans.Add(sucursal);
                }
                read.Close();
                conn.Close();
                return ans;
            }
            catch
            {
                return ans;
            }
        }

        public string GetReporte()
        {
            CrystalReport1 objRpt;
            ReportDocument rd = new ReportDocument();
            objRpt = new CrystalReport1();
            NpgsqlConnection conn;
            NpgsqlCommand command;
            Reportes ds = new Reportes();
            conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
            command = new NpgsqlCommand("select * from cantones", conn);

            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(command);
            adapter.Fill(ds, "Cantones");
           // rd.Load(Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath("~/Reports"), "UserRegistration.rpt"));
            objRpt.SetDataSource(ds);
            rd.SetDataSource(ds);

            return "";
        }
    }
}