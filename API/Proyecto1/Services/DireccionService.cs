using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Proyecto1.Classes;
using System.Web.Http;
using Npgsql;
using System.Data;

namespace Proyecto1.Services
{
    public class ProvinciaService
    {
        
        public List<string> GetCantonesxProvincia(string id)
        {
            List<string> ans = new List<string>();
            try
            {
                NpgsqlConnection conn;
                NpgsqlCommand command;
                NpgsqlDataReader read;

                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

                command = new NpgsqlCommand("select * from getcantonesprovincia(:pId)", conn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("pId", id);

                read = command.ExecuteReader();

                while (read.Read())
                {
                    ans.Add(Convert.ToString(read["canton_nombre"]));
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
        public List<Direccion> GetDirPersona(int id)
        {
            List<Direccion> ans = new List<Direccion>();
            try
            {
                NpgsqlConnection conn;
                NpgsqlCommand command;
                NpgsqlDataReader read;

                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

                command = new NpgsqlCommand("select * from getdiruser(:pId)", conn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("pId", id);

                read = command.ExecuteReader();

                while (read.Read())
                {
                    Direccion d = new Direccion();
                    d.Provincia = Convert.ToString(read["provincia"]);
                    d.Canton = Convert.ToString(read["canton"]);
                    d.Distrito = Convert.ToString(read["distrito"]);
                    d.OtrasSenas = Convert.ToString(read["direccion"]);
                    ans.Add(d);
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
        public List<string> GetDistritosxCantones(string id)
        {
            List<string> ans = new List<string>();
            try
            {
                NpgsqlConnection conn;
                NpgsqlCommand command;
                NpgsqlDataReader read;

                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

                command = new NpgsqlCommand("select * from getdistritoscanton(:pId)", conn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("pId", id);

                read = command.ExecuteReader();

                while (read.Read())
                {
                    ans.Add(Convert.ToString(read["distrito_nombre"]));
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
        public List<string> GetAllProvincias()
        {
            List<string> ans = new List<string>();
            try
            {
                NpgsqlConnection conn;
                NpgsqlCommand command;
                NpgsqlDataReader read;

                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

                command = new NpgsqlCommand("select nombre from provincias", conn);
                command.CommandType = CommandType.Text;

                read = command.ExecuteReader();

                while (read.Read())
                {
                    ans.Add(Convert.ToString(read["nombre"]));
                }
                read.Close();
                conn.Close();
                return ans;
            }
            catch {
                return ans;
            }
            
        }
        
    }
}
