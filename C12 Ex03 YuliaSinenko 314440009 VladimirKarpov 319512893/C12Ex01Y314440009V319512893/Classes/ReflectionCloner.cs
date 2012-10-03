using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace C12Ex03Y314440009V319512893
{
    public static class ReflectionCloner<T>
        where T : class
    {
        public static void CopyPropertiesUsingReflectionToCurrentObject(T i_CloneFrom, ref T i_CloneTo)
       {
           // copy properties using reflection to current object 
           foreach (var oPropertyInfo in i_CloneFrom.GetType().GetProperties())
           {
               // Check the method is not static
               if (!oPropertyInfo.GetGetMethod().IsStatic)
               {
                   // Check this property can write
                   if (i_CloneTo.GetType().GetProperty(oPropertyInfo.Name).CanWrite)
                   {
                       // Check the supplied property can read
                       if (oPropertyInfo.CanRead)
                       {
                           // Update the properties on this object
                           i_CloneTo.GetType().GetProperty(oPropertyInfo.Name).SetValue(i_CloneTo, oPropertyInfo.GetValue(i_CloneFrom, null), null);
                       }
                   }
               }
           }
       }
    }
}
