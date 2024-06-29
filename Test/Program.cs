using System;
using System.ComponentModel;
using Entities;
using DAL.DAOImpl;
using DAL.DAOs;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            LibreriaDAOImp l = new LibreriaDAOImp();
            var exit = false;

            while (!exit)
            {
                Console.WriteLine("Benvenuto nella libreria, cosa vuoi fare?");
                Console.WriteLine("-- Premi 1 per visualizzare i libri");
                Console.WriteLine("-- Premi 2 per aggiungere libro");
                Console.WriteLine("-- Premi 3 per cercare un libro per titolo");
                Console.WriteLine("-- Premi 4 per rimuovere un libro");
                Console.WriteLine("-- Premi 5 per uscire");

                var choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        var list = l.VisualizzaLibri();

                        for (int i = 0; i <= list.Count() - 1; i++)
                        {
                            Console.WriteLine($"{i + 1}) Titolo: {list[i].Titolo}  Autore: {list[i].Autore}");
                        }

                        break;
                    case 2:
                        Console.WriteLine("Inserisci titolo libro");
                        var titolo = Console.ReadLine();

                        Console.WriteLine("Inserisci nome autore");
                        var autore = Console.ReadLine();

                        var libro = new Libro(titolo, autore);

                        l.AggiungiLibro(libro);

                        Console.WriteLine(libro.ToString());
                        break;
                    case 3:
                        Console.WriteLine("Inserisci il titolo del libro che vuoi cercare");
                        string userInputRicerca = Console.ReadLine().ToLower();
                        l.CercaLibroPerTitolo(userInputRicerca);
                        break;
                    case 4:
                        Console.WriteLine("scrivi il titolo del libro che vuoi cercare");
                        string userInputDelete = Console.ReadLine().ToLower();

                        if (l.RimuoviLibro(userInputDelete))
                        {
                            Console.WriteLine($"{userInputDelete} rimosso");
                        }
                        else
                        {
                            Console.WriteLine("Libri non rimosso");
                        }
                        break;
                    case 5:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("input errato");
                        exit = true;
                        break;
                }
            }

        }
    }
}