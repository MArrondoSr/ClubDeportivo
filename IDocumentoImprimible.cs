using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo
{
    // INTERFAZ: define un contrato que deben cumplir
    // todas las clases que la implementen.
    public interface IDocumentoImprimible
    {
        // Cada clase deberá implementar este método
        // con su propia lógica para generar un PDF.
        //
        // rutaArchivo indica dónde guardar el documento.
        void GenerarPdf(string rutaArchivo);
    }
}
