using System;
using System.Net;
using System.Runtime.Serialization;

namespace InterfaceAgence
{
    [Serializable]
    internal class ClientReservationHotelServiceException : Exception
    {
        private HttpStatusCode statusCode;
        private string reasonPhrase;

        public ClientReservationHotelServiceException()
        {
        }

        public ClientReservationHotelServiceException(string message) : base(message)
        {
        }

        public ClientReservationHotelServiceException(HttpStatusCode statusCode, string reasonPhrase, string url)
            : this("Hotel service " + url + " failed with status : " + reasonPhrase)
        {
            this.statusCode = statusCode;
            this.reasonPhrase = reasonPhrase;
        }

        public ClientReservationHotelServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClientReservationHotelServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}