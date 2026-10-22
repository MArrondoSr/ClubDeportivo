using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo
{
    // ABSTRACCION: Pago representa los datos y comportamientos comunes
    // de cualquier cobro, sea efectivo o tarjeta.
    // Al ser abstracta, no se pueden crear objetos Pago directamente.
    internal abstract class Pago
    {
        private int idPago;
        private DateTime fecha;
        private decimal importe;

        public Pago(DateTime fecha, decimal importe)
        {
            
            this.fecha = fecha;
            this.importe = importe;
        }

        public DateTime getFecha()
        {
            return fecha;
        }

        public decimal getImporte()
        {
            return importe;
        }

        public int getIdPago()
        {
            return idPago;
        }

        // ENCAPSULAMIENTO: el identificador se asigna mediante un metodo
        // luego de que MySQL lo genera automaticamente con AUTO_INCREMENT.
        public void setIdPago(int idPago)
        {
            this.idPago = idPago;
        }

        public virtual string obtenerDetalle()
        {
            return "Pago por $" + importe;
        }

        // POLIMORFISMO: este metodo virtual define una operacion comun.
        // Cada clase derivada puede redefinirla con override para devolver
        // su propio medio de pago.
        public virtual string getMedioPago()
        {
            return "Pago";
        }

        public virtual int? getCantidadCuotas()
        {
            return null;
        }

    }

}
