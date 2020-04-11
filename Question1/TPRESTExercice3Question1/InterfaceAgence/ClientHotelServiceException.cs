using System;
using System.Net;
using System.Runtime.Serialization;

namespace InterfaceAgence
{
    [Serializable]
    internal class ClientHotelServiceException : Exception
    {
        private HttpStatusCode statusCode;
        private string reasonPhrase;

        public ClientHotelServiceException()
        {
        }

        public ClientHotelServiceException(string message) : base(message)
        {
        }

        public ClientHotelServiceException(HttpStatusCode statusCode, string reasonPhrase, string url)
            : this("Hotel service " + url + " failed with status : " + reasonPhrase)
        {
            this.statusCode = statusCode;
            this.reasonPhrase = reasonPhrase;
        }

        public ClientHotelServiceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClientHotelServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}