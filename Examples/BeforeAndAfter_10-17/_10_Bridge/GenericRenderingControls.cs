using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace _10_Bridge.GenericControls
{
    /// <summary>
    ///  The Absatract "Implementor" in the BRIDGE pattern
    /// </summary>
    public interface IRenderer
    {
        void DrawButton(Button i_Button);

        void DrawCheckBox(CheckBox i_CheckBox);
    }

    // Just a base control class (the 'Abstraction' in the Abstraction side in the BRIDGE patterns)
    public abstract class Control
    {
        protected IRenderer m_Renderer;

        private Point m_Location;

        public Point Location
        {
            get { return m_Location; }
            set { m_Location = value; }
        }

        protected Size m_Size;

        public Size Size
        {
            get { return m_Size; }
            set { m_Size = value; }
        }

        protected string m_Text;

        public string Text
        {
            get { return m_Text; }
            set { m_Text = value; }
        }

        public Control()
        {
            CreateRenderer();
        }

        protected abstract void CreateRenderer();

        public abstract void Draw();
    }

    // Base Product 1 (one of the 'specializations' in the Abstraction side in the BRIDGE patterns)
    public abstract class Button : Control
    {
        public void Click()
        {
            this.Draw();
            Console.WriteLine("- Button Clicked");
            this.Draw();
        }
    }

    // Base Product 2 (one of the 'specializations' in the Abstraction side in the BRIDGE patterns)
    public abstract class CheckBox : Control
    {
        protected bool m_Checked;

        public bool Checked
        {
            get { return m_Checked; }
            set
            {
                if (m_Checked != value)
                {
                    m_Checked = value;
                    Draw();
                }
            }
        }
    }

    /// <summary>
    /// A concerte "Implementor" in the BRIDGE pattern
    /// </summary>
    public class Renderer98 : IRenderer
    {
        public void DrawButton(Button i_Button)
        {
            Console.WriteLine("98: Button at " + i_Button.Location);
        }

        public void DrawCheckBox(CheckBox i_CheckBox)
        {
            Console.WriteLine("98: Checkbox is " + i_CheckBox.Checked);
        }
    }

    /// <summary>
    ///  A concerte "Implementor" in the BRIDGE pattern
    /// </summar
    public class RendererXP : IRenderer
    {
        public void DrawButton(Button i_Button)
        {
            Console.WriteLine("XP: {{" + i_Button.Location + "}}");
        }

        public void DrawCheckBox(CheckBox i_CheckBox)
        {
            string checkSign = i_CheckBox.Checked ? "*" : "-";
            Console.WriteLine("XP: {{" + checkSign + "}}");
        }
    }

    // All Concrete Buttons (in one genereic class)
    public class Button<TRenderer> : Button
      where TRenderer : IRenderer, new()
    {
        protected override void CreateRenderer()
        {
            m_Renderer = new TRenderer();
        }

        public override void Draw()
        {
            m_Renderer.DrawButton(this);
        }
    }

    // All concrete Checkboxes (in one genereic class)
    public class CheckBox<TRenderer> : CheckBox
      where TRenderer : IRenderer, new()
    {
        protected override void CreateRenderer()
        {
            m_Renderer = new TRenderer();
        }

        public override void Draw()
        {
            m_Renderer.DrawCheckBox(this);
        }
    }
}
