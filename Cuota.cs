using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo
{
   internal class Cuota
    {
        private int idCuota;
        private DateTime fechaInicio;
        private DateTime fechaVencimiento;
        private decimal importe;
        private Pago? pago;

        public Cuota(int idCuota, DateTime fechaInicio, decimal importe)
        {
            this.idCuota = idCuota;
            this.fechaInicio = fechaInicio;
            this.fechaVencimiento = fechaInicio.AddMonths(1);
            this.importe = importe;
            this.pago = null;
        }

        public bool estaVencida()
        {
            return DateTime.Today > fechaVencimiento;
        }

        public bool estaPagada()
        {
            return pago != null;
        }
        public bool registrarPago(Pago pago)
        {
            if (this.pago == null)
            {
                this.pago = pago;
                return true;
            }

            return false;
        }
    }
}
