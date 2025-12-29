using _2_RentingModel;
using Microsoft.Extensions.Logging;

namespace RentingApp.Components.Layout
{
    public partial class MainLayout :IAsyncDisposable
    {

        protected override void OnInitialized()
        {
            _logger.LogInformation( "MainLayout initialized with culture: " + _localizationService.GetCurrentCulture());
            _localizationService.OnCultureChanged += StateHasChanged;
        }

        private void ChangeCulture(SupportedLanguagesEnum culture)
        {
            _localizationService.SetCulture(culture);
        }
        public ValueTask DisposeAsync()
        {
            _localizationService.OnCultureChanged -= StateHasChanged;
            return default;
        }
        private string Word(string englishWord)
        {
            return _localizationService.TransalateFromEnglish(englishWord);
        }
    }
}
