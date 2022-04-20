using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;

namespace CapaDatos
{
    public class DTransaccion
    {

        // Añadir transacción
        public void addTransaccion(Transaccion transaccion)
        {
    
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                db.Transacciones.Add(transaccion);
                db.SaveChanges();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Entrada duplicada en la Base de Datos. Esa transaccion ya existe.\n\n" + ex.Message);
                return;
            }
}

        // Eliminar transacción
        public void deleteTransaccion(int id)
        {
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                Transaccion transaccion = db.Transacciones.Find(id); // Si buscamos la transaccion por su id
               
                db.Transacciones.Remove(transaccion);
                db.SaveChanges();

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Esa transaccion no existe.\n\n" + ex.Message);
                return;
            }
        }

        // Actualizar transacción
        public void updateTransaccion(Transaccion transaccion)
        {
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {

                db.Entry(transaccion).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("La transaccion no se ha actualizado.\n\n" + ex.Message);
                return;
            }
        }

        // Mostrar una transacción
        public Transaccion getTransaccion(int id)
        {
            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    Transaccion transaccion = db.Transacciones.Find(id);
                    return transaccion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("La transaccion no se ha encontrado.\n\n" + ex.Message);
                return null;
            }
        }


        // Mostrar todas las transacciones
        public ArrayList listTransacciones()
        {
            ArrayList list = new ArrayList();
            try
            {

                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    var lst = db.Transacciones;
                    foreach (var transaccion in lst)
                    {
                        //Console.WriteLine(transaccion.ToString());
                        list.Add(transaccion);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se han encontrado transacciones.\n\n" + ex.Message);
                return null;
            }

            return list;
        }


        // Mostrar todas las transacciones de un usuario
        public ArrayList listTransaccionesPorUsuario(int idUsuario)
        {
            ArrayList list = new ArrayList();

            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("La transaccion por usuario no existe.\n\n" + ex.Message);
                return null;
            }

            return list;
        }

        // Mostrar todas las transacciones de un usuario por fecha de solicitud
        public ArrayList listTransaccionesPorFecha(int idUsuario, DateTime fechaSolicitud)
        {
            ArrayList list = new ArrayList();
            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay transaccion en esa fecha.\n\n" + ex.Message);
                return null;
            }

            return list;
        }


        // Mostrar todas las transacciones de un usuario realizadas a un mismo usuarioProporciona
        public ArrayList listTransaccionesPorUsuarioProporciona(int idUsuario, int idUsuarioProporciona)
        {
            ArrayList list = new ArrayList();
            try { 
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
        }
            catch (Exception ex)
            {
                MessageBox.Show("No hay transacciones para mostrar.\n\n" + ex.Message);
                return null;
            }





            return list;
        }

    }
}
