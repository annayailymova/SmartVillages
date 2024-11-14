using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;

namespace MON.Pages.MON;

public class Products : PageModel
{
    public Dictionary<string, List<string>> Categories { get; } = new();
    public Dictionary<string, ProductObj> Objects { get; } = new();

    public void OnGet()
    {
        DirectoryInfo d = new DirectoryInfo("wwwroot/products/MON");
        var files = d.GetFiles("*.json");
        
        foreach (var file in files)
        {
            Console.WriteLine(file.Name);
            var product = JsonSerializer.Deserialize<ProductObj>(System.IO.File.ReadAllText(Path.Combine(file.FullName)));
            if (product is null)
            {
                Console.WriteLine("Failed to parse");
                continue;
            }

            if (!Categories.ContainsKey(product.Supcategory))
                Categories.Add(product.Supcategory, new());
            
            Categories[product.Supcategory].Add(product.Title);
            
            Objects.Add(product.Supcategory + "+++" + product.Title, product);
        }
        
        
    }

    public record ProductObj(string Supcategory, string Title, string Id, string Icon, string Iframe, string Image, string Description);
}