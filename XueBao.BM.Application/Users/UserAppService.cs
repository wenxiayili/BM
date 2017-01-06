using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.UI;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XueBao.BM.Authorization;
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
            var user = await _userRepository.GetAsync(input.Id);

            user.Password = new PasswordHasher().HashPassword(input.Password);

            CheckErrors(await UserManager.UpdateAsync(user));
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DeleteUser(EntityDto input)
        {
            //user do not delete His own
            var userId = AbpSession.UserId;
            var user = _userRepository.Get(input.Id);
            if (userId == input.Id || user == null)
            {
                //这里不应该有UI层代码
                throw new UserFriendlyException("您不能删除自己");
            }
            else
            {
                await _userRepository.DeleteAsync(input.Id);
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task GivePermissions(GivePermissionInput input)
        {
            var user = await UserManager.GetUserByIdAsync(input.UserId);

            var permission = _permissionManager.GetPermission(input.PerminssionName);

            await UserManager.GrantPermissionAsync(user, permission);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task BatchDeleteUsersAsync(IEnumerable<long> input)
        {
            if (input.Contains((long)AbpSession.UserId))
            {
                throw new UserFriendlyException("you can not delete yourself");
            }

            foreach (var item in input)
            {
                var user = await UserManager.GetUserByIdAsync(item);
                continue;
            }

            await _userRepository.DeleteAsync(
                (s) =>

                   input.Contains(s.Id)
           );
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public async Task ResetPermission(ResetPermissionInput input)
        {
            //get user
            var user = _userRepository.Get(input.id);

            //reset user permission
            await UserManager.ResetAllPermissionsAsync(user);

            //get permission
            IEnumerable<Permission> permission;

            List<Permission> tt = new List<Permission>();
            foreach (var item in input.PermissionName)
            {
                var _permission = _permissionManager.GetPermission(item);
                tt.Add(_permission);
            }

            permission = tt;

            //granted Permission
            await UserManager.SetGrantedPermissionsAsync(user, permission);
        }
    }
}