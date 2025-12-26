using _2_RentingModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1_RentingBS.Languages
{
    public abstract class Language
    {

        public SupportedLanguagesEnum LanguageEnum { get; protected set; }

        /// <summary>
        /// Gets the technical name associated with the object. ex: "en-US"
        /// </summary>
        public string? TechnicalName { get; protected set; }

        /// <summary>
        /// Retrieves the localized translation for the specified English key.
        /// </summary>
        /// <param name="englishKey">The English key that identifies the text to translate. Cannot be null or empty.</param>
        /// <returns>A string containing the localized translation corresponding to the specified key.Return the original value if translation fails.</returns>
        public abstract string GetTranslation(string englishKey);
    }
}
