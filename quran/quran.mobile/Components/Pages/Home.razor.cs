using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text;
using System.Text.Json;

namespace quran.mobile.Components.Pages
{
    public class Reader
    {
        public string Name { get; set; } = string.Empty;
        public string URL { get; set; } = string.Empty;
    }

    public partial class Home : ComponentBase
    {
        [Inject]
        public IJSRuntime JS { get; set; } = default!;

        const string alphabet = "ابتثجحخدذرزسشصضطظعغفقكلمنهوي";
        protected List<Reader> readers { get; private set; } = new();
        string searchText = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await LoadReadersFromEmbeddedJsonAsync();
        }

        private async Task LoadReadersFromEmbeddedJsonAsync()
        {
            var assembly = typeof(Home).Assembly;

            // Use the embedded resource name: <DefaultNamespace>.<folder>.<file>
            // Adjust if your project's root namespace differs.
            var resourceName = "quran.mobile.Data.readers.json";

            // If this returns null, inspect available names:
            // var names = assembly.GetManifestResourceNames();
            using var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null)
            {
                var names = string.Join(", ", assembly.GetManifestResourceNames());
                throw new FileNotFoundException($"Embedded resource '{resourceName}' not found. Available: {names}");
            }

            using var sr = new StreamReader(stream);
            var json = await sr.ReadToEndAsync();

            readers = JsonSerializer.Deserialize<List<Reader>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }) ?? new List<Reader>();

            readers.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
        }

        string NormalizeText(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) { return string.Empty; }
            var normalized = input.Normalize(NormalizationForm.FormD).Replace("ى", "ي");
            return normalized;
        }

        public async Task ShowUrlAsync(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                await JS.InvokeVoidAsync("alert", "No URL available for this reader.");
                return;
            }

            await JS.InvokeVoidAsync("alert", url);
        }
    }
}