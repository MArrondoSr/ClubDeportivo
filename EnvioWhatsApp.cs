using System.Diagnostics;

namespace ClubDeportivo
{
    // Envia el carnet por WhatsApp:
    // toma una "foto" del panel del carnet (igual que CarnetPdf),
    // la copia al portapapeles y abre WhatsApp en el chat del socio.
    internal class EnvioWhatsApp
    {
        // ENCAPSULAMIENTO: referencias privadas, se cargan por el constructor
        private readonly Panel panelCarnet;
        private readonly Cliente cliente;

        public EnvioWhatsApp(Panel panelCarnet, Cliente cliente)
        {
            this.panelCarnet = panelCarnet;
            this.cliente = cliente;
        }

        public void Enviar(string vencimiento)
        {
            // 1) convierto el panel del carnet en una imagen y la copio
            using Bitmap imagen = new Bitmap(panelCarnet.Width, panelCarnet.Height);
            panelCarnet.DrawToBitmap(imagen, new Rectangle(0, 0, panelCarnet.Width, panelCarnet.Height));
            Clipboard.SetImage(imagen);

            // 2) armo el mensaje
            string nroSocio = cliente.getCarnet() != null
                ? cliente.getCarnet()!.getNroCarnet().ToString() : "";

            string mensaje = "Hola " + cliente.getNombre() + "! " +
                             "Te enviamos tu carnet de Socio N° " + nroSocio +
                              "del Club Deportivo POO GYM." + vencimiento;

            // 3) abro WhatsApp en el chat del socio (Web o app de escritorio)
            string link = "https://web.whatsapp.com/send?phone=" +
              NormalizarTelefono(cliente.getTelefono()) +
              "&text=" + Uri.EscapeDataString(mensaje);
            Process.Start(new ProcessStartInfo(link) { UseShellExecute = true });
        }

        // Pasa el telefono al formato que pide WhatsApp (Argentina).
        // Ejemplo: "11 6252-0330" -> "5491162520330". Si esta vacio devuelve "".
        private static string NormalizarTelefono(string telefono)
        {
            string numeros = new string(
                (telefono ?? "").Where(char.IsDigit).ToArray()
            );

            // Formato internacional completo: 549 + 10 dígitos.
            if (numeros.StartsWith("549") && numeros.Length == 13)
                return numeros;

            // Código de país sin el 9 de celular.
            if (numeros.StartsWith("54") && numeros.Length == 12)
                return "549" + numeros.Substring(2);

            // Número nacional con cero inicial.
            if (numeros.StartsWith("0") && numeros.Length == 11)
                numeros = numeros.Substring(1);

            // Código de área + número local.
            if (numeros.Length == 10)
                return "549" + numeros;

            // No se puede determinar un número válido.
            throw new ArgumentException(
                "El teléfono del cliente no tiene un formato válido."
            );
        }
    }
}