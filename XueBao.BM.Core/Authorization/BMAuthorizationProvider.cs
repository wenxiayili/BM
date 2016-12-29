using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace XueBao.BM.Authorization
{
    public class BMAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //Common permissions
            var pages = context.GetPermissionOrNull(PermissionNames.Pages);
            if (pages == null)
            {
                pages = context.CreatePermission(PermissionNames.Pages, L("Pages"));
            }

            var users = pages.CreateChildPermission(PermissionNames.Pages_Users, L("Users"));

            //Page_Users页面下的 创建用户 的权限
            var createNewUser = users.CreateChildPermission(PermissionNames.Pages_Users_CreateNewUser, L("CreateNewUser"));
            

            //Host permissions
            var tenants = pages.CreateChildPermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, BMConsts.LocalizationSourceName);
        }
    }
}
