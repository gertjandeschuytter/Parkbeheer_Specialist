using System;

namespace ParkBusinessLayer.Model
{
    public class Huurperiode
    {
        public Huurperiode(DateTime startDatum, int aantaldagen)
        {
            StartDatum = startDatum;
            EindDatum = startDatum.AddDays(aantaldagen);
            Aantaldagen = aantaldagen;
        }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public int Aantaldagen { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Huurperiode huurperiode &&
                   StartDatum == huurperiode.StartDatum &&
                   EindDatum == huurperiode.EindDatum &&
                   Aantaldagen == huurperiode.Aantaldagen;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StartDatum, EindDatum, Aantaldagen);
        }
    }
}
