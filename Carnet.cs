using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubDeportivo
{
    internal class Carnet
    {
        private int nroCarnet;
        private List<Cuota> cuotas;


        public Carnet(int nroCarnet)
        {
            this.nroCarnet = nroCarnet;
            this.cuotas = new List<Cuota>();
        }

        public int getNroCarnet()
        {
            return nroCarnet;
        }
    }
}
