using _2_RentingModel;
using Microsoft.Extensions.Logging;
using System.Reflection.Metadata;

namespace RentingApp.Components.Layout
{
    public partial class MainLayout : IAsyncDisposable
    {
        bool _drawerOpen = false;
        protected override void OnInitialized()
        {
            _logger.LogInformation("MainLayout initialized with culture: " + _localizationService.GetCurrentCulture());
            _localizationService.OnCultureChanged += StateHasChanged;
        }

         private void HandleCultureChange()
        {
            InvokeAsync(StateHasChanged);
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
        

        void DrawerToggle()
        {
            _drawerOpen = !_drawerOpen;
        }
    }
}
