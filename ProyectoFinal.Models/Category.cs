using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Nombre")]
        [MaxLength(30)]
        public string Name { get; set; }

        [DisplayName("Orden de Visualizacion")]
        [Range(1, 100, ErrorMessage = "El orden de visualizacion debe ser entre 1 y 100")]
        public int DisplayOrder { get; set; }
    }
}
