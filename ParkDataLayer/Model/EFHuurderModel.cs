using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model {
    public class EFHuurderModel {
        public EFHuurderModel()
        {
        }

        public EFHuurderModel(string naam, string telefoon, string email, string adres)
        {
            Naam = naam;
            Telefoon = telefoon;
            Email = email;
            Adres = adres;
        }

        public EFHuurderModel(int id, string naam, string telefoon, string email, string adres)
        {
            Id = id;
            Naam = naam;
            Telefoon = telefoon;
            Email = email;
            Adres = adres;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Naam { get; set; }

        [MaxLength(100)]
        public string Telefoon { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Adres { get; set; }
    }
}
