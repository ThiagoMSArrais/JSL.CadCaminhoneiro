using JSL.CadCaminhoneiro.Core.Models;
using FluentValidation;
using System;

namespace JSL.CadCaminhoneiro.Domain.Models
{
    public class Motorista : Entity<Motorista>
    {
        public string Nome { get; set; }

        public Guid? IdCaminhoneiro { get; set; }
        public Caminhao Caminhao { get; set; }
        public Guid? IdEndereco { get; set; }
        public Endereco Endereco { get; set; }

        #region validacoes
        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarNome();
            ValidationResult = Validate(this);
        }

        private void ValidarNome()
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("Informe o nome do motorista.")
                .Length(3, 80).WithMessage("Informe o nome do motorista entre 3 a 80 caracteres.");
        }
        #endregion
    }
}
