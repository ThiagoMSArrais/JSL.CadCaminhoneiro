using System;
using System.ComponentModel.DataAnnotations;

namespace JSL.CadCaminhoneiro.Api.Dto
{
    public class MotoristaDto
    {
        public MotoristaDto()
        {
            Id = Guid.NewGuid();

        }

        public Guid? Id { get; set; }
        [Required(ErrorMessage = "Informe o nome.")]
        [MaxLength(80, ErrorMessage = "Informe o nome entre 3 a 80 caracteres.")]
        public string Nome { get; set; }
        public virtual EnderecoDto EnderecoDto { get; set; }
        public virtual CaminhaoDto CaminhaoDto { get; set; }
    }
}
