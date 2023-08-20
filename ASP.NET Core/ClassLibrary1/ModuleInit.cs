using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Zack.Commons;

namespace ClassLibrary1
{
    /// <summary>
    /// 项目各自注册各自的服务
    /// </summary>
    public class ModuleInit : IModuleInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddScoped<Class1>();
            services.AddScoped<Class2>();
        }
    }
}
