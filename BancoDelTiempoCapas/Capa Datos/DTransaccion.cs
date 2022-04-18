using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CapaDatos
{
    public class DTransaccion
    {

        // Añadir transacción
        public void addTransaccion(Transaccion transaccion)
        {
    

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                db.Transacciones.Add(transaccion);
                db.SaveChanges();
            }
        }

        // Eliminar transacción
        public void deleteTransaccion(int id)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                Transaccion transaccion = db.Transacciones.Find(id); // Si buscamos la transaccion por su id
               
                db.Transacciones.Remove(transaccion);
                db.SaveChanges();

            }
        }

        // Actualizar transacción
        public void updateTransaccion(Transaccion transaccion)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {

                db.Entry(transaccion).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        // Mostrar una transacción
        public Transaccion getTransaccion(int id)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                Transaccion transaccion = db.Transacciones.Find(id);
                return transaccion;
            }
        }


        // Mostrar todas las transacciones
        public ArrayList listTransacciones()
        {
            ArrayList list = new ArrayList();

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Transacciones;
                foreach (var transaccion in lst)
                {
                    //Console.WriteLine(transaccion.ToString());
                    list.Add(transaccion);
                }
            }

            return list;
        }


        // Mostrar todas las transacciones de un usuario
        public ArrayList listTransaccionesPorUsuario(int idUsuario)
        {
            ArrayList list = new ArrayList();

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Transacciones;
                foreach (var transaccion in lst)
                {
                    if (transaccion.idUsuarioSolicita == idUsuario)
                    {
                        //Console.WriteLine(transaccion.ToString());
                        list.Add(transaccion);
                    }
                    
                }
            }

            return list;
        }

        // Mostrar todas las transacciones de un usuario por fecha de solicitud
        public ArrayList listTransaccionesPorFecha(int idUsuario, DateTime fechaSolicitud)
        {
            ArrayList list = new ArrayList();

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Transacciones;
                foreach (var transaccion in lst)
                {
                    if (transaccion.idUsuarioSolicita == idUsuario)
                    {
                        if (transaccion.fechaSolicitud == fechaSolicitud)
                        {
                            //Console.WriteLine(transaccion.ToString());
                            list.Add(transaccion);
                        }
                        
                    }

                }
            }

            return list;
        }


        // Mostrar todas las transacciones de un usuario realizadas a un mismo usuarioProporciona
        public ArrayList listTransaccionesPorUsuarioProporciona(int idUsuario, int idUsuarioProporciona)
        {
            ArrayList list = new ArrayList();

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Transacciones;
                foreach (var transaccion in lst)
                {
                    if (transaccion.idUsuarioSolicita == idUsuario)
                    {
                        if (transaccion.idUsuarioProporciona == idUsuarioProporciona)
                        {
                            //Console.WriteLine(transaccion.ToString());
                            list.Add(transaccion);
                        }

                    }

                }
            }

            return list;
        }

    }
}
