using System.Threading.Tasks;
using Abp.Application.Services;
using XueBao.BM.Roles.Dto;

namespace XueBao.BM.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
