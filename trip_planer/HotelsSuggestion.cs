using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace trip_planer
{
    /// <summary>
    /// Klasa <c>HotelsSuggestion</c> zawiera właściwości odpowiednie do odpowiedzi
    /// odpowiedniej części API i metodę walidacji otrzymanych danych.
    /// <list type="bullet">
    /// <item>
    /// <term>Walidacja </term>
    /// <description>Metoda walidacji danych</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para>Klasa <c>HotelsSuggestion</c> zawiera właściwości odpowiednie do 
    /// odpowiedzi odpowiedniej części API i metodę walidacji otrzymanych 
    /// danych.</para>
    /// </remarks>
    public class HotelsSuggestion
    {
        /// <value>Pobiera informację o nazwie grupy elementów (hotele, punkty
        /// widokowe, środki transportu, części miasta) w mieście.</value>
        [Required]
        [StringLength(100, ErrorMessage = "The group name is more than 100 characters long.")]
        public string Group { get; set; }

        /// <value>Pobiera grupę elementów w mieście.</value>
        [Required]
        public HotelsEntity[] Entities { get; set; }

        /// <summary>
        /// Metoda realizuje walidację danych zawartych w obiekcie typu 
        /// <c>HotelsSuggestion</c>.
        /// </summary>
        /// <remarks>
        /// <para>Metoda realizuje walidację danych zawartych w obiekcie typu 
        /// <c>HotelsSuggestion</c>.</para>
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

            foreach (var entity in this.Entities)
                entity.Walidacja();
        }
    }
}
