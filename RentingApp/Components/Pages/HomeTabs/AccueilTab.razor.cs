namespace RentingApp.Components.Pages.HomeTabs
{
    public partial class AccueilTab
    {

        private int _selectedIndex = 0;
        private CancellationTokenSource? cancelTokenAnim;

        // Textes à afficher
        private string _displayedText = "";
        private string _targetText = "";// Texte pour la 1ere image

        private string _displayedText2 = "";
        private string _targetText2 = ""; // Texte pour la 2ème image

        private string _displayedText3 = "";
        private string _targetText3 = ""; // Texte pour la 3ème image

        private string _displayedText4 = "";
        private string _targetText4 = ""; // Texte pour la 4ème image

        protected override void OnInitialized() 
        {
            base.OnInitialized();

            //init des textes a afficher sur les images
            UpdateTargetTexts();

            // on s'abonne a la culture changed , le state.haschanged suffit pas
            LocalizationService.OnCultureChanged += HandleLanguageChanged;
        }
        public override async ValueTask DisposeAsync()
        {
            LocalizationService.OnCultureChanged -= HandleLanguageChanged;
            await base.DisposeAsync();
        }

        private void UpdateTargetTexts()
        {
            _targetText2 = Word("An exeptional view");
            _targetText3 = Word("100m next to l'Autre Bord beach");
        }

        /// <summary>
        /// Déclenché quand la langue change. Met à jour les textes et relance l'animation.
        /// </summary>
        private void HandleLanguageChanged()
        {
            UpdateTargetTexts();

            // On relance l'animation sur la slide actuelle pour afficher le texte dans la nouvelle langue
            InvokeAsync(() => StartAnimationForIndex(_selectedIndex));
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // Lance l'animation pour la première slide au chargement
                await StartAnimationForIndex(0);
            }
        }

        private async Task OnSlideChanged(int index)
        {
            _selectedIndex = index;
            await StartAnimationForIndex(index);
        }

        private async Task StartAnimationForIndex(int index)
        {
            // 1. Annuler l'animation en cours (si on change de slide rapidement)
            cancelTokenAnim?.Cancel();
            cancelTokenAnim = new CancellationTokenSource();
            CancellationToken token = cancelTokenAnim.Token;

            // 2. Réinitialiser les textes (effacer l'écran)
            _displayedText = "";
            _displayedText2 = "";
            _displayedText3 = "";
            _displayedText4 = "";

            StateHasChanged();

            try
            {
                // 3. Lancer l'animation correspondant à l'index
                if (index == 0)
                {
                    await AnimateText(_targetText, s => _displayedText = s, token);
                }
                else if (index == 1)
                {
                    await AnimateText(_targetText2, s => _displayedText2 = s, token);
                }
                else if (index == 2)
                {
                    await AnimateText(_targetText3, s => _displayedText3 = s, token);
                }
                else if (index == 3)
                {
                    await AnimateText(_targetText4, s => _displayedText4 = s, token);
                }
            }
            catch (TaskCanceledException)
            {
                // L'animation a été stoppée car on a changé de slide, c'est normal.
            }
        }

        /// <summary>
        /// Animates the display of the specified text by progressively revealing each character and invoking a callback
        /// with the current state.
        /// </summary>
        /// <remarks>If the operation is canceled via the provided cancellation token, the animation stops
        /// immediately and no further updates are made.</remarks>
        /// <param name="target">The target string to animate. Each character will be revealed in sequence.</param>
        /// <param name="updateAction">An action to invoke with the current substring as the animation progresses. This callback is called after
        /// each character is added.</param>
        /// <param name="token">A cancellation token that can be used to cancel the animation before it completes.</param>
        /// <returns></returns>
        private async Task AnimateText(string target, Action<string> updateAction, CancellationToken token)
        {
            string current = "";
            await Task.Delay(250);
            foreach (var character in target)
            {
                // Vérifie si on doit annuler
                token.ThrowIfCancellationRequested();

                current += character;

                //on lance l'action
                updateAction(current);
                StateHasChanged();

                // Délai entre chaque lettre
                await Task.Delay(50, token);
            }
        }
    }
}
