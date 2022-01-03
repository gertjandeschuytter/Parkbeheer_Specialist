using ParkBeheerBussinesLayer.Beheerders;
using ParkBeheerDataLayer.Repositories;
using ParkBusinessLayer.Beheerders;
using ParkBusinessLayer.Interfaces;
using ParkBusinessLayer.Model;
using ParkDataLayer.Model;
using ParkDataLayer.Repositories;
using System;
using System.Configuration;

namespace ParkBeheerOpgave_ConsoleApp {
    class Program {
        static void Main(string[] args)
        {
            string ConnectionStringEF = ConfigurationManager.ConnectionStrings["connectionstringEF"].ConnectionString;

            //aanmaken ipv migrations
            //ctx.Database.EnsureDeleted();
            //ctx.Database.EnsureCreated();

            ParkRepository ParkREPO = new(ConnectionStringEF);
            HuizenRepositoryEF HuisREPO = new(ConnectionStringEF);
            HuurderRepositoryEF HuurderREPO = new(ConnectionStringEF);
            ContractenRepositoryEF ContractREPO = new(ConnectionStringEF);

            BeheerParken ParkBeheerder = new(ParkREPO);
            BeheerHuizen HuisBeheerder = new (HuisREPO);
            BeheerHuurders HuurderBeheerder = new BeheerHuurders(HuurderREPO);
            BeheerContracten ContractenBeheerder = new BeheerContracten(ContractREPO);

            //Park parkje = new("1", "Centerparcs De Haan", "De Haan");
            //ParkBeheerder.VoegParkToe(parkje);
            //Park parkje = ParkBeheerder.GeefPark("1");
            //parkje.ZetNaam("De Haan Aangepast");
            //ParkBeheerder.UpdatePark(parkje);


            //HuisBeheerder.VoegNieuwHuisToe("Dolfijnstraat", 12, parkje);
            //Huis huisje3 = HuisBeheerder.GeefHuis(3);
            //Huis huisje = HuisBeheerder.GeefHuis(1);
            //huisje.ZetStraat("Dolfijnstraat Aangepast");
            //HuisBeheerder.UpdateHuis(huisje);
            //HuisBeheerder.ArchiveerHuis(huisje);

            //HuurderBeheerder.VoegNieuweHuurderToe("Gertjan Deschuytter", new("testemailadres@gmail.com", "0471920423", "Karel De Stoutelaan 5"));
            //var huurdertje = HuurderBeheerder.GeefHuurder(1);
            //HuurderBeheerder.GeefHuurders("Gertjan Deschuytter");


            //ContractenBeheerder.MaakContract("2", new(DateTime.Today, 7), huurdertje, huisje);
            //var contractje = ContractenBeheerder.GeefContract("2");
            //var contractjes = ContractenBeheerder.GeefContracten(DateTime.Today, null);
            //ContractenBeheerder.AnnuleerContract(contractje);
            //contractje.ZetHuis(huisje3);
            //ContractenBeheerder.UpdateContract(contractje);
        }
    }
}
