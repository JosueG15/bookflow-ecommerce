using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Este campo es requerido")]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [DisplayName("Direccion")]
        public string? StreetAddress { get; set; }

        [DisplayName("Municipio")]
        public string? City { get; set; }

        [DisplayName("Departamento")]
        public string? State { get; set; }

        [DisplayName("Codigo Postal")]
        public string? PostalCode { get; set; }

        [DisplayName("Numero de telefono")]
        public string? PhoneNumber { get; set; }

    }
}
