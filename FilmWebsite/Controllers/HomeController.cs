using FilmWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using FilmWebsite.Database;
using MySql.Data.MySqlClient;
using System;

namespace FilmWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // alle namen ophalen
            var products = GetProducts();

            // stop de namen in de html
            return View(products);
        }
        public List<Film> GetProducts()
        {

            string connectionString = "Server=172.16.160.21;Port=3306;Database=111410;Uid=111410;Pwd=inf2021sql;";
            //string connectionString = "Server=informatica.st-maartenscollege.nl;Port=3306;Database=111410;Uid=111410;Pwd=inf2021sql;";

            // maak een lege lijst waar we de namen in gaan opslaan
            List<Film> products = new List<Film>();

            // verbinding maken met de database
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                // verbinding openen
                conn.Open();

                // SQL query die we willen uitvoeren
                MySqlCommand cmd = new MySqlCommand("select * from film", conn);

                // resultaat van de query lezen
                using (var reader = cmd.ExecuteReader())
                {
                    // elke keer een regel (of eigenlijk: database rij) lezen
                    while (reader.Read())
                    {
                        Film p = new Film
                        {
                            // selecteer de kolommen die je wil lezen. In dit geval kiezen we de kolom "naam"
                            Naam = reader["Naam"].ToString(),
                            poster = reader["poster"].ToString(),
                            Id = Convert.ToInt32(reader["Id"].ToString()),
                            Cast = reader["Cast"].ToString()
                        };

                        // voeg de naam toe aan de lijst met namen
                        products.Add(p);

                    }
                }
            }


            // return de lijst met namen
            return products;
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
