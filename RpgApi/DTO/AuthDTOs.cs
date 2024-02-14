using RpgApi.Enums;

namespace RpgApi.DTO
{
    public record RegisterPayloadDTO 
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }

	public record RegisteredReturnDTO
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
    }

    public record LoginPayloadDTO
    {
        public required string Username { get; set;}
        public required string Password { get; set;}
    }
    public record LoginReturnDTO
    {
        public required string Username { get; set; }
        public required string Token { get; set; }
    }

}