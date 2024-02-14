using exercise.minimalapi.Utils;
using Microsoft.AspNetCore.Identity;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.ExpressionTranslators.Internal;
using RpgApi.Models;

namespace RpgApi.Repositories.PlayersRepos
{
    public class AuthRepo : IAuthRepo
    {
        private UserManager<Player> _userManager;
        private TokenService _tokenService;
        public AuthRepo(UserManager<Player> userManager, TokenService tokenService) 
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }
        public async Task<Player?> GetPlayerAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null) { return null; }
            return user;
        }

        public async Task<Tuple<Player, string>?> LoginPlayerAsync(string userName, string password)
        {
            var player = await GetPlayerAsync(userName);
            if(player == null) { return null; };
            var isPasswordValid = await _userManager.CheckPasswordAsync(player, password);
            if (!isPasswordValid) { return null; }


            var accessToken = _tokenService.CreateToken(player);
            return new Tuple<Player,string>(player, accessToken);
        }

        public async Task<Player?> RegisterPlayerAsync(string userName, string email, string password)
        {
            var result = await _userManager.CreateAsync(new Player
            {
                UserName = userName,
                Email = email,                
            },
            password!);

            if ( !result.Succeeded ) { throw new Exception("Failed to register player"); }

            var newPlayer = await GetPlayerAsync(userName);
            return newPlayer;

        }
    }
}
