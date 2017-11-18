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
    public class PersonaService
    {        
        public Boolean ValidCajero(int id,string contrasena,int money)
        {
            Boolean ans = false;
            try
            {
                NpgsqlConnection conn;
                NpgsqlCommand command;
                NpgsqlDataReader read;

                conn = new NpgsqlConnection("Host=p2tec-bd.postgres.database.azure.com;Database=Proyecto2;Persist Security Info=True;Username=tecbdadmin@p2tec-bd;Password=2t0e1c7BD;Trust Server Certificate=True;SSL Mode=Require");
                conn.Open();

                command = new NpgsqlCommand("select * from validcajerologin(:pId, :pContrasena, :pMoney)", conn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("pId", id);
                command.Parameters.AddWithValue("pContrasena", contrasena);
                command.Parameters.AddWithValue("pMoney", money);

                read = command.ExecuteReader();

                while (read.Read())
                {
                    ans = Convert.ToBoolean(read["validcajerologin"]);
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
