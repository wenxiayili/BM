using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using XueBao.BM.Authorization;
using XueBao.BM.MultiTenancy;

namespace XueBao.BM.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Tenants)]
    public class TenantsController : BMControllerBase
    {
        private readonly ITenantAppService _tenantAppService;

        public TenantsController(ITenantAppService tenantAppService)
        {
            _tenantAppService = tenantAppService;
        }

        public ActionResult Index()
        {
            var output = _tenantAppService.GetTenants();
            return View(output);
        }
    }
}