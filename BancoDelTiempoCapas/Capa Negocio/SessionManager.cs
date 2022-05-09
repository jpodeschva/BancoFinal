using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public sealed class SessionManager
    {
        private readonly static SessionManager _instance = new SessionManager();

        public bool isLoggedIn = false;
        public String username = "";

        private SessionManager()
        {
        }

        public static SessionManager Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
