using System;

namespace Hotel1Service.Protocol
{
    public class RequeteRecherche
    {
        public string IdentifiantAgence { get; set; }
        public string MotDePasseAgence { get; set; }
        public int NombrePersonnes { get; set; }
        public DateTime DateArrivee { get; set; }
        public DateTime DateDepart { get; set; }
    }
}