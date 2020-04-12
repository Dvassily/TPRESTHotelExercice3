using HotelProtocol;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace InterfaceAgence
{
    internal class ClientReservationHotelService
    {
        private string Url;
        private HttpClient Client;

        public ClientReservationHotelService(string url)
        {
            Url = url;
            Client = new HttpClient();
        }

        public async Task<int> Reserver(RequeteReservation requete)
        {
            var uri = string.Format(Url, string.Empty);

            var requeteJson = JsonConvert.SerializeObject(requete);
            var buffer = System.Text.Encoding.UTF8.GetBytes(requeteJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await Client.PostAsync(uri, byteContent);
            if (response.IsSuccessStatusCode)
            {
                int numeroReservation = Int32.Parse(await response.Content.ReadAsStringAsync());

                return numeroReservation;
            }

            throw new ClientReservationHotelServiceException(response.StatusCode, response.ReasonPhrase, Url);
        }
    }
}