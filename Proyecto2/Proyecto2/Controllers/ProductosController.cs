using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Proyecto2DataAccess;
using Npgsql;

namespace Proyecto2.Controllers
{
    public class ProductosController : ApiController
    {
        public IEnumerable<productos> GetAllProductos()
        {
            using (Proyecto2Entities entities = new Proyecto2Entities())
            {
                entities.Configuration.LazyLoadingEnabled = false;
                return entities.productos.ToList();
            }
        }

        public productos GetProducto(int id)
        {
            using (Proyecto2Entities entities = new Proyecto2Entities())
            {
                entities.Configuration.LazyLoadingEnabled = false;
                return entities.productos.FirstOrDefault(e => e.idproducto == id);
            }
        }
        public string Prueba() {
            String message = "";
            try
            {
                {
                    
                    Proyecto2Entities entities = new Proyecto2Entities();
                    NpgsqlConnection conn = new NpgsqlConnection(entities.Database.Connection.ConnectionString);
                    conn.Open();
                    using (NpgsqlCommand com = new NpgsqlCommand("BEGIN; SELECT * FROM getalldistritos(); COMMIT;", conn))
                    //using (NpgsqlCommand com = new NpgsqlCommand("BEGIN; SELECT * FROM regventa(:P0, :P1, :P2, :P3, :P4, :P5); COMMIT;", conn))
                    {
                        /* com.Parameters.Add(new NpgsqlParameter("P0", NpgsqlDbType.Integer));
                         com.Parameters.Add(new NpgsqlParameter("P1", NpgsqlDbType.Integer));
                         com.Parameters.Add(new NpgsqlParameter("P2", NpgsqlDbType.Text));
                         com.Parameters.Add(new NpgsqlParameter("P3", NpgsqlDbType.Integer));
                         com.Parameters.Add(new NpgsqlParameter("P4", NpgsqlDbType.Integer));
                         com.Parameters.Add(new NpgsqlParameter("P5", NpgsqlDbType.Timestamp));
                         com.Prepare();
                         com.Parameters[0].Value = venta.idCliente;
                         com.Parameters[1].Value = venta.idEmpleado;
                         com.Parameters[2].Value = venta.productos.ToString();
                         com.Parameters[3].Value = venta.idSucursal;
                         com.Parameters[4].Value = venta.tipoPago;
                         com.Parameters[5].Value = venta.fecha;*/
                        using (NpgsqlDataReader dr = com.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                message = dr.GetString(0);
                            }
                        }

                    };
                    conn.Close();
                    return message;
                }
            }
            catch (Exception ex)
            {
                return message;
            }
        }


    }
}
