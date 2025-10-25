using quran.mobile.Components.Pages;

namespace quran.mobile
{
    public static class State
    {
        public static Data data { get; set; } = new();
        public static string searchText = string.Empty;
        public static Reciter? selectedReciter = null;

        public static void Reset()
        {
            data = new Data();
            searchText = string.Empty;
            selectedReciter = null;
        }
    }
}