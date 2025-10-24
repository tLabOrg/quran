using Microsoft.AspNetCore.Components;

namespace quran.mobile.Components.Pages
{
    public partial class Settings
    {
        [Inject]
        NavigationManager Nav { get; set; }

        async Task OnBackPressed()
        {
            Nav.NavigateTo("/");
        }

        async Task OnChatPressed()
        {
            await Launcher.OpenAsync("https://wa.me/201031160910");
        }
    }
}