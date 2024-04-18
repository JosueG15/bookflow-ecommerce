using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinal.Models
{
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }

        public string ApplicationUserId { get; set;  }

        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public double OrderTotal { get; set; }

        public string? OrderStatus { get; set; }
        public string? PaymentStatus { get; set; }
        public string? TrackingNumber { get; set; }
        public string? Carrier { get; set; }

        public DateTime PaymentDate { get; set; }
        public DateOnly PaymentDueDate { get; set; }

        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }

        [Required(ErrorMessage ="Este campo es obligatorio")]
        [DisplayName("Numero de telefono")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Direccion")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Municipio")]
        public string City { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Departamento")]
        public string State { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Codigo Postal")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Nombre")]
        public string Name { get; set; }

    }
}
