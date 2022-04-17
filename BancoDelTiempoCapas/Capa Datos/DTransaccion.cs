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

        // Añadir transaccion
        public void addTransaccion(Transaccion transaccion)
        {
    

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                db.Transacciones.Add(transaccion);
                db.SaveChanges();
            }
        }

        // Eliminar transaccion
        public void deleteTransaccion(int id)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                Transaccion transaccion = db.Transacciones.Find(id); // Si buscamos la transaccion por su id
               
                db.Transacciones.Remove(transaccion);
                db.SaveChanges();

            }
        }

        // Actualizar transaccion
        public void updateTransaccion(Transaccion transaccion)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {

                db.Entry(transaccion).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        // Mostrar una transaccion
        public Transaccion getTransaccion(int id)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                Transaccion transaccion = db.Transacciones.Find(id);
                return transaccion;
            }
        }


        // Mostrar toas las transacciones
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


        // Comprobar si existe transaccion en la BD con un username dado
        public Boolean checkTransaccion(int id)
        {
            bool existe = false;

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Transacciones;
                foreach (var transaccion in lst)
                {
                    if (transaccion.idTransaccion == id)
                    {
                        existe = true;
                    }
                }
            }
            return existe;
        }


    }
}
