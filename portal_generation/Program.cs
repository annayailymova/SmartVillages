using AspNetStatic;

namespace MON;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSingleton<IStaticResourcesInfoProvider>(
            new StaticResourcesInfoProvider(
                new ResourceInfoBase []
                {
                    new PageResource("/Index"),
                    new PageResource("/MON"),
                    // new PageResource("/Interactive.e"),
                    new PageResource("/MON/Products"),
                }));

        builder.Services.AddControllersWithViews();
        builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
        
        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();
        
        app.MapRazorPages();
        
        app.GenerateStaticContent(@"E:\Work\MON-KPI\gen");
        app.Run();
    }
}