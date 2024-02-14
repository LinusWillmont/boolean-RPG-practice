using RpgApi.Enums;
using RpgApi.Models;

namespace RpgApi.Repositories.PlayerRepos
{
    public interface IPlayerRepo
    {
        public Task<Character?> CreateCharacter(string playerId, string name, Class charClass);
        public Task<List<Character>> GetPlayersCharacters(string playerId);
    }
}
