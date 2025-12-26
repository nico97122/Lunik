using _2_RentingModel;

namespace _1_RentingBS.Languages
{
    public class EnglishLanguage : Language
    {
        public EnglishLanguage()
        {
            LanguageEnum = SupportedLanguagesEnum.English;
            TechnicalName = "en-US";
        }

        private static readonly Dictionary<string, string> Translations = new Dictionary<string, string>
        {
            // Since this is the English language, translations map to themselves most of the time
            { "GuadeloupeName1", "Guadeloupe" },
            { "WelcomeName1", "Welcome you" },

        };
        public override string GetTranslation(string englishKey)
        {
            return Translations.TryGetValue(englishKey, out string? translation) ? translation : englishKey;
        }
    }
}
