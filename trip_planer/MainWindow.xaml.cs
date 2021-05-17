using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace trip_planer
{

    /// <summary>
    /// Klasa częściowa <c>DispatcherTimersetup : Window</c> zawiera metody 
    /// obsługujące elementy wyświetlane w aplikacji.
    /// <list type="bullet">
    /// <item><term>DispatcherTimersetup</term></item>
    /// <item><term>dispatcherTimer_Tick</term></item>
    /// <item><term>Zmien_Obraz</term></item>
    /// <item><term>Zapisz_do_bazy_ostatnie</term></item>
    /// <item><term>Wyszukaj_podroz</term></item>
    /// <item><term>Dodaj_do_ulubionych</term></item>
    /// <item><term>Wyszukaj_ulubione</term></item>
    /// <item><term>Wyszukaj_ostatnie</term></item>
    /// <item><term>Usun_ulubione</term></item>
    /// <item><term>Usun_ostatnie</term></item>
    /// <item><term>Wyswietlanie_pogody</term></item>
    /// <item><term>Wyswietlanie_hoteli</term></item>
    /// <item><term>Wyswietlanie_wykresu</term></item>
    /// </list>
    /// </summary>
    /// <remarks>
    /// <para> Klasa częściowa <c>DispatcherTimersetup : Window</c> zawiera  
    /// metody obsługujące elementy wyświetlane w aplikacji.</para>
    /// </remarks>
    public partial class DispatcherTimersetup : Window
    {
        /// <summary>
        /// Konstruktor realizuje wyświetlenie danych z bazy i wywołuje zmianę 
        /// obrazu.
        /// </summary>
        /// <remarks>
        /// <para>Konstruktor realizuje wyświetlenie danych z bazy, wywołuje  
        /// zmianę obrazu i inicjalizuje klienta API.</para>
        /// </remarks>
        public DispatcherTimersetup()
        {
            InitializeComponent();
            Trip_planerDBEntities db = new Trip_planerDBEntities();
            // wyswietlenie danych z bazy
            var ulubione = from ulub in db.Ulubione_tabela select ulub;
            grid_ulubione.ItemsSource = ulubione.ToList();
            var ostatnie = from ost in db.Ostatnie_tabela select ost;
            grid_ostatnie.ItemsSource = ostatnie.ToList();
            API.Initialize_Client();

            // wykonwyanie co 15 sekund - zmiana obrazka
            DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 15);
            dispatcherTimer.Start();
        }

        // funkcja zmieniajaca obraz co okreslona ilosc sekund
        /// <summary>
        /// Metoda realizuje zmianę obrazu co określoną ilość sekund.
        /// </summary>
        /// <remarks>
        /// <para>Metoda realizuje zmianę obrazu co określoną ilość sekund.
        /// </para>
        /// </remarks>
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var Obraz = new Imageprocessing();
            Zmien_Obraz(Obraz.Zwroc_losowy_obraz("img_window_1"));
        }

        // zmiana obrazu
        /// <summary>
        /// Metoda zmieniająca obraz.
        /// </summary>
        /// <remarks>
        /// <para>Metoda zmieniająca obraz.</para>
        /// </remarks>
        /// <param name="nazwa_pliku">Nazwa pliku z obrazem.</param>
        public void Zmien_Obraz(string nazwa_pliku)
        {
            Obraz_pokaz_slajdow.Source = new BitmapImage(new Uri($@"/img_window_1/{ nazwa_pliku }", UriKind.Relative));
        }

        /// <summary>
        /// Metoda zapisująca dane podróży do bazy ostatnich.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Metoda zapisująca dane podróży do bazy ostatnich.
        /// </para>
        /// </remarks>
        /// <param name="poczatek">Nazwa miasta startowego.</param>
        /// <param name="koniec">Nazwa miasta docelowego.</param>
        /// <param name="data">Data podróży.</param>
        /// <exception cref="System.Exception">Wyrzucany, gdy zapis danych nie 
        /// powiódł się.</exception> 
        public void Zapisz_do_bazy_ostatnie(string poczatek, string koniec, string data)
        {
            try
            {
                var Baza_danych = new Data_Base();
                // zapis do bazy danych
                Baza_danych.Zapis_BD_ostatnie(poczatek, koniec, data);
                Trip_planerDBEntities db = new Trip_planerDBEntities();
                // aktualizacja data grid'a
                grid_ostatnie.ItemsSource = db.Ostatnie_tabela.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Data write error :(\n" + ex);
            }
        }

        /// <summary>
        /// Metoda sprawdzająca wprowadzone dane, wyświetlająca odpowiedź API 
        /// i zapisująca do bazy ostatnich.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Metoda sprawdzająca wprowadzone dane, wyświetlająca odpowiedź API 
        /// i zapisująca do bazy ostatnich.
        /// </para>
        /// </remarks>
        /// <exception cref="System.IndexOutOfRangeException">Wyrzucany, gdy data 
        /// jest zbyt odległa lub przeszła.</exception>        
        /// <exception cref="System.Exception">Wyrzucany, gdy walidacja zgłosiła 
        /// błędy.</exception> 
        public async void Wyszukaj_podroz(object sender, RoutedEventArgs e)
        {
            var Mod_Tekst = new String_mod();
            var input = new UserInput();
            // odczyt danych
            input.Start = start_city.Text;
            input.Stop = stop_city.Text;
            input.Date = data.Text;
            // sprawdzenie warunku - wszystkie pola musza byc wypelnione
            if (start_city.Text.Length > 0 && stop_city.Text.Length > 0 && data.Text.Length > 0 && Mod_Tekst.Popraw_Date(data.Text) != "-1")
            {
                // sproawdzenie daty do prawidlowego formatu
                string new_data = Mod_Tekst.Popraw_Date(data.Text);
                // warunek - miasta poczatkowe i koncowe musza byc rozne
                if (Mod_Tekst.Popraw_Tekst2(start_city.Text) != Mod_Tekst.Popraw_Tekst2(stop_city.Text))
                {
                    try
                    {
                        input.Walidacja();
                        // uruchomienie wyszukiwania planera - pogoda
                        Wyswietlanie_pogody(stop_city.Text, new_data);
                        // podsumowanie podrozy
                        start_opis.Text = "beginning of the trip: " + $"{ Mod_Tekst.Popraw_Tekst(start_city.Text) }";
                        stop_opis.Text = "destination of the trip: " + $"{ Mod_Tekst.Popraw_Tekst(stop_city.Text) }";
                        data_opis.Text = "date of the trip: " + $"{ data.Text }";
                        // zapis do bazy danych
                        Zapisz_do_bazy_ostatnie(Mod_Tekst.Popraw_Tekst(start_city.Text), Mod_Tekst.Popraw_Tekst(stop_city.Text), data.Text);
                        // planer - informacje o hotelach, dzielnicach, transporcie
                        Wyswietlenie_hoteli(stop_city.Text);
                    }
                    // warunek - api pogodowe dziala do 3 dni do przodu
                    catch (System.IndexOutOfRangeException)
                    {
                        MessageBox.Show("Data może wykraczać 3 dni do przodu.");
                    }
                    //
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString().Substring(ex.ToString().IndexOf(" ") + 1, ex.ToString().IndexOf("\n") - 15));
                    }
                }
                // warunek - te same miasta poczatkowe i koncowe
                if (Mod_Tekst.Popraw_Tekst2(start_city.Text) == Mod_Tekst.Popraw_Tekst2(stop_city.Text))
                {
                    MessageBox.Show("The starting city and the end city are the same :(");
                }
            }
            // warunek - nie wszystkie pola wypelnione
            else
            {
                MessageBox.Show("Please complete all fields :)");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// Metoda dodająca parametry podróży do ulubionych.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Metoda dodająca parametry podróży do ulubionych.
        /// </para>
        /// </remarks>
        /// <exception cref="System.InvalidCastException">Wyrzucany, gdy któreś 
        /// z miast nie zostało podane.</exception> 
        public void Dodaj_do_ulubionych(object sender, RoutedEventArgs e)
        {
            // obsluga bazy danych - dodanie podrozy do ulubionych
            try
            {
                // odczyt wartosci
                string poczatek = start_city.Text;
                string koniec = stop_city.Text;
                string data_ = data.Text;
                var Baza_danych = new Data_Base();
                // zapis do bazy
                Baza_danych.Zapis_BD_ulubione(poczatek, koniec, data_);
                Trip_planerDBEntities db = new Trip_planerDBEntities();
                // aktualizcja data grid'a
                grid_ulubione.ItemsSource = db.Ulubione_tabela.ToList();
            }
            catch (System.InvalidCastException)
            {
                MessageBox.Show("Please provide the names of both cities.");
            }
        }

        /// <summary>
        /// Metoda wyszukująca parametry podróży w ulubionych.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Metoda wyszukująca parametry podróży w ulubionych.
        /// </para>
        /// </remarks>
        /// <exception cref="System.InvalidCastException">Wyrzucany, gdy pole
        /// wyszukiwania nie zostało podane.</exception> 
        public void Wyszukaj_ulubione(object sender, RoutedEventArgs e)
        {
            // warunek - pole musi zostac zaznaczone
            if (grid_ulubione.SelectedItems.Count > 0)
            {
                // warunek - pole nie moze byc puste
                try
                {
                    Trip_planerDBEntities db = new Trip_planerDBEntities();
                    Ulubione_tabela o = (Ulubione_tabela)grid_ulubione.SelectedItems[0];
                    // znalezienie zaznaczonej pozycji
                    var wybrane = from ulubione in db.Ulubione_tabela
                                  where ulubione.Id_ulubione == o.Id_ulubione
                                  select ulubione;
                    Ulubione_tabela obj = wybrane.SingleOrDefault();
                    // wypelnienie pol zaznaczonymi danymi
                    if (obj != null)
                    {
                        start_city.Text = obj.poczatek_wycieczki;
                        stop_city.Text = obj.cel_wycieczki;
                        data.Text = obj.data;
                    }
                }
                catch (System.InvalidCastException)
                {
                    MessageBox.Show("The search field cannot be empty.");
                }
            }
            else
            {
                MessageBox.Show("Please mark the field to search :)");
            }
        }

        /// <summary>
        /// Metoda wyszukująca parametry podróży w ostatnich.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Metoda wyszukująca parametry podróży w ostatnich.
        /// </para>
        /// </remarks>
        /// <exception cref="System.InvalidCastException">Wyrzucany, gdy pole
        /// wyszukiwania nie zostało podane.</exception> 
        public void Wyszukaj_ostatnie(object sender, RoutedEventArgs e)
        {
            // warunek - pole musi zostac zaznaczone
            if (grid_ostatnie.SelectedItems.Count > 0)
            {
                // warunek - pole nie moze byc puste
                try
                {
                    Trip_planerDBEntities db = new Trip_planerDBEntities();
                    Ostatnie_tabela o = (Ostatnie_tabela)grid_ostatnie.SelectedItems[0];
                    // znalezienie zaznaczonej pozycji
                    var wybrane = from ostatnie in db.Ostatnie_tabela
                                  where ostatnie.Id_ostatnie == o.Id_ostatnie
                                  select ostatnie;
                    Ostatnie_tabela obj = wybrane.SingleOrDefault();
                    // wypelnienie pol zaznaczonymi danymi
                    if (obj != null)
                    {
                        start_city.Text = obj.poczatek_wycieczki;
                        stop_city.Text = obj.cel_wycieczki;
                        data.Text = obj.data;
                    }
                }
                catch (System.InvalidCastException)
                {
                    MessageBox.Show("The search field cannot be empty.");
                }
            }
            else
            {
                MessageBox.Show("Please mark the field to search :)");
            }
        }

        /// <summary>
        /// Metoda usuwająca pole z ulubionych.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Metoda usuwająca pole z ulubionych.
        /// </para>
        /// </remarks>
        /// <exception cref="System.InvalidCastException">Wyrzucany, gdy pole
        /// do usunięcianie zostało podane.</exception> 
        public void Usun_ulubione(object sender, RoutedEventArgs e)
        {
            if (grid_ulubione.SelectedItems.Count > 0)
            {
                try
                {
                    var Baza_danych = new Data_Base();
                    Trip_planerDBEntities db = new Trip_planerDBEntities();
                    // usuniecie zaznaczonego pola
                    Baza_danych.Usun_BD_ulubione((Ulubione_tabela)grid_ulubione.SelectedItems[0]);
                    // aktualizacja
                    grid_ulubione.ItemsSource = db.Ulubione_tabela.ToList();
                }
                catch (System.InvalidCastException)
                {
                    MessageBox.Show("The field to be deleted cannot be empty.");
                }
            }
            else
            {
                MessageBox.Show("Please mark the field to delete :)");
            }
        }

        /// <summary>
        /// Metoda usuwająca pole z ostatnich.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Metoda usuwająca pole z ostatnich.
        /// </para>
        /// </remarks>
        /// <exception cref="System.InvalidCastException">Wyrzucany, gdy pole
        /// do usunięcia nie zostało podane.</exception> 
        public void Usun_ostatnie(object sender, RoutedEventArgs e)
        {
            if (grid_ostatnie.SelectedItems.Count > 0)
            {
                try
                {
                    var Baza_danych = new Data_Base();
                    Trip_planerDBEntities db = new Trip_planerDBEntities();
                    // usuniecie zaznaczonego pola
                    Baza_danych.Usun_BD_ostatnie((Ostatnie_tabela)grid_ostatnie.SelectedItems[0]);
                    // aktualizacja
                    grid_ostatnie.ItemsSource = db.Ostatnie_tabela.ToList();
                }
                catch (System.InvalidCastException)
                {
                    MessageBox.Show("The field to be deleted cannot be empty.");
                }
            }
            else
            {
                MessageBox.Show("Please mark the field to delete :)");
            }
        }

        /// <summary>
        /// Metoda wywietlająca informacje o pogodzie.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Metoda wywietlająca informacje o pogodzie.
        /// </para>
        /// </remarks>
        /// <param name="stop_city">Nazwa miasta docelowego.</param>
        /// <param name="new_data">Nazwa miasta docelowego.</param>
        /// <exception cref="System.Exception">Wyrzucany, gdy podano 
        /// błędnąnazwe miasta.</exception> 
        /// <exception cref="System.IndexOutOfRangeException">Wyrzucany, gdy 
        /// podano nieprawidłową datę.</exception> 
        public async void Wyswietlanie_pogody(string stop_city, string new_data)
        {
            var Mod_Tekst = new String_mod();
            try
            {
                // modyfikacja tekstu + odczyt
                var infoweather = await WeatherProcessor.Wczytaj(Mod_Tekst.Popraw_Tekst2(stop_city));
                int index = 0;
                foreach (WeatherList list in infoweather.List)
                {
                    if (list.Dt_txt.Equals(new_data))
                        break;
                    ++index;
                }
                // wyczyszczenie list box'a z poprzednich danych
                listBoxpogoda.Items.Clear();
                try
                {
                    // wypisanie informacji
                    listBoxpogoda.Items.Add($"Weather in city { Mod_Tekst.Popraw_Tekst(stop_city) }:");

                    listBoxpogoda.Items.Add($"Temperature 1st day: {infoweather.List[index].Main.Temp} \u00B0C");
                    listBoxpogoda.Items.Add($"Pressure 1st day: {infoweather.List[index].Main.Pressure} hPa");
                    listBoxpogoda.Items.Add($"Humidity 1st day: {infoweather.List[index].Main.Humidity}%");
                    listBoxpogoda.Items.Add($"Description 1st day: {infoweather.List[index].Weather[0].Description}");
                    // wyswietlenie ikonki pogody
                    Obraz_pogoda1.Source = new BitmapImage(new Uri($@"/icons/{ $"{infoweather.List[index].Weather[0].Icon}.png" }", UriKind.Relative));

                    listBoxpogoda.Items.Add($"Temperature 2nd day: {infoweather.List[index + 8].Main.Temp} \u00B0C");
                    listBoxpogoda.Items.Add($"Pressure 2nd day: {infoweather.List[index + 8].Main.Pressure} hPa");
                    listBoxpogoda.Items.Add($"Humidity 2nd day: {infoweather.List[index + 8].Main.Humidity}%");
                    listBoxpogoda.Items.Add($"Description 2nd day: {infoweather.List[index + 8].Weather[0].Description}");
                    Obraz_pogoda2.Source = new BitmapImage(new Uri($@"/icons/{ $"{infoweather.List[index + 8].Weather[0].Icon}.png" }", UriKind.Relative));

                    listBoxpogoda.Items.Add($"Temperature 3rd day: {infoweather.List[index + 16].Main.Temp} \u00B0C");
                    listBoxpogoda.Items.Add($"Pressure 3rd day: {infoweather.List[index + 16].Main.Pressure} hPa");
                    listBoxpogoda.Items.Add($"Humidity 3rd day: {infoweather.List[index + 16].Main.Humidity}%");
                    listBoxpogoda.Items.Add($"Description 3rd day: {infoweather.List[index + 16].Weather[0].Description}");
                    Obraz_pogoda3.Source = new BitmapImage(new Uri($@"/icons/{ $"{infoweather.List[index + 16].Weather[0].Icon}.png" }", UriKind.Relative));

                    Wyswietlenie_wykresu(infoweather.List[index].Main.Temp, infoweather.List[index + 8].Main.Temp, infoweather.List[index + 16].Main.Temp, true);
                }
                // warunek - pogoda moze wybiegac do 3 dni do przodu - ograniczenia api
                catch (System.IndexOutOfRangeException)
                {
                    listBoxpogoda.Items.Clear();
                    Obraz_pogoda1.Source = new BitmapImage(new Uri($@"/icons/unknown.png", UriKind.Relative));
                    Obraz_pogoda2.Source = new BitmapImage(new Uri($@"/icons/unknown.png", UriKind.Relative));
                    Obraz_pogoda3.Source = new BitmapImage(new Uri($@"/icons/unknown.png", UriKind.Relative));
                    Wyswietlenie_wykresu(0, 0, 0, false);
                    MessageBox.Show("The date of the first day can be up to three days ahead.");
                }
            }
            // literowka lub brak polaczenia z internetem
            catch(System.Exception)
            {
                MessageBox.Show("You probably made a typo in the name of the town.");
            }
        }

        /// <summary>
        /// Metoda wywietlająca informacje o punktach w mieście.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Metoda wywietlająca informacje o punktach w mieście.
        /// </para>
        /// </remarks>
        /// <param name="stop_city">Nazwa miasta docelowego.</param>
        /// <exception cref="System.Exception">Wyrzucany, gdy podano 
        /// błędnąnazwe miasta.</exception> 
        /// <exception cref="System.Exception">Wyrzucany, gdy 
        /// nie otrzymano odpowiednich informacji.</exception> 
        public async void Wyswietlenie_hoteli(string stop_city)
        {
            var Mod_Tekst = new String_mod();
            // odczyt informacji
            var infohotels = await HotelsProcessor.Wczytaj(Mod_Tekst.Popraw_Tekst2(stop_city));
            try
            {
                // czyszczenie list box'a
                listBoxhotele.Items.Clear();
                listBoxhotele.Items.Add($"Info about city { Mod_Tekst.Popraw_Tekst(stop_city) }:");
                // wyswietlenie informacji
                if (infohotels.Suggestions[1].Entities.Length != 0)
                {
                    listBoxhotele.Items.Add("Hotels:");
                    foreach (HotelsEntity entity in infohotels.Suggestions[1].Entities) // 0 - hotele, 1 - transport, 2 - pkty orientacyjne, 3 - części miasta
                    {
                        listBoxhotele.Items.Add($"Name of hotel: {entity.Name}");
                    }
                }
                else listBoxhotele.Items.Add("No information about hotels.");
                if (infohotels.Suggestions[3].Entities.Length != 0)
                {
                    listBoxhotele.Items.Add("Means of transport:");
                    foreach (HotelsEntity entity in infohotels.Suggestions[3].Entities) // 0 - hotele, 1 - transport, 2 - pkty orientacyjne, 3 - części miasta
                    {
                        listBoxhotele.Items.Add($"Name of mean of transport: {entity.Name}");
                    }
                }
                else listBoxhotele.Items.Add("No information about means of transport.");
                if (infohotels.Suggestions[2].Entities.Length != 0)
                {
                    listBoxhotele.Items.Add("Landmarks:");
                    foreach (HotelsEntity entity in infohotels.Suggestions[2].Entities) // 0 - hotele, 1 - transport, 2 - pkty orientacyjne, 3 - części miasta
                    {
                        listBoxhotele.Items.Add($"Name of landmark: {entity.Name}");
                    }
                }
                else listBoxhotele.Items.Add("No information about landmarks.");
                if (infohotels.Suggestions[0].Entities.Length != 0)
                {
                    listBoxhotele.Items.Add("City ​​districts:");
                    foreach (HotelsEntity entity in infohotels.Suggestions[0].Entities) // 0 - hotele, 1 - transport, 2 - pkty orientacyjne, 3 - części miasta
                    {
                        listBoxhotele.Items.Add($"Name of district: {entity.Name}");
                    }
                }
                else listBoxhotele.Items.Add("No information about city districts.");
            }
            catch
            {
                MessageBox.Show("No information found :(");
            }
        }

        // wykres - jest tworzony wzgledem najwyzszej temperatury,
        // 2 kolejne slupki sa proporcjonalne do niej
        /// <summary>
        /// Metoda przygotowująca dane do wyświetlenia na wykresie.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Metoda przygotowująca dane do wyświetlenia na wykresie.
        /// </para>
        /// </remarks>
        /// <param name="Temp_dzien1">Nazwa miasta docelowego.</param>
        /// <param name="Temp_dzien2">Nazwa miasta docelowego.</param>
        /// <param name="Temp_dzien3">Nazwa miasta docelowego.</param>
        /// <param name="Czy_poprawny">Nazwa miasta docelowego.</param>
        public void Wyswietlenie_wykresu(double Temp_dzien1, double Temp_dzien2, double Temp_dzien3, bool Czy_poprawny)
        {
            var Wykres = new Values_for_plot();
            // poprawne dane
            if (Czy_poprawny == true)
            {
                var Lista_wartosci = Wykres.Oblicz_wysokosci_wykresu(Temp_dzien1, Temp_dzien2, Temp_dzien3);
                // odczyt, wypisanie temperatur
                Temp_Dzien_1.Text = Temp_dzien1.ToString() + "\u00B0C";
                Temp_Dzien_2.Text = Temp_dzien2.ToString() + "\u00B0C";
                Temp_Dzien_3.Text = Temp_dzien3.ToString() + "\u00B0C";
                // zapis wartosci wysokosci
                Dzien_1.Height = Lista_wartosci[0];
                Dzien_2.Height = Lista_wartosci[1];
                Dzien_3.Height = Lista_wartosci[2];
            }
            // blad wynikajacy z przekroczenia zakresu
            if (Czy_poprawny == false)
            {
                Dzien_1.Height = 0;
                Dzien_2.Height = 0;
                Dzien_3.Height = 0;

                Temp_Dzien_1.Text = "Lack of information";
                Temp_Dzien_2.Text = "Lack of information";
                Temp_Dzien_3.Text = "Lack of information";
            }
        }

        private void grid_ulubione_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
