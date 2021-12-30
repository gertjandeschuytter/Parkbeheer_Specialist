using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkDataLayer.Model {
    public class EFHuurContractModel {
        public EFHuurContractModel()
        {
        }

        public EFHuurContractModel(string id, DateTime startDatum, DateTime eindDatum,
            int aantalDagenVerblijf, int huisId, EFHuisModel huis, int huurderId, EFHuurderModel huurder)
        {
            Id = id;
            StartDatum = startDatum;
            EindDatum = eindDatum;
            AantalDagenVerblijf = aantalDagenVerblijf;
            HuisId = huisId;
            Huis = huis;
            HuurderId = huurderId;
            Huurder = huurder;
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [MaxLength(7)]
        public string Id { get; set; }
        [Required]
        public DateTime StartDatum { get; set; }

        [Required]
        public DateTime EindDatum { get; set; }

        public int AantalDagenVerblijf { get; set; }

        [Required]
        public int HuisId { get; set; }
        public EFHuisModel Huis { get; set; }

        [Required]
        public int HuurderId { get; set; }
        public EFHuurderModel Huurder { get; set; }
    }
}
