using System;
using System.ComponentModel.DataAnnotations;

namespace JSL.CadCaminhoneiro.Api.Dto
{
    public class CaminhaoDto
    {
        public CaminhaoDto()
        {
            Id = Guid.NewGuid();
        }

        public Guid? Id { get; set; }
        [Required(ErrorMessage = "Informe o marca.")]
        [MaxLength(30, ErrorMessage = "Informe o marca entre 3 a 30 caracteres.")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Informe o modelo.")]
        [MaxLength(30, ErrorMessage = "Informe o modelo entre 3 a 30 caracteres.")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Informe o placa.")]
        [MaxLength(8, ErrorMessage = "Informe o placa entre 3 a 8 caracteres.")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "Informe o eixo.")]
        public string Eixo { get; set; }
        public Guid? IdMotorista { get; set; }
    }
}
