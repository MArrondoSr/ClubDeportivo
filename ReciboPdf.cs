using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;

namespace ClubDeportivo
{
    // INTERFACES:
    // ReciboPdf implementa el mismo contrato que CarnetPdf,
    // pero será responsable de generar comprobantes de pago.
    internal class ReciboPdf : IDocumentoImprimible
    {
        // ENCAPSULAMIENTO:
        // Guarda los objetos y datos que necesita el comprobante.
        private readonly Cliente cliente;
        private readonly Pago pago;
        private readonly string concepto;

        // CONSTRUCTOR:
        // Recibe un cliente, un pago ya registrado
        // y el concepto correspondiente a la operación.
        public ReciboPdf(Cliente cliente, Pago pago, string concepto)
        {
            this.cliente = cliente;
            this.pago = pago;
            this.concepto = concepto;
        }

        // IMPLEMENTACIÓN DE LA INTERFAZ:
        // Este método tiene la misma firma que el de CarnetPdf.
        public void GenerarPdf(string rutaArchivo)
        {
            using PrintDocument documento = new PrintDocument();

            documento.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            if (!documento.PrinterSettings.IsValid)
            {
                throw new Exception("No está disponible Microsoft Print to PDF.");
            }

            documento.PrinterSettings.PrintToFile = true;
            documento.PrinterSettings.PrintFileName = rutaArchivo;

            // Selecciona papel A4.
            foreach (PaperSize papel in documento.PrinterSettings.PaperSizes)
            {
                if (papel.PaperName == "A4")
                {
                    documento.DefaultPageSettings.PaperSize = papel;
                    break;
                }
            }

            documento.DefaultPageSettings.Landscape = false;

            documento.PrintPage += (sender, e) =>
            {
                using Font titulo = new Font("Arial", 18, FontStyle.Bold);
                using Font texto = new Font("Arial", 11);

                float x = e.MarginBounds.Left;
                float y = e.MarginBounds.Top;

                e.Graphics!.DrawString(
                    "CLUB DEPORTIVO POO",
                    titulo,
                    Brushes.Black,
                    x,
                    y
                );

                y += 55;

                e.Graphics.DrawString(
                    "COMPROBANTE DE PAGO",
                    titulo,
                    Brushes.Black,
                    x,
                    y
                );

                y += 65;

                string datos =
                    "Comprobante N.º: " + pago.getIdPago() + "\n\n" +
                    "Cliente: " + cliente.getNombre() + " " +
                    cliente.getApellido() + "\n\n" +
                    "Fecha: " + pago.getFecha().ToString("dd/MM/yyyy") + "\n\n" +
                    "Concepto: " + concepto + "\n\n" +
                    "Medio de pago: " + pago.getMedioPago() + "\n\n" +
                    "Importe: $" + pago.getImporte().ToString("N2");

                e.Graphics.DrawString(
                    datos,
                    texto,
                    Brushes.Black,
                    x,
                    y
                );

                e.HasMorePages = false;
            };

            documento.Print();
        }
    }
}
