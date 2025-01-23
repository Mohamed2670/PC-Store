
using System.Security.Claims;
using ServerSide.Model;

namespace ServerSide.Authentication
{
    public class UserAccessToken(IHttpContextAccessor _httpContextAccessor)
    {
        public bool IsAuthenticated(int entityId)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null)
            {
                return false;
            }
            Console.WriteLine("sdsa : " + user.IsInRole("admin"));
            var role = user.FindFirst(ClaimTypes.Role)?.Value;
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = user.FindFirst(ClaimTypes.Email)?.Value;
            var storeId = user.FindFirst("StoreId")?.Value;
            if (role == "Admin")
                return true;
            if(storeId == entityId.ToString()){
                return true;
            }
            
            return false;
        }
        public bool IsAuthenticatedUser(int userId)
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user == null)
            {
                return false;
            }
            var personId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = user.FindFirst(ClaimTypes.Role)?.Value;
            if (role == "Admin")
            {
                return true;
            }
            if (personId != userId.ToString())
            {
                return false;
            }
            return true;

        }
    }
}