using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace trip_planer
{
    /// <summary>
    /// Klasa <c>WeatherMain</c> zawiera właściwości odpowiednie do odpowiedzi
    /// odpowiedniej części API i metodę walidacji otrzymanych danych.
    /// <list type="bullet">
    /// <item>
    /// <term>Walidacja </term>
    /// <description>Metoda walidacji danych</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para>Klasa <c>WeatherMain</c> zawiera właściwości odpowiednie do 
    /// odpowiedzi odpowiedniej części API i metodę walidacji otrzymanych 
    /// danych.</para>
    /// </remarks>
    public class WeatherMain
    {
        /// <value>Pobiera temperaturę w danym pomiarze.</value>
        [Required]
        [Range(-100, 100, ErrorMessage = "The temperature is out of the range (-100, 100)\u00B0C.")]
        public double Temp { get; set; }

        /// <value>Pobiera temperaturę minimalną w danym pomiarze.</value>
        [Required]
        [Range(-100, 100, ErrorMessage = "The maximum temperature is out of range (-100, 100)\u00B0C.")]
        public double Temp_min { get; set; }

        /// <value>Pobiera temperaturę maksymalną w danym pomiarze.</value>
        [Required]
        [Range(-100, 100, ErrorMessage = "The minimum temperature is out of range (-100, 100)\u00B0C.")]
        public double Temp_max { get; set; }

        /// <value>Pobiera ciśnienie w danym pomiarze.</value>
        [Required]
        [Range(900, 1100, ErrorMessage = "The pressure is out of range (900, 1100) hPa.")]
        public double Pressure { get; set; }

        /// <value>Pobiera wilgotność w danym pomiarze.</value>
        [Required]
        [Range(0, 100, ErrorMessage = "The humidity is out of range (0, 100)%.")]
        public double Humidity { get; set; }

        /// <summary>
        /// Metoda realizuje walidację danych zawartych w obiekcie typu 
        /// <c>WeatherMain</c>.
        /// </summary>
        /// <remarks>
        /// <para>Metoda realizuje walidację danych zawartych w obiekcie typu 
        /// <c>WeatherMain</c>.</para>
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
