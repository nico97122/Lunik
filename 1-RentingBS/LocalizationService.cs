using _1_RentingBS.Languages;
using _2_RentingModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.Extensions.Logging;

namespace _1_RentingBS
{
    /// <summary>
    /// Cette classe gère la culture de l'application et les traductions.C'est une Factory.
    /// </summary>
    public class LocalizationService : ILocalizationService
    {
        private CultureInfo _currentCulture;

        //action pour notif le frontend => abonnement important
        public event Action? OnCultureChanged;

        private readonly ILogger<LocalizationService> _logger;

        public LocalizationService(ILogger<LocalizationService> logger)
        {
            _logger = logger;
            _currentCulture= new CultureInfo(SupportedLanguagesEnum.French.GetTechnicalName());
        }
        public void SetCulture(SupportedLanguagesEnum language)
        {
            _currentCulture = new CultureInfo(language.GetTechnicalName());
            CultureInfo.DefaultThreadCurrentCulture = _currentCulture;
            CultureInfo.DefaultThreadCurrentUICulture = _currentCulture;
            OnCultureChanged?.Invoke();
        }

        public string TransalateFromEnglish(string sentence)
        {
            Language language;
            switch (_currentCulture.Name.GetCommonName())
            {
                case SupportedLanguagesEnum.English:
                    language = new EnglishLanguage();
                    break;
                case SupportedLanguagesEnum.French:
                    language = new FrenchLanguage();
                    break;
                default:
                    _logger.LogWarning("Language not supported: " + _currentCulture.Name);
                    return sentence; 
            }
            return language.GetTranslation(sentence);
        }

        public string GetLanguageCode()
        {
            return _currentCulture.Name;
        }

        public string GetCurrentCulture()
        {
            return _currentCulture.Name.GetCommonName().ToString();
        }
    }
}
