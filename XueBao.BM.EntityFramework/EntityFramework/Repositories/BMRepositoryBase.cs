using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace XueBao.BM.EntityFramework.Repositories
{
    public abstract class BMRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<BMDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected BMRepositoryBase(IDbContextProvider<BMDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class BMRepositoryBase<TEntity> : BMRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected BMRepositoryBase(IDbContextProvider<BMDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
