using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerScienceUtilities
{
    public class KeyBinding
    {
        private Keys k;
        private KeyAction ka;
        private bool pressed = false;

        public KeyBinding(Keys key, KeyAction action)
        {
            k = key;
            ka = action;
        }

        public Keys getKey()
        {
            return k;
        }

        public KeyAction getAction()
        {
            return ka;
        }

        public bool isPressed()
        {
            return pressed;
        }

        public void press(bool arg0)
        {
            pressed = arg0;
        }

    }

    public enum KeyAction {
        MOVEMENT_LEFT,
        MOVEMENT_RIGHT,
        MOVEMENT_UP,
        UTIL_1,
        UTIL_2,
        UTIL_3,
        UTIL_4
    }

}
