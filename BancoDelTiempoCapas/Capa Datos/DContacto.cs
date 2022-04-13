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
    public class DContacto
    {

        public void addMensaje(Contacto contacto)
        {


            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                db.Contactos.Add(contacto);
                db.SaveChanges();
            }
        }

        // Eliminar usuario
        public void deleteMensaje(int id)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                Contacto contacto = db.Contactos.Find(id); // Si buscamos el mensaje por su id

                db.Contactos.Remove(contacto);
                db.SaveChanges();

            }
        }

        // Actualizar mensaje
        public void updateMensaje(Contacto contacto)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {


                db.Entry(contacto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        // Mostrar un contacto
        public Contacto getMensaje(int id)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                Contacto contacto = db.Contactos.Find(id);
                return contacto;
            }
        }


        // Mostrar todos los contactos
        public ArrayList listContactos()
        {
            ArrayList list = new ArrayList();

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Contactos;
                foreach (var contacto in lst)
                {
                    //Console.WriteLine(contacto.ToString());
                    list.Add(contacto);
                }
            }

            return list;
        }


        // Comprobar si existe usuario en la BD con un mensaje dado
        public Boolean checkMensaje(int idMensaje)
        {
            bool existe = false;

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Contactos;
                foreach (var contacto in lst)
                {
                    if (contacto.idMensaje == idMensaje)
                    {
                        existe = true;
                    }
                }
            }
            return existe;
        }


      



    }
}
