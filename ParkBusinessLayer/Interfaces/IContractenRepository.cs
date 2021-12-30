using ParkBusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkBusinessLayer.Interfaces
{
    public interface IContractenRepository
    {
        bool HeeftContract(DateTime startDatum, int huurderid, int huisid);
        void VoegContractToe(Huurcontract contract);
        void AnnuleerContract(Huurcontract contract);
        bool HeeftContract(string id);
        void UpdateContract(Huurcontract contract);
        Huurcontract GeefContract(string id);
        List<Huurcontract> GeefContracten(DateTime dtBegin, DateTime? dtEinde);
    }
}
