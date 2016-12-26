using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using XueBao.BM.EntityFramework;

namespace XueBao.BM.Migrator
{
    [DependsOn(typeof(BMDataModule))]
    public class BMMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<BMDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}