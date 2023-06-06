using Infraestructure.Core.Context;
using Infraestructure.Core.Repository;
using Infraestructure.Core.Repository.Inerface;
using Infraestructure.Core.UnitOfWork;
using Infraestructure.Core.UnitOfWork.Interface;
using Lab.Domain.Services;
using Lab.Domain.Services.Interfaces;

namespace MyLabApp.Handlers
{
    public static class DependencyInyectionHandler
    {
        public static void DependencyInyectionConfig(IServiceCollection services)
        {

            // Infrastructure
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<SeedDb>();

            //Domain
            services.AddTransient<ISkillServices, SkillServices>();

            services.AddTransient<IUserServices, UserServices>();

            services.AddTransient<IProfileServices, ProfileServices>();

            services.AddTransient<IRoleServices, RoleServices>();

            services.AddTransient<IJobPositionServices, JobPositionServices>();

            services.AddTransient<IWorkTypeServices, WorkTypeServices>();

        }
    }
}
