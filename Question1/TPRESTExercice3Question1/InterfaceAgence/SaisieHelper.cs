using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceAgence
{
    public class SaisieHelper
    {
        private const string CHAINE_ANNEE = "Année format YYYY";
        private const string CHAINE_MOIS = "Mois format MM";
        private const string CHAINE_JOUR = "Jour format DD";
        private const string CHAINE_POUR_IGNORER = " (* pour ignorer) : ";
        private const string CHAINE_IGNORER = "*";

        public static  bool verifierIgnorer(string entree)
        {
            if (string.Compare(entree, CHAINE_IGNORER) == 0)
            {
                return true;
            }

            return false;
        }

        public static  string SaisirChaine(string libelle, bool demanderIgnorer)
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

        public static  int SaisirEntierPositif(string libelle, bool demanderIgnorer)
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

        public static  DateTime SaisirDate(string libelle, bool demanderIgnorer)
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
    }
}
