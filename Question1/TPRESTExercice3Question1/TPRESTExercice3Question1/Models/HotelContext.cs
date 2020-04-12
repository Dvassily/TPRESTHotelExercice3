using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel1Service.Models
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
            if (Agences.Count() == 0)
            {
                Agences.Add(new HotelModel.Agence
                {
                    IdentifiantAgence = "abcd",
                    MotDePasseAgence = "efgh",
                    Reduction = 0.25
                });

                Agences.Add(new HotelModel.Agence
                {
                    IdentifiantAgence = "hijk",
                    MotDePasseAgence = "lmnop",
                    Reduction = 0.5
                });

                SaveChanges();
            }
            
            if (Chambres.Count() == 0)
            {
                Chambres.Add(new HotelModel.Chambre
                {
                    NombreDeLits = 3,
                    Surface = 20,
                    BasePrix = 80,
                    ImageUrl = "https://www.hotel-beaujolais.com/img/build/les-pierres-dorees-chambres.jpg"
                });

                Chambres.Add(new HotelModel.Chambre
                {
                    NombreDeLits = 5,
                    Surface = 50,
                    BasePrix = 100,
                    ImageUrl = "https://assets.hotelaparis.com/uploads/pictures/000/043/953/Chambre-3-6.jpg"
                });

                Chambres.Add(new HotelModel.Chambre
                {
                    NombreDeLits = 2,
                    Surface = 40,
                    BasePrix = 60,
                    ImageUrl = "https://www.hotel-diana-dauphine.com/media/cache/jadro_resize/rc/rhCiPkJe1582096951/jadroRoot/medias/5658345e8f976/chambre-1.jpg"
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
