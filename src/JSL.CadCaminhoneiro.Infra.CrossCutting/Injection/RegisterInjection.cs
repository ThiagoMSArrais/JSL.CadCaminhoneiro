using JSL.CadCaminhoneiro.Domain.Models.Interfaces;
using JSL.CadCaminhoneiro.Domain.Notificacoes;
using JSL.CadCaminhoneiro.Domain.Notificacoes.Interface;
using JSL.CadCaminhoneiro.Domain.ServicesDomain;
using JSL.CadCaminhoneiro.Domain.ServicesDomain.Interfaces;
using JSL.CadCaminhoneiro.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace JSL.CadCaminhoneiro.Infra.CrossCutting.Injection
{
    public static class RegisterInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMotoristaServices, MotoristaServices>();
            services.AddScoped<IMotoristaRepository, MotoristaRepository>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
