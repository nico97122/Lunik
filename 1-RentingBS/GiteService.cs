using _2_RentingModel;

namespace _1_RentingBS
{
    public class GiteService : IGiteService
    {
        private readonly List<Gite> _gites;
        public GiteService()
        {
            _gites = new List<Gite>
            {
                new Gite {
                    Id = 1,
                    Nom = "Villa Colibri",
                    DescriptionCourte = "Un havre de paix vue mer.",
                    DescriptionLongue = "Située à Deshaies, la Villa Colibri offre une vue imprenable sur la mer des Caraïbes. Piscine à débordement et jardin tropical.",
                    PrixNuit = 120,
                    ImageUrl = "images/gites/gite1.jpg", 
                    Capacite = 4,
                    Equipements = new List<string> { "Wifi", "Climatisation", "Piscine", "Parking" }
                },
                new Gite {
                    Id = 2,
                    Nom = "Bungalow Lagon",
                    DescriptionCourte = "Les pieds dans l'eau à Saint-François.",
                    DescriptionLongue = "Accès direct au lagon. Idéal pour les amateurs de kitesurf et de farniente. Proche de la marina et du golf.",
                    PrixNuit = 95,
                    ImageUrl = "images/gites/gite2.jpeg",
                    Capacite = 2,
                    Equipements = new List<string> { "Wifi", "Cuisine équipée", "Terrasse", "Accès plage" }
                },
                new Gite {
                    Id = 3,
                    Nom = "Kaz' Tropik",
                    DescriptionCourte = "Authenticité au cœur de la forêt tropicale.",
                    DescriptionLongue = "Nichée sur la route de la Traversée, cette case créole rénovée vous plonge dans la nature luxuriante de la Guadeloupe.",
                    PrixNuit = 80,
                    ImageUrl = "images/gites/gite3.jpeg",
                    Capacite = 6,
                    Equipements = new List<string> { "Barbecue", "Jardin", "Randonnée", "Hamac" }
                }
            };
        }

        public List<Gite> GetGites() => _gites;

        public Gite? GetGiteById(int id) => _gites.FirstOrDefault(g => g.Id == id);
    }
}
