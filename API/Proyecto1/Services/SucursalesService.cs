using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;
using Npgsql;
using System.Data;

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
    }
}