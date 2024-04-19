using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ProyectoFinal.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Titulo")]
        public string Title { get; set; }

        [DisplayName("Descripcion")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Precio de lista")]
        [Range(1, 1000, ErrorMessage = "El precio debe ser en el rango de $1.00 y $1000.00")]
        public double ListPrice { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Precio 1+")]
        [Range(1, 1000, ErrorMessage = "El precio debe ser en el rango de $1.00 y $1000.00")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Precio 50+")]
        [Range(1, 1000, ErrorMessage = "El precio debe ser en el rango de $1.00 y $1000.00")]
        public double Price50 { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        [DisplayName("Precio 100+")]
        [Range(1, 1000, ErrorMessage = "El precio debe ser en el rango de $1.00 y $1000.00")]
        public double Price100 { get; set; }

        [DisplayName("Categoria")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [DisplayName("Categoria")]
        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        [DisplayName("Imagenes de libro")]
        public List<ProductImage> ProductImages { get; set; }
    }
}
