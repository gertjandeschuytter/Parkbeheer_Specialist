using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBusinessLayer.Interfaces
{
    public interface IHuizenRepository
    {
        bool HeeftHuis(string straat, int nummer, Park park);
        Huis VoegHuisToe(Huis h);
        bool HeeftHuis(int id);
        void UpdateHuis(Huis huis);
        Huis GeefHuis(int id);
    }
}
