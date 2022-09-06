using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOS2Randomizer.UI.Components
{
    public class BaseWindow : Form, IChoosableDesign
    {
        private DesignType _design = DesignType.Dark;
        public virtual DesignType Design
        {
            get => DesignBaseImpl;
            set => DesignBaseImpl = value;
        }

        protected DesignType DesignBaseImpl
        {
            get => _design;
            set
            {
                _design = value;
                DarkModeHax.UseImmersiveDarkMode(Handle, value == DesignType.Dark);
                foreach (Control control in Controls)
                {
                    if (control is IChoosableDesign c)
                    {
                        c.Design = value;
                    }
                }
            }
        }
    }
}
