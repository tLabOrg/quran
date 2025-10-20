using Microsoft.AspNetCore.Components;
using System.Text;
using System.Text.Json;

namespace quran.mobile.Components.Pages
{
    public class Surah
    {
        public int Index { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
    }

    public class Reciter
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Server { get; set; } = string.Empty;
        public List<int> Surahs { get; set; } = new List<int>();
    }

    public class Data
    {
        public List<Surah> Sorahs { get; set; } = new();
        public List<Reciter> Reciters { get; set; } = new();
    }

    public partial class Home
    {
        [Inject]
        NavigationManager Nav { get; set; }

        const string alphabet = "ابتثجحخدذرزسشصضطظعغفقكلمنهوي";
        //static string placeHolder { get { return "ابحث عن " + (State.isReciterSelected ? "سورة" : "قارئ") + " ..."; } }

        protected override async Task OnInitializedAsync()
        {
            await LoadData();
        }

        async Task LoadData()
        {
            var assembly = typeof(Home).Assembly;
            var resourceName = "quran.mobile.Data.data.json";

            using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                var names = string.Join(", ", assembly.GetManifestResourceNames());
                throw new FileNotFoundException($"Embedded resource '{resourceName}' not found. Available: {names}");
            }

            using var sr = new StreamReader(stream);
            var json = await sr.ReadToEndAsync();

            State.data = JsonSerializer.Deserialize<Data>(json) ?? new Data();
            State.data.Reciters.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
        }

        string NormalizeText(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) { return string.Empty; }
            var normalized = input.Normalize(NormalizationForm.FormD).Replace("ى", "ي");
            return normalized;
        }

        async Task OnReciterSelected(Reciter reciter)
        {
            State.selectedReciter = reciter;
            State.searchText = string.Empty;

            Nav.NavigateTo("surahs");
        }

        async Task OnSettingsPressed()
        {
            Nav.NavigateTo("settins");
        }
    }
}