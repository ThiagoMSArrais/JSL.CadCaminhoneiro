using JSL.CadCaminhoneiro.Core.Models;
using FluentValidation;
using System;

namespace JSL.CadCaminhoneiro.Domain.Models
{
    public class Endereco : Entity<Endereco>
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public Guid? IdMotorista { get; set; }

        #region validacoes

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        private void Validar()
        {
            ValidarLogradouro();
            ValidarNumeroLogradouro();
            ValidarBairro();
            ValidarCidade();
            ValidarEstado();
            ValidarCep();

            ValidationResult = Validate(this);
        }

        private void ValidarLogradouro()
        {
            RuleFor(e => e.Logradouro)
                .NotEmpty().WithMessage("Informe o logradouro.")
                .Length(3, 80).WithMessage("Informe o logradouro entre 3 a 80 caracteres.");
        }

        private void ValidarNumeroLogradouro()
        {
            RuleFor(e => e.Numero)
                .NotEmpty().WithMessage("Informe o logradouro");
        }

        private void ValidarBairro()
        {
            RuleFor(e => e.Bairro)
                .NotEmpty().WithMessage("Informe o bairro.")
                .Length(3, 30).WithMessage("Informe o bairro entre 3 a 30 caracteres.");
        }

        private void ValidarCidade()
        {
            RuleFor(e => e.Cidade)
                .NotEmpty().WithMessage("Informe o cidade.")
                .Length(3, 30).WithMessage("Informe o cidade entre 3 a 30 caracteres.");
        }

        private void ValidarEstado()
        {
            RuleFor(e => e.Estado)
                .NotEmpty().WithMessage("Informe o estado.")
                .Length(3, 30).WithMessage("Informe o estado entre 3 a 30 caracteres.");
        }

        private void ValidarCep()
        {
            RuleFor(e => e.Cep)
                .NotEmpty().WithMessage("Informe o cep.")
                .MaximumLength(10).WithMessage("Informe o cep corretamente Ex.: 00.000-000");
        }

        #endregion
    }
}
