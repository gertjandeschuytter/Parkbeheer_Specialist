using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using System;

namespace ParkDataLayer.Repositories
{
    public class HuizenRepositoryEF : IHuizenRepository
    {
        public Huis GeefHuis(int id)
        {
            throw new NotImplementedException();
        }

        public bool HeeftHuis(string straat, int nummer, Park park)
        {
            throw new NotImplementedException();
        }

        public bool HeeftHuis(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateHuis(Huis huis)
        {
            throw new NotImplementedException();
        }

        public Huis VoegHuisToe(Huis h)
        {
            throw new NotImplementedException();
        }
    }
}
