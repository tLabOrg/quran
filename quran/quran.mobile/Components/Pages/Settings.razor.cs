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

        async Task OnRatePressed()
        {
            string url = string.Empty;
#if ANDROID
            url = "https://play.google.com/store/apps/details?id=org.arbweb.moratal";
#elif IOS
            url = "https://apps.apple.com/us/app/moratal/id310633997";
#elif WINDOWS
            url = "ms-windows-store://pdp/?productid=9NC0NPGCRXRH";
#endif
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
                Text = "https://play.google.com/store/apps/details?id=org.arbweb.moratal"
            });
        }
    }
}