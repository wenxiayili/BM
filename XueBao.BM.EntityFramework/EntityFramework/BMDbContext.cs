using System.Data.Common;
using Abp.Zero.EntityFramework;
using XueBao.BM.Authorization.Roles;
using XueBao.BM.MultiTenancy;
using XueBao.BM.Users;
using System.Data.Entity;
using XueBao.BM.NewsArticles;

namespace XueBao.BM.EntityFramework
{
    public class BMDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public IDbSet<News> News { get; set;}
        public IDbSet<NewsCategory> NewsCategories { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public BMDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in BMDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of BMDbContext since ABP automatically handles it.
         */
        public BMDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public BMDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
