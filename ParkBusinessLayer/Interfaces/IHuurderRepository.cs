using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBusinessLayer.Interfaces
{
    public interface IHuurderRepository
    {
        Huurder VoegHuurderToe(Huurder h);
        bool HeeftHuurder(string naam, Contactgegevens contact);
        bool HeeftHuurder(int id);
        void UpdateHuurder(Huurder huurder);
        Huurder GeefHuurder(int id);
        List<Huurder> GeefHuurders(string naam);
    }
}
