using System.ComponentModel.DataAnnotations;

namespace Parcial1_AP1_AaronHernandez.Models
{
    public class Metas
    {
        [Key]
        public int MetaId { get; set; }

        [Required(ErrorMessage ="Este campo es obligatorio.")]
        public string? Descripcion { get; set; }

		[Required(ErrorMessage = "Este campo es obligatorio.")]
        [Range(1,int.MaxValue, ErrorMessage ="Debe de ser mayor a uno.")]
		public float Monto { get; set; }

		[Required(ErrorMessage = "Este campo es obligatorio.")]
		public DateTime Fecha { get; set; }
	}
}
