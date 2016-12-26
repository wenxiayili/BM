using System.Reflection;
using System.Web.Http;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;
using Swashbuckle.Application;
using System.Linq;
using System;
using System.IO;

namespace XueBao.BM.Api
{
    [DependsOn(typeof(AbpWebApiModule), typeof(BMApplicationModule))]
    public class BMWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(BMApplicationModule).Assembly, "app")
                .Build();

            Configuration.Modules.AbpWebApi().HttpConfiguration.Filters.Add(new HostAuthenticationFilter("Bearer"));

            //调用ConfigureSwaggerUi--调试API
            ConfigureSwaggerUi();
        }

        private void ConfigureSwaggerUi()
        {
            Configuration.Modules.AbpWebApi().HttpConfiguration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "XueBao.BM API");
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                    //将应用层中的添加到Swaggerui中
                    var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

                    var commentsFileName = "Bin//XueBao.BM.Application.XML";
                    var commentsFile = Path.Combine(baseDirectory, commentsFileName);
                    //将注释的XML文档添加到SwaggerUI中
                    c.IncludeXmlComments(commentsFile);
                })
                .EnableSwaggerUi("apis/{*assetPath}",c =>
                {
                    c.InjectJavaScript(Assembly.GetExecutingAssembly(), "XueBao.BM.Scripts.translator.js");
                });

        }
    }
}
