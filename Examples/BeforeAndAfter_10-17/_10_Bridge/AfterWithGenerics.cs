#define WINXP

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using _10_Bridge.GenericControls;


namespace _10_Bridge
{
    public class AfterWithGenerics
    {
        public static void Run()
        {
            // Call Client twice
#if WINXP
            new FormWithControls<RendererXP>().Show();
#else
            new FormWithControls<Renderer98>().Show();
#endif
        }

        // Concrete Generic Factory(ies) (all in the same one)
        public static class ControlFactory<TRenderer>
          where TRenderer : IRenderer, new()
        {
            public static Button CreateButton()
            {
                return new Button<TRenderer>();
            }

            public static CheckBox CreateCheckBox()
            {
                return new CheckBox<TRenderer>();
            }
        }

        // Concrete Form (all in the same one)
        public class FormWithControls<TRenderer>
            where TRenderer : IRenderer, new()
        {
            private Button m_Button;
            private CheckBox m_CheckBox;

            public void Show()
            {
                m_Button = ControlFactory<TRenderer>.CreateButton();
                m_CheckBox = ControlFactory<TRenderer>.CreateCheckBox();

                Console.WriteLine("I am a form with " + typeof(TRenderer).Name);

                m_Button.Text = "button text";
                m_CheckBox.Checked = true; 
                m_Button.Draw();
                m_CheckBox.Draw();

                // these operation will also force re-draw:
                m_Button.Click();
            }
        }
    }
}
