using DAL.DAOs;
using Entities;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Utilities.Collections;

namespace DAL.DAOImpl
{
    public class LibreriaDAOImp : List<Libro>, LibreriaDAO
    {
        string connectionString = "**********************************";
        public void AggiungiLibro(Libro l)
        {
            var query = $"insert into Libri(id, titolo, autore) values('{l.Uid}', '{l.Titolo}', '{l.Autore}');";

            using (var cn = new MySqlConnection(connectionString))
            {
                cn.Open();
                var cmd = new MySqlCommand(query, cn);
                var dr = cmd.ExecuteNonQuery();
                cn.Close();
            }
        }


        public LibreriaDAOImp VisualizzaLibri()
        {
            var query = "SELECT * FROM libri;";
            var l = new LibreriaDAOImp();

            using (var cn = new MySqlConnection(connectionString))
            {
                cn.Open();
                var cmd = new MySqlCommand(query, cn);
                var dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var libro = new Libro(new Guid(dr[0].ToString()), dr[1].ToString(), dr[2].ToString());
                    l.Add(libro);
                }

                cn.Close();
            }

            return l;
        }


        public Libro CercaLibroPerTitolo(string userInput)
        {
            var query = $"SELECT * FROM libri where titolo='{userInput}';";
            Libro libro = null;

            using (var cn = new MySqlConnection(connectionString))
            {
                cn.Open();
                var cmd = new MySqlCommand(query, cn);
                var dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    libro = new Libro(new Guid(dr[0].ToString()), dr[1].ToString(), dr[2].ToString());
                }

                cn.Close();
                return libro;
            }
        }


        public bool RimuoviLibro(string userInput)
        {
            var query = $"delete from libri where titolo='{userInput}';";
            Libro l = null;

            using (var cn = new MySqlConnection(connectionString))
            {
                cn.Open();
                var cmd = new MySqlCommand(query, cn);
                var dr = cmd.ExecuteNonQuery();
                cn.Close();

                return dr > 0;
            }
        }
    }
}
