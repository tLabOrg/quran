using CommunityToolkit.Maui.Views;
using quran.mobile.Components.Pages;

namespace quran.mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public async Task LoadSorah(string server, int index, string surah, string reciter)
        {
            string fullUrl = $"{server}{index.ToString("000")}.mp3";
            player.Source = MediaSource.FromUri(fullUrl);
            player.MetadataTitle = surah;
            player.MetadataArtist = reciter;
        }
    }
}