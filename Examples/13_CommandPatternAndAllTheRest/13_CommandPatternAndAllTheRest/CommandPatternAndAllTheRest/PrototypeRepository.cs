using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WindowsControlsAndDialogs
{
    /// <summary>
    /// A Generic proptotype repository
    /// </summary>
    /// <typeparam name="T">The type of the prototype</typeparam>
    public abstract class PrototypeRepository<TKey, TType>
    {
        protected readonly Dictionary<TKey, TType> m_Dictionary = new Dictionary<TKey, TType>();

        public void AddPrototype(TType i_Prototype, TKey i_Type)
        {
            m_Dictionary.Add(i_Type, i_Prototype);
        }

        public TType GetDeepCopy(TKey i_Key)
        {
            TType toClone = m_Dictionary[i_Key];
            if (toClone == null)
            {
                createPrototype(i_Key);
            }
            return (TType)toClone.DeepClone();
        }

        public TType GetReference(TKey i_Key)
        {
            TType toClone = m_Dictionary[i_Key];
            if (toClone == null)
            {
                createPrototype(i_Key);
            }
            return m_Dictionary[i_Key];
        }

        protected abstract TType createPrototype(TKey i_Key);

        public IEnumerable<TKey> GetTypes()
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

}
