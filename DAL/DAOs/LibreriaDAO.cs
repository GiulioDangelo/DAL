using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAOImpl;
using Entities;

namespace DAL.DAOs
{
    public interface LibreriaDAO
    {
        public LibreriaDAOImp VisualizzaLibri();
        public void AggiungiLibro(Libro libro);
        public Libro CercaLibroPerTitolo(string userInput);
        public bool RimuoviLibro(string userInput);
    }
}
