using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace trip_planer
{
    /// <summary>
    /// Klasa <c>HotelsEntity</c> zawiera właściwości odpowiednie do odpowiedzi
    /// odpowiedniej części API i metodę walidacji otrzymanych danych.
    /// <list type="bullet">
    /// <item>
    /// <term>Walidacja </term>
    /// <description>Metoda walidacji danych</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para>Klasa <c>HotelsEntity</c> zawiera właściwości odpowiednie do 
    /// odpowiedzi odpowiedniej części API i metodę walidacji otrzymanych 
    /// danych.</para>
    /// </remarks>
    public class HotelsEntity
    {
        /// <value>Pobiera nazwę elementu w mieście.</value>
        [Required]
        [StringLength(100, ErrorMessage = "The element name has more than 100 characters.")]
        public string Name { get; set; }

        /// <summary>
        /// Metoda realizuje walidację danych zawartych w obiekcie typu 
        /// <c>HotelsEntity</c>.
        /// </summary>
        /// <remarks>
        /// <para>Metoda realizuje walidację danych zawartych w obiekcie typu 
        /// <c>HotelsEntity</c>.</para>
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
