using RpgApi.Enums;

namespace RpgApi.DTO
{
    public record PlayerRegisterPayloadDTO 
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

	public record PlayerRegisterReturnDTO
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
    }
}