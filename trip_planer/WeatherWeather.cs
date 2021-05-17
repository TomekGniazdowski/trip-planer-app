using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trip_planer
{
    /// <summary>
    /// Klasa <c>WeatherWeather</c> zawiera właściwości odpowiednie do odpowiedzi
    /// odpowiedniej części API i metodę walidacji otrzymanych danych.
    /// <list type="bullet">
    /// <item>
    /// <term>Walidacja </term>
    /// <description>Metoda walidacji danych</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para>Klasa <c>WeatherWeather</c> zawiera właściwości odpowiednie do 
    /// odpowiedzi odpowiedniej części API i metodę walidacji otrzymanych 
    /// danych.</para>
    /// </remarks>
    public class WeatherWeather
    {
        /// <value>Pobiera informację o opisie pogody.</value>
        [Required]
        [StringLength(20, ErrorMessage = "The weather description is more than 20 characters long.")]
        public string Description { get; set; }

        /// <value>Pobiera informację o oznaczeniu grafiki pogody.</value>
        [Required]
        [StringLength(4, ErrorMessage = "The weather image name has more than 4 characters.")]
        public string Icon { get; set; }

        /// <summary>
        /// Metoda realizuje walidację danych zawartych w obiekcie typu 
        /// <c>WeatherWeather</c>.
        /// </summary>
        /// <remarks>
        /// <para>Metoda realizuje walidację danych zawartych w obiekcie typu 
        /// <c>WeatherWeather</c>.</para>
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
        }

    }
}
