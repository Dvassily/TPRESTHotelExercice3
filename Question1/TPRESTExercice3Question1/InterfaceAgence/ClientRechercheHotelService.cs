using HotelModel;
using HotelProtocol;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAgence
{
    class ClientRechercheHotelService
    {
        private string Url;
        private HttpClient Client;

        public ClientRechercheHotelService(string url)
        {
            Client = new HttpClient();
            Url = url;
        }

        public async Task<List<Offre>> Rechercher(RequeteRecherche requete)
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

                List<Offre> offres = JsonConvert.DeserializeObject<List<Offre>>(content);
                System.Diagnostics.Debug.WriteLine(content);

                System.Diagnostics.Debug.WriteLine(offres);
                return offres;
            }

            throw new ClientRechercheHotelServiceException(response.StatusCode, response.ReasonPhrase, Url);
        }
    }
}
