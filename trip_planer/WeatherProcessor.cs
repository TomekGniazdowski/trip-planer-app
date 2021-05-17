using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;

namespace trip_planer
{
    /// <summary>
    /// Klasa <c>WeatherProcessor</c> zawiera metodę wysyłającą żądanie do API
    /// i odczytującą odpowiedź.
    /// <list type="bullet">
    /// <item>
    /// <term>Wczytaj </term>
    /// <description>Metoda wczytania odpowiedzi API</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para> Klasa <c>WeatherProcessor</c> zawiera metodę wysyłającą żądanie
    /// do API i odczytującą odpowiedź.</para>
    /// </remarks>
    public class WeatherProcessor
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
        public static async Task<WeatherResult> Wczytaj(string Text)
        {
            Text = Text.Replace(" ", "%20");
            string url = $"http://api.openweathermap.org/data/2.5/forecast?q={Text}&units=metric&appid=b506ccd50fa5c028ff1bb79d0209a4b6&lang=en_US";

            using (HttpResponseMessage response = await API.Api_Client.GetAsync(url))
            {

                if (response.IsSuccessStatusCode)
                {
                    WeatherResult result = await response.Content.ReadAsAsync<WeatherResult>();
                    result.Walidacja();
                    return result;
                }
                else
                {
                    throw new Exception("You probably made a typo in the name of the town :(");
                }
            }
        }
    }
}