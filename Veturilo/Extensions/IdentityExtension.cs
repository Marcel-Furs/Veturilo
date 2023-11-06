using System.Security.Claims;

namespace Veturilo.API.Extensions
{
    public static class IdentityExtension
    {
        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            string userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return int.Parse(userId);
        }
    }
}
