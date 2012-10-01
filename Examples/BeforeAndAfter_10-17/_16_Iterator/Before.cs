using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace _16_Iterator
{
    public class Before
    {
        public static void Run()
        {
            Country country = new Country();

            /// this is what the client should do in order
            /// to get the list of city names of the country:
            for (int i = 0; i < country.Cities.Count; ++i)
            {
                Console.Write(country.Cities[i].Name + ", ");                
            }

            /// This is what we would like it to do:
            /// foreach (string cityName in country)
            /// {
            ///     Console.Write(cityName);
            /// }

            Console.WriteLine();

            /// Do we really want a client to be able to
            /// trash encapsulated data?
            country.Cities.Clear();
        }

        public class Country /// this is an aggregate
        {
            private readonly List<City> m_Cities;

            public Country()
            {
                m_Cities = new List<City>()
                {
                    new City() {Name = "Tel Aviv", Prefix = "03", Area = 122.7f, Population = 1250000},
                    new City() {Name = "Herzelia", Prefix = "09", Area = 35.17f, Population = 65200},
                    new City() {Name = "Haifa", Prefix = "04", Area = 105.5f, Population = 1080000},
                    new City() {Name = "Hadera", Prefix = "08", Area = 68.25f, Population = 225000}
                };
            }

            /// We have no choice but toe expose our collection..
            public List<City> Cities
            {
                get { return m_Cities; }
            }
        }

        public class City
        {
            public string Name { get; set; }
            public int Population { get; set; }
            public string Prefix { get; set; }
            public float Area { get; set; }
        } 
    }
}
