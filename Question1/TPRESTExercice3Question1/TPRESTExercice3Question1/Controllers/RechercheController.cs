using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel1Service.Models;
using HotelProtocol;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel1Service.Controllers
{
    [Route("hotel1/[controller]")]
    [ApiController]
    public class RechercheController : ControllerBase
    {
        private readonly HotelContext _context;

        public RechercheController(HotelContext context)
        {
            _context = context;
        }
        // POST: api/Recherche
        [HttpPost]
        public async Task<ActionResult<IEnumerable<HotelModel.Offre>>> Recherche([FromBody] RequeteRecherche requete)
        {
            List<HotelModel.Offre> resultat = new List<HotelModel.Offre>();

            List<HotelModel.Agence> agences = await _context.Agences.ToListAsync();

            HotelModel.Agence agence = null;
            foreach (HotelModel.Agence a in agences)
            {
                if (a.IdentifiantAgence == requete.IdentifiantAgence && a.MotDePasseAgence == requete.MotDePasseAgence)
                {
                    agence = a;
                }
            }

            List<HotelModel.Chambre> chambres = await _context.Chambres.ToListAsync();
            List<HotelModel.Reservation> reservations = await _context.Reservations.ToListAsync();
            System.Diagnostics.Debug.WriteLine(reservations.Count());
            foreach (HotelModel.Chambre c in chambres)
            {
                if (c.NombreDeLits >= requete.NombrePersonnes && c.estDisponible(requete.DateArrivee, requete.DateDepart, reservations))
                {
                    HotelModel.Offre offre = new HotelModel.Offre
                    {
                        NombreDeLits = c.NombreDeLits,
                        DateArrivee = requete.DateArrivee,
                        DateDepart = requete.DateDepart,
                        Prix = c.PrixCalcule(agence),
                        ChambreId = c.Id
                    };

                    _context.Offres.Add(offre);

                    _context.SaveChanges();

                    resultat.Add(offre);
                }
            }

            return resultat;
        }
    }
}
