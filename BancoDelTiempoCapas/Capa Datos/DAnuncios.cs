using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

//ponemos las librerias necesarias
using System.Data;
using System.Data.SqlClient;

//enlazamos con CapaEntidades
using CapaEntidades;

namespace CapaDatos
{
    public class DAnuncios
    {
        //creamos un metodo tipo string para insertar anuncios
        //tiene 3 parametros. 1 Entidad. 2 referenciamos cadena de conexion. 3 refenciamos transaccion de sql
        public string PublicarAnuncios(EAnuncios anuncios, ref SqlConnection conexion, ref SqlTransaction transaccion)
        {
            //variable de tipo string para recibir respuesta
            string respuesta;

            try
            {
                //instanciamos command con nombre de procedimiento almacenado
                SqlCommand comando = new SqlCommand("spinsertar_anuncios", conexion)
                {
                    //tipo de comando procedimiento almacenado
                    CommandType = CommandType.StoredProcedure,
                    //enviamos la transaccion
                    Transaction = transaccion

                };

                //añadimos valores a los parametros para luego enviar
                comando.Parameters.AddWithValue("@idAnuncio", anuncios.idAnuncio);
                comando.Parameters.AddWithValue("@descripcion", anuncios.descripcion);
                comando.Parameters.AddWithValue("@fechaPublicacion", anuncios.fechaPublicacion);
                comando.Parameters.AddWithValue("@tipoServicio", anuncios.tipoServicio);
                comando.Parameters.AddWithValue("@localidad", anuncios.localidad);
                comando.Parameters.AddWithValue("@idUsuario", anuncios.idUsuario);
                comando.Parameters.AddWithValue("@idCategoria", anuncios.idCategoria);

                //ejecutamos comando en la variable respuesta
                respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo insertar el anuncio";
            }
            catch (Exception ex) {

                respuesta = ex.Message;
                
            }
            return respuesta;
        }
    }
}
