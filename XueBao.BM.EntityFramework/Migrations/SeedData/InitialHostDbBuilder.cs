using XueBao.BM.EntityFramework;
using EntityFramework.DynamicFilters;

namespace XueBao.BM.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly BMDbContext _context;

        public InitialHostDbBuilder(BMDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
