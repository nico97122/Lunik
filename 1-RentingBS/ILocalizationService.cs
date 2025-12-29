using _2_RentingModel;

namespace _1_RentingBS
{
    public interface ILocalizationService
    {
        /// <summary>
        /// Sets the application's culture to the specified supported language.
        /// </summary>
        /// <param name="supportedLanguagesEnum">A value from the SupportedLanguagesEnum enumeration that specifies the language and culture to set for the
        /// application.</param>
        void SetCulture(SupportedLanguagesEnum supportedLanguagesEnum);

        /// <summary>
        /// Translates the specified English sentence into the target language.
        /// </summary>
        /// <param name="sentence">The sentence in English to be translated. Cannot be null.</param>
        /// <returns>A string containing the translated sentence. Returns original value if translation failed.</returns>
        string TransalateFromEnglish(string sentence);

        string GetCurrentCulture();

        /// <summary>
        /// Occurs when the application's culture changes.
        /// </summary>
        /// <remarks>Subscribe to this event to be notified when the culture is updated, allowing
        /// components to respond to localization changes. Handlers are invoked after the culture has changed.</remarks>
        public event Action? OnCultureChanged;
    }
}