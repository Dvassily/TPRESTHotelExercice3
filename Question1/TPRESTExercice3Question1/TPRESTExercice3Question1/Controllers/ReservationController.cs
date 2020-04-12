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
    public class ReservationController : ControllerBase
    {
        private readonly HotelContext _context;

        public ReservationController(HotelContext context)
        {
            _context = context;
        }

        // POST: api/Reservation
        [HttpPost, ActionName("Reserver")]
        public async Task<ActionResult<long>> Post([FromBody] RequeteReservation requete)
        {
            List<HotelModel.Agence> agences = await _context.Agences.ToListAsync();

            HotelModel.Agence agence = null;
            foreach (HotelModel.Agence a in agences)
            {
                if (a.IdentifiantAgence == requete.IdentifiantAgence && a.MotDePasseAgence == requete.MotDePasseAgence)
                {
                    agence = a;
                }
            }

            HotelModel.Offre offre = await _context.Offres.FindAsync(requete.IdentifiantOffre);

            HotelModel.Reservation reservation = new HotelModel.Reservation
            {
                ChambreId = offre.ChambreId,
                Prix = offre.Prix,
                DateArrivee = offre.DateArrivee,
                DateDepart = offre.DateDepart,
                NomClient = requete.NomClient,
                PrenomClient = requete.PrenomClient,
                NumeroCarteClient = requete.NumeroCarteClient,
                IdentifiantAgence = requete.IdentifiantAgence
            };

            _context.Reservations.Add(reservation);

            _context.SaveChanges();

            return reservation.Id;
        }
    }
}
