using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace trip_planer
{
    /// <summary>
    /// Klasa <c>WeatherList</c> zawiera właściwości odpowiednie do odpowiedzi
    /// odpowiedniej części API i metodę walidacji otrzymanych danych.
    /// <list type="bullet">
    /// <item>
    /// <term>Walidacja </term>
    /// <description>Metoda walidacji danych</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para>Klasa <c>WeatherList</c> zawiera właściwości odpowiednie do 
    /// odpowiedzi odpowiedniej części API i metodę walidacji otrzymanych 
    /// danych.</para>
    /// </remarks>
    public class WeatherList
    {
        /// <value>Pobiera obiekt danych Main w danym pomiarze.</value>
        [Required]
        public WeatherMain Main { get; set; }

        /// <value>Pobiera obiekt danych Weather w danym pomiarze.</value>
        [Required]
        [MaxLength(1, ErrorMessage = "The length of the measurement list is greater than expected 1.")]
        [MinLength(1, ErrorMessage = "The length of the measurement list is smaller than expected 1.")]
        public WeatherWeather[] Weather { get; set; }

        /// <value>Pobiera datę w formacie YYY-MM-DD danego pomiaru.</value>
        [Required]
        [StringLength(20, ErrorMessage = "The weather reading date has more than 20 characters.")]
        public string Dt_txt { get; set; }

        /// <summary>
        /// Metoda realizuje walidację danych zawartych w obiekcie typu 
        /// <c>WeatherList</c>.
        /// </summary>
        /// <remarks>
        /// <para>Metoda realizuje walidację danych zawartych w obiekcie typu 
        /// <c>WeatherList</c>.</para>
        /// </remarks>
        /// <exception cref="System.Exception">Wyrzucany, gdy dane nie są 
        /// prawidłowe.</exception>
        public void Walidacja()
        {
            var ctx = new ValidationContext(this);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(this, ctx, results, true))
                foreach (var errors in results)
                    throw new Exception(errors.ErrorMessage);

            this.Main.Walidacja();
            this.Weather[0].Walidacja();
        }

    }
}