using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace trip_planer
{
    /// <summary>
    /// Klasa <c>UserInput</c> zawiera właściwości odpowiednie do danych
    /// wprowadzanych przez użytkownika i metodę walidacji otrzymanych danych.
    /// <list type="bullet">
    /// <item>
    /// <term>Walidacja </term>
    /// <description>Metoda walidacji danych</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para>Klasa <c>UserInput</c> zawiera właściwości odpowiednie do 
    /// danych wprowadzanych przez użytkownika i metodę walidacji otrzymanych danych.</para>
    /// </remarks>
    internal class UserInput
    {
        /// <value>Pobiera nazwę miasta początkowego.</value>
        [Required]
        [StringLength(30, ErrorMessage = "The starting city name has more than 30 characters.")]
        public string Start { get; set; }

        /// <value>Pobiera nazwę miasta docelowego.</value>
        [Required]
        [StringLength(30, ErrorMessage = "Destination city name has more than 30 characters.")]
        public string Stop { get; set; }

        /// <value>Pobiera datę podróży.</value>
        [Required]
        [StringLength(12, ErrorMessage = "The travel date has more than 12 characters.")]
        public string Date { get; set; }

        /// <summary>
        /// Metoda realizuje walidację danych zawartych w obiekcie typu 
        /// <c>UserInput</c>.
        /// </summary>
        /// <remarks>
        /// <para>Metoda realizuje walidację danych zawartych w obiekcie typu 
        /// <c>UserInput</c>.</para>
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