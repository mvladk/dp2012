using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsControlsAndDialogs.Commands;

namespace WindowsControlsAndDialogs.SmartUIElements
{
    /// class Proxy / Visitor
    public class SmartTSMenutItem : ToolStripMenuItem
    {
        private CommandObserver m_CommandHolder; /// this is my command holder (visitor)
        private ToolStripMenuItem m_BasicMenuItem; /// I wish I could hold an adaptee.. but I HAVE to derive from..

        public ICommand Command
        {
            set { m_CommandHolder.Command = value; }
        }

        public SmartTSMenutItem(ToolStripMenuItem i_MenuItem, ICommand i_Command)
        {
            m_BasicMenuItem = i_MenuItem;
            i_Command.Title = i_MenuItem.Text;
            m_CommandHolder = CommandObserver.CreateCommandHolder(this);
            m_CommandHolder.Command = i_Command;
            replaceBasicItem();
        }

        private void replaceBasicItem()
        {
            this.Text = m_BasicMenuItem.Text;
            this.ToolTipText = m_BasicMenuItem.ToolTipText;
            this.Image = m_BasicMenuItem.Image;
            m_BasicMenuItem.Visible = false;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            m_CommandHolder.Command.Execute(null);
        }
    }
}
