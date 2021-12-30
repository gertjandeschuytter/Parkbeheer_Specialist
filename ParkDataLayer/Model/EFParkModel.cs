using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model {
    public class EFParkModel {
        public EFParkModel()
        {
        }

        public EFParkModel(string id, string naam, string locatie)
        {
            Id = id;
            Naam = naam;
            Locatie = locatie;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(7)]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Naam { get; set; }

        [MaxLength(500)]
        public string Locatie { get; set; }

        public List<EFHuisModel> Huizen { get; set; } = new List<EFHuisModel>();

    }
}
