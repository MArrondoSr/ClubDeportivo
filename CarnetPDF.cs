using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace ClubDeportivo
{
    // Implementa el contrato definido por IDocumentoImprimible.
    //Usamos TRES CONCEPTOS:
    // 1 -Interfaz: IDocumentoImprimible establece el contrato.
   // 2 - Encapsulamiento: CarnetPdf conserva la referencia al panel en un atributo privado.
   // 3 - Polimorfismo: utilizamos una variable de tipo interfaz para trabajar con un objeto CarnetPdf.
    public class CarnetPdf : IDocumentoImprimible
    {
        // Guardamos una referencia al panel que contiene el carnet.
        private readonly Panel panelCarnet;

        // Constructor: recibe el panel desde FormCarnet.
        public CarnetPdf(Panel panelCarnet)
        {
            this.panelCarnet = panelCarnet;
        }

        // Implementación del método exigido por la interfaz.
        public void GenerarPdf(string rutaArchivo)
        {
            using PrintDocument documento = new PrintDocument();

            documento.PrinterSettings.PrinterName = "Microsoft Print to PDF";

            if (!documento.PrinterSettings.IsValid)
            {
                throw new InvalidOperationException(
                    "Microsoft Print to PDF no está disponible.");
            }



            // Selecciono A4, un tamaño admitido por la impresora PDF.
            foreach (PaperSize papel in documento.PrinterSettings.PaperSizes)
            {
                if (papel.PaperName == "A4")
                {
                    documento.DefaultPageSettings.PaperSize = papel;
                    break;
                }
            }

            // Orientación vertical.
            documento.DefaultPageSettings.Landscape = false;

            // Elimino los márgenes configurados.
            documento.DefaultPageSettings.Margins =
                new Margins(0, 0, 0, 0);
            documento.PrinterSettings.PrintToFile = true;
            documento.PrinterSettings.PrintFileName = rutaArchivo;

            // Este evento define el contenido de la página.
            documento.PrintPage += (sender, e) =>
            {
                // Convertimos el panel en una imagen
                using Bitmap imagen = new Bitmap(
                    panelCarnet.Width,
                    panelCarnet.Height
                );

                panelCarnet.DrawToBitmap(
                    imagen,
                    new Rectangle(
                        0,
                        0,
                        panelCarnet.Width,
                        panelCarnet.Height
                    )
                );

                // Graphics trabaja aquí con unidades de centésimas de pulgada.
                e.Graphics.PageUnit = GraphicsUnit.Display;

                // Dimensiones físicas del carnet:
                // 86 mm = 339 centésimas de pulgada.
                // 54 mm = 213 centésimas de pulgada.
                int anchoCarnet = 339;
                int altoCarnet = 213;

                // Carnet centrado en la página A4.
                int x = (e.PageBounds.Width - anchoCarnet) / 2;
                int y = (e.PageBounds.Height - altoCarnet) / 2;

                // Imagen escalada al tamaño físico deseado.
                e.Graphics.DrawImage(
                    imagen,
                    new Rectangle(x, y, anchoCarnet, altoCarnet)
                );

                // Indica que el documento tiene una sola página.
                e.HasMorePages = false;
            };

            // Envia el documento a Microsoft Print to PDF.
            documento.Print();
        }
    }
}