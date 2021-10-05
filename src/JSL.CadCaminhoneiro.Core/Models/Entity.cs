using FluentValidation;
using FluentValidation.Results;
using System;

namespace JSL.CadCaminhoneiro.Core.Models
{
    public abstract class Entity<T> : AbstractValidator<T> where T : Entity<T>
    {
        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public Guid Id { get; set; }
        public ValidationResult ValidationResult { get; protected set; }
        public abstract bool EhValido();

    }
}
