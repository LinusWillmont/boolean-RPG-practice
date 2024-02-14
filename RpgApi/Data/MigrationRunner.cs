using Microsoft.EntityFrameworkCore;
using RpgApi.Data;

namespace exercise.wwwapi.Data
{
    public static class MigrationRunner
    {
        public static void ApplyProjectMigrations(this WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<RpgContext>();
                db.Database.Migrate();
            }

        }
    }
}
