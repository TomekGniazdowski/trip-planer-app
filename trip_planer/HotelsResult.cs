using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace trip_planer
{
    /// <summary>
    /// Klasa <c>HotelsResult</c> zawiera właściwości odpowiednie do odpowiedzi
    /// odpowiedniej części API i metodę walidacji otrzymanych danych.
    /// <list type="bullet">
    /// <item>
    /// <term>Walidacja </term>
    /// <description>Metoda walidacji danych</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para>Klasa <c>HotelsResult</c> zawiera właściwości odpowiednie do 
    /// odpowiedzi odpowiedniej części API i metodę walidacji otrzymanych 
    /// danych.</para>
    /// </remarks>
    public class HotelsResult
    {
        /// <value>Pobiera listę z elementami w miećie.</value>
        [Required]
        [MaxLength(4, ErrorMessage = "Suggestion list length is longer than expected 4.")]
        [MinLength(4, ErrorMessage = "Suggestion list length is shorter than expected 4.")]
        public HotelsSuggestion[] Suggestions { get; set; }

        /// <summary>
        /// Metoda realizuje walidację danych zawartych w obiekcie typu 
        /// <c>HotelsResult</c>.
        /// </summary>
        /// <remarks>
        /// <para>Metoda realizuje walidację danych zawartych w obiekcie typu 
        /// <c>HotelsResult</c>.</para>
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

            foreach (var suggestion in this.Suggestions)
                suggestion.Walidacja();
        }
    }
}
