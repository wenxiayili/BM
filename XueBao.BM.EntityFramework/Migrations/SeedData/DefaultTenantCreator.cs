using System.Linq;
using XueBao.BM.EntityFramework;
using XueBao.BM.MultiTenancy;

namespace XueBao.BM.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly BMDbContext _context;

        public DefaultTenantCreator(BMDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
