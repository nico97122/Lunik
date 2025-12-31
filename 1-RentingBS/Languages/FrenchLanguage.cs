using _2_RentingModel;

namespace _1_RentingBS.Languages
{
    public class FrenchLanguage : Language
    {
        public FrenchLanguage()
        {
            LanguageEnum = SupportedLanguagesEnum.French;
            TechnicalName = "fr-FR";
        }

        private static readonly Dictionary<string, string> Translations = new Dictionary<string, string>
        {
            { "Hello", "Bonjour" },
            { "WelcomeName1", "Bienvenue" },
            { "About", "À propos" },
            { "Home", "Accueil" },
            { "Our Bungalows", "Nos Bungalows" },
            { "Contact", "Contact" },
            { "GuadeloupeName1", "La Guadeloupe" },
            { "All rights reserved", "Tous droits réservés" },
            {"has the pleasure to", "vous souhaite la" },
            {"Activities", "Activités" },
            {"Our accommodations", "Nos Logis" },
            {"Treat yourself with a unique experience of comfort and relaxation", "Offrez-vous une expérience unique de confort et de détente" },
            {"An exeptional view", "Une vue exceptionnelle" },
            {"Next to L'Autre Bord beach", "Proche de la plage de l'Autre Bord" },
            // Add more translations as needed
        };
        public override string GetTranslation(string englishKey)
        {
            return Translations.TryGetValue(englishKey, out string? translation) ? translation : englishKey;
        }
    }
}
