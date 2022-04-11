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
            var rows = DatabaseConnector.GetRows("select * from film");

            List<Film> films = new List<Film>();
            foreach (var row in rows)
            {
                Film f = new Film
                {
                    // selecteer de kolommen die je wil lezen. In dit geval kiezen we de kolom "naam"
                    Naam = row["naam"].ToString(),
                    poster = row["poster"].ToString(),
                    Id = Convert.ToInt32(row["id"].ToString()),
                    Cast = row["Cast"].ToString()
                };

                films.Add(f);
            }

            // stop de namen in de html
            return View(films);
        }      


        public IActionResult Privacy()
        {
            return View();
        }

        [Route("film/{id}")]

        public IActionResult Film(int id)
        {
            var rows = DatabaseConnector.GetRows($"select * from film where id = {id}");

            List<Film> films = new List<Film>();
            foreach (var row in rows)
            {
                Film f = new Film
                {
                    // selecteer de kolommen die je wil lezen. In dit geval kiezen we de kolom "naam"
                    Naam = row["naam"].ToString(),
                    poster = row["poster"].ToString(),
                    Id = Convert.ToInt32(row["id"].ToString()),
                    Cast = row["Cast"].ToString()
                };

                films.Add(f);
            }

            return View(films[0]);
        }       


        [Route("actie")]
        public IActionResult Action()
        {
            var rows = DatabaseConnector.GetRows("select * from film where genre = 'actie'");

            List<Film> films = new List<Film>();
            foreach (var row in rows)
            {
                Film f = new Film
                {
                    // selecteer de kolommen die je wil lezen. In dit geval kiezen we de kolom "naam"
                    Naam = row["naam"].ToString(),
                    poster = row["poster"].ToString(),
                    Id = Convert.ToInt32(row["id"].ToString()),
                    Cast = row["Cast"].ToString()
                };

                films.Add(f);
            }

            return View(films);
        }

        [Route("romantiek")]
        public IActionResult Romantiek()
        {
            var rows = DatabaseConnector.GetRows("select * from film where genre = 'Romantiek'");

            List<Film> films = new List<Film>();
            foreach (var row in rows)
            {
                Film f = new Film
                {
                    // selecteer de kolommen die je wil lezen. In dit geval kiezen we de kolom "naam"
                    Naam = row["naam"].ToString(),
                    poster = row["poster"].ToString(),
                    Id = Convert.ToInt32(row["id"].ToString()),
                    Cast = row["Cast"].ToString()
                };

                films.Add(f);
            }

            return View(films);
        }

        [Route("comedy")]
        public IActionResult Comedy()
        {
            var rows = DatabaseConnector.GetRows("select * from film where genre = 'Comedy'");

            List<Film> films = new List<Film>();
            foreach (var row in rows)
            {
                Film f = new Film
                {
                    // selecteer de kolommen die je wil lezen. In dit geval kiezen we de kolom "naam"
                    Naam = row["naam"].ToString(),
                    poster = row["poster"].ToString(),
                    Id = Convert.ToInt32(row["id"].ToString()),
                    Cast = row["Cast"].ToString()
                };

                films.Add(f);
            }

            return View(films);
        }

        [Route("Kinderfilms")]
        public IActionResult Kinderfilms()
        {
            var rows = DatabaseConnector.GetRows("select * from film where genre = 'Kinderfilm'");

            List<Film> films = new List<Film>();
            foreach (var row in rows)
            {
                Film f = new Film
                {
                    // selecteer de kolommen die je wil lezen. In dit geval kiezen we de kolom "naam"
                    Naam = row["naam"].ToString(),
                    poster = row["poster"].ToString(),
                    Id = Convert.ToInt32(row["id"].ToString()),
                    Cast = row["Cast"].ToString()
                };

                films.Add(f);
            }

            return View(films);
        }

        [Route("Contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Person person)
        {
            // hebben we alles goed ingevuld? Dan sturen we de gebruiker door naar de succes pagina
            if (ModelState.IsValid){

                return Redirect("/Succes");
            }
            // niet goed? Dan sturen we de gegevens door naar de view zodat we de fouten kunnen tonen
           
            return View(person);
        }

        [Route("Succes")]
        public IActionResult Succes()
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
