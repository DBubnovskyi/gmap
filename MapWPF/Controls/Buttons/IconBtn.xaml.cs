using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MapWPF.Controls.Buttons
{
    /// <summary>
    /// Interaction logic for IconBtn.xaml
    /// </summary>
    public partial class IconBtn : UserControl
    {
        public bool IsActive { get; set; } = true;

        [Category("Employee Control")]
        public string Text { get
            {
                return TextLabel.Content.ToString();
            } 
            set
            { 
                TextLabel.Content = value; 
            } 
        }

        public IconBtn()
        {
            InitializeComponent();
        }
    }
}
