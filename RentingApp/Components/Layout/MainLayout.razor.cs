using _2_RentingModel;

namespace RentingApp.Components.Layout
{
    public partial class MainLayout :IAsyncDisposable
    {

        protected override void OnInitialized()
        {
            LocalizationService.OnCultureChanged += StateHasChanged;
        }

        private void ChangeCulture(SupportedLanguagesEnum culture)
        {
            LocalizationService.SetCulture(culture);
        }
        public ValueTask DisposeAsync()
        {
            LocalizationService.OnCultureChanged -= StateHasChanged;
            return default;
        }
        private string Word(string englishWord)
        {
            return LocalizationService.TransalateFromEnglish(englishWord);
        }
    }
}
