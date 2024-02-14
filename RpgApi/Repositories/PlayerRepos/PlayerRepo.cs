using Microsoft.EntityFrameworkCore;
using RpgApi.Data;
using RpgApi.Enums;
using RpgApi.Models;

namespace RpgApi.Repositories.PlayerRepos
{
    public class PlayerRepo : IPlayerRepo
    {
        RpgContext _db;
        public PlayerRepo(RpgContext db) 
        { 
            _db = db;
        }

        public async Task<Character?> CreateCharacter(string playerId, string name, Class charClass)
        {
            var newCharacter = await _db.CharacterDB.AddAsync(new Character { Player_Id = playerId, Name = name, Class = charClass });
            if(newCharacter == null) { return null; }
            await _db.SaveChangesAsync();
            return newCharacter.Entity;
        }

        public async Task<List<Character>> GetPlayersCharacters(string playerId)
        {
            var characters = await _db.CharacterDB.Where( c => c.Player_Id == playerId ).ToListAsync();
            return characters;
        }
    }
}
