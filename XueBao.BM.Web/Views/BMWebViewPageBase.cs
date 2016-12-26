using Abp.Web.Mvc.Views;

namespace XueBao.BM.Web.Views
{
    public abstract class BMWebViewPageBase : BMWebViewPageBase<dynamic>
    {

    }

    public abstract class BMWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected BMWebViewPageBase()
        {
            LocalizationSourceName = BMConsts.LocalizationSourceName;
        }
    }
}