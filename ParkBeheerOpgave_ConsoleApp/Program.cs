using ParkDataLayer.Model;
using System;
using System.Configuration;

namespace ParkBeheerOpgave_ConsoleApp {
    class Program {
        static void Main(string[] args)
        {
            string EFDataLayer = ConfigurationManager.AppSettings["EFlayer"];
            string ConnectionStringEF = ConfigurationManager.ConnectionStrings["connectionstringEF"].ConnectionString;
            ParkBeheerContext ctx = new ParkBeheerContext(ConnectionStringEF);

            //aanmaken ipv migrations
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
        }
    }
}
