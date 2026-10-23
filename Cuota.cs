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

        public Cuota(
    int idCuota,
    DateTime fechaPago,
    DateTime? vencimientoAnterior,
    decimal importe)
        {
            this.idCuota = idCuota;

            // REGLA DE NEGOCIO - RENOVACIÓN DE CUOTAS:
            //
            // Si el socio paga antes de que venza su cuota anterior,
            // el nuevo período comienza en el vencimiento anterior.
            // De esta manera, no pierde los días que ya tenía abonados.
            //
            // Si la cuota anterior ya venció, el nuevo período
            // comienza en la fecha del nuevo pago.
            //
            // Si es la primera cuota del socio, vencimientoAnterior
            // será null y el período comenzará en la fecha del pago.

            if (vencimientoAnterior.HasValue &&
                vencimientoAnterior.Value.Date > fechaPago.Date)
            {
                this.fechaInicio = vencimientoAnterior.Value.Date;
            }
            else
            {
                this.fechaInicio = fechaPago.Date;
            }

            // La cuota tiene una duración de un mes calendario.
            this.fechaVencimiento = this.fechaInicio.AddMonths(1);

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

        // REGLA DE NEGOCIO:
        // Determina si la cuota vence en la fecha actual.
        // No significa que ya esté vencida.
        public bool venceHoy()
        {
            return DateTime.Today == fechaVencimiento.Date;
        }

        // ENCAPSULAMIENTO:
        // Permite consultar la fecha de inicio de la cuota
        // sin acceder directamente al atributo privado.
        public DateTime getFechaInicio()
        {
            return fechaInicio;
        }

        // ENCAPSULAMIENTO:
        // Permite consultar la fecha de vencimiento,
        // calculada por el constructor según la regla de negocio.
        //
        // En una renovación anticipada, el nuevo período
        // comienza al vencer la cuota anterior.
        // Así el socio conserva los días ya abonados.
        public DateTime getFechaVencimiento()
        {
            return fechaVencimiento;
        }
    }
}
