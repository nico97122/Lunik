using _2_RentingModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace _1_RentingBS
{
    public class LocalizationService : ILocalizationService
    {
        private CultureInfo _currentCulture = CultureInfo.CurrentCulture;

        //action pour notif le frontend => abonnement important
        public event Action? OnCultureChanged;

        public CultureInfo CurrentCulture => _currentCulture;

        public void SetCulture(SupportedLanguagesEnum language)
        {
            _currentCulture = new CultureInfo(language.GetTechnicalName());
            CultureInfo.DefaultThreadCurrentCulture = _currentCulture;
            CultureInfo.DefaultThreadCurrentUICulture = _currentCulture;
            OnCultureChanged?.Invoke();
        }

        public string TransalateFromEnglish(string sentence)
        {
            Dictionary.TryGetValue(sentence, out Dictionary<SupportedLanguagesEnum, string>? translations);
            if (translations != null && translations.TryGetValue(SupportedLanguagesEnumExtensions.GetCommonName(_currentCulture.Name), out string? translatedSentence))
            {
                return translatedSentence;
            }
            else
            {
                return sentence; // Return the original sentence if not found in the dictionary
            }
        }

        public string GetLanguageCode()
        {
            return _currentCulture.Name;
        }

        private Dictionary<string, Dictionary<SupportedLanguagesEnum, string>> Dictionary = new Dictionary<string, Dictionary<SupportedLanguagesEnum, string>>()
        {
            {"Hello",
             new Dictionary<SupportedLanguagesEnum, string>()
                   {
                   {SupportedLanguagesEnum.French,"Bonjour"},
                   {SupportedLanguagesEnum.English,"Hello"}
                   }
            },
            {"Welcome",
              new Dictionary<SupportedLanguagesEnum, string>()
                   {
                   {SupportedLanguagesEnum.French,"Bienvenue"},
                   {SupportedLanguagesEnum.English,"Welcome"}
                   }
            },
            {"About",
              new Dictionary<SupportedLanguagesEnum, string>()
                   {
                   {SupportedLanguagesEnum.French,"A propos"},
                   {SupportedLanguagesEnum.English,"About"}
                   }
            },

            //{"Welcome", "Bienvenue" },
            //{"Language", "Langue" },
            //{"French,", "Français" },
            //{"About", "À propos" }
        };
    }
}
