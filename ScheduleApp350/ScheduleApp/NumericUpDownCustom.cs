using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NumericUpDownCustom
{
    // This class overrides the NumericUpDown form to allow the text it displays to be formatted as "XX:00" for hours and minutes 
    public class NumericUpDownEx : NumericUpDown
    {
        public NumericUpDownEx()
        {
        }
        
        protected override void UpdateEditText()
        {
            this.Text = ((int)(this.Value)).ToString("00")+":00";
        }
    }

}
