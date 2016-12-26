using Abp.Authorization;
using XueBao.BM.Authorization.Roles;
using XueBao.BM.MultiTenancy;
using XueBao.BM.Users;

namespace XueBao.BM.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
