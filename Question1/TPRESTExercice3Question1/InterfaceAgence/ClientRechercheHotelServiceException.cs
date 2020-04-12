using System;
using System.Net;
using System.Runtime.Serialization;

namespace InterfaceAgence
{
    [Serializable]
    internal class ClientRechercheHotelServiceException : Exception
    {
        private HttpStatusCode statusCode;
        private string reasonPhrase;

        public ClientRechercheHotelServiceException()
        {
        }

        public ClientRechercheHotelServiceException(string message) : base(message)
        {
        }

        public ClientRechercheHotelServiceException(HttpStatusCode statusCode, string reasonPhrase, string url)
            : this("Hotel service " + url + " failed with status : " + reasonPhrase)
        {
            this.statusCode = statusCode;
            this.reasonPhrase = reasonPhrase;
        }

        public ClientRechercheHotelServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClientRechercheHotelServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}