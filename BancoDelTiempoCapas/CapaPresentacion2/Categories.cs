using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories
{
    class Categories : ObservableCollection<string>
    {
        Categories categories = new Categories();
        public Categories()
        {

            Add("Limpieza");
            Add("Música");
            Add("Deporte");
            Add("Bricolaje");
            Add("Idiomas");
            Add("Transporte");
            Add("Compras");
        }
    }
}
