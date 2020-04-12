using HotelModel;
using HotelProtocol;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClientAgenceService
{
    class ClientOffreAgenceService
    {
        private string Url;
        private HttpClient Client;

        public ClientOffreAgenceService(string url)
        {
            Url = url;
            Client = new HttpClient();
        }

        public async Task<List<OffreAgence>> RechercherAsync(RequeteOffreAgence requete)
        {
            var uri = string.Format(Url, string.Empty);

            var requeteJson = JsonConvert.SerializeObject(requete);
            var buffer = System.Text.Encoding.UTF8.GetBytes(requeteJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await Client.PostAsync(uri, byteContent);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<OffreAgence>>(content);
            }

            throw new ClientReservationHotelServiceException(response.StatusCode, response.ReasonPhrase, Url);
        }
    }
}
