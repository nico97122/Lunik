using System;
using System.Collections.Generic;
using System.Text;

namespace _2_RentingModel
{
    /// <summary>
    /// IMPORTANT : 
    /// Pensez à mettre à jour SupportedLanguagesEnumExtensions lors de l'ajout de nouvelles langues.
    /// </summary>
    public enum SupportedLanguagesEnum
    {
        English,
        French
    }

    public static class SupportedLanguagesEnumExtensions
    {
        /// <summary>
        /// Returns the technical language name corresponding to the specified language enumeration value.
        /// </summary>
        /// <param name="language">The language enumeration value for which to retrieve the technical name.</param>
        /// <returns>A string containing the technical language name, such as "en-US" for English or "fr-FR" for French. If the
        /// language is not recognized, returns the string representation of the enumeration value.</returns>
        public static string GetTechnicalName(this SupportedLanguagesEnum language)
        {
            return language switch
            {
                SupportedLanguagesEnum.English => "en-US",
                SupportedLanguagesEnum.French => "fr-FR",
                _ => language.ToString()
            };
        }

        /// <summary>
        /// Returns the localized display name for the specified language.
        /// </summary>
        /// <param name="language">The language for which to retrieve the display name.</param>
        /// <returns>The value of the language for front.</returns>
        public static string GetDisplayName(this SupportedLanguagesEnum language)
        {
            return language switch
            {
                SupportedLanguagesEnum.English => "English",
                SupportedLanguagesEnum.French => "Français",
                _ => language.ToString()
            };
        }
        /// <summary>
        /// Converts a language code string to its corresponding value in the SupportedLanguagesEnum enumeration.
        /// </summary>
        /// <param name="language">The language code to convert. Must be a supported culture name, such as "en-US" or "fr-FR".</param>
        /// <returns>A SupportedLanguagesEnum value that corresponds to the specified language code.</returns>
        /// <exception cref="ArgumentException">Thrown if the specified language code is not supported.</exception>
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
