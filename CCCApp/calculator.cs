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
    public partial class calculator : UserControl
    {

        string desc;
        string text3 = "Min RM3000";
        string text1 = "Min RM1000";
        string desc1;
        int i = 0;

        private static calculator _instance;
        public static calculator Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new calculator();
                return _instance;
            }
        }
        public calculator()
        {
            InitializeComponent();


        }

        public calculator(string value)
        {
            InitializeComponent();
            txtBTAmount.Text = value;
            txtCXAmount.Text = value;
            txtDAIAmount.Text = value;
        }
        void calculatorDAI(object sender, EventArgs e)
        {
            if(i == 2 ){
                desc1 = "No Maximum purchase amount limit, promotion is valid from 1 January 2018 to 30 June 2018";
            }
            try
            {
                if (cbDAI.Text == "PLAN A")
                {
                    lblDAIInterest.Text = "2.50%";
                    lblDAImin.Text = "Min RM500";
                    lblDAITenure.Text = "6";
                    lblDAITotalInterest.Text = "RM " + (Convert.ToInt32(txtDAIAmount.Text) * 2.50 / 100).ToString("#.##") + "";
                    desc = desc1;
                    displayNotif();
                    lblTotalInterestDAI.Text = "RM " + (Convert.ToInt32(txtDAIAmount.Text) + Convert.ToInt32(txtDAIAmount.Text) * 2.50 / 100).ToString("#.##") + "";
                    lblDAIMonthly.Text = "RM " + (((Convert.ToInt32(txtDAIAmount.Text) + Convert.ToInt32(txtDAIAmount.Text) * 2.50 / 100)) / Convert.ToInt32(lblDAITenure.Text)).ToString("#.##") + "";
                }
                else if (cbDAI.Text == "PLAN B")
                {
                    lblDAIInterest.Text = "12.00%";
                    lblDAImin.Text = "Min RM1000";
                    lblDAITenure.Text = "12";
                    lblDAITotalInterest.Text = "RM " + (Convert.ToInt32(txtDAIAmount.Text) * 12 / 100).ToString("#.##") + "";
                    desc = desc1;
                    displayNotif();
                    lblTotalInterestDAI.Text = "RM " + (Convert.ToInt32(txtDAIAmount.Text) + Convert.ToInt32(txtDAIAmount.Text) * 12 / 100).ToString("#.##") + "";
                    lblDAIMonthly.Text = "RM " + (((Convert.ToInt32(txtDAIAmount.Text) + Convert.ToInt32(txtDAIAmount.Text) * 12 / 100)) / Convert.ToInt32(lblDAITenure.Text)).ToString("#.##") + "";
                }
                else if (cbDAI.Text == "PLAN C")
                {
                    lblDAIInterest.Text = "9.00%";
                    lblDAImin.Text = "Min RM1000";
                    lblDAITenure.Text = "18";
                    lblDAITotalInterest.Text = "RM " + (Convert.ToInt32(txtDAIAmount.Text) * 9 / 100).ToString("#.##") + "";
                    desc = desc1;
                    displayNotif();
                    lblTotalInterestDAI.Text = "RM " + (Convert.ToInt32(txtDAIAmount.Text) + Convert.ToInt32(txtDAIAmount.Text) * 9 / 100).ToString("#.##") + "";
                    lblDAIMonthly.Text = "RM " + (((Convert.ToInt32(txtDAIAmount.Text) + Convert.ToInt32(txtDAIAmount.Text) * 9 / 100)) / Convert.ToInt32(lblDAITenure.Text)).ToString("#.##") + "";
                }
                else if (cbDAI.Text == "PLAN D")
                {
                    lblDAIInterest.Text = "15.00%";
                    lblDAImin.Text = "Min RM2000";
                    lblDAITenure.Text = "24"; 
                    lblDAITotalInterest.Text = "RM " + (Convert.ToInt32(txtDAIAmount.Text) * 15/ 100).ToString("#.##") + "";
                    desc = desc1;
                    displayNotif();
                    lblTotalInterestDAI.Text = "RM " + (Convert.ToInt32(txtDAIAmount.Text) + Convert.ToInt32(txtDAIAmount.Text) * 15 / 100).ToString("#.##") + "";
                    lblDAIMonthly.Text = "RM " + (((Convert.ToInt32(txtDAIAmount.Text) + Convert.ToInt32(txtDAIAmount.Text) * 15 / 100)) / Convert.ToInt32(lblDAITenure.Text)).ToString("#.##") + "";
                }
                i = 1;
            }
            catch (Exception)
            {

            
            }
        }

        void calculatorBT(object sender, EventArgs e)
        {

            try
            {
                if (cbBT.Text == "PLAN A")
                {
                    lblBTInterest.Text = "4.00%";
                    lblBTmin.Text = text1;
                    lblBTTenure.Text = "12";
                    lblBTTotalInterest.Text = "RM " + (Convert.ToInt32(txtBTAmount.Text) * 4 / 100).ToString("#.##") + "";
                    desc = "";
                    displayNotif();
                    lblTotalInterest.Text = "RM " + (Convert.ToInt32(txtBTAmount.Text) + Convert.ToInt32(txtBTAmount.Text) * 4 / 100).ToString("#.##") + "";
                    lblBTMonthly.Text = "RM " + (((Convert.ToInt32(txtBTAmount.Text) + Convert.ToInt32(txtBTAmount.Text) * 4 / 100)) / Convert.ToInt32(lblBTTenure.Text)).ToString("#.##") + "";
                }
                else if (cbBT.Text == "PLAN B")
                {
                    lblBTInterest.Text = "7.00%";
                    lblBTmin.Text = text1;
                    lblBTTenure.Text = "18";
                    lblBTTotalInterest.Text = "RM " + (Convert.ToInt32(txtBTAmount.Text) * 7 / 100).ToString("#.##") + "";
                    desc = "";
                    displayNotif();
                    lblTotalInterest.Text = "RM " + (Convert.ToInt32(txtBTAmount.Text) + Convert.ToInt32(txtBTAmount.Text) * 7 / 100).ToString("#.##") + "";
                    lblBTMonthly.Text = "RM " + (((Convert.ToInt32(txtBTAmount.Text) + Convert.ToInt32(txtBTAmount.Text) * 7 / 100)) / Convert.ToInt32(lblBTTenure.Text)).ToString("#.##") + "";
                }
                else if (cbBT.Text == "PLAN C")
                {
                    lblBTInterest.Text = "10.99%";
                    lblBTmin.Text = text1;
                    lblBTTenure.Text = "24";
                    lblBTTotalInterest.Text = "RM " + (Convert.ToInt32(txtBTAmount.Text) * 10.99 / 100).ToString("#.##") + "";
                    desc = "";
                    displayNotif();
                    lblTotalInterest.Text = "RM " + (Convert.ToInt32(txtBTAmount.Text) + Convert.ToInt32(txtBTAmount.Text) * 10.99 / 100).ToString("#.##") + "";
                    lblBTMonthly.Text = "RM " + (((Convert.ToInt32(txtBTAmount.Text) + Convert.ToInt32(txtBTAmount.Text) * 10.99 / 100)) / Convert.ToInt32(lblBTTenure.Text)).ToString("#.##") + "";
                }
                else if (cbBT.Text == "PLAN 631")
                {
                    lblBTInterest.Text = "2.99%";
                    lblBTmin.Text = text3;
                    lblBTTenure.Text = "6";
                    lblBTTotalInterest.Text = "RM " + (Convert.ToInt32(txtBTAmount.Text) * 2.99 / 100).ToString("#.##") + "";
                    desc = "";
                    displayNotif();
                    lblTotalInterest.Text = "RM " + (Convert.ToInt32(txtBTAmount.Text) + Convert.ToInt32(txtBTAmount.Text) * 2.99 / 100).ToString("#.##") + "";
                    lblBTMonthly.Text = "RM " + (((Convert.ToInt32(txtBTAmount.Text) + Convert.ToInt32(txtBTAmount.Text) * 2.99 / 100)) / Convert.ToInt32(lblBTTenure.Text)).ToString("#.##") + "";
                }
            }
            catch (Exception)
            {

             
            }
        }

        void calculatorCX(object sender, EventArgs e)
        {



            try
            {
                if (cbCX.Text == "PLAN A")
                {

                    lblCXInterest.Text = "8.00%";
                    lblCXTenure.Text = "12";
                    lblCXTotalInterest.Text = "RM " + (Convert.ToInt32(txtCXAmount.Text) * 8 / 100).ToString("#.##") + "";
                    lblCXmin.Text = text1;
                    lblTotalInterestCX.Text = "RM " + (Convert.ToInt32(txtCXAmount.Text) + Convert.ToInt32(txtCXAmount.Text) * 8 / 100).ToString("#.##") + "";
                    lblCXMonthly.Text = "RM " + (((Convert.ToInt32(txtCXAmount.Text) + Convert.ToInt32(txtCXAmount.Text) * 8 / 100)) / Convert.ToInt32(lblCXTenure.Text)).ToString("#.##") + "";
                    desc = "";
                    displayNotif();
                }
                else if (cbCX.Text == "PLAN B")
                {
                    lblCXInterest.Text = "18.00%";
                    lblCXTenure.Text = "24";
                    lblCXTotalInterest.Text = "RM " + (Convert.ToInt32(txtCXAmount.Text) * 18 / 100).ToString("#.##") + "";
                    lblCXmin.Text = text1;
                    lblTotalInterestCX.Text = "RM " + (Convert.ToInt32(txtCXAmount.Text) + Convert.ToInt32(txtCXAmount.Text) * 18 / 100).ToString("#.##") + "";
                    lblCXMonthly.Text = "RM " + (((Convert.ToInt32(txtCXAmount.Text) + Convert.ToInt32(txtCXAmount.Text) * 18 / 100)) / Convert.ToInt32(lblCXTenure.Text)).ToString("#.##") + "";
                    desc = "";
                    displayNotif();


                }
                else if (cbCX.Text == "PLAN 630")
                {
                    lblCXInterest.Text = "4.88%";
                    lblCXTenure.Text = "12";
                    lblCXmin.Text = text3;
                    lblCXTotalInterest.Text = "RM " + (Convert.ToInt32(txtCXAmount.Text) * 4.88 / 100).ToString("#.##") + "";
                    desc = "";
                    displayNotif();
                    lblTotalInterestCX.Text = "RM " + (Convert.ToInt32(txtCXAmount.Text) + Convert.ToInt32(txtCXAmount.Text) * 4.88 / 100).ToString("#.##") + "";
                    lblCXMonthly.Text = "RM " + (((Convert.ToInt32(txtCXAmount.Text) + Convert.ToInt32(txtCXAmount.Text) * 4.88 / 100)) / Convert.ToInt32(lblCXTenure.Text)).ToString("#.##") + "";
                }

                else if (cbCX.Text == "PLAN 633")
                {
                    desc = "SMS Selected Customer Only, validity 30 days after blasting";
                    
                    lblCXInterest.Text = "3.99%";
                    lblCXmin.Text = text3;
                    displayNotif();
                    lblCXTenure.Text = "12";
                    lblCXTotalInterest.Text = "RM " + (Convert.ToInt32(txtCXAmount.Text) * 3.99 / 100).ToString("#.##") + "";
                    lblTotalInterestCX.Text = "RM " + (Convert.ToInt32(txtCXAmount.Text) + Convert.ToInt32(txtCXAmount.Text) * 3.99 / 100).ToString("#.##") + "";
                    lblCXMonthly.Text = "RM " + (((Convert.ToInt32(txtCXAmount.Text) + Convert.ToInt32(txtCXAmount.Text) * 3.99 / 100)) / Convert.ToInt32(lblCXTenure.Text)).ToString("#.##") + "";
                }

                else if (cbCX.Text == "PLAN 634")
                {
                    desc = "Customer is new to bank - upon card activation";
                    
                    lblCXInterest.Text = "2.99%";
                    lblCXmin.Text = text3;
                    displayNotif();
                    lblCXTenure.Text = "12";
                    lblCXTotalInterest.Text = "RM " + (Convert.ToInt32(txtCXAmount.Text) * 2.99 / 100).ToString("#.##") + "";
                    lblTotalInterestCX.Text = "RM " + (Convert.ToInt32(txtCXAmount.Text) + Convert.ToInt32(txtCXAmount.Text) * 2.99 / 100).ToString("#.##") + "";
                    lblCXMonthly.Text = "RM " + (((Convert.ToInt32(txtCXAmount.Text) + Convert.ToInt32(txtCXAmount.Text) * 2.99 / 100)) / Convert.ToInt32(lblCXTenure.Text)).ToString("#.##") + "";
                }

                else if (cbCX.Text == "PLAN 693")
                {
                    lblCXInterest.Text = "7.88%";
                    
                    desc = "";
                    displayNotif();
                    lblCXmin.Text = text3;
                    lblCXTenure.Text = "24";
                    lblCXTotalInterest.Text = "RM " + (Convert.ToInt32(txtCXAmount.Text) * 7.88 / 100).ToString("#.##") + "";
                    lblTotalInterestCX.Text = "RM " + (Convert.ToInt32(txtCXAmount.Text) + Convert.ToInt32(txtCXAmount.Text) * 7.88 / 100).ToString("#.##") + "";
                    lblCXMonthly.Text = "RM " + (((Convert.ToInt32(txtCXAmount.Text) + Convert.ToInt32(txtCXAmount.Text) * 7.88 / 100)) / Convert.ToInt32(lblCXTenure.Text)).ToString("#.##") + "";
                }

                else if (cbCX.Text == "PLAN 694")
                {
                    lblCXInterest.Text = "9.88%";
                    
                    desc = "";
                    displayNotif();
                    lblCXmin.Text = text3;
                    lblCXTotalInterest.Text = "RM " + (Convert.ToInt32(txtCXAmount.Text) * 9.88 / 100).ToString("#.##") + "";
                    lblTotalInterestCX.Text = "RM " + (Convert.ToInt32(txtCXAmount.Text) + Convert.ToInt32(txtCXAmount.Text) * 9.88 / 100).ToString("#.##") + "";
                    lblCXMonthly.Text = "RM " + (((Convert.ToInt32(txtCXAmount.Text) + Convert.ToInt32(txtCXAmount.Text) * 9.88 / 100)) / Convert.ToInt32(lblCXTenure.Text)).ToString("#.##") + "";
                }

            }
            catch (Exception)
            {

               
            }
            
        }


        void displayNotif()
        {
            btnNotificationC.Text = desc;

            //if (lblBTmin.Text == "Min RM3000")
            //{
            //    if (lblBTmin.ForeColor == Color.LightGray)
            //    {
            //        lblBTmin.ForeColor = Color.DarkRed;
            //    } else
            //    {
            //        lblBTmin.ForeColor = Color.LightGray;
            //    }
            //}
            //else
            //{
            //    lblBTmin.ForeColor = Color.LightGray;
            //}

            //if (lblCXmin.Text == "Min RM3000")
            //{
            //    if (lblCXmin.ForeColor == Color.LightGray)
            //    {
            //        lblCXmin.ForeColor = Color.DarkRed;
            //    }
            //    else
            //    {
            //        lblCXmin.ForeColor = Color.LightGray;
            //    }
            //}
            //else
            //{
            //    lblCXmin.ForeColor = Color.LightGray;
            //}

            //if (lblDAImin.Text == "Min RM2000")
            //{
            //    if (lblDAImin.ForeColor == Color.LightGray)
            //    {
            //        lblDAImin.ForeColor = Color.DarkRed;
            //    }
            //    else
            //    {
            //        lblDAImin.ForeColor = Color.LightGray;
            //    }
            //}
            //else
            //{
            //    lblDAImin.ForeColor = Color.LightGray;
            //}

        }




        private void calculator_Load(object sender, EventArgs e)
        {
            //Product pro = new Product();

            //txtBTAmount.Text = pro.Amount;

            if(Clipboard.GetText().Length < 6)
            {
                txtBTAmount.Text = Clipboard.GetText();
                txtCXAmount.Text = Clipboard.GetText();
                txtDAIAmount.Text = Clipboard.GetText();

                calculatorBT(sender, e);
                calculatorCX(sender, e);
                calculatorDAI(sender, e);
            }

        }

    }
}
