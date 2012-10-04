using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace C12Ex02Y314440009V319512893
{
    public static class Singleton<T>
        where T : class
    {
        private static volatile T s_Instance;
        private static object s_LockObj = new object();

        //// static Singleton() { }

        public static T Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_LockObj)
                    {
                        if (s_Instance == null)
                        {
                            ConstructorInfo constructor = null;

                            try
                            {
                                constructor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[0], null);
                            }
                            catch (Exception exception)
                            {
                                throw new Exception(null, exception);
                            }

                            if (constructor == null || constructor.IsAssembly)
                            {
                                throw new Exception(string.Format("A private or protected constructor is missing for '{0}'.", typeof(T).Name));
                            }

                            s_Instance = constructor.Invoke(null) as T;
                        }
                    }
                }

                return s_Instance;
            }
        }
    }
}
