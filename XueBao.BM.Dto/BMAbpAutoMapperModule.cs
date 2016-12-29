using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Reflection;
using System.Reflection;

namespace XueBao.BM
{
    public class BMAbpAutoMapperModule : AbpAutoMapperModule
    {
        public BMAbpAutoMapperModule(ITypeFinder typeFinder) : base(typeFinder)
        {
            
        }
    }
}
