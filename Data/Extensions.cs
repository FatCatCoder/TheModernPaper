using ModernPaper.Contexts;
// using Microsoft.Extensions.Hosting;

namespace ModernPaper.Data
{
    public static class Extensions
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    
                    if (context.Database.EnsureCreated())
                    {
                        DbSeed.Initialize(context);
                    }
                }
            }
        }
    }
}