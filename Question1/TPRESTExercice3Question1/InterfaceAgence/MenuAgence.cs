using HotelModel;
using HotelProtocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAgence
{
    public class MenuAgence
    {
        private const string CHAINE_IGNORER = "*";
        private const string CHAINE_VILLE_SEJOUR = "Ville de séjour";
        private const string CHAINE_DATE_DEPART = "Date de départ";
        private const string CHAINE_DATE_ARRIVEE = "Date d'arrivée";
        private const string CHAINE_PRIX_MINIMAL = "Prix minimal";
        private const string CHAINE_PRIX_MAXIMAL = "Prix maximal";
        private const string CHAINE_NOMBRE_ETOILE = "Nombre d'etoile";
        private const string CHAINE_NOMBRE_PERSONNE = "Nombre de personnes";
        private const string CHAINE_ANNEE = "Année format YYYY";
        private const string CHAINE_MOIS = "Mois format MM";
        private const string CHAINE_JOUR = "Jour format DD";
        private const string CHAINE_RESULTAT_HOTEL = "Hotel : ";
        private const string CHAINE_RESULTAT_VILLE = "Ville : ";
        private const string CHAINE_RESULTAT_RUE = "Rue : ";
        private const string CHAINE_RESULTAT_PRIX = "Prix : ";
        private const string CHAINE_RESULTAT_NOMBRE_LIT = "Nombre de lit : ";
        private const string CHAINE_CHOIX_INVALIDE = "Choix invalide";
        private const string CHAINE_POUR_IGNORER = " (* pour ignorer) : ";
        private const string CHAINE_MENU = "Choix : \n" +
                                           "1) Rechercher\n" +
                                           "2) Réserver\n" +
                                           "3) Consulter une réservation\n" +
                                           "4) Quitter\n" +
                                           "> ";
        private const string CHAINE_IDENTIFIANT_HOTEL = "Identifiant hotel";
        private const string CHAINE_IDENTIFIANT_CHAMBRE = "Identifiant chambre";
        private const string CHAINE_NOM_CLIENT = "Nom";
        private const string CHAINE_PRENOM_CLIENT = "Prenom";
        private const string CHAINE_NUMERO_CARTE_BANCAIRE = "Numero de carte bancaire";
        private const string CHAINE_NUMERO_RESERVATION = "Numéro de reservation";
        private readonly string nomAgence;
        private string identifiantAgence;
        private readonly string motDePasseAgence;

        private Dictionary<int, ClientHotelService> Services = new Dictionary<int, ClientHotelService>();

        public MenuAgence(string nomAgence, string identifiantAgence, string motDePasseAgence)
        {
            this.nomAgence = nomAgence;
            this.identifiantAgence = identifiantAgence;
            this.motDePasseAgence = motDePasseAgence;
            this.Services.Add(1, new ClientHotelService("https://localhost:44393/hotel1/Recherche"));
            this.Services.Add(2, new ClientHotelService("https://localhost:44309/hotel2/Recherche"));
        }

        private bool verifierIgnorer(string entree)
        {
            if (string.Compare(entree, CHAINE_IGNORER) == 0)
            {
                return true;
            }

            return false;
        }

        private string SaisirChaine(string libelle, bool demanderIgnorer)
        {
            string affichage = libelle;

            if (demanderIgnorer)
            {
                affichage += CHAINE_POUR_IGNORER;
            }

            affichage += " : ";

            Console.WriteLine(affichage);

            string chaine = Console.ReadLine();

            if (demanderIgnorer && verifierIgnorer(chaine))
            {
                return null;
            }

            return chaine;
        }

        private int SaisirEntierPositif(string libelle, bool demanderIgnorer)
        {
            string affichage = libelle;

            if (demanderIgnorer)
            {
                affichage += CHAINE_POUR_IGNORER;
            }

            affichage += " : ";

            Console.WriteLine(affichage);

            string entier = Console.ReadLine();

            if (verifierIgnorer(entier))
            {
                return -1;
            }

            return Int32.Parse(entier);
        }

        private DateTime SaisirDate(string libelle, bool demanderIgnorer)
        {
            Console.WriteLine(libelle + " : ");
            int year = SaisirEntierPositif(CHAINE_ANNEE, demanderIgnorer);
            if (year == -1)
            {
                return default;
            }
            int month = SaisirEntierPositif(CHAINE_MOIS, demanderIgnorer);
            int day = SaisirEntierPositif(CHAINE_JOUR, demanderIgnorer);

            return new DateTime(year, month, day);
        }
        private void MenuRechercher()
        {
            DateTime dateArrivee = SaisirDate(CHAINE_DATE_ARRIVEE, true);
            DateTime dateDepart = DateTime.MaxValue;

            if (dateArrivee != default)
            {
                dateDepart = SaisirDate(CHAINE_DATE_DEPART, true);
            }
            else
            {
                dateArrivee = DateTime.MinValue;
            }

            if (dateArrivee > dateDepart)
            {
                throw new PeriodeInvalideException(dateArrivee, dateDepart);
            }

            int nbPersonne = SaisirEntierPositif(CHAINE_NOMBRE_PERSONNE, true);

            List<Offre> offres = new List<Offre>();
            foreach (ClientHotelService client in Services.Values)
            {
                RequeteRecherche requete = new RequeteRecherche();
                requete.IdentifiantAgence = identifiantAgence;
                requete.MotDePasseAgence = motDePasseAgence;
                requete.NombrePersonnes = nbPersonne;
                requete.DateArrivee = dateArrivee;
                requete.DateDepart = dateDepart;

                offres.AddRange(client.Rechercher(requete).Result);
            }

            foreach (Offre offre in offres)
            {
                AfficherResultat(offre);
            }
        }

        private void AfficherResultat(Offre offre)
        {
            Console.WriteLine("Identifiant de l'offre : " + offre.Id);
            Console.WriteLine("Hotel : " + offre.HotelId);
            Console.WriteLine("Date arrivee : " + offre.DateArrivee);
            Console.WriteLine("Date départ : " + offre.DateDepart);
            Console.WriteLine("Nombre de lits : " + offre.DateDepart);
            Console.WriteLine("Prix : " + offre.Prix);
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
                // MenuReserver();
            }
            else if (choix == 4)
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
