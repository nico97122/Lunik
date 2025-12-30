using _1_RentingBS;
using Microsoft.AspNetCore.Components;

namespace RentingApp.Components
{
    public class BlazorComponentBase : ComponentBase, IAsyncDisposable
    {
        [Inject]
        protected ILocalizationService LocalizationService { get; set; } = null!;

        protected override void OnInitialized()
        {
            LocalizationService.OnCultureChanged += HandleCultureChange;
        }

        private void HandleCultureChange()
        {
            InvokeAsync(StateHasChanged);
        }
        protected string Word(string englishWord)
        {
            return LocalizationService.TransalateFromEnglish(englishWord);
        }

        public virtual ValueTask DisposeAsync()
        {
            LocalizationService.OnCultureChanged -= HandleCultureChange;
            return default;
        }
    }
}
