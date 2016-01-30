using Buls.Models;

namespace Buls.Utilities
{
    public static class UserRoleUtilities
    {
        public static bool IsInRole(this User user, Role role)
        {
            bool isInRole = (user != null) && (user.Role == role);
            
            return isInRole;
        }
    }
}
