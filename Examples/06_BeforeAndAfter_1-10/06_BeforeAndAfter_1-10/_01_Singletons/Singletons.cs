using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Singletons
{
    /// version 0 - original
    public class SomeSingleton0
    {
        /// the single instance
        private static SomeSingleton0 s_Instance = null;

        /// a private (non accessible) parameterless  CTOR)
        private SomeSingleton0() { }

        /// The global access point
        public static SomeSingleton0 GetInstance()      
        {
            if (s_Instance == null)
            {
                s_Instance = new SomeSingleton0();
            }

            return s_Instance;
        }

        /// my other member functions..
    }

    /// version 1 - The C# way - sealed with a property
    public sealed class SomeSingleton1 /// sealed for clr-performance
    {
        private static SomeSingleton1 s_Instance = null;

        private SomeSingleton1() { }

        /// A property instead of a method
        public static SomeSingleton1 Instance 
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = new SomeSingleton1();
                }

                return s_Instance;
            }
        }

        /// my other member functions..
    }/// not thread-safe

    /// version 2 - simple thread safety with a lock
    public sealed class SomeSingleton2
    {
        private static SomeSingleton2 s_Instance = null;
        private static object s_LockObj = new Object();

        private SomeSingleton2() { }

        public static SomeSingleton2 Instance
        {
            get
            {
                lock (s_LockObj)
                {
                    if (s_Instance == null)
                    {
                        s_Instance = new SomeSingleton2();
                    }
                }

                return s_Instance;
            }
        }
    }
    /// 1. Not perfomant (locking on each access)

    /// version 3 - double-check locking 
    public sealed class SomeSingleton5
    {
        private static SomeSingleton5 s_Instance = null;
        private static object s_LockObj = new Object();

        private SomeSingleton5() { }

        public static SomeSingleton5 Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    lock (s_LockObj)
                    {
                        if (s_Instance == null)
                        {
                            s_Instance = new SomeSingleton5();
                        }
                    }
                }

                return s_Instance;
            }
        }
    }

    /// version 4 - static initialization (fully-lazy, not thread-safe, not exception-proof)
    public sealed class SomeSingleton3
    {
        public static readonly SomeSingleton3 s_Instance = new SomeSingleton3();

        private SomeSingleton3() { }     
    }

    /// version 4.1 - static initialization with a static CTOR (not thread safe, not exception-proof)
    public sealed class SomeSingleton3_1
    {
        public static readonly SomeSingleton3_1 Instance = new SomeSingleton3_1();

        private SomeSingleton3_1() { }

        // decalre a static CTOR to flag the class as BeforeFieldInit
        // and to not execute the static creation of the singleton before accessing the field
        static SomeSingleton3_1() { }
    }

    /// version 4.2 - static initialization with a static CTOR and -volatile- (not exception-proof, and not set-proof)
    public sealed class SomeSingleton3_2
    {
        /// can't use volatile and readonly together so we need to declare it as private
        private static volatile SomeSingleton3_2 s_Instance = new SomeSingleton3_2();

        private SomeSingleton3_2() { }

        // decalre a static CTOR to flag the class as BeforeFieldInit
        // and to not execute the static creation of the singleton before accessing the field
        static SomeSingleton3_2() { }

        /// can't use volatile in readonly together, so we need to declare it as private and expose a get property
        public static SomeSingleton3_2 Instance
        {
            get { return s_Instance; }
        }
    }

    /// Version 5 - Nested Holder to avoid BeforeFieldInit (not exception-proof)
    public sealed class SomeSingleton4
    {
        private SomeSingleton4() { }

        public static SomeSingleton4 Instance
        {
            get { return NestedHolder.instance; }
        }

        class NestedHolder
        {
            internal static volatile SomeSingleton4 instance = new SomeSingleton4();
        }
    }


    //
    // Copyright (c) DevInstinct Inc. All rights reserved.
    // http://devinstinct.com
    // Code author: Martin Lapierre
    // You cannot remove this copyright and notice.
    // This source file is part of the DevInstinct Application Framework.
    // You can redistribute the DevInstinct Application Framework in compiled, obfuscated form.
    // You cannot redistribute its source files without the written consent of DevInstinct Inc.
    // You can freely use and redistribute THIS source file: Singleton.cs

    /// <summary>
    /// Manages the single instance of a class.
    /// </summary>
    /// <typeparam name="T">Type of the singleton class.</typeparam>
    public static class Singleton<T>
        where T : class
    {
        /// <summary>
        /// The single instance of the target class.
        /// </summary>
        /// <remarks>
        /// The volatile keyword makes sure to remove any compiler optimization that could make concurrent 
        /// threads reach a race condition with the double-checked lock pattern used in the Instance property.
        /// See http://www.bluebytesoftware.com/blog/PermaLink,guid,543d89ad-8d57-4a51-b7c9-a821e3992bf6.aspx
        /// </remarks>
        private static volatile T s_Instance;

        /// <summary>
        /// The dummy object used for locking.
        /// </summary>
        private static object s_LockObj = new object();

        /// <summary>
        /// Type-initializer to prevent type to be marked with beforefieldinit.
        /// </summary>
        /// <remarks>
        /// This simply makes sure that static fields initialization occurs 
        /// when Instance is called the first time and not before.
        /// </remarks>
        static Singleton()
        {
        }

        /// <summary>
        /// Gets the single instance of the class.
        /// </summary>
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
                                /// Binding flags exclude public and static constructors.
                                constructor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, null, new Type[0], null);
                            }
                            catch (Exception exception)
                            {
                                throw new Exception(null, exception);
                            }
                            if (constructor == null || constructor.IsAssembly) /// Also exclude internal constructors.
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
