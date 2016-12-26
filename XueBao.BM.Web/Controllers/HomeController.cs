using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace XueBao.BM.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : BMControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}