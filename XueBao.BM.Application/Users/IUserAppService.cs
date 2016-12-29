using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using XueBao.BM.Users.DTOS;

namespace XueBao.BM.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);

        Task<ListResultDto<UserListDto>> GetUsers();

        Task CreateUser(CreateUserInput input);
    }
}