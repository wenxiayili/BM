using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using XueBao.BM.MultiTenancy.Dto;

namespace XueBao.BM.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultDto<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}
