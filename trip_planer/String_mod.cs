using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trip_planer
{
    /// <summary>
    /// Klasa <c>String_mod</c> zawiera metody formatujące tekst.
    /// <list type="bullet">
    /// <item>
    /// <term>Popraw_Tekst </term>
    /// <description>Metoda zmieniająca ciąg znaków na pierwszą dużą literę
    /// i pozostałe małe.</description>
    /// </item>
    /// <item>
    /// <term>Popraw_Date </term>
    /// <description>Metoda zmieniająca ciąg znaków na małe litery.</description>
    /// </item>
    /// <item>
    /// <term>Popraw_Tekst </term>
    /// <description>Metoda zmieniająca format daty.</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para> Klasa <c>String_mod</c>zawiera metody formatujące tekst.</para>
    /// </remarks>
    public class String_mod
    {
        // formatowanie tekstu - duza litera z przodu reszta male (bazy danych)
        /// <summary>
        /// Metoda zmieniająca ciąg znaków na pierwszą dużą literę i pozostałe małe.
        /// </summary>
        /// <remarks>
        /// <para>Metoda zmieniająca ciąg znaków na pierwszą dużą literę i pozostałe
        /// małe.</para>
        /// </remarks>
        /// <param name="text_we">Tekst wejściowy.</param>
        /// <returns>Tekst po zmianie.</returns>
        public string Popraw_Tekst(string text_we)
        {
            string text_wy = char.ToUpper(text_we[0]) + text_we.Substring(1).ToLower();
            return text_wy;
        }

        // formatowanie tekstu - wszystkie listery male (api)
        /// <summary>
        /// Metoda zmieniająca ciąg znaków na małe litery.
        /// </summary>
        /// <remarks>
        /// <para>Metoda zmieniająca ciąg znaków na małe litery.</para>
        /// </remarks>
        /// <param name="text_we">Tekst wejściowy.</param>
        /// <returns>Tekst po zmianie.</returns>
        public string Popraw_Tekst2(string text_we)
        {
            string text_wy = text_we.ToLower();
            return text_wy;
        }

        // formatowanie daty do formatu rok-miesiac-dzien 15:00:00
        /// <summary>
        /// Metoda zmieniająca format daty.
        /// </summary>
        /// <remarks>
        /// <para>Metoda zmieniająca format daty.</para>
        /// </remarks>
        /// <param name="text_we">Tekst wejściowy.</param>
        /// <returns>Tekst po zmianie.</returns>
        public string Popraw_Date(string text_we)
        {
            if (text_we.Length > 0)
            {
                string text_wy = text_we.Substring(6, 4) + "-" + text_we.Substring(3, 2) + "-" + text_we.Substring(0, 2) + " 15:00:00";
                return text_wy;
            }
            else
            {
                return "-1";
            }
        }
    }
}
