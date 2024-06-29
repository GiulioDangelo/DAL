using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Libro
    {
        public Guid Uid { get; set; }
        public string Titolo { get; set; }
        public string Autore { get; set; }

        public Libro(string titolo, string autore)
        {
            Uid = Guid.NewGuid();
            Titolo = titolo;
            Autore = autore;
        }

        public Libro(Guid uid,string titolo, string autore)
        {
            Uid = uid;
            Titolo = titolo;
            Autore = autore;
        }

        public override string ToString()
        {
            return $"Titolo: {Titolo}, Autore: {Autore}";
        }

    }
}
