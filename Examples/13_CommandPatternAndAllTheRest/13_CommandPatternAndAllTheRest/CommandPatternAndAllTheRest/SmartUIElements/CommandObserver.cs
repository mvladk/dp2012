using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using WindowsControlsAndDialogs.Commands;

namespace WindowsControlsAndDialogs.SmartUIElements
{
    /// Observer
    public class CommandObserver
    {
        protected ICommand m_Command; /// this is my command. I am the command's ovserver
        protected ToolStripItem m_MenuItem; /// I am the item's visitor

        public ICommand Command
        {
            get { return m_Command; }
            set
            {
                if (m_Command != value)
                {
                    unHookFromCommand();
                    m_Command = value;
                    updateAccordingToCommandState();
                    hookToCommand();
                }
            }
        }

        public CommandObserver(ToolStripItem i_MenuItem)
        {
            m_MenuItem = i_MenuItem;
        }

        private void hookToCommand()
        {
            m_Command.PropertyChanged += new PropertyChangedEventHandler(m_Command_PropertyChanged);
        }

        private void m_Command_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            updateAccordingToCommandState();
        }

        private void updateAccordingToCommandState()
        {
            m_MenuItem.Enabled = m_Command.Enabled;
            m_MenuItem.Available = m_Command.Available;
            m_MenuItem.Visible = m_Command.Available;

            m_MenuItem.ToolTipText = m_Command.ToolTip;
            m_MenuItem.Text = m_Command.Title;

            updateSpecific();
        }

        protected virtual void updateSpecific()
        {
        }

        public static CommandObserver CreateCommandHolder(ToolStripItem i_Item)
        {
            CommandObserver retVal = null;
            if (i_Item is SmartTSMenutItem)
            {
                retVal = new CommandObserverForTSMenuItem(i_Item);
            }
            else if (i_Item is SmartTSButton)
            {
                retVal = new CommandObserverForTSButton(i_Item);
            }

            return retVal;
        }

        private void unHookFromCommand()
        {
            if (m_Command != null)
            {
                m_Command.PropertyChanged -= new PropertyChangedEventHandler(m_Command_PropertyChanged);
            }
        }
    }

    public class CommandObserverForTSMenuItem : CommandObserver
    {
        public CommandObserverForTSMenuItem(ToolStripItem i_Item)
            :base(i_Item)
        {}

        protected override void updateSpecific()
        {
            if (m_MenuItem is SmartTSMenutItem)
            {
                (m_MenuItem as SmartTSMenutItem).Checked = m_Command.Checked;
            }
        }
    }

    public class CommandObserverForTSButton : CommandObserver
    {
        public CommandObserverForTSButton(ToolStripItem i_Item)
            :base(i_Item)
        {}

        protected override void updateSpecific()
        {
            if (m_MenuItem is SmartTSButton)
            {
                (m_MenuItem as SmartTSButton).Checked = m_Command.Checked;
            }
        }
    }
}
