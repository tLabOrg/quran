using Microsoft.AspNetCore.Components;
using System.Text;

namespace quran.mobile.Components.Pages
{
    public partial class SurahsList
    {
        [Inject]
        NavigationManager Nav { get; set; }

        string NormalizeText(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) { return string.Empty; }
            var normalized = input.Normalize(NormalizationForm.FormD).Replace("ى", "ي");
            return normalized;
        }

        async Task OnSorahSelected(Surah surah)
        {
            var mainPage = (MainPage)App.Current.MainPage;
            mainPage?.LoadSorah(State.selectedReciter.Server, surah.Index, surah.Name, State.selectedReciter.Name);
            
            await OnBackPressed();
        }

        async Task OnBackPressed()
        {
            State.searchText = string.Empty;
            Nav.NavigateTo("/");
        }

        async Task OnSettingsPressed()
        {
            Nav.NavigateTo("settins");
        }
    }
}