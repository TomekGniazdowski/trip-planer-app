using System;
using System.Collections.Generic;

namespace trip_planer
{
    /// <summary>
    /// Klasa <c>Values_for_plot</c> zawiera metodę obliczania wysokości
    /// wykresu.
    /// <list type="bullet">
    /// <item>
    /// <term>Oblicz_wysokosci_wykresu </term>
    /// <description>Metoda obliczania wysokości wykresu</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para>Klasa <c>Values_for_plot</c> zawiera metodę obliczania wysokości
    /// wykresu.</para>
    /// </remarks>
    public class Values_for_plot
    {
        // obliczenie wysokosci slupkow temperatur jako proporcja wzglem
        // maksymalnej tmperatury
        /// <summary>
        /// Metoda realizuje obliczenie wysokosci slupkow temperatur jako 
        /// proporcji wzglem maksymalnej tmperatury.
        /// </summary>
        /// <remarks>
        /// <para>Metoda realizuje obliczenie wysokosci slupkow temperatur jako 
        /// proporcji wzglem maksymalnej tmperatury.</para>
        /// </remarks>
        /// <param name="Temp_dzien1">Temperatura pierwszego dnia podróży.</param>
        /// <param name="Temp_dzien2">Temperatura drugiego dnia podróży.</param>
        /// <param name="Temp_dzien3">Temperatura trzeciego dnia podróży.</param>
        /// <returns>Wysokości słupków w formie listy</returns>
        public List<double> Oblicz_wysokosci_wykresu(double Temp_dzien1, double Temp_dzien2, double Temp_dzien3)
        {
            List<double> Lista_do_wykresu = new List<double>();
            
            double Max_temp = Math.Max(Temp_dzien1, Math.Max(Temp_dzien2, Temp_dzien3));
            double Dzien_1_wysokosc;
            double Dzien_2_wysokosc;
            double Dzien_3_wysokosc;

            if (Temp_dzien1 == 0)
                Temp_dzien1 = 0.1;

            if (Temp_dzien2 == 0)
                Temp_dzien2 = 0.1;

            if (Temp_dzien3 == 0)
                Temp_dzien3 = 0.1;

            if (Max_temp == Temp_dzien1)
            {
                Dzien_1_wysokosc = 100;
                Dzien_2_wysokosc = (Temp_dzien2 * 100) / Temp_dzien1;
                Dzien_3_wysokosc = (Temp_dzien3 * 100) / Temp_dzien1;

                Lista_do_wykresu.Add(Dzien_1_wysokosc);
                Lista_do_wykresu.Add(Dzien_2_wysokosc);
                Lista_do_wykresu.Add(Dzien_3_wysokosc);
            }

            else if (Max_temp == Temp_dzien2)
            {
                Dzien_1_wysokosc = (Temp_dzien1 * 100) / Temp_dzien2;
                Dzien_2_wysokosc = 100;
                Dzien_3_wysokosc = (Temp_dzien3 * 100) / Temp_dzien2;

                Lista_do_wykresu.Add(Dzien_1_wysokosc);
                Lista_do_wykresu.Add(Dzien_2_wysokosc);
                Lista_do_wykresu.Add(Dzien_3_wysokosc);
            }

            else if (Max_temp == Temp_dzien3)
            {
                Dzien_1_wysokosc = (Temp_dzien1 * 100) / Temp_dzien3;
                Dzien_2_wysokosc = (Temp_dzien2 * 100) / Temp_dzien3;
                Dzien_3_wysokosc = 100;

                Lista_do_wykresu.Add(Dzien_1_wysokosc);
                Lista_do_wykresu.Add(Dzien_2_wysokosc);
                Lista_do_wykresu.Add(Dzien_3_wysokosc);
            }
            // zwrocenie wysokosci slupkow w formie listy
            return Lista_do_wykresu;
        }
    }
}
