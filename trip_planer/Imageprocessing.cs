using System;
using System.IO;

namespace trip_planer
{
    /// <summary>
    /// Klasa <c>Imageprocessing</c> zawiera metodę losującą obraz.
    /// <list type="bullet">
    /// <item>
    /// <term>Zwroc_losowy_obraz </term>
    /// <description>Metoda zwracająca nazwę losowanego obrazu.</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para> 
    /// Klasa <c>Imageprocessing</c> zawiera metodę losującą obraz.
    /// </para>
    /// </remarks>
    public class Imageprocessing
    {
        // formatowanie tekstu - duza litera z przodu reszta male (bazy danych)
        /// <summary>
        /// Metoda zwracająca nazwę losowanego obrazu.
        /// </summary>
        /// <remarks>
        /// <para> 
        /// Metoda zwracająca nazwę losowanego obrazu.        
        /// </para>
        /// </remarks>
        /// <param name="nazwa_folderu">Nazwa folderu z obrazami.</param>
        /// <returns>Nazwa wylosowanego obrazu.</returns>
        public string Zwroc_losowy_obraz(string nazwa_folderu)
        {
            var rand = new Random();
            DirectoryInfo dierectory = new DirectoryInfo($@"{Directory.GetCurrentDirectory()}/{nazwa_folderu}/");
            // uzyskanie wszystkich zdjec jpg z wybranego folderu
            FileInfo[] Files = dierectory.GetFiles("*.jpg");
            // zwrocenie losowego zdjecia
            return Files[rand.Next(Files.Length)].Name;
        }
    }
}
