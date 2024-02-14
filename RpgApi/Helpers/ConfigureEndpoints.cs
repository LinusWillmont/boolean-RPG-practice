using RpgApi.Endpoints;

namespace RpgApi.Helpers
{
    public static class ConfigureEndpoints
    {
        public  static void ConfigureAllEndpoints(this WebApplication app) 
        {
            app.ConfigureAuthEndpoints();
            app.ConfigurePlayerEndpoints();
        }
    }
}
