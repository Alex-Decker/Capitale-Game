using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitale_Game
{
    internal class Pays
    {
        public string Nom { get; set; }
        public string Capitale { get; set; }
        public string Continent { get; set; }

        public Pays(string nom)
        {
            Nom = nom;
        }

        public Pays(string nom, string capitale) : this(nom)
        {
            Capitale = capitale;
        }

        public Pays(string nom, string capitale, string continent) : this(nom, capitale)
        {
            Continent = continent;
        }
    }
}
