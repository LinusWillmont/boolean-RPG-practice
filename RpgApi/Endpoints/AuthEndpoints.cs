using Microsoft.AspNetCore.Mvc;
using RpgApi.DTO;
using RpgApi.Repositories.PlayersRepos;

namespace RpgApi.Endpoints
{
    public static class AuthEndpoints
    {
        public static void ConfigureAuthEndpoints(this WebApplication app)
        {
            var auth = app.MapGroup("/auth");
            auth.MapPost("/register", RegisterPlayer);
            auth.MapPost("/login", LoginPlayer);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> RegisterPlayer(IAuthRepo repo, RegisterPayloadDTO payload)
        {
            if(string.IsNullOrWhiteSpace(payload.Username)) { return TypedResults.BadRequest("Username is required"); }
            if (string.IsNullOrWhiteSpace(payload.Email)) { return TypedResults.BadRequest("Email is required"); }
            if (string.IsNullOrWhiteSpace(payload.Password)) { return TypedResults.BadRequest("Password is required"); }

            var user = await repo.RegisterPlayerAsync(payload.Username, payload.Email, payload.Password);
            if(user == null) { TypedResults.BadRequest("Failed to register user"); }

            return TypedResults.Created($"/players/{user.Id}",new RegisteredReturnDTO { Username = user.UserName, Email = user.Email});
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> LoginPlayer(IAuthRepo repo, LoginPayloadDTO payload)
        {
            if (string.IsNullOrWhiteSpace(payload.Username)) return TypedResults.BadRequest("Username is required");
            if (string.IsNullOrWhiteSpace(payload.Password)) return TypedResults.BadRequest("Password is required");

            var result = await repo.LoginPlayerAsync(payload.Username, payload.Password);
            if(result == null) { return TypedResults.BadRequest("Email or password is wrong"); }

            var user = result.Item1;
            var token = result.Item2;

            return TypedResults.Ok(new LoginReturnDTO { Username = user.UserName, Token = token});
        }
    }
}
