using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WindowsControlsAndDialogs.Commands
{
    /// Command / Observable
    public interface ICommand : INotifyPropertyChanged
    {
        void Execute(object param);

        string Name { get; set; }

        string Title { get; set; }

        string ToolTip { get; set; }

        bool Enabled { get; set; }

        bool Available { get; set; }

        bool Checked { get; set; }
    }

}
