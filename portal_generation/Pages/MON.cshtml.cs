using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace MON.Pages;

public class MONPage : PageModel
{
    public List<Publication> Publications { get; private set; } = new();

    public void OnGet()
    {
        string localFile = "E:\\Work\\MON-KPI\\MON\\wwwroot\\references\\MON.json";
        Publications = JsonSerializer.Deserialize<List<Publication>>(System.IO.File.ReadAllText(localFile));
    }

    public record Publication(string Title, string Authors, string Location, string Doi);
}