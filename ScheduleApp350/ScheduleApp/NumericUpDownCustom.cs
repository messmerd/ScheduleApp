﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;



namespace NumericUpDownCustom
{
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
