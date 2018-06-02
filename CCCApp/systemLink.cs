using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCCApp
{
    public partial class systemLink : UserControl
    {
        public systemLink()
        {
            InitializeComponent();
        }

        private void italicWord(object sender, EventArgs e)
        {
            Label label = sender as Label;

            if (label.Font.Italic == true)
            {
                label.Font = new Font("Haettenschweiler", 15);
            } else
            {
                label.Font = new Font("Haettenschweiler", 15, FontStyle.Italic|FontStyle.Underline);
            }
        }

        private void serviceCharges(object sender, EventArgs e)
        {
            Label label = sender as Label;

            if(label.Tag == "sc")
            {
                System.Diagnostics.Process.Start(@"https://www.rhbgroup.com/products-and-services/rates-and-charges/service-charges/new-application");
            } else if (label.Tag == "rhbweb")
            {
                System.Diagnostics.Process.Start(@"https://www.rhbgroup.com/");
            } else if (label.Tag == "rhbweb")
            {
                System.Diagnostics.Process.Start(@"https://www.rhbgroup.com/");
            } else if (label.Tag == "loads")
            {
                System.Diagnostics.Process.Start(@"C:\Users\Yusri\Desktop\AddOn.xlsx");
            } else if (label.Tag == "rhbweb")
            {
                System.Diagnostics.Process.Start(@"https://www.rhbgroup.com/");
            }
        }



    }
}
