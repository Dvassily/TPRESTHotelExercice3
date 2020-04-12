using System;
using System.Net;
using System.Runtime.Serialization;

namespace ClientAgenceService
{
    [Serializable]
    internal class ClientReservationHotelServiceException : Exception
    {
        private HttpStatusCode statusCode;
        private string reasonPhrase;
        private string url;

        public ClientReservationHotelServiceException()
        {
        }

        public ClientReservationHotelServiceException(string message) : base(message)
        {
        }

        public ClientReservationHotelServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public ClientReservationHotelServiceException(HttpStatusCode statusCode, string reasonPhrase, string url)
            : this("Hotel service " + url + " failed with status : " + reasonPhrase)
        {
            this.statusCode = statusCode;
            this.reasonPhrase = reasonPhrase;
            this.url = url;
        }

        protected ClientReservationHotelServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}