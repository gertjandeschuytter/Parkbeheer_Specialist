namespace ParkBusinessLayer.Model
{
    public class Contactgegevens
    {
        public Contactgegevens(string email, string tel, string adres)
        {
            Email = email;
            Tel = tel;
            Adres = adres;
        }
        public string Email { get; set; }
        public string Tel { get; set; }
        public string Adres { get; set; }
    }
}