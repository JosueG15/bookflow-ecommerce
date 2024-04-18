using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [DisplayName("Direccion")]
        public string? StreetAddress { get; set; }

        [DisplayName("Municipio")]
        public string? City { get; set;}

        [DisplayName("Departamento")]
        public string? State { get; set;}

        [DisplayName("Codigo Postal")]
        public string? PostalCode { get; set; }

        public int? CompanyId { get; set;}

        [ForeignKey("CompanyId")]
        [ValidateNever]
        public Company Company { get; set; }
    }
}
