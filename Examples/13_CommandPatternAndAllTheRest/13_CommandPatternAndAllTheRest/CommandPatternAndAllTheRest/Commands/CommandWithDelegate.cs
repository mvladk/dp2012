using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsControlsAndDialogs.Commands
{
    /// Command / Teplate Method / Strategy
    public class CommandWithDelegate : CommandBase
    {
        public Action Action { get; set; }  /// This is my strategy object which I will invoke when someone will execute me :)

        public CommandWithDelegate(Action i_Action)
        {
            this.Action = i_Action;
        }

        public CommandWithDelegate(ICommand i_ChainedCommand)
            : base(i_ChainedCommand)
        { }

        protected override void internalExecute(object param)
        {
            /// in the template method, i execute my strategy object
            Action.Invoke();
        }
    }
}
