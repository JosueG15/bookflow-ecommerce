using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal.Utility
{
    public static class SD
    {
        public const string Role_Customer = "Customer";
        public const string Role_Company = "Company";
        public const string Role_User_Admin = "Admin";
        public const string Role_User_Employee = "Employee";

        public const string StatusPending = "Pendiente";
		public const string StatusApproved = "Aprobado";
		public const string StatusInProcess = "En Proceso";
		public const string StatusShipped = "Despachado";
		public const string StatusCancelled = "Cancelado";
		public const string StatusRefunded = "Devolucion Finalizada";


		public const string PaymentStatusPending = "Pendiente";
		public const string PaymentStatusApproved = "Aprobado";
		public const string PaymentStatusDelayedPayment = "Aprobado (Pendiente de pago)";
		public const string PaymentStatusRejected = "Denegado";

		public const string SessionCart = "SessionShoppingCart";
	}
}
