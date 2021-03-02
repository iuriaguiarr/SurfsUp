using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaDandoOnda.Models
{
    public class Surfista
    {
        [Key]
        public int SurfistaId { get; set; }
        [Required(ErrorMessage = "Insira o nome do surfista")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Insira a cidade do surfista")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Insira o estado do surfista.")]
        [MaxLength(2)]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Insira a idade do surfista.")]
        public int Idade { get; set; }
        public virtual ICollection<Manobra> Manobras { get; set; }
    }
}