using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WindowsControlsAndDialogs.Commands
{
    /// Command / Observable / Template Method / Chain of responsability
    public abstract class CommandBase : ICommand
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ICommand m_ChainedCommand; /// Chained object

        public CommandBase(ICommand i_ChainedCommand)
        {
            m_ChainedCommand = i_ChainedCommand;
        }

        public CommandBase()
        {
        }

        protected void invokePropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, e);
            }
        }

        public string Name { get; set; }

        private bool m_Enabled = true;
        public bool Enabled
        {
            get { return m_Enabled; }
            set
            {
                if (m_Enabled != value)
                {
                    m_Enabled = value;
                    invokePropertyChanged(new PropertyChangedEventArgs("Enabled"));
                }
            }
        }

        private bool m_Available = true;
        public bool Available
        {
            get { return m_Available; }
            set
            {
                if (m_Available != value)
                {
                    m_Available = value;
                    invokePropertyChanged(new PropertyChangedEventArgs("Available"));
                }
            }
        }

        private bool m_Checked;
        public bool Checked
        {
            get { return m_Checked; }
            set
            {
                if (m_Checked != value)
                {
                    m_Checked = value;
                    invokePropertyChanged(new PropertyChangedEventArgs("Checked"));
                }
            }
        }

        private string m_Title;
        public string Title
        {
            get { return m_Title; }
            set
            {
                if (m_Title != value)
                {
                    m_Title = value;
                    invokePropertyChanged(new PropertyChangedEventArgs("Title"));
                }
            }
        }

        private string m_ToolTip;
        public string ToolTip
        {
            get { return m_ToolTip; }
            set
            {
                if (m_ToolTip != value)
                {
                    m_ToolTip = value;
                    invokePropertyChanged(new PropertyChangedEventArgs("ToolTip"));
                }
            }
        }

        public void Execute(object param)
        {
            internalExecute(param);

            if (m_ChainedCommand != null)
            {
                m_ChainedCommand.Execute(param);
            }
        }

        protected abstract void internalExecute(object param);
    }
}
