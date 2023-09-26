using System.ComponentModel.DataAnnotations;

namespace CartasPapaiNoel.Models
{
    public class CartasPapaiNoelViewModel
    {
        [MinLength(3, ErrorMessage = "Mínimo 3 letras.")]
        [MaxLength(255, ErrorMessage = "Limite máximo atingido.")]
        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string NomeCrianca { get; set; }


        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        public string Estado { get; set; }


        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [Range(1, 14)]
        public int IdadeCriancaEmAnos { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]

        [MaxLength(500, ErrorMessage = "Limite máximo atingido.")]
        public string TextoCartaCrianca { get; set; }
    }
}
