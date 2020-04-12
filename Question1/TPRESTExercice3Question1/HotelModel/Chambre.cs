using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelModel
{
    public class Chambre
    {
        public long Id { get; set; }
        public int NombreDeLits { get; set; }
        public double Surface { get; set; }
        public double BasePrix { get; set; }

        public string ImageUrl { get; set; }

        public double PrixCalcule(Agence agence)
        {
            if (agence == null)
            {
                return BasePrix;
            }

            return agence.Reduction * BasePrix;
        }

        public bool estDisponible(DateTime dateArrivee, DateTime dateDepart, List<Reservation> reservations)
        {
            bool disponible = true;

            foreach (Reservation reservation in reservations)
            {
                if (reservation.ChambreId == Id && dateDepart >= reservation.DateArrivee && dateArrivee <= reservation.DateDepart)
                {
                    disponible = false;
                }
            }

            return disponible;
        }
    }
}
