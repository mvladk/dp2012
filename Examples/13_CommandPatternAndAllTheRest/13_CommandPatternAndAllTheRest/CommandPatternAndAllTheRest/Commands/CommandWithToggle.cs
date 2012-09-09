using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsControlsAndDialogs.Commands
{
    /// Chain of responsibility
    public class CommandWithToggle : CommandBase
    {
        public CommandWithToggle(ICommand i_ChainedCommand)
            : base(i_ChainedCommand)
        { }

        protected override void internalExecute(object param)
        {
            this.Checked = !this.Checked;
        }
    }
}
