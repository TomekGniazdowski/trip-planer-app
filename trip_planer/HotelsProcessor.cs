using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;

namespace trip_planer
{
    /// <summary>
    /// Klasa <c>HotelsProcessor</c> zawiera metodę wysyłającą żądanie do API
    /// i odczytującą odpowiedź.
    /// <list type="bullet">
    /// <item>
    /// <term>Wczytaj </term>
    /// <description>Metoda wczytania odpowiedzi API</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para> Klasa <c>HotelsProcessor</c> zawiera metodę wysyłającą żądanie
    /// do API i odczytującą odpowiedź.</para>
    /// </remarks>
    public class HotelsProcessor
    {
        /// <summary>
        /// Metoda realizuje wysłanie żądania do odpowiedniego API i odebranie 
        /// odpowiedzi.
        /// </summary>
        /// <remarks>
        /// <para>Metoda realizuje wysłanie żądania do odpowiedniego API i 
        /// odebranie odpowiedzi oraz jej walidację.</para>
        /// </remarks>
        /// <exception cref="System.Exception">Wyrzucany, gdy dane nie są 
        /// prawidłowe lub nie uzyskano odpowiedzi.</exception>
        /// <param name="Text">Nazwa miasta docelowego.</param>
        /// <returns>Odpowiedź API</returns>
        public static async Task<HotelsResult> Wczytaj(string Text)
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://hotels4.p.rapidapi.com/locations/search?query={Text}&locale=en_US"),
                Headers =
                    {
                        { "x-rapidapi-key", "5364401a31msha0b8c4f79687174p1f9d4fjsn2e71ef22fc88" },
                        { "x-rapidapi-host", "hotels4.p.rapidapi.com" },
                    },
            };
            using (HttpResponseMessage response = await API.Api_Client.SendAsync(request))
            {
                if (response.IsSuccessStatusCode)
                {
                    HotelsResult body = await response.Content.ReadAsAsync<HotelsResult>();
                    body.Walidacja();
                    return body;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
