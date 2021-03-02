using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaDandoOnda.Models
{
    public class Manobra
    {
        [Key]
        public int ManobraId { get; set; }
        [Required(ErrorMessage = "Insira o nome da manobra.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Insira o tipo de manobra.")]
        public Aerea Aérea { get; set; }
        [Required(ErrorMessage = "Insira o tipo de onda.")]
        [DisplayName("Preferência de Onda")]
        public Onda TipoDeOnda { get; set; }
        [ForeignKey("Surfista")]
        [DisplayName("Pioneiro ou Criador")]
        public int? SurfistaId { get; set; }
        public virtual Surfista Surfista { get; set; }

    }
}