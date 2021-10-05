using FluentValidation.Results;
using JSL.CadCaminhoneiro.Domain.Notificacoes;
using JSL.CadCaminhoneiro.Domain.Notificacoes.Interface;

namespace JSL.CadCaminhoneiro.Domain.ServicesDomain
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;

        protected BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
