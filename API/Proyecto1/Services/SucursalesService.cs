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
        public Boolean UpdateSucursal(int id, string nombre, int admin)
        {
            try
            {
                NpgsqlConnection conn;
                NpgsqlCommand command;
                NpgsqlDataReader read;

                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

                command = new NpgsqlCommand("update sucursales set nombre=:pNombre, administrador=:pAdmin where idsucursal=:pId", conn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("pId", id);
                command.Parameters.AddWithValue("pNombre", nombre);
                command.Parameters.AddWithValue("pAdmin", admin);

                read = command.ExecuteReader();
                read.Close();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
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
                    sucursal.Provincia = Convert.ToString(read["sprovincia"]);
                    sucursal.Canton = Convert.ToString(read["scanton"]);
                    sucursal.Distrito = Convert.ToString(read["sdistrito"]);
                    sucursal.Direccion = Convert.ToString(read["sdireccion"]);
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

        public Boolean CrearSucursal([FromBody] Sucursal sucursal)
        {
            Boolean ans = false;
            try
            {
                NpgsqlConnection conn;
                NpgsqlCommand command;


                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

                NpgsqlParameter Nombre = new NpgsqlParameter("pNombre", NpgsqlTypes.NpgsqlDbType.Varchar);
                Nombre.Value = sucursal.Nombre;

                NpgsqlParameter Distrito = new NpgsqlParameter("pDistrito", NpgsqlTypes.NpgsqlDbType.Varchar);
                Distrito.Value = sucursal.Distrito;

                NpgsqlParameter Direccion = new NpgsqlParameter("pDireccion", NpgsqlTypes.NpgsqlDbType.Varchar);
                Direccion.Value = sucursal.Direccion;

                NpgsqlParameter Compania = new NpgsqlParameter("pCompania", NpgsqlTypes.NpgsqlDbType.Varchar);
                Compania.Value = sucursal.Compania;


                NpgsqlParameter Administrador = new NpgsqlParameter("pAdministrador", NpgsqlTypes.NpgsqlDbType.Integer);
                Administrador.Value = sucursal.Administrador;


                command = new NpgsqlCommand("select * from createsucursal(:pNombre ,:pDistrito ,:pDireccion ,:pCompania,:pAdministrador)", conn);
                command.CommandType = CommandType.Text;

                command.Parameters.Add(Nombre);
                command.Parameters.Add(Distrito);
                command.Parameters.Add(Direccion);
                command.Parameters.Add(Compania);
                command.Parameters.Add(Administrador);

                var a = command.ExecuteScalar();
                ans = Convert.ToBoolean(a);

                conn.Close();
                return ans;

            }
            catch
            {

                return ans;
            }
        }

        public Boolean DeleteSucursal(int id)
        {
            NpgsqlConnection conn;
            NpgsqlCommand command;
            NpgsqlDataReader read;
            Boolean ans = false;
            try
            {
                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

                command = new NpgsqlCommand("select * from deletesucursal(:pId)", conn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("pId", id);
                read = command.ExecuteReader();

                while (read.Read())
                {
                    ans = Convert.ToBoolean(read["deletesucursal"]);
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