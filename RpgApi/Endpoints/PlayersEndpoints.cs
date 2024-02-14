using RpgApi.DTO;
using RpgApi.Repositories.PlayersRepos;

namespace RpgApi.Endpoints
{
    public static class PlayersEndpoints
    {
        public static void ConfigurePlayersEndpoints(this WebApplication app)
        {
            var players = app.MapGroup("/players");
            players.MapPost("", RegisterPlayer);
        }

        public static async Task<IResult> RegisterPlayer(IPlayerRepo repo, PlayerRegisterPayloadDTO payload)
        {
            if(string.IsNullOrWhiteSpace(payload.Username)) { return TypedResults.BadRequest("Username is required"); }
            if (string.IsNullOrWhiteSpace(payload.Email)) { return TypedResults.BadRequest("Email is required"); }
            if (string.IsNullOrWhiteSpace(payload.Password)) { return TypedResults.BadRequest("Password is required"); }

            var user = await repo.RegisterPlayerAsync(payload.Username, payload.Email, payload.Password);
            if(user == null) { TypedResults.BadRequest("Failed to register user"); }

            return TypedResults.Ok(new PlayerRegisterReturnDTO { Username = user.UserName, Email = user.Email});
        }
    }
}
