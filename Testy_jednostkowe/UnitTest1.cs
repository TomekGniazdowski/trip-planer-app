using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Threading;
using NUnit.Framework;

namespace Testy_jednostkowe
{
    public class STATestMethodAttribute : TestMethodAttribute
    {
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            if (Thread.CurrentThread.GetApartmentState() == ApartmentState.STA)
                return Invoke(testMethod);

            TestResult[] result = null;
            var thread = new Thread(() => result = Invoke(testMethod));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
            return result;
        }

        private TestResult[] Invoke(ITestMethod testMethod)
        {
            return new[] { testMethod.Invoke(null) };
        }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        // test metod modyfikujacych tekst
        public void TestMethodString()
        {
            var tekst = new trip_planer.String_mod();
            string pop_str_fun1 = tekst.Popraw_Tekst("ALA ma KOTA");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Ala ma kota", pop_str_fun1);

            string pop_str_fun2 = tekst.Popraw_Tekst2("ALA ma KOTA");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("ala ma kota", pop_str_fun2);

            string pop_date = tekst.Popraw_Date("10.04.2021");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("2021-04-10 15:00:00", pop_date);
        }

        // test metody obliczajacej wysokosci slupkow
        [TestMethod]
        public void TestMethodWykres()
        {
            var wykres = new trip_planer.Values_for_plot();
            List<double> lista_oblicz_wysokosci = new List<double>();
            List<double> poprawne_wysokosci = new List<double>();
            poprawne_wysokosci.Add(80.0);
            poprawne_wysokosci.Add(100.0);
            poprawne_wysokosci.Add(84.0);

            lista_oblicz_wysokosci = wykres.Oblicz_wysokosci_wykresu(20, 25, 21);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(poprawne_wysokosci[0], lista_oblicz_wysokosci[0]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(poprawne_wysokosci[1], lista_oblicz_wysokosci[1]);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(poprawne_wysokosci[2], lista_oblicz_wysokosci[2]);
        }

        // test metody zwracajacej losowy obraz
        [TestMethod]
        public void TestMethodObraz()
        {
            var obraz = new trip_planer.Imageprocessing();
            string losowy_obraz = obraz.Zwroc_losowy_obraz("img_testy");
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Bai-Sao-beach-in-Phu-Quoc-island.jpg", losowy_obraz);
        }

        // test metody wczytujacej dane o hotelach
        [TestMethod]
        public async Task TestMethodHotel()
        {
            try
            {
                var result = await trip_planer.HotelsProcessor.Wczytaj("Warszawa");
                Console.Write(result);
            }
            catch (Exception ex)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Wyj¹tek: " + ex.Message);
            }
        }

        // test metody wczytujacej dane o pogodzie
        [TestMethod]
        public async Task TestMethodPogodaAsync()
        {
            try
            {
                var result = await trip_planer.WeatherProcessor.Wczytaj("Warszawa");
                Console.Write(result);
            }
            catch (Exception ex)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Wyj¹tek: " + ex.Message);
            }
        }

        // test tworzenia API
        [TestMethod]
        public void TestMethodAPI()
        {
            try
            {
                trip_planer.API.Initialize_Client();
            }
            catch (Exception ex)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Wyj¹tek: " + ex.Message);
            }
        }


        // test walidacji weatherresult
        [TestMethod]
        public void TestMethodWalidacjaWeatherResult()
        {
            var pogoda_weatherweather = new trip_planer.WeatherWeather();
            pogoda_weatherweather.Description = "opis pogody abc";
            pogoda_weatherweather.Icon = "ikon";

            var pogoda_main = new trip_planer.WeatherMain();
            pogoda_main.Humidity = 20;
            pogoda_main.Pressure = 1000;
            pogoda_main.Temp = 30;
            pogoda_main.Temp_max = 40;
            pogoda_main.Temp_min = -10;

            var pogoda_weatherlist = new trip_planer.WeatherList();

            pogoda_weatherlist.Dt_txt = "A";
            pogoda_weatherlist.Main = pogoda_main;
            pogoda_weatherlist.Weather = new trip_planer.WeatherWeather[1];
            pogoda_weatherlist.Weather[0] = pogoda_weatherweather;


            var pogoda_weatherresult = new trip_planer.WeatherResult();
            pogoda_weatherresult.List = new trip_planer.WeatherList[40];

            for (int i = 0; i < 40; i++)
            {
                pogoda_weatherresult.List[i] = pogoda_weatherlist;
            }


            try
            {
                pogoda_main.Walidacja();
                pogoda_weatherlist.Walidacja();
                pogoda_weatherweather.Walidacja();
                pogoda_weatherresult.Walidacja();
            }
            catch (Exception ex)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Wyj¹tek: " + ex.Message);
            }
        }

        [TestMethod]
        public void TestMethodWalidacjaHotelsResult()
        {
            var hotel_suggestions = new trip_planer.HotelsSuggestion();

            var entity1 = new trip_planer.HotelsEntity();
            var entity2 = new trip_planer.HotelsEntity();
            var entity3 = new trip_planer.HotelsEntity();
            var entity4 = new trip_planer.HotelsEntity();

            entity1.Name = "AAAA";
            entity2.Name = "BBBB";
            entity3.Name = "CCCC";
            entity4.Name = "DDDD";

            hotel_suggestions.Group = "nazwa grupy obiektow";

            hotel_suggestions.Entities = new trip_planer.HotelsEntity[4];

            hotel_suggestions.Entities[0] = entity1;
            hotel_suggestions.Entities[1] = entity2;
            hotel_suggestions.Entities[2] = entity3;
            hotel_suggestions.Entities[3] = entity4;

            var hotel_results = new trip_planer.HotelsResult();
            hotel_results.Suggestions = new trip_planer.HotelsSuggestion[4];

            for (int i = 0; i < 4; i++)
            {
                hotel_results.Suggestions[i] = hotel_suggestions;
            }
            try
            {
                entity1.Walidacja();
                entity2.Walidacja();
                entity3.Walidacja();
                entity4.Walidacja();
                hotel_suggestions.Walidacja();
                hotel_results.Walidacja();
            }
            catch (Exception ex)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail("Wyj¹tek: " + ex.Message);
            }
        }
    }
}