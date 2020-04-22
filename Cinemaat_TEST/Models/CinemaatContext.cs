using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.DependencyInjection;

namespace Cinemaat_TEST.Models
{
    public class CinemaatContext
    {
        public string ConnectionString { get; set; }

        public CinemaatContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Movie> GetAllMovies()
        {
            List<Movie> movies = new List<Movie>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM movie", conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        movies.Add(new Movie()
                        {
                            MovieId = reader.GetInt32("MovieId"),
                            MovieName = reader.GetString("MovieName"),
                            Description = reader.GetString("Description"),
                            DateCreated = reader.GetDateTime("DateCreated"),
                            Genre = reader.GetString("Genre"),
                            Review = reader.GetString("Review"),
                            Rating = reader.GetDouble("Rating")
                        });
                    }
                }
            }
            return movies;
        }
    }
}
