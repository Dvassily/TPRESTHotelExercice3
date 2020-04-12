using System;
using System.Runtime.Serialization;

namespace InterfaceAgence
{
    [Serializable]
    public class PeriodeInvalideException : Exception
    {
        private DateTime dateArrivee;
        private DateTime dateDepart;

        public PeriodeInvalideException()
        {
        }

        public PeriodeInvalideException(string message) : base(message)
        {
        }

        public PeriodeInvalideException(DateTime dateArrivee, DateTime dateDepart)
            : base("La période " + dateArrivee.ToString() + "-" + dateDepart.ToString() + " n'est pas disponible")
        {
            this.dateArrivee = dateArrivee;
            this.dateDepart = dateDepart;
        }

        public PeriodeInvalideException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PeriodeInvalideException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}