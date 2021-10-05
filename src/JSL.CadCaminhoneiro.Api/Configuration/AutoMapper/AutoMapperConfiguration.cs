using AutoMapper;
using JSL.CadCaminhoneiro.Api.Dto;
using JSL.CadCaminhoneiro.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace JSL.CadCaminhoneiro.Api.Configuration.AutoMapper
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<MotoristaDto, Motorista>().ReverseMap();
            CreateMap<CaminhaoDto, Caminhao>().ReverseMap();
            CreateMap<EnderecoDto, Endereco>().ReverseMap();
            
        }
    }

    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfig(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new AutoMapperConfiguration());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
