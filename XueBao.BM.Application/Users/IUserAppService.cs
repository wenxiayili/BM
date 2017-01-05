using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using XueBao.BM.Users.DTOS;
using System.Collections.Generic;

namespace XueBao.BM.Users
{
    public interface IUserAppService : IApplicationService
    {
        /// <summary>
        /// prohibit user's the permission
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task ProhibitPermission(ProhibitPermissionInput input);

        /// <summary>
        /// remove the user from role
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        Task RemoveFromRole(long userId, string roleName);

        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        Task<ListResultDto<UserListDto>> GetUsers();

        /// <summary>
        /// create user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task CreateUser(CreateUserInput input);

        /// <summary>
        /// update user's password
        /// </summary>
        /// <returns></returns>
        Task UpdateUserPassWord(UpdateUserInput input);

        /// <summary>
        /// delete user if id = input.UserId
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task DeleteUser(EntityDto input);

        /// <summary>
        /// give permission for user
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task GivePermissions(GivePermissionInput input);

        /// <summary>
        /// Batch delete User.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task BatchDeleteUsersAsync(IEnumerable<long> input);

        /// <summary>
        /// ÷ÿ÷√»®œﬁ
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task ResetPermission(ResetPermissionInput input);
    }
}