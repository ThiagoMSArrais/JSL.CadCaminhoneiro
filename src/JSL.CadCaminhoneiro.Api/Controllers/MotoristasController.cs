using AutoMapper;
using JSL.CadCaminhoneiro.Api.Dto;
using JSL.CadCaminhoneiro.Domain.Models;
using JSL.CadCaminhoneiro.Domain.Notificacoes.Interface;
using JSL.CadCaminhoneiro.Domain.ServicesDomain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSL.CadCaminhoneiro.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/motoristas")]
    public class MotoristasController : MainController
    {
        private readonly IMotoristaServices _motoristaService;
        private readonly IMapper _mapper;

        public MotoristasController(IMotoristaServices motoristaService,
                                    IMapper mapper,
                                    INotificador notificador) : base(notificador)
        {
            _motoristaService = motoristaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MotoristaDto>> Get()
        {
            var motoristas = new List<MotoristaDto>();

            foreach(var itemMotorista in await _motoristaService.ObterMotoristas())
            {
                var motorista = _mapper.Map<MotoristaDto>(itemMotorista);
                motorista.CaminhaoDto = _mapper.Map<CaminhaoDto>(itemMotorista.Caminhao);
                motorista.EnderecoDto = _mapper.Map<EnderecoDto>(itemMotorista.Endereco);

                motoristas.Add(motorista);
            }

            return motoristas;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<MotoristaDto>> Get(Guid id)
        {
            var resultMotorista = await _motoristaService.ObterMotoristaPorId(id);

            var motorista = _mapper.Map<MotoristaDto>(resultMotorista);
            motorista.CaminhaoDto = _mapper.Map<CaminhaoDto>(resultMotorista.Caminhao);
            motorista.EnderecoDto = _mapper.Map<EnderecoDto>(resultMotorista.Endereco);

            return motorista;
        }

        [HttpPost]
        public async Task<ActionResult<MotoristaDto>> Post(MotoristaDto motoristaDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var motorista = _mapper.Map<Motorista>(motoristaDto);
            motorista.Endereco = _mapper.Map<Endereco>(motoristaDto.EnderecoDto);
            motorista.Caminhao = _mapper.Map<Caminhao>(motoristaDto.CaminhaoDto);

            await _motoristaService.Adicionar(motorista);

            return CustomResponse(motoristaDto);
        }

        [HttpPut]
        public async Task<ActionResult<MotoristaDto>> Put(MotoristaDto motoristaDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var motorista = _mapper.Map<Motorista>(motoristaDto);
            motorista.Endereco = _mapper.Map<Endereco>(motoristaDto.EnderecoDto);
            motorista.Caminhao = _mapper.Map<Caminhao>(motoristaDto.CaminhaoDto);

            await _motoristaService.Adicionar(_mapper.Map<Motorista>(motorista));

            return CustomResponse(motoristaDto);
        }

        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
            _motoristaService.Remover(id);
        }

    }
}
