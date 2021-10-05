using JSL.CadCaminhoneiro.Core.Models;
using FluentValidation;
using System;

namespace JSL.CadCaminhoneiro.Domain.Models
{
    public class Caminhao : Entity<Caminhao>
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Eixo { get; set; }
        public Guid? IdMotorista { get; set; }

        #region validacoes

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarMarca();
            ValidarModelo();
            ValidarPlaca();
            ValidarEixo();

            ValidationResult = Validate(this);
        }

        private void ValidarMarca()
        {
            RuleFor(e => e.Marca)
                .NotEmpty().WithMessage("Informe a marca do caminhão.")
                .Length(3, 30).WithMessage("Informe a marca entre 3 a 30 caracteres.");
        }

        private void ValidarModelo()
        {
            RuleFor(e => e.Modelo)
                .NotEmpty().WithMessage("Informe o modelo do caminhão.")
                .Length(3, 30).WithMessage("Informe a modelo entre 3 a 30 caracteres.");
        }

        private void ValidarPlaca()
        {
            RuleFor(e => e.Modelo)
                .NotEmpty().WithMessage("Informe a placa do caminhão.")
                .Length(8).WithMessage("Informe a placa com 8 caracteres.");
        }

        private void ValidarEixo()
        {
            RuleFor(e => e.Eixo)
                .NotEmpty().WithMessage("Informe o eixo do caminhão.");
        }

        #endregion
    }
}
