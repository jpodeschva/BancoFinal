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
    public class DContacto
    {
        // Añadir mensaje
        public void addMensaje(Contacto contacto)
        {

            try
            {
                using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
                {
                    db.Contactos.Add(contacto);
                    db.SaveChanges();
                }
            }
            catch (Exception ex){
                MessageBox.Show("No se ha podido añadir mensaje. \n\n" + ex.Message);
                return;
            }
        }

        // Eliminar mensaje
        public void deleteMensaje(int id)
        {
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                Contacto contacto = db.Contactos.Find(id); // Si buscamos el mensaje por su id

                db.Contactos.Remove(contacto);
                db.SaveChanges();

            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido eliminar el mensaje. \n\n" + ex.Message);
                return;
            }
        }

        // Actualizar mensaje
        public void updateMensaje(Contacto contacto)
        {
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {


                db.Entry(contacto).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido actualizar el mensaje. \n\n" + ex.Message);
                return;
            }
        }

        // Mostrar un mensaje
        public Contacto getMensaje(int id)
        {
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                Contacto contacto = db.Contactos.Find(id);
                return contacto;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido encontrar el mensaje. \n\n" + ex.Message);
                return null;
            }
        }

        // Mostrar todos los mensajes de la BD
        public ArrayList listMensajes()
        {
            ArrayList list = new ArrayList();
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Contactos;
                foreach (var mensaje in lst)
                {
                    //Console.WriteLine(contacto.ToString());
                    list.Add(mensaje);
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se han podido encontrar mensajes. \n\n" + ex.Message);
                return null;
            }
            return list;
        }

        // Mostrar todos los mensajes de un usuario (where idEmisor = x)
        public ArrayList listMensajesPorEmisor(int idEmisor)
        {
            ArrayList list = new ArrayList();
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Contactos;
                foreach (var mensaje in lst)
                {
                    if (mensaje.idEmisor == idEmisor)
                    {
                        //Console.WriteLine(contacto.ToString());
                        list.Add(mensaje);
                    }

                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se han podido encontrar mensaje de este usuario. \n\n" + ex.Message);
                return null;
            }

            return list;
        }

        // Mostrar todos los mensajes de un usuario con el mismo receptor
        public ArrayList listMensajesPorReceptor(int idEmisor, int idReceptor)
        {
            ArrayList list = new ArrayList();
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Contactos;
                foreach (var mensaje in lst)
                {
                    if (mensaje.idEmisor == idEmisor)
                    {
                        if (mensaje.idReceptor == idReceptor)
                        {
                            //Console.WriteLine(contacto.ToString());
                            list.Add(mensaje);
                        }
                    }
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se han podido encontrar mensajes para este receptor. \n\n" + ex.Message);
                return null;
            }

            return list;
        }

        // Mostrar todos los mensajes de un usuario que contengan una palabra concreta en el mensaje
        public ArrayList listMensajesPorPalabra(int idEmisor, String palabraBuscada)
        {
            ArrayList list = new ArrayList();
            try { 
            using (BancoDelTiempoEntities db = new BancoDelTiempoEntities())
            {
                var lst = db.Contactos;
                foreach (var mensaje in lst)
                {
                    if (mensaje.idEmisor == idEmisor)
                    {
                        if (mensaje.mensaje.StartsWith(palabraBuscada, System.StringComparison.CurrentCultureIgnoreCase))
                        {
                            //Console.WriteLine(contacto.ToString());
                            list.Add(mensaje);
                        }
                    }
                }
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido encontrar mensaje con esta palabra. \n\n" + ex.Message);
                return null;
            }

            return list;
        }

        // TODO: Enviar mensaje

        // TODO: Responder mensaje

    }
}
