using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace trip_planer
{

    /// <summary>
    /// Klasa statyczna <c>API</c> zawiera metodę inicjalizującą klienta 
    /// aplikacji.
    /// <list type="bullet">
    /// <item>
    /// <term>Initialize_Client </term>
    /// <description>Metoda inicjalizująca klienta.</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para> Klasa statyczna <c>API</c> zawiera metodę inicjalizującą klienta 
    /// aplikacji.</para>
    /// </remarks>
    public static class API
    {
        // umozliwienie pobierania danych ze stron -> całość
        //static -> chcemy otworzyc raz, dla całej aplikacji
        /// <value>Umozliwia pobieranie danych ze stron.</value>
        public static HttpClient Api_Client { get; set; } = new HttpClient();

        /// <summary>
        /// Metoda inicjalizująca klienta.
        /// </summary>
        /// <remarks>
        /// <para>Metoda inicjalizuje klienta.</para>
        /// </remarks>  
        /// <exception cref="System.Exception">Wyrzucany, gdy inicjalizacja 
        /// klienta API nie powiodła się.</exception> 
        public static void Initialize_Client()
        {
            try
            {
                Api_Client = new HttpClient();
                // pierwsza czesc adresu url strony z danymi
                Api_Client.DefaultRequestHeaders.Accept.Clear();
                // json header -> tylko dane
                Api_Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
