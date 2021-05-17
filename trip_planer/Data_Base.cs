using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trip_planer
{
    /// <summary>
    /// Klasa <c>Data_Base</c> zawiera metody obsługujące zapis i usuwanie
    /// z tabel Ostatnie_tabela i Ulubione_tabela.
    /// <list type="bullet">
    /// <item>
    /// <term>Zapis_BD_ostatnie </term>
    /// <description>Metoda zapisu danych do Ostatnie_tabela</description>
    /// </item>
    /// <item>
    /// <term>Zapis_BD_ulubione </term>
    /// <description>Metoda zapisu danych do Ulubione_tabela</description>
    /// </item>
    /// <item>
    /// <term>Usun_BD_ulubione </term>
    /// <description>Metoda usuwania danych z Ulubione_tabela</description>
    /// </item>
    /// <item>
    /// <term>Usun_BD_ostatnie </term>
    /// <description>Metoda usuwania danych z Ostatnie_tabela</description>
    /// </item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para>Klasa <c>Data_Base</c> zawiera metody obsługujące zapis i usuwanie
    /// z tabel Ostatnie_tabela i Ulubione_tabela.</para>
    /// </remarks>
    public class Data_Base
    {
        /// <summary>
        /// Metoda realizująca zapis danych do Ostatnie_tabela.
        /// </summary>
        /// <remarks>
        /// <para>Metoda realizuje zapis danych do Ostatnie_tabela.</para>
        /// </remarks>
        /// <param name="poczatek">Nazwa miasta startowego.</param>
        /// <param name="koniec">Nazwa miasta docelowego.</param>
        /// <param name="data_">Data podróży.</param>
        public void Zapis_BD_ostatnie(string poczatek, string koniec, string data_)
        {
            var Mod_Tekst = new String_mod();
            Trip_planerDBEntities db = new Trip_planerDBEntities();
            // stworzenie nowego wiersza zawierajacego informacje o podrozy
            Ostatnie_tabela ostatnie_wyszukanie = new Ostatnie_tabela()
            {
                poczatek_wycieczki = Mod_Tekst.Popraw_Tekst(poczatek),
                cel_wycieczki = Mod_Tekst.Popraw_Tekst(koniec),
                data = data_
            };
            // dodanie go do bazy danych i zapisanie rezulatu
            db.Ostatnie_tabela.Add(ostatnie_wyszukanie);
            db.SaveChanges();
        }

        /// <summary>
        /// Metoda realizująca zapis danych do Ulubione_tabela.
        /// </summary>
        /// <remarks>
        /// <para>Metoda realizuje zapis danych do Ulubione_tabela.</para>
        /// </remarks>
        /// <param name="poczatek">Nazwa miasta startowego.</param>
        /// <param name="koniec">Nazwa miasta docelowego.</param>
        /// <param name="data_">Data podróży.</param>
        public void Zapis_BD_ulubione(string poczatek, string koniec, string data_)
        {
            var Mod_Tekst = new String_mod();
            Trip_planerDBEntities db = new Trip_planerDBEntities();
            // stworzenie nowego wiersza zawierajacego informacje o podrozy
            Ulubione_tabela ulubione_wyszukanie = new Ulubione_tabela()
            {
                poczatek_wycieczki = Mod_Tekst.Popraw_Tekst(poczatek),
                cel_wycieczki = Mod_Tekst.Popraw_Tekst(koniec),
                data = data_
            };
            // dodanie go do bazy danych i zapisanie rezulatu
            db.Ulubione_tabela.Add(ulubione_wyszukanie);
            db.SaveChanges();
        }

        /// <summary>
        /// Metoda realizująca usuwanie danych z Ostatnie_tabela.
        /// </summary>
        /// <remarks>
        /// <para>Metoda realizuje usuwanie danych do Ostatnie_tabela.</para>
        /// </remarks>
        /// <param name="o">Obiekt do usunięcia.</param>
        public void Usun_BD_ostatnie(Ostatnie_tabela o)
        {
            Trip_planerDBEntities db = new Trip_planerDBEntities();
            // znalezienie wybranego pola
            var wybrane = from ostatnie in db.Ostatnie_tabela
                          where ostatnie.Id_ostatnie == o.Id_ostatnie
                          select ostatnie;
            Ostatnie_tabela obj = wybrane.SingleOrDefault();
            // usuniecie wiersza, zapis stanu
            if (obj != null)
            {
                db.Ostatnie_tabela.Remove(obj);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Metoda realizująca usuwanie danych z Ulubione_tabela.
        /// </summary>
        /// <remarks>
        /// <para>Metoda realizuje usuwanie danych do Ulubione_tabela.</para>
        /// </remarks>
        /// <param name="o">Obiekt do usunięcia.</param>
        public void Usun_BD_ulubione(Ulubione_tabela o)
        {
            Trip_planerDBEntities db = new Trip_planerDBEntities();
            // znalezienie pola
            var wybrane = from ulubione in db.Ulubione_tabela
                          where ulubione.Id_ulubione == o.Id_ulubione
                          select ulubione;
            Ulubione_tabela obj = wybrane.SingleOrDefault();
            // usuniecie wiersza, zapis
            if (obj != null)
            {
                db.Ulubione_tabela.Remove(obj);
                db.SaveChanges();
            }
        }
    }
}
