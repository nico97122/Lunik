namespace _2_RentingModel
{
    public class Gite
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string DescriptionCourte { get; set; } = string.Empty;
        public string DescriptionLongue { get; set; } = string.Empty;
        public decimal PrixNuit { get; set; }
        public string ImageUrl { get; set; } = string.Empty; // URL de l'image principale
        public List<string> Equipements { get; set; } = new List<string>();
        public int Capacite { get; set; }
    }
}
