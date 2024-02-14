using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RpgApi.DTO;
using RpgApi.Helpers;
using RpgApi.Repositories.PlayerRepos;
using System.Security.Claims;

namespace RpgApi.Endpoints
{
    public static class PlayerEndpoints
    {
        public static void ConfigurePlayerEndpoints(this WebApplication app)
        {
            var players = app.MapGroup("/players");
            players.MapPost("/characters", CreateCharacter);
            players.MapGet("/characters", GetPlayerCharacters);
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateCharacter(IPlayerRepo repo, CreateCharacterPayload payload)
        {
            if (string.IsNullOrWhiteSpace(payload.Name)) { return TypedResults.BadRequest("Must choose a character name"); }
            if(string.IsNullOrWhiteSpace(payload.Class.ToString())) { return TypedResults.BadRequest("Must choose a class"); }
            string? playerId = ClaimsPrincipal.Current.PlayerId();

            var newCharacter = await repo.CreateCharacter(playerId, payload.Name, payload.Class);
            if (newCharacter == null) { return TypedResults.BadRequest("Failed to create character"); }
            return TypedResults.Created($"/players/characters/{newCharacter.Id}",newCharacter);
        }

        [Authorize]
        public static async Task<IResult> GetPlayerCharacters(IPlayerRepo repo)
        {
            string? playerId = ClaimsPrincipal.Current.PlayerId();
            var characters = await repo.GetPlayersCharacters(playerId);

            var returnCharacters = new List<AllPlayerCharactersResponseDTO>();
            foreach (var character in characters)
            {
                returnCharacters.Add(new AllPlayerCharactersResponseDTO(character));
            }

            return TypedResults.Ok(returnCharacters);
        }

    }
}
