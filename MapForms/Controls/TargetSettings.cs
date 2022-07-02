using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MapForms.Controls
{
    public partial class TargetSettings : UserControl
    {
        public Action<string> NameChanged;
        public TargetSettings()
        {
            InitializeComponent();
        }

        private void textTargetName_TextChanged(object sender, EventArgs e)
        {
            string name = textTargetName.Text;
            NameChanged?.Invoke(name);
        }
    }
}
