using HotelModel;
using HotelProtocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAgence
{
    public class MenuAgence
    {
        private const string CHAINE_VILLE_SEJOUR = "Ville de séjour";
        private const string CHAINE_DATE_DEPART = "Date de départ";
        private const string CHAINE_DATE_ARRIVEE = "Date d'arrivée";
        private const string CHAINE_PRIX_MINIMAL = "Prix minimal";
        private const string CHAINE_PRIX_MAXIMAL = "Prix maximal";
        private const string CHAINE_NOMBRE_ETOILE = "Nombre d'etoile";
        private const string CHAINE_NOMBRE_PERSONNE = "Nombre de personnes";
        private const string CHAINE_RESULTAT_HOTEL = "Hotel : ";
        private const string CHAINE_RESULTAT_VILLE = "Ville : ";
        private const string CHAINE_RESULTAT_RUE = "Rue : ";
        private const string CHAINE_RESULTAT_PRIX = "Prix : ";
        private const string CHAINE_RESULTAT_NOMBRE_LIT = "Nombre de lit : ";
        private const string CHAINE_CHOIX_INVALIDE = "Choix invalide";
        private const string CHAINE_MENU = "Choix : \n" +
                                           "1) Rechercher\n" +
                                           "2) Réserver\n" +
                                           "3) Quitter\n" +
                                           "> ";
        private const string CHAINE_IDENTIFIANT_HOTEL = "Identifiant hotel";
        private const string CHAINE_IDENTIFIANT_CHAMBRE = "Identifiant chambre";
        private const string CHAINE_NOM_CLIENT = "Nom";
        private const string CHAINE_PRENOM_CLIENT = "Prenom";
        private const string CHAINE_NUMERO_CARTE_BANCAIRE = "Numero de carte bancaire";
        private const string CHAINE_NUMERO_RESERVATION = "Numéro de reservation";
        private const string CHAINE_IDENTIFIANT_OFFRE = "Identifiant de l'offre";
        private const string CHAINE_VILLE = "Ville";
        private const string CHAINE_NOMBRE_ETOILES = "Nombre d'étoiles";
        private readonly string nomAgence;
        private readonly string identifiantAgence;
        private readonly string motDePasseAgence;
        private List<ClientRechercheHotelService> Services = new List<ClientRechercheHotelService>();
        private List<Offre> Offres = new List<Offre>();
        public MenuAgence(string nomAgence, string identifiantAgence, string motDePasseAgence)
        {
            this.nomAgence = nomAgence;
            this.identifiantAgence = identifiantAgence;
            this.motDePasseAgence = motDePasseAgence;
            this.Services.Add(new ClientRechercheHotelService("https://localhost:44393/hotel1/Recherche"));
            this.Services.Add(new ClientRechercheHotelService("https://localhost:44309/hotel2/Recherche"));
        }

        private void MenuRechercher()
        {
            string villeHotel = SaisieHelper.SaisirChaine(CHAINE_VILLE, false);
            DateTime dateArrivee = SaisieHelper.SaisirDate(CHAINE_DATE_ARRIVEE, true);
            DateTime dateDepart = DateTime.MaxValue;

            if (dateArrivee != default)
            {
                dateDepart = SaisieHelper.SaisirDate(CHAINE_DATE_DEPART, true);
            }
            else
            {
                dateArrivee = DateTime.MinValue;
            }

            if (dateArrivee > dateDepart)
            {
                throw new PeriodeInvalideException(dateArrivee, dateDepart);
            }

            int nbPersonne = SaisieHelper.SaisirEntierPositif(CHAINE_NOMBRE_PERSONNE, true);
            int nombreEtoiles = SaisieHelper.SaisirEntierPositif(CHAINE_NOMBRE_ETOILES, true);

            List<Offre> offres = new List<Offre>();
            foreach (ClientRechercheHotelService client in Services)
            {
                RequeteRecherche requete = new RequeteRecherche();
                requete.IdentifiantAgence = identifiantAgence;
                requete.MotDePasseAgence = motDePasseAgence;
                requete.VilleHotel = villeHotel;
                requete.NombrePersonnes = nbPersonne;
                requete.DateArrivee = dateArrivee;
                requete.DateDepart = dateDepart;
                requete.NombreEtoiles = nombreEtoiles;

                offres.AddRange(client.Rechercher(requete).Result);
            }

            foreach (Offre offre in offres)
            {
                AfficherResultat(offre);

                Offres.Add(offre);
            }
        }

        private void AfficherResultat(Offre offre)
        {
            Console.WriteLine("Identifiant de l'hotel : " + offre.HotelId);
            Console.WriteLine("Nom de l'hotel : " + offre.NomHotel);
            Console.WriteLine("Ville de l'hotel : " + offre.VilleHotel);
            Console.WriteLine("Adresse de l'hotel : " + offre.AdresseHotel);
            Console.WriteLine("Nombre d'étoiles : " + offre.NombreEtoiles);
            Console.WriteLine("Identifiant de l'offre : " + offre.Id);
            Console.WriteLine("Chambre : " + offre.ChambreId);
            Console.WriteLine("Image chambre : " + offre.ImageChambreUrl);
            Console.WriteLine("Date arrivee : " + offre.DateArrivee);
            Console.WriteLine("Date départ : " + offre.DateDepart);
            Console.WriteLine("Nombre de lits : " + offre.NombreDeLits);
            Console.WriteLine("Prix : " + offre.Prix);
            Console.WriteLine();
        }

        private void MenuReserver()
        {
            int identifiantHotel = SaisieHelper.SaisirEntierPositif(CHAINE_IDENTIFIANT_HOTEL, false);
            int identifiantOffre = SaisieHelper.SaisirEntierPositif(CHAINE_IDENTIFIANT_OFFRE, false);
            string nom = SaisieHelper.SaisirChaine(CHAINE_NOM_CLIENT, false);
            string prenom = SaisieHelper.SaisirChaine(CHAINE_PRENOM_CLIENT, false);
            string numeroCarte = SaisieHelper.SaisirChaine(CHAINE_NUMERO_CARTE_BANCAIRE, false);

            Offre offre = trouverOffre(identifiantHotel, identifiantOffre);

            if (offre != null)
            {
                RequeteReservation requete = new RequeteReservation();
                requete.IdentifiantAgence = identifiantAgence;
                requete.MotDePasseAgence = motDePasseAgence;
                requete.IdentifiantOffre = identifiantOffre;
                requete.NomClient = nom;
                requete.PrenomClient = prenom;
                requete.NumeroCarteClient = numeroCarte;

                ClientReservationHotelService client = new ClientReservationHotelService(offre.UrlReservation);
                int numeroReservation = client.Reserver(requete).Result;

                Console.WriteLine(CHAINE_NUMERO_RESERVATION + " : " + numeroReservation);
            } else
            {
                Console.WriteLine("Erreur : l'offre " + identifiantOffre + " n'existe pas pour l'hotel " + identifiantHotel);
            }
        }

        private Offre trouverOffre(int identifiantHotel, int identifiantOffre)
        {
            foreach (Offre offre in Offres)
            {
                if (offre.Id == identifiantOffre && offre.HotelId == identifiantHotel)
                {
                    return offre;
                }
            }

            return null;
        }

        public bool AfficherMenu()
        {
            Console.WriteLine(CHAINE_MENU);

            int choix = Int32.Parse(Console.ReadLine());

            if (choix == 1)
            {
                MenuRechercher();
            }
            else if (choix == 2)
            {
                MenuReserver();
            }
            else if (choix == 3)
            {
                return false;
            }
            else
            {
                Console.WriteLine(CHAINE_CHOIX_INVALIDE);
            }

            return true;
        }

        public void BouclePrincipale()
        {
            Console.WriteLine("Bievenue à l'agence " + nomAgence + " !");

            bool continuer = true;

            do
            {
                try
                {
                    continuer = AfficherMenu();
                }
                catch (PeriodeInvalideException e)
                {
                    Console.WriteLine("Erreur : " + e.Message);
                }
            } while (continuer);
        }
    }
}
