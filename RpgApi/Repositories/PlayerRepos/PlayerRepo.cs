using exercise.minimalapi.Utils;
using Microsoft.AspNetCore.Identity;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using RpgApi.Models;

namespace RpgApi.Repositories.PlayersRepos
{
    public class PlayerRepo : IPlayerRepo
    {
        private UserManager<Player> _userManager;
        private TokenService _tokenService;
        public PlayerRepo(UserManager<Player> userManager, TokenService tokenService) 
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<Player?> GetPlayerAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync( email );
            if (user == null) { return null; }
            return user;
        }

        public async Task<Tuple<Player, string>?> LoginPlayerAsync(string email, string password)
        {
            var player = await GetPlayerAsync(email);
            if(player == null) { return null; };
            var isPasswordValid = await _userManager.CheckPasswordAsync(player, password);
            if (!isPasswordValid) { return null; }


            var accessToken = _tokenService.CreateToken(player);
            return new Tuple<Player,string>(player, accessToken);

        }

        public async Task<Player?> RegisterPlayerAsync(string username, string email, string password)
        {
            var result = await _userManager.CreateAsync(new Player
            {
                UserName = username,
                Email = email,                
            },
            password!);

            if ( !result.Succeeded ) { throw new Exception("Failed to register player"); }

            var newPlayer = await GetPlayerAsync(email);
            return newPlayer;

        }
    }
}
