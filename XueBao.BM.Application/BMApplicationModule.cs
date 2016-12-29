using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using XueBao.BM.Users.DTOS;
using XueBao.BM.Users;

namespace XueBao.BM
{
    [DependsOn(typeof(BMCoreModule), typeof(BMAbpAutoMapperModule))]
    //[DependsOn(typeof(BMCoreModule), typeof(AbpAutoMapperModule))]
    public class BMApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().Configurators.Add(mapper =>
            {
                //Add your custom AutoMapper mappings here...
                //mapper.CreateMap<,>()

                //mapper.CreateMap<User, UserListDto>();
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
