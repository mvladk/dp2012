using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GenericSingletons;
using System.Collections;

namespace WindowsControlsAndDialogs.Commands
{

    /// Prototype / Repository / Iterator
    public class CommandRepository : PrototypeRepository<string, ICommand>, IEnumerable<ICommand>
    {
        /// SINGLETON!! (private ctor and public static access using the generic singleton)
        private CommandRepository()
        {
        }

        public static CommandRepository Instance { get { return Singleton<CommandRepository>.Instance; } }

        protected override ICommand createPrototype(string i_Type)
        {
            return null; /// not implemented
        }

        #region IEnumerable<ICommand> Members

        public IEnumerator<ICommand> GetEnumerator()
        {
            //return m_Dictionary.Values.GetEnumerator();
            foreach (string key in this.GetTypes())
            {
                yield return m_Dictionary[key];
            }
        }

        #endregion

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        #endregion
    }
}
