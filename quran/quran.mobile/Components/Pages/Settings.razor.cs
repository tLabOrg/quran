using Microsoft.AspNetCore.Components;

namespace quran.mobile.Components.Pages
{
    public partial class Settings
    {
        [Inject]
        NavigationManager Nav { get; set; }

#if ANDROID
        const string url = "https://play.google.com/store/apps/details?id=org.arbweb.moratal";

#elif WINDOWS
        const string url = "ms-windows-store://pdp/?productid=9P4V496BSCWP";
#endif

        async Task OnBackPressed()
        {
            Nav.NavigateTo("/");
        }

        async Task OnRatePressed()
        {
            await Launcher.OpenAsync(url);
        }

        async Task OnSupportPressed() 
        {
            await Launcher.OpenAsync("https://arbweb.org/support_proj.html");
        }

        async Task OnChatPressed()
        {
            await Launcher.OpenAsync("https://wa.me/201031160910");
        }

        async Task OnSharePressed()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Title = "مشاركة تطبيق المصحف المرتل",
                Text = url
            });
        }
    }
}