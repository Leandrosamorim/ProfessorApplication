using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Domain.ProfessorNS.Interface;
using Data.Repositories;
using Domain.ProfessorNS.Service;
using Domain.TarefaNS.Interface;
using Domain.TarefaNS.Service;
using Domain.AtrasoNS.Interface;
using Domain.AtrasoNS.Service;
using Domain.FaltaNS.Interface;
using Domain.FaltaNS.Service;
using Domain.AvaliacaoNS.Service;
using Domain.AvaliacaoNS.Interface;
using Domain.Queue.Interface;
using Domain.Queue.Service;

namespace IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ProfessorContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<IAtrasoRepository, AtrasoRepository>();
            services.AddScoped<IFaltaRepository, FaltaRepository>();
            services.AddScoped<IAvaliacaoRepository, AvaliacaoRepository>();
            services.AddScoped<IProfessorService, ProfessorService>();
            services.AddScoped<ITarefaService, TarefaService>();
            services.AddScoped<IAtrasoService, AtrasoService>();
            services.AddScoped<IFaltaService, FaltaService>();
            services.AddScoped<IAvaliacaoService, AvaliacaoService>();
            services.AddScoped<IQueueService, QueueService>();
            return services;
        }
    }
}