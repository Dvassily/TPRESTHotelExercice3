using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel1Service.Protocol
{
    public class RequeteReservation
    {
        public string IdentifiantAgence { get; set; }
        public string MotDePasseAgence { get; set; }
        public long IdentifiantOffre { get; set; }
        public string NomClient { get; set; }
        public string PrenomClient { get; set; }
        public string NumeroCarteClient { get; set; }
    }
}
