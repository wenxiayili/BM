using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using XueBao.BM.Users;

namespace XueBao.BM.Sessions.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
