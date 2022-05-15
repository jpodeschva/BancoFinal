using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;
using CapaEntidades;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CapaNegocio
{
    public class NCategoriaDeServicio
    {
        CapaDatos.CategoriaDeServicio nuevaCategoria;
        CapaDatos.DCategoriaDeServicio dCategoriaDeServicio = new CapaDatos.DCategoriaDeServicio();
        

       public ArrayList listarCategorias()
     {
            return dCategoriaDeServicio.listCategoriasDeServicio();
           /* {
                using (BancoDelTiempoEntities bd = new BancoDelTiempoEntities())
                {
                    var Query = (from n in bd.CategoriaDeServicios
                                 select new CategoriaDeServicio
                                 {

                                     idCategoria = n.idCategoria,
                                     nombreCategoria = n.nombreCategoria,
                                     descripcion = n.descripcion

                                 }).ToList();
                    BindingList<CategoriaDeServicio> Result = new BindingList<CategoriaDeServicio>(Query);
                    return Result;

                }

            }
            catch (Exception)
            {

                throw;
            }
          */
        }
        public ArrayList buscarSegunPalabra(String palabra)
        {
            if (palabra == "")
            {
                return mostrarTodasLasCategorias();
            }
            else
            {
                return mostrarCategoriaPorNombre(palabra);
            }
        }
        public ArrayList mostrarTodasLasCategorias()
        {
            return dCategoriaDeServicio.listCategoriasDeServicio();
        }

        public ArrayList mostrarCategoriaPorNombre(String palabra)
        {
            return dCategoriaDeServicio.listCategoriasDeServicioQueContiene(palabra);
        }
        public void guardarCategoria(String nombreCategoria, String descripcion) {

            // Creamos el nuevo usuario con los datos introducidos
            nuevaCategoria = new CapaDatos.CategoriaDeServicio(nombreCategoria, descripcion);
            nuevaCategoria.nombreCategoria = nombreCategoria;
            nuevaCategoria.descripcion = descripcion;
            // Llamamos al método addUsuario() de DUsuario (CapaDatos) y le pasamos el usuario creado
            dCategoriaDeServicio.addCategoria(nuevaCategoria);
            MessageBox.Show("Categoria añadida correctamente.");
        }
        
    }


}

