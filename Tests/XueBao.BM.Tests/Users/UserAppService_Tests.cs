using Shouldly;
using System.Data.Entity;
using System.Threading.Tasks;
using XueBao.BM.Users;
using XueBao.BM.Users.DTOS;
using Xunit;

namespace XueBao.BM.Tests.Users
{
    public class UserAppService_Tests : BMTestBase
    {
        private readonly IUserAppService _userAppService;

        public UserAppService_Tests()
        {
            _userAppService = Resolve<IUserAppService>();
        }

        [Fact]
        public async Task GetUsers_Test()
        {
            //Act
            var output = await _userAppService.GetUsers();

            //Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task CreateUser_Test()
        {
            //Act
            await _userAppService.CreateUser(
                new CreateUserInput
                {
                    EmailAddress = "john@volosoft.com",
                    IsActive = true,
                    Name = "John",
                    Surname = "Nash",
                    Password = "123qwe",
                    UserName = "john.nash"
                });

            await UsingDbContextAsync(async context =>
            {
                var johnNashUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == "john.nash");
                johnNashUser.ShouldNotBeNull();
            });
        }

        [Fact]
        public async Task UpdateUser_Test()
        {
            //Act
            await _userAppService.UpdateUserPassWord(

                  new UpdateUserInput
                  {
                      Id = 2,
                      Password = "1234"
                  }
                );

            await UsingDbContextAsync(async context =>
            {
                var j = await context.Users.FirstOrDefaultAsync(u => u.Id == 2);
                j.Password.ShouldBe("1234");
            });
        }

     
    }
}