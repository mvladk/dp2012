using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace _16_Iterator
{
    public class After
    {
        public static void Run()
        {
            Country country = new Country();

            /// the get_Cities property has been removed.
            /// Client has to use Iterator.
            for (IIterator it = country.CreateIterator() ; !it.IsDone ; it.Next())
            {
                Console.Write(it.CurrentItem as string + ", ");
            }


            /// This demonstrates the abililty to create many iterators
            /// and to iterate on them simultaniously
            IIterator it1 = country.CreateIterator();
            IIterator it2 = country.CreateIterator();

            it1.Next();
            it1.Next();
            Console.WriteLine(it1.CurrentItem + Environment.NewLine);

            Console.WriteLine("Two simultaneous iterations:");
            while (it1.Next() && it2.Next())
            {
                Console.Write("[" + it1.CurrentItem + "]" + " " + it2.CurrentItem + " ");
            }
        }

        /// The Aggregte interface
        public interface IAggregate
        {
            IIterator CreateIterator();
        }

        /// The Iterator interface
        public interface IIterator
        {
            bool Next();
            object CurrentItem { get; } /// polymorphic item reference
            bool IsDone { get; }
            void Reset();
        }

        /// the ConcreteAggregate
        public class Country : IAggregate
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

            public IIterator CreateIterator()
            {
                return new CityNamesIterator(this);
            }

            /// The ConcreteIterator:
            /// This is a private nested class, which is tightly-coupled 
            /// with the aggregate, and is specific to its needs.
            private class CityNamesIterator : IIterator
            {
                private Country m_Collection;
                private int m_CurrentIdx = 0;
                private int m_Count = -1;

                public CityNamesIterator(Country i_Collection)
                {
                    m_Collection = i_Collection;
                    m_Count = m_Collection.m_Cities.Count;
                }

                public void Reset()
                {
                    m_CurrentIdx = 0;
                }

                public bool Next()
                {
                    return ++m_CurrentIdx < m_Collection.m_Cities.Count;
                }

                public object CurrentItem
                {
                    get { return m_Collection.m_Cities[m_CurrentIdx].Name; }
                }

                public bool IsDone
                {
                    get { return m_CurrentIdx >= m_Collection.m_Cities.Count - 1; }
                }
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
