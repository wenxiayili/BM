using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using XueBao.BM.Authorization;
using Microsoft.AspNet.Identity;
using XueBao.BM.Users.DTOS;

namespace XueBao.BM.Users
{
    /// <summary>
    /// 用户服务
    /// </summary>
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class UserAppService : BMAppServiceBase, IUserAppService
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly IPermissionManager _permissionManager;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="permissionManager"></param>
        public UserAppService(IRepository<User, long> userRepository, IPermissionManager permissionManager)
        {
            
            _userRepository = userRepository;
            _permissionManager = permissionManager;
            
        }

        
        public async Task ProhibitPermission(ProhibitPermissionInput input)
        {
            var user = await UserManager.GetUserByIdAsync(input.UserId);
            var permission = _permissionManager.GetPermission(input.PermissionName);

            await UserManager.ProhibitPermissionAsync(user, permission);
        }

        
        public async Task RemoveFromRole(long userId, string roleName)
        {
            CheckErrors(await UserManager.RemoveFromRoleAsync(userId, roleName));
        }

        /// <summary>
        /// get all users
        /// </summary>
        /// <returns></returns>
        public async Task<ListResultDto<UserListDto>> GetUsers()
        {
           
            var users = await _userRepository.GetAllListAsync();

            return new ListResultDto<UserListDto>(
                users.MapTo<List<UserListDto>>()
                );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateUser(CreateUserInput input)
        {
            var user = input.MapTo<User>();

            user.TenantId = AbpSession.TenantId;
            user.Password = new PasswordHasher().HashPassword(input.Password);
            user.IsEmailConfirmed = true;

            CheckErrors(await UserManager.CreateAsync(user));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task UpdateUserPassWord(UpdateUserInput input)
        {
            var user = await UserManager.GetUserByIdAsync(input.Id);

            user.Password = new PasswordHasher().HashPassword(input.Password);

            CheckErrors(await UserManager.UpdateAsync(user));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DeleteUser(DeleteUserInput input)
        {
            var user = await UserManager.GetUserByIdAsync(input.UserId);
            CheckErrors(await UserManager.DeleteAsync(user));
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task GivePermissions(GivePermissionInput input)
        {
            var user = await UserManager.GetUserByIdAsync(input.UserId);

            var permission =  _permissionManager.GetPermission(input.PerminssionName);

            await UserManager.GrantPermissionAsync(user, permission);
        }
    }
}