using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Reflection;
using GenericSingletons;

namespace WindowsControlsAndDialogs
{
    /// <summary>
    /// A Generic proptotype repository
    /// </summary>
    /// <typeparam name="T">The type of the prototype</typeparam>
    public abstract class PrototypeRepository<T>
    {
        protected readonly Dictionary<Type, T> m_Dictionary = new Dictionary<Type, T>();

        public void AddPrototype(T i_Prototype, Type i_Type)
        {
            m_Dictionary.Add(i_Type, i_Prototype);
        }

        public T GetDeepCopy(Type i_Type)
        {
            T toClone = m_Dictionary[i_Type];
            if (toClone == null)
            {
                createPrototype(i_Type);
            }
            return (T)toClone.DeepClone();
        }

        public T GetReference(Type i_Type)
        {
            T toClone = m_Dictionary[i_Type];
            if (toClone == null)
            {
                createPrototype(i_Type);
            }
            return m_Dictionary[i_Type];
        }

        protected abstract T createPrototype(Type i_Type);

        // moved to extension method..
        //private T deepClone(T i_ToClone)
        //{
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        BinaryFormatter formatter = new BinaryFormatter();
        //        formatter.Serialize(stream, i_ToClone);
        //        stream.Seek(0, SeekOrigin.Begin);
        //        T copy = (T)formatter.Deserialize(stream);
        //        stream.Close();
        //        return copy;
        //    }
        //}

        public IEnumerable<Type> GetTypes()
        {
            return m_Dictionary.Keys;
        }
    }

    public static class ObjectExtensions
    {
        public static object DeepClone(this object i_ToClone)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, i_ToClone);
                stream.Seek(0, SeekOrigin.Begin);
                object copy = formatter.Deserialize(stream);
                stream.Close();
                return copy;
            }
        }
    }

    public class FormsRepository : PrototypeRepository<Form>
    {
        private Assembly m_Assembly = Assembly.GetExecutingAssembly();

        // SINGLETON!! (private ctor and public static access using the generic singleton)
        private FormsRepository()
        {
            PopulateRepositoryFromExecutingAssembly();
        }

        public static FormsRepository Instance { get { return Singleton<FormsRepository>.Instance; } }


        private void PopulateRepositoryFromExecutingAssembly()
        {
            foreach (Type type in m_Assembly.GetTypes())
            {
                if (type.IsSubclassOf(typeof(Form))
                    && type.IsPublic)
                {
                    this.AddPrototype(null, type);
                }
            }
        }

        protected override Form createPrototype(Type i_Type)
        {
            Form form = m_Assembly.CreateInstance(i_Type.FullName) as Form;
            m_Dictionary[i_Type] = form;
            return form;
        }
    }













































    //public static class ObjectExtensions
    //{
    //    public static object DeepClone(this object i_ThisToClone)
    //    {
    //        using (MemoryStream stream = new MemoryStream())
    //        {
    //            BinaryFormatter formatter = new BinaryFormatter();
    //            formatter.Serialize(stream, i_ThisToClone);
    //            stream.Seek(0, SeekOrigin.Begin);
    //            object copy = formatter.Deserialize(stream);
    //            stream.Close();
    //            return copy;
    //        }
    //    }
    //}

    //public class FormsRepository : PrototypeRepository<Form>
    //{
    //    private Assembly m_Assembly = Assembly.GetExecutingAssembly();

	
    //    // SINGLETON: a private CTOR and a public static access to the single instance:
    //    private FormsRepository()
    //    {
    //        PopulateRepositoryFromExecutingAssembly();
    //    }
    //    public static FormsRepository Instance { get { return Singleton<FormsRepository>.Instance; } }

    //    private void PopulateRepositoryFromExecutingAssembly()
    //    {
    //        foreach (Type type in m_Assembly.GetTypes())
    //        {
    //            if (type.IsSubclassOf(typeof(Form))
    //                && type.IsPublic)
    //            {
    //                this.AddPrototype(null, type);
    //            }
    //        }
    //    }

    //    protected override Form createPrototype(Type i_Type)
    //    {
    //        Form form = m_Assembly.CreateInstance(i_Type.FullName) as Form;
    //        m_Dictionary[i_Type] = form;
    //        return form;
    //    }
    //}
}
