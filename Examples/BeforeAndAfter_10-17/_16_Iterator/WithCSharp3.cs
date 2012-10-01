using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Net.Sockets;
using System.Collections;

namespace _16_Iterator
{
    /// <summary>
    /// 1. In C# 1.1 we already have an IAggregate insterface called IEnumerable
    /// 2. In C# 1.1 we already have an IIterator insterface called IEnumerator
    /// 3. In C# 1.1 we already have a traverse mechanism on aggregates called 'foreach'
    /// 4. In C# 2.0 we can create an on-the-fly iterator using the 'yield' mechanism
    /// 5. In C# 3.0 we can use anonymous types ot return projected objects
    /// </summary>
    public class WithCSharp3
    {
        public static void Run()
        {
            Country country = new Country();

            /// Using the iterator (enumerator) the C# way:
            Console.WriteLine("Using the iterator (enumerator) the C# way");
            for (IEnumerator it = (country as IEnumerable).GetEnumerator();
                it.MoveNext(); )
            {
                Console.Write((it.Current as object[])[0] + ", ");
            }

            /// You can also create two parallel iterators:
            IEnumerator it1 = (country as IEnumerable).GetEnumerator();
            IEnumerator it2 = (country as IEnumerable).GetEnumerator();
            /// advancing one of the iterators two demonstrate independency:
            it1.MoveNext();
            it1.MoveNext();
            Console.WriteLine(it1.Current);

            Console.WriteLine("Two simultaneous iterations:");
            while (it1.MoveNext() && it2.MoveNext())
            {
                Console.Write("[" + it1.Current + "]" + " " + it2.Current + " ");
            }
            Console.WriteLine();

            Console.WriteLine("using the 'foreach' keyword on our country:");
            /// Using the 'foreach' keyword on our country (which is an IEnumerable):
            foreach (string cityName in country)
            {
                Console.Write(cityName);
            }
        }

        /// The ConcreteAggregate (we already have an IAggregate insterface called IEnumerable)
        /// We declared our selfs as IEnumerable so clients will know we can give an iterator (IEnumerator)
        /// We also declared our selfs as IEnumerable<string> so clients will know we can give an iterator (IEnumerator)
        public class Country : IEnumerable, IEnumerable<string>
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

            /// <summary>
            /// returns the iterator of the list:
            /// </summary>
            /// IEnumerator IEnumerable.GetEnumerator()
            /// {
            ///    return m_Cities.GetEnumerator();
            /// }    
            
            /// <summary>
            /// returns an iterator for city names:
            /// </summary>        
            IEnumerator IEnumerable.GetEnumerator()
            {
                return new BigCityNamesIterator(this);

                /// another way to create an iterator for city names:
                /// using 'yield to create an "on the fly" iterator
                //for (int i = 0; i < m_Cities.Count; ++i)
                //{
                //    if (m_Cities[i].Population > 1000000)
                //    {
                //        continue;
                //    }
                //    yield return m_Cities[i].Name;

                //    /// or, return a projected object in one of the three ways:
                //    /// (1) an object array
                //    //yield return new object[]
                //    //    {
                //    //        m_Collection.m_Cities[m_CurrentIdx].Name,
                //    //        m_Collection.m_Cities[m_CurrentIdx].Area
                //    //    };

                //    /// (2) a dedicated partial class
                //    //yield return new PartialCity()
                //    //    {
                //    //        Name = m_Collection.m_Cities[m_CurrentIdx].Name,
                //    //        Area = m_Collection.m_Cities[m_CurrentIdx].Area
                //    //    };
                //    /// (3) an anonymous type:
                //    //yield return new
                //    //{
                //    //    Name = m_Collection.m_Cities[m_CurrentIdx].Name,
                //    //    Area = m_Collection.m_Cities[m_CurrentIdx].Area
                //    //};
                //}
            }


            /// <summary>
            /// Using the yield keyword to return an iterator:
            /// </summary>
            IEnumerator<string> IEnumerable<string>.GetEnumerator()
            {
                for (int i = 0; i < m_Cities.Count; ++i)
                {
                    if (m_Cities[i].Population > 1000000)
                    {
                        continue;
                    }
                    yield return m_Cities[i].Name;
                }
            }

            private class BigCityNamesIterator : IEnumerator
            {
                private Country m_Collection;
                private int m_CurrentIdx = -1;
                private int m_Count = -1;

                public BigCityNamesIterator(Country i_Collection)
                {
                    m_Collection = i_Collection;
                    m_Count = m_Collection.m_Cities.Count;
                }

                public object Current
                {
                    get
                    {
                        return m_Collection.m_Cities[m_CurrentIdx].Name;

                        /// for a projected object, you can use either:
                        /// (1) an object array
                        //return new object[]
                        //    {
                        //        m_Collection.m_Cities[m_CurrentIdx].Name,
                        //        m_Collection.m_Cities[m_CurrentIdx].Area
                        //    };
                        
                        /// (2) a dedicated partial class
                        //return new PartialCity()
                        //    {
                        //        Name = m_Collection.m_Cities[m_CurrentIdx].Name,
                        //        Area = m_Collection.m_Cities[m_CurrentIdx].Area
                        //    };
                        /// (3) an anonymous type:
                        //return new
                        //{
                        //    Name = m_Collection.m_Cities[m_CurrentIdx].Name,
                        //    Area = m_Collection.m_Cities[m_CurrentIdx].Area
                        //};
                       
                    }
                }

                public bool MoveNext()
                {
                    ++m_CurrentIdx;
                    if (m_Collection.m_Cities[m_CurrentIdx].Population > 100000)
                    {
                        ++m_CurrentIdx;
                    }
                    return m_CurrentIdx < m_Collection.m_Cities.Count;
                }

                public void Reset()
                {
                    m_CurrentIdx = 0;
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

        /// <summary>
        /// A dedicated partial object.
        /// Can be replaced with an anonymous object
        /// </summary>
        public class PartialCity
        {
            public float Area { get; set; }
            public string Name { get; set; }
        }
    }
}
