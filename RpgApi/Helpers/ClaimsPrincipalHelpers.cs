using System.Security.Claims;

namespace RpgApi.Helpers
{
    public static class ClaimsPrincipalHelpers
    {
        public static string? PlayerId(this ClaimsPrincipal player)
        {
            Claim? claim = player.FindFirst(ClaimTypes.NameIdentifier);
            return claim?.Value;
        }
    }
}
