using RpgApi.Enums;
using RpgApi.Models;

namespace RpgApi.DTO
{
    public record CreateCharacterPayload
    {
        //TODO FETCH the logged in users id
        //public required string PlayerId {  get; set; }
        public required string Name { get; set; }
        public Class Class { get; set; }
    }

    public record AllPlayerCharactersResponseDTO
    {
        public string Name { get; set; }
        public Class Class { get; set; }
        public int Level { get; set; }
        public AllPlayerCharactersResponseDTO(Character character)
        {
            Name = character.Name;
            Class = character.Class;
            Level = character.Level;
        }
    }
}
