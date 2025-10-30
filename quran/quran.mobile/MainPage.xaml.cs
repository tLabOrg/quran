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
            string indexStr = index.ToString("000");
            string fullUrl = $"{server}{indexStr}.mp3";
            player.Source = MediaSource.FromUri(fullUrl);
            player.MetadataTitle = surah;
            player.MetadataArtist = reciter;
        }

        public async Task Play()
        {
            player.Play();
        }

        public async Task Pause()
        {
            player.Pause();
        }

        public async Task Stop()
        {
            player.Stop();
        }
    }
}