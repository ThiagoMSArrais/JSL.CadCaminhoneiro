using System;
using System.ComponentModel.DataAnnotations;

namespace JSL.CadCaminhoneiro.Api.Dto
{
    public class EnderecoDto
    {
        public EnderecoDto()
        {
            Id = Guid.NewGuid();
        }

        public Guid? Id { get; set; }
        [Required(ErrorMessage = "Informe o logradouro.")]
        [MaxLength(80, ErrorMessage = "Informe o logradouro entre 3 a 80 caracteres.")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Informe o número.")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "Informe o bairro.")]
        [MaxLength(30, ErrorMessage = "Informe o bairro entre 3 a 30 caracteres.")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Informe o cidade.")]
        [MaxLength(30, ErrorMessage = "Informe o cidade entre 3 a 30 caracteres.")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Informe o estado.")]
        [MaxLength(30, ErrorMessage = "Informe o estado entre 3 a 30 caracteres.")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Informe o cep.")]
        [MaxLength(10, ErrorMessage = "Informe o cep entre 3 a 10 caracteres.")]
        public string Cep { get; set; }
        public Guid? IdMotorista { get; set; }
    }
}
