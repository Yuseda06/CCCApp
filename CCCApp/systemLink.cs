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

            if(label.Text == "Back Office")
            {
                System.Diagnostics.Process.Start(@"https://172.22.1.38/Dribbackoffice/Login.aspx");
            }

            else if (label.Text == "Dynasis")
            {
                System.Diagnostics.Process.Start(@"http://172.22.1.106/login.aspx");
            }

            else if (label.Text == "Whoops")
            {
                System.Diagnostics.Process.Start(@"http://10.163.1.32/WhoopsRHB/myPage/userLogin.asp");
            }

            else if (label.Text == "RHB Website")
            {
                System.Diagnostics.Process.Start(@"https://www.rhbgroup.com/");
            }

            else if (label.Text == "RHB Now Dummy")
            {
                System.Diagnostics.Process.Start(@"\\maanetapp1\Consumer Product\CCCKL\Malaysia Operations\For Internal Use Only\RHB Now\RHB Online Banking V3\Home.html");
            }

            else if (label.Text == "One Pay")
            {
                System.Diagnostics.Process.Start(@"http://10.163.1.32/OnePay/default.aspx");
            }

            else if (label.Text == "FDS")
            {
                System.Diagnostics.Process.Start(@"https://172.22.1.20/backoffice/login.jsp;jsessionid=B7F5A5558EFD4760B1D2A594A2DB989B  ");
            }

            else if (label.Text == "MSP")
            {
                System.Diagnostics.Process.Start(@"https://accounts.infobip.com/login/?callback=https%3A%2F%2Faccounts.infobip.com%2Fsettings%2Froundabout%3Fcallback%3Dhttp%253A%252F%252Freporting.infobip.com%252Fhome%252Fex");
            }

            else if (label.Text == "ePONE")
            {
                System.Diagnostics.Process.Start(@"http://172.26.4.114:8084/EPOneWeb ");
            }

            else if (label.Text == "Spick")
            {
                System.Diagnostics.Process.Start(@"http://10.163.1.32/WhoopsRHB/myPage/userLogin.asp ");
            }

            else if (label.Text == "RLOS")
            {
                System.Diagnostics.Process.Start(@"https://dcms-my.rhbgroup.com/dcms/login.action");
            }


            else if (label.Text == "Service Charges")
            {
                System.Diagnostics.Process.Start(@"https://www.rhbgroup.com/products-and-services/rates-and-charges/service-charges/new-application");
            }

            else if (label.Text == "SR Guides")
            {
                System.Diagnostics.Process.Start(@"http://my1portal.rhbgroup.com/sites/grb/echannels/ccc/customercare/Customer%20Care%20Centre/Forms/AllItems.aspx?RootFolder=%2Fsites%2Fgrb%2Fechannels%2Fccc%2Fcustomercare%2FCustomer%20Care%20Centre%2FCCC%20Learnings%2FMalaysia%2FSR%20%20SO%20Guide%2C%20Escalation%20Process%20in%20CCC&FolderCTID=0x0120001311E78EE0E16E4C9DB40EED42909D53&View=%7B4A5AEFC5-AC8E-41DC-A2E1-574B3DFC7EDA%7D");
            }

            else if (label.Text == "e-Transact")
            {
                System.Diagnostics.Process.Start(@"http://172.26.3.132/ETRANSACTV52/login.trs");
            }

            else if (label.Text == "e-Services")
            {
                System.Diagnostics.Process.Start(@"http://eservices.intranet.rhbbank.com/eservices/");
            }

            else if (label.Text == "Back Office (Reflex)")
            {
                System.Diagnostics.Process.Start(@"https://reflexbo.rhbgroup.com/rhbcams/backoffice/login.jsp");
            }
            else if (label.Text == "Back Office (UAT)")
            {
                System.Diagnostics.Process.Start(@"http://172.30.81.198:8003/rhbcams/corporate/login.jsp");
            }

            else if (label.Text == "Activate")
            {
                System.Diagnostics.Process.Start(@"http://osad/activate_cards/ActivateHome.aspx");

            } else if (label.Text == "Fax Utils")
            {
                System.Diagnostics.Process.Start(@"http://vccnfaxp1/webutil");

            }
            else if (label.Text == "WFM")
            {
                System.Diagnostics.Process.Start(@"http://172.23.96.126:8080/wfm/");

            } else if (label.Text == "Loads")
            {
                System.Diagnostics.Process.Start(@"http://loads3.intranet.rhbbank.com/loads3/L3COM_Index.asp");
            }



        }



    }
}
