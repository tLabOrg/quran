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
    }
}