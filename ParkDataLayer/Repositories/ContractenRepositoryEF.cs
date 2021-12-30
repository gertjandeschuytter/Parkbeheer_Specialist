using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;

namespace ParkDataLayer.Repositories
{
    public class ContractenRepositoryEF : IContractenRepository
    {
        public void AnnuleerContract(Huurcontract contract)
        {
            throw new NotImplementedException();
        }

        public Huurcontract GeefContract(string id)
        {
            throw new NotImplementedException();
        }

        public List<Huurcontract> GeefContracten(DateTime dtBegin, DateTime? dtEinde)
        {
            throw new NotImplementedException();
        }

        public bool HeeftContract(DateTime startDatum, int huurderid, int huisid)
        {
            throw new NotImplementedException();
        }

        public bool HeeftContract(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateContract(Huurcontract contract)
        {
            throw new NotImplementedException();
        }

        public void VoegContractToe(Huurcontract contract)
        {
            throw new NotImplementedException();
        }
    }
}
