using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Zack.Commons;

namespace ClassLibrary2
{
    public class ModuleInit : IModuleInitializer
    {
        public void Initialize(IServiceCollection services)
        {
            services.AddScoped<Class3>();
            services.AddScoped<Class4>();
        }
    }
}
