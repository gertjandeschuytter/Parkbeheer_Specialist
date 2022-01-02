using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model {
    public class EFHuisModel {
        public EFHuisModel()
        {
        }

        public EFHuisModel(int id, string straat, int nr, bool actief, EFParkModel park)
        {
            Id = id;
            Straat = straat;
            Nr = nr;
            Actief = actief;
            Park = park;
        }

        public EFHuisModel(int id, string straat, int nr, bool actief, EFParkModel park, List<EFHuurContractModel> huurContracten) : this(id, straat, nr, actief, park)
        {
            HuurContracten = huurContracten;
        }

        public int Id { get; set; }
        [MaxLength((50))]
        public string Straat { get; private set; }
        [Required]
        public int Nr { get; private set; }
        [Required]
        public bool Actief { get; set; }

        public EFParkModel Park { get; set; }

        public List<EFHuurContractModel> HuurContracten { get; set; } = new List<EFHuurContractModel>();


    }
}
