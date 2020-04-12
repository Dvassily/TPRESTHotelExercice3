using HotelModel;
using HotelProtocol;
using InterfaceAgence;
using System;
using System.Collections.Generic;

namespace ClientAgenceService
{
    class Client
    {
        private const string CHAINE_MENU = "Choix : \n" +
                                   "1) Rechercher\n" +
                                   "2) Quitter\n" +
                                   "> ";
        private const string CHAINE_VILLE = "Ville";
        private const string CHAINE_NOMBRE_ETOILES = "Nombre d'etoile";
        private const string CHAINE_NOMBRE_PERSONNE = "Nombre de personnes";
        private const string CHAINE_DATE_DEPART = "Date de départ";
        private const string CHAINE_DATE_ARRIVEE = "Date d'arrivée";
        private const string CHAINE_CHOIX_INVALIDE = "Choix invalide";
        private List<ClientOffreAgenceService> ClientsServices = new List<ClientOffreAgenceService>();

        public Client()
        {
            ClientsServices.Add(new ClientOffreAgenceService("https://localhost:44385/agence1/Offre"));
            ClientsServices.Add(new ClientOffreAgenceService("https://localhost:44375/agence2/Offre"));
        }

        public void BouclePrincipale()
        {
            Console.WriteLine("Bievenue sur l'application de comparateur d'agences hotelliere !");

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

        private bool AfficherMenu()
        {
            Console.WriteLine(CHAINE_MENU);

            int choix = Int32.Parse(Console.ReadLine());

            if (choix == 1)
            {
                MenuRechercher();
            }
            else if (choix == 2)
            {
                return false;
            }
            else
            {
                Console.WriteLine(CHAINE_CHOIX_INVALIDE);
            }

            return true;
        }

        private void MenuRechercher()
        {
            string villeHotel = SaisieHelper.SaisirChaine(CHAINE_VILLE, false);
            DateTime dateArrivee = SaisieHelper.SaisirDate(CHAINE_DATE_ARRIVEE, true);
            DateTime dateDepart = SaisieHelper.SaisirDate(CHAINE_DATE_ARRIVEE, true);

            if (dateArrivee > dateDepart)
            {
                throw new PeriodeInvalideException(dateArrivee, dateDepart);
            }

            int nbPersonne = SaisieHelper.SaisirEntierPositif(CHAINE_NOMBRE_PERSONNE, true);
            int nombreEtoiles = SaisieHelper.SaisirEntierPositif(CHAINE_NOMBRE_ETOILES, true);


            List<OffreAgence> offres = new List<OffreAgence>();

            RequeteOffreAgence requete = new RequeteOffreAgence
            {
                Ville = villeHotel,
                DateArrivee = dateArrivee,
                DateDepart = dateDepart,
                NombrePersonnes = nbPersonne,
                NombreEtoiles = nombreEtoiles
            };

            foreach (ClientOffreAgenceService client in ClientsServices)
            {
                offres.AddRange(client.RechercherAsync(requete).Result);
            }

            List<OffreComparee> offresComparees = new Comparateur(offres).Comparer().Resultat;

            foreach (OffreComparee offreComparee in offresComparees)
            {
                AfficherResultat(offreComparee);
            }
        }

        private void AfficherResultat(OffreComparee offreComparee)
        {
            Console.WriteLine("Nom : " + offreComparee.NomHotel);
            Console.WriteLine("Ville : " + offreComparee.VilleHotel);
            Console.WriteLine("Adresse : " + offreComparee.AdresseHotel);
            Console.WriteLine("Nombre d'étoiles : " + offreComparee.NombreEtoiles);
            Console.WriteLine("Nombre de lits : " + offreComparee.NombreDeLits);
            Console.WriteLine("Prix : ");
            foreach (KeyValuePair<string, double> entry in offreComparee.ComparatifPrix)
            {
                Console.WriteLine("... " + entry.Key + " : " + entry.Value);
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            new Client().BouclePrincipale();
        }
    }
}