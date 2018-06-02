using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace CCCApp
{

    
    public partial class criteria : UserControl
    {
        

        public criteria()
        {   
           InitializeComponent();
            //MessageBox.Show(lblName.Text);
            
           
           
        }



        public criteria(string name,string legal, string card, string interested, string source,string estate,string rhb,string product )
        {
            // InitializeComponent();
            lblName.Text = name;
            //lblLegal.Text = legal;
            //lblCard.Text = card;
            //lblInterest.Text = interested;
            //lblSource.Text = source;
            //lblEstate.Text = estate;
            //lblRHB.Text = rhb;
            //lblProduct.Text = product;
            // MessageBox.Show(legal);
        }

        public void PassName(string name)
        {
           MessageBox.Show(name);
            lblName.Text = name;
        }


        private void testing(object sender, EventArgs e)
        {
            //criteria cri = new criteria(legal);
            //MessageBox.Show(legal);
            //CreateMailItem();

        } 


        private void CreateMailItem()
        {
            //MessageBox.Show(name);

            string body = "Customer Name : " + lblName.Text +
            Environment.NewLine + "Legal ID: " + lblLegal.Text +
            Environment.NewLine + "Card Number: " + lblCard.Text +
            Environment.NewLine + "Product: " + lblProduct.Text +
            Environment.NewLine + "Source: " + lblSource.Text +
            Environment.NewLine + "Interested: " + lblInterest.Text +
            Environment.NewLine + "Available Balance: " + lblInterest.Text +
            Environment.NewLine + "Remarks: " + lblInterest.Text +
            Environment.NewLine + "Staff ID: " + Environment.UserName.ToString();

            Outlook.Application app = new Outlook.Application();
            Outlook.MailItem mailItem = app.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = "This is the subject";
            mailItem.To = "someone@example.com";

            crosssell cro = new crosssell();
            
            mailItem.Body = "";
            //mailItem.Attachments.Add(logPath);//logPath is a string holding path to the log.txt file
            mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
            mailItem.Display(true);
        }

        private void txtAvailable_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtAvailable.Text != null)
                {
                    double bal = Convert.ToDouble(txtAvailable.Text);

                    bal = (80 * bal / 100);

                    // MessageBox.Show(bal.ToString());

                    lbl80.Text = "80% ( " + bal + " )";

                    if (bal >= 1000)
                    {
                        picEli.Visible = true;
                        picEli.BackgroundImage = CCCApp.Properties.Resources.yes;
                    }
                    else
                    {
                        picEli.Visible = true;
                        picEli.BackgroundImage = CCCApp.Properties.Resources.png_wrong_cross_png_small_medium_large_600;
                    }
                }
            }
            catch (Exception)
            {

                
            }

        }

        private void criteria_Load(object sender, EventArgs e)
        {
            crosssell cro = new crosssell();
            cro.Show();
        }
    }
}
