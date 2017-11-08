using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerScienceUtilities
{
    public class DisplaySettings
    {

        private Form f;

        public DisplaySettings(Form f)
        {
            this.f = f;
        }

        public void resizeDisplayToScreenSize()
        {
            f.Size = Screen.PrimaryScreen.Bounds.Size;
        }

    }
}
