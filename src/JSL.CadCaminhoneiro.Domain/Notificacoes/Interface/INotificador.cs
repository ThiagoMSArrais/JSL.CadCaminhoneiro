using System.Collections.Generic;

namespace JSL.CadCaminhoneiro.Domain.Notificacoes.Interface
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
