using System.ComponentModel.DataAnnotations;

namespace FilmWebsite.Models
{
public class Person
    {
        [Required(ErrorMessage = "Voornaam is een verplicht veld")]
        [Display(Name = "Voornaam")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Achternaam is een verplicht veld")]
        [Display(Name = "Achternaam")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is een verplicht veld")]
        [EmailAddress(ErrorMessage = "Geen geldig email adres")]
        public string Email { get; set; }

        public string Phone { get; set; }

        public string Adress { get; set; }

        [Required(ErrorMessage = "Omschrijving is een verplicht veld")]
        [Display(Name = "Omschrijving")]
        public string Description { get; set; }
    }
}