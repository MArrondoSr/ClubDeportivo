using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo
{
    internal class Cliente

    // ENCAPSULAMIENTO: los datos internos son privados y se accede
    // a ellos mediante metodos controlados, evitando modificaciones
    // directas desde otras clases.
    {
        // IDENTIFICACIÓN DEL CLIENTE:
        // idCliente es el identificador interno generado por MySQL.
        // tipoDocumento y nroDocumento identifican el documento presentado.
        private int idCliente;
        private string tipoDocumento;
        private string nroDocumento;
        private string nombre;
        private string apellido;
        private string domicilio;
        private string telefono;
        private string mail;
        private bool aptoFisico;

        private Carnet? carnet;
        private List<Pago> pagos;

        public Cliente(string tipoDocumento, string nroDocumento, string nombre, string apellido, string domicilio, string telefono, string mail, bool aptoFisico)
        {
            this.idCliente = 0; // Todavía no fue registrado en MySQL.
            this.tipoDocumento = tipoDocumento;
            this.nroDocumento = nroDocumento;
            this.nombre = nombre;
            this.apellido = apellido;
            this.domicilio = domicilio;
            this.telefono = telefono;
            this.mail = mail;
            this.aptoFisico = aptoFisico;

            this.carnet = null;
            this.pagos = new List<Pago>();
        }


        // ENCAPSULAMIENTO:
        // Los atributos son privados y se consultan mediante
        // métodos públicos, sin permitir su modificación directa.

        public int getIdCliente()
        {
            return idCliente;
        }

        public void setIdCliente(int idCliente)
        {
            this.idCliente = idCliente;
        }

        public string getTipoDocumento()
        {
            return tipoDocumento;
        }

        public string getNroDocumento()
        {
            return nroDocumento;
        }

        public string getNombre()
        {
            return nombre;
        }

        public string getApellido()
        {
            return apellido;
        }

        public string getDomicilio()
        {
            return domicilio;
        }

        public string getTelefono()
        {
            return telefono;
        }

        public string getMail()
        {
            return mail;
        }

        public bool tieneAptoFisico()
        {
            return aptoFisico;
        }

        // ASOCIACION: el estado de socio se obtiene por la existencia
        // de un Carnet asociado. No es necesario cambiar la clase Cliente
        // ni mantener un booleano redundante para indicar ese estado.
        public bool esSocio()
        {
            return carnet != null;
        }

        public bool asignarCarnet(Carnet carnet)
        {
            if (this.carnet == null)
            {
                this.carnet = carnet;
                return true;
            }

            return false;
        }

        public void agregarPago(Pago pago)
        {
            pagos.Add(pago);
        }
    }
}