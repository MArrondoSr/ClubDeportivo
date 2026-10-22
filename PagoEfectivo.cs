using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo
{
    // HERENCIA: PagoEfectivo reutiliza los atributos y metodos
    // comunes de Pago y define el comportamiento propio del efectivo
    internal class PagoEfectivo : Pago
    {
         public PagoEfectivo(DateTime fecha, decimal importe)
                : base(fecha, importe)
            {
            }

         public override string obtenerDetalle()
         {
            return "Pago en efectivo por $" + getImporte();
         }

         public override string getMedioPago()
         {
            return "Efectivo";
         }

    }
}

