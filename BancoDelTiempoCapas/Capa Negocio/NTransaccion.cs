using CapaDatos;

namespace CapaNegocio
{
    public class NTransaccion
    {
        DUsuario dUsuario = new DUsuario();

        public void restarHorasDelBalance(string username, int horasPagadas)
        {
            // Cogemos el usuario a partir del username
            Usuario usuario = dUsuario.getUsuarioByUsername(username);
            // Buscamos su id
            int idUsuario = usuario.idUsuario;
            // Pasamos el idUsuario y las horasPagadas para restar las horas del balance
            dUsuario.substractHoursFromUser(usuario, horasPagadas);
        }
    }
}
