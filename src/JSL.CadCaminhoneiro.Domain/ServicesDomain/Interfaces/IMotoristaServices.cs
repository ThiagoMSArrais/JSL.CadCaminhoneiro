using JSL.CadCaminhoneiro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JSL.CadCaminhoneiro.Domain.ServicesDomain.Interfaces
{
    public interface IMotoristaServices
    {
        Task<IEnumerable<Motorista>> ObterMotoristas();
        Task<Motorista> ObterMotoristaPorId(Guid idMotorista);
        Task<Motorista> Adicionar(Motorista motorista);
        Task<Motorista> Atualizar(Motorista motorista);
        void Remover(Guid idMotorista);
    }
}
