using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace _04_AbstractFactory.Controls
{
    public abstract class Control
    {
        public Point Location { get; set; }

        public Size Size { get; set; }

        public string Text { get; set; }

        public abstract void Draw();
    }

    public abstract class Button : Control
    {
        public void Click()
        {
            this.Draw();
            Console.WriteLine("- Button Clicked");
            this.Draw();
        }
    }

    public abstract class CheckBox : Control
    {
        private bool m_Checked;

        public bool Checked
        {
            get { return m_Checked; }
            set { m_Checked = value; }
        }
    }

    public class CheckBox98 : CheckBox
    {
        public override void Draw()
        {
            Console.WriteLine("CheckBox98 is " +
                (Checked ? "[Checked]" : "[Unchecked]"));
        }
    }

    public class CheckBoxXP : CheckBox
    {
        public override void Draw()
        {
            Console.WriteLine("CheckBoxXP is " +
                (Checked ? "{{*}}" : "{{ }}"));
        }
    }

    public class Button98 : Button
    {
        public override void Draw()
        {
            Console.WriteLine("Button98 [" + Text + "]");
        }
    }

    public class ButtonXP : Button
    {
        public override void Draw()
        {
            Console.WriteLine("ButtonXP {{" + Text + "}}");
        }
    }
}
