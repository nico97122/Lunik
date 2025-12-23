using System;
using System.Collections.Generic;
using System.Text;

namespace _2_RentingModel
{
    public enum SupportedLanguagesEnum
    {
        
        English,
        French
    }

    public static class SupportedLanguagesEnumExtensions
    {
        public static string GetTechnicalName(this SupportedLanguagesEnum language)
        {
            return language switch
            {
                SupportedLanguagesEnum.English => "en-US",
                SupportedLanguagesEnum.French => "fr-FR",
                _ => language.ToString()
            };
        }
        public static SupportedLanguagesEnum GetCommonName(this string language)
        {
            return language switch
            {
                "en-US"=> SupportedLanguagesEnum.English,
                "fr-FR"=> SupportedLanguagesEnum.French,
                _ => throw new ArgumentException("Unsupported language code", nameof(language))
            };
        }
    }
}
