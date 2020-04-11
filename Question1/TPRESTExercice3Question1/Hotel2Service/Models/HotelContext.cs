using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel2Service.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
            if (Agences.Count() == 0)
            {
                Agences.Add(new HotelModel.Agence
                {
                    IdentifiantAgence = "hijk",
                    MotDePasseAgence = "lmnop",
                    Reduction = 0.75
                });

                SaveChanges();
            }

            if (Chambres.Count() == 0)
            {
                Chambres.Add(new HotelModel.Chambre
                {
                    NombreDeLits = 3,
                    Surface = 40,
                    BasePrix = 100
                });

                Chambres.Add(new HotelModel.Chambre
                {
                    NombreDeLits = 1,
                    Surface = 100,
                    BasePrix = 35
                });

                SaveChanges();
            }
        }

        public int NombreOffres()
        {
            return Offres.Count();
        }

        public DbSet<HotelModel.Agence> Agences { get; set; }
        public DbSet<HotelModel.Chambre> Chambres { get; set; }
        public DbSet<HotelModel.Offre> Offres { get; set; }
        public DbSet<HotelModel.Reservation> Reservations { get; set; }
    }
}
