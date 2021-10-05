using JSL.CadCaminhoneiro.Domain.Models;
using JSL.CadCaminhoneiro.Domain.Models.Interfaces;
using JSL.CadCaminhoneiro.Domain.Notificacoes.Interface;
using JSL.CadCaminhoneiro.Domain.ServicesDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSL.CadCaminhoneiro.Domain.ServicesDomain
{
    public class MotoristaServices : BaseService, IMotoristaServices
    {
        private readonly IMotoristaRepository _motoristaRepository;

        public MotoristaServices(IMotoristaRepository motoristaRepository,
                                 INotificador notificador) : base(notificador)
        {
            _motoristaRepository = motoristaRepository;
        }

        public async Task<Motorista> Adicionar(Motorista motorista)
        {
            if (!motorista.EhValido())
                Notificar(motorista.ValidationResult);
            
            return await _motoristaRepository.Adicionar(motorista);
        }

        public async Task<Motorista> Atualizar(Motorista motorista)
        {
            if (!motorista.EhValido())
                Notificar(motorista.ValidationResult);

            return await _motoristaRepository.Atualizar(motorista);
        }

        public async Task<Motorista> ObterMotoristaPorId(Guid idMotorista)
        {
            return await _motoristaRepository.ObterMotoristaPorId(idMotorista);
        }

        public async Task<IEnumerable<Motorista>> ObterMotoristas()
        {
            return await _motoristaRepository.ObterMotoristas();
        }

        public void Remover(Guid idMotorista)
        {
            _motoristaRepository.Remover(idMotorista);
        }
    }
}
