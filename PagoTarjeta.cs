using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo
{
    // HERENCIA: PagoTarjeta extiende Pago con la cantidad de cuotas
    // y el calculo del importe correspondiente a cada una.
    internal class PagoTarjeta : Pago
    {
        private int cantidadCuotas;

        public PagoTarjeta(DateTime fecha, decimal importe, int cantidadCuotas)
            : base(fecha, importe)

        {
            this.cantidadCuotas = cantidadCuotas;
        }

        public override int? getCantidadCuotas()
        {
            return cantidadCuotas;
        }

        public decimal calcularImporteCuota()
        {
            return getImporte() / cantidadCuotas;
        }


        // POLIMORFISMO: override reemplaza el comportamiento heredado (VER clasePago).
        // Aunque se invoque desde una referencia de tipo Pago, se ejecuta
        // esta version cuando el objeto real es PagoTarjeta.
        public override string obtenerDetalle()
        {
            return "Pago con tarjeta en " +
                   cantidadCuotas +
                   " cuotas de $" +
                   calcularImporteCuota().ToString("0.00");
            // PRESENTACION: ToString("0.00") limita la visualizacion a dos
            // decimales; no modifica el resultado decimal del calculo.
        }

        public override string getMedioPago()
        {
            return "Tarjeta";
        }
    }
}