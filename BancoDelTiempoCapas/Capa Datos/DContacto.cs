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
        // Añadir mensaje
        public void addMensaje(Contacto contacto)
        {


            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                db.Contactos.Add(contacto);
                db.SaveChanges();
            }
        }

        // Eliminar mensaje
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

        // Mostrar un mensaje
        public Contacto getMensaje(int id)
        {
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                Contacto contacto = db.Contactos.Find(id);
                return contacto;
            }
        }

        // Mostrar todos los mensajes de la BD
        public ArrayList listMensajes()
        {
            ArrayList list = new ArrayList();

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Contactos;
                foreach (var mensaje in lst)
                {
                    //Console.WriteLine(contacto.ToString());
                    list.Add(mensaje);
                }
            }

            return list;
        }

        // Mostrar todos los mensajes de un usuario (where idEmisor = x)
        public ArrayList listMensajesPorEmisor(String idEmisor)
        {
            ArrayList list = new ArrayList();

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Contactos;
                foreach (var mensaje in lst)
                {
                    if (mensaje.idEmisor.Equals(idEmisor))
                    {
                        //Console.WriteLine(contacto.ToString());
                        list.Add(mensaje);
                    }

                }
            }

            return list;
        }

        // Mostrar todos los mensajes de un usuario con el mismo receptor
        public ArrayList listMensajesPorReceptor(String idEmisor, String idReceptor)
        {
            ArrayList list = new ArrayList();

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Contactos;
                foreach (var mensaje in lst)
                {
                    if (mensaje.idEmisor.Equals(idEmisor))
                    {
                        if (mensaje.idReceptor.Equals(idReceptor))
                        {
                            //Console.WriteLine(contacto.ToString());
                            list.Add(mensaje);
                        }
                    }
                }
            }

            return list;
        }

        // Mostrar todos los mensajes de un usuario que contengan una palabra concreta en el mensaje
        public ArrayList listMensajesPorPalabra(String idEmisor, String palabraBuscada)
        {
            ArrayList list = new ArrayList();

            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Contactos;
                foreach (var mensaje in lst)
                {
                    if (mensaje.idEmisor.Equals(idEmisor))
                    {
                        if (mensaje.mensaje.StartsWith(palabraBuscada, System.StringComparison.CurrentCultureIgnoreCase))
                        {
                            //Console.WriteLine(contacto.ToString());
                            list.Add(mensaje);
                        }
                    }
                }
            }

            return list;
        }

        // TODO: Enviar mensaje

        // TODO: Responder mensaje

    }
}
