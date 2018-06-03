using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace CCCApp
{
    public delegate void passingName(string name);

    public partial class crosssell : UserControl


    {
        private static TextBox _instance;
        string StaffID;
        //string StaffID = "450011";
        int pointTM;
        int pointUH;
        int intStaffID;
        string MMM;

        void checkingID()
        {
            int j = 0;
            if (j == 1)
            {
                try
                {
                    intStaffID = Convert.ToInt32(Environment.UserName);
                }
                catch (Exception)
                {

                }



                StaffID = Environment.UserName.ToString();

            }
            else
            {
                intStaffID = 192396;
                StaffID = "192396";
            }
        }

        public crosssell()
        {
            InitializeComponent();
            checkingID();
            picRHB.BackgroundImage = null;
            picESTMT.BackgroundImage = null;
            try
            {
                MMM = DateTime.Now.ToString("MMM").Replace('-', '/');
           

            }
            catch (Exception)
            {
                MMM = DateTime.Now.AddMonths(-1).ToString("MMM").Replace('-', '/');

            }
            //if (StaffID == null)
            //{
            //    MMM = DateTime.Now.AddMonths(-1).ToString("MMM").Replace('-', '/');
            //}

        }
        string secondLegalID;
        public crosssell(string value)
        {
            InitializeComponent();
            txtAvailable.Text = value;
            //criteria1.Visible = false;

        }

        public String BTScript = "Hello Sir/Madam, we are currently promoting RHB Balance Transfer to our existing RHB cardholder to save your credit card payment with lower interest rate at 2.99% per annum, with min amount of 3K. " + Environment.NewLine + "Do you have any outstanding balance with other bank credit card? ( If Yes/ If No - Close conversation)" + Environment.NewLine + "Would you be interested to apply? (Tick Yes - Confirm)";
        public String CXScript = "Hello Sir/Madam, we are currently promoting RHB Cash Excess to our existing RHB cardholder with the hottest interest rate at 4.88% per annum, with min amount of 3K. " + Environment.NewLine + "If you are in need of extra cash and fast approval.( If Yes/ If No - Close conversation)" + Environment.NewLine + "Would you be interested to apply? (Tick Yes - Confirm)";

        private string done;
        string carddone;
        string text;
        private string name;
        string interested;
        string interestBT;
        string interestCX;
        string product;
        string source;
        string legalID;
        string rhb;
        string estate;
        string cust;
        string status;

        private void CreateMailItem()
        {
            //MessageBox.Show(name);

            source = Source().ToString();

            if (txtCardNo.Text != "")
            {
                cust = txtName.Text;
            }
            else
            {
                cust = legalID;
            }

            if (interested == "Yes")
            {
                status = " is interested in ";
            }
            else
            {
                status = " rejected the offer of ";
            }

            string subject = cust + status + product;

            string body = "Customer Name : " + txtName.Text +
            Environment.NewLine + "Legal ID: " + legalID +
            Environment.NewLine + "Card Number: " + txtCardNo.Text +
            Environment.NewLine + "Product: " + product +
            Environment.NewLine + "Source: " + Source().ToString() +
            Environment.NewLine + "Interested: " + interested +
            Environment.NewLine + "Available Balance: " + txtAvailable.Text +
            Environment.NewLine + "Remarks: " + txtCriteriaRemarks.Text +
            Environment.NewLine + "Staff ID: " + Environment.UserName.ToString();

            Outlook.Application app = new Outlook.Application();
            Outlook.MailItem mailItem = app.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = subject;
            //mailItem.To = "CCC Sales Support";
            mailItem.To = "179264";
            crosssell cro = new crosssell();

            mailItem.Body = body;
            //mailItem.Attachments.Add(logPath);//logPath is a string holding path to the log.txt file
            //mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
            mailItem.Send();


        }



        //Customer Name : TAN KHAI MENG
        //Legal ID: 700304075085
        //Card Number : 4570701183076004
        //Product: Balance Transfer
        //Source: 005
        //Interested: YES
        //Available balance: 6046.01
        //Remarks: Please call customer at this num 012 - 3801229 next monday 21 / 05 / 2018 after 12.00 noon
        //Staff ID: 452314

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
                sendValueToCal();
                Clipboard.SetText(txtAvailable.Text);
                //var value = new Product();
                //value.Amount = txtAvailable.Text;
            }
            catch (Exception)
            {


            }

        }


        public void ProductSelected()
        {

            interested = "";
            product = "";

            if (cbBTYes.Checked)
            {
                interestBT = "Yes";
                product = "Balance Transfer";

            }
            else if (cbBTNo.Checked)
            {
                interestBT = "No";

            }

            if (cbCXYes.Checked)
            {
                interestCX = "Yes";
                product = "Cash Excess";
            }
            else if (cbCXNo.Checked)
            {
                interestCX = "No";

            }

            if (interestBT == "Yes" || interestCX == "Yes")
            {
                interested = "Yes";
            }
            else
            {
                interested = "No";
            }


            if (cbBTYes.Checked && cbCXYes.Checked)
            {
                interested = "Yes";
                product = "BTCX";
            }
            else if (cbBTNo.Checked && cbCXNo.Checked)

            {
                interested = "No";
                product = "BTCX";
            }


        }

        public void sendValueToCal()
        {
            calculator.Instance.txtBTAmount.Text = txtAvailable.Text;
            calculator.Instance.txtBTAmount.Text = txtAvailable.Text;
            calculator.Instance.txtBTAmount.Text = txtAvailable.Text;
        }

        public string agentList(int staffID)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=Agent List.xls;Extended Properties=\"Excel 8.0;HDR=YES;\""))
            {
                try
                {
                    DateTime now = DateTime.Now;
                    date2 = now.Month.ToString();
                    date3 = Convert.ToInt32(date2);

                    //int Staff = Convert.ToInt32(Environment.UserName);

                    OleDbCommand command = new OleDbCommand("SELECT `" + MMM + "$`.WFM FROM `" + MMM + "$` `" + MMM + "$` WHERE(`" + MMM + "$`.`Staff ID`= " + staffID + ")   ", connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    //`Staff ID` = '" + Staff + "'
                    while (reader.Read())
                    {
                        if (reader["WFM"].ToString() == null)
                        {
                            return staffID.ToString();

                        }
                        else
                        {
                            return reader["WFM"].ToString();
                        }


                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error" + ex.Message);
                    Console.WriteLine(ex.Message);
                }

                connection.Close();

                return null;
            }
        }

        bool checks;
        private void checkingCriteria(object sender, EventArgs e)
        {


            if (txtAvailable.Text == "" && (cbBTYes.Checked == true || cbCXYes.Checked == true))
            {
                timer1.Stop();
                text = "Please check customer available balance before press submit!";
                max = 10;
                timer1.Start();

            }
            else
            {
                if (txtName.Text != "" && (cbBTYes.Checked || cbCXYes.Checked))
                {

                    ProductSelected();
                    Source();
                    CreateMailItem();

                    string staffID1 = agentList(intStaffID);
                    string testing = checkDouble(legalID);
                    if (staffID1 != null && testing == "checked")
                    {
                        insertDataMDB();
                    }
                    secondLegalID = legalID;
                    resetItems();
                    MessageBox.Show("Submitted, Thank You!");

                }
                else if (txtName.Text != "" && (cbBTNo.Checked || cbCXNo.Checked))
                {
                    ProductSelected();
                    Source();
                    CreateMailItem();

                    string staffID1 = agentList(intStaffID);
                    string testing = checkDouble(legalID);
                    if (staffID1 != null && testing == "checked")
                    {
                        insertDataMDB();

                    }
                    secondLegalID = legalID;
                    resetItems();
                    text = "Thank you for your effort to do the cross selling, try again!";
                    max = 20;
                    timer1.Start();

                }
                else
                {
                    text = "Press <ENTER> after key-in the legal ID !";
                    max = 20;
                    timer1.Start();
                }
            }


        }

        void resetItems()
        {
            product = "";
            source = "";
            //legalID="";
            rhb = "";
            estate = "";
            cust = "";
            status = "";
            cbBTNo.Checked = false;
            cbBTYes.Checked = false;
            cbCXNo.Checked = false;
            cbCXYes.Checked = false;
            txtAvailable.Text = "";
            txtCardNo.Text = "";
            txtCriteriaRemarks.Text = "";
            txtLegalID.Text = "";
            txtName.Text = "";
            lbl80.Text = "80% (  )";
            picEli.Visible = false;
            picESTMT.BackgroundImage = null;
            picRHB.BackgroundImage = null;
            lblBTScript.Text = "";
            lblCXScript.Text = "";
            interestBT = "";
            interestCX = "";
            interested = "";
            max = 0;

        }

        private void enlarge(object sender, EventArgs e)
        {
            Label n = sender as Label;

            if (n.Font.Size.Equals(8))
            {
                n.Font = new Font("Century Gothic", 9);



            }
            else if (n.Font.Size.Equals(9))
            {
                n.Font = new Font("Century Gothic", 8);
            }


        }


        void openPlan(object sender, EventArgs e)
        {

            Label l = sender as Label;
            l.Font = new Font(l.Font, FontStyle.Underline);

            BTPlan bTPlan = new BTPlan();
            bTPlan.ShowDialog();
        }




        public void CBBTCX(object sender, EventArgs e)
        {

            CheckBox cb = sender as CheckBox;

            if (cb == cbBTYes)
            {
                cbBTYes.Checked = true;
                cbBTNo.Checked = false;
            }
            if (cb == cbBTNo)
            {
                cbBTYes.Checked = false;
                cbBTNo.Checked = true;
            }
            if (cb == cbCXYes)
            {
                cbCXYes.Checked = true;
                cbCXNo.Checked = false;
            }
            if (cb == cbCXNo)
            {
                cbCXYes.Checked = false;
                cbCXNo.Checked = true;
            }

        }


        public string Source()
        {
            if (txtCardNo.Text == string.Empty)
            {
                return "BAU";
            }
            else
            {
                return "Squad";
            }

        }


        double balance;

        private void insertDataMDB()
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=BTCXData.mdb;"))

                //using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=\\\\B720W999\\BTCX\\BTCXData.mdb;"))

                try
                {
                    connection.Open();




                    if (done != txtLegalID.Text || carddone != txtCardNo.Text || cbBTNo.Checked == true || cbBTYes.Checked == true || cbCXNo.Checked == true || cbCXYes.Checked == true)
                    {

                        //MessageBox.Show(userID);
                        DateTime date1 = DateTime.Now;
                        source = Source().ToString();

                        if (txtAvailable.Text != "")
                        {
                            balance = Convert.ToDouble(txtAvailable.Text);
                        }

                        if (cbBTNo.Checked == true || cbBTYes.Checked == true || cbCXNo.Checked == true || cbCXYes.Checked == true)
                        {

                            status = "cross selling";
                        }
                        else
                        {
                            status = "checked";
                        }

                        if (cbBTYes.Checked == true || cbCXYes.Checked == true)
                        {
                            insertDataCSA();
                        }


                        String my_querry = "INSERT INTO XSell (CUSTOMER, LEGAL_ID, CARD_NO, STAFF_ID, DATE1, PRODUCT, INTEREST, REMARKS, SOURCE, RHBNOW, ESTATEMENT, BALANCE, STATUS )VALUES('" + txtName.Text.Replace("'", "''") + "','" + legalID + "','" + txtCardNo.Text + "','" + StaffID + "' ,'" + date1 + "','" + product + "','" + interested + "','" + txtCriteriaRemarks.Text + "','" + source + "','" + rhb + "','" + estate + "','" + balance + "','" + status + "')";

                        OleDbCommand cmd = new OleDbCommand(my_querry, connection);
                        cmd.ExecuteNonQuery();

                        //MessageBox.Show("Data saved successfuly...!");
                        done = txtLegalID.Text;
                        carddone = txtCardNo.Text;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to" + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
        }
        int totalPoints;
        string date2;
        int date3;

        private void insertDataCSA()
        {

            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=CSA.mdb;"))

                try
                {

                    DateTime now = DateTime.Now;
                    date2 = now.Month.ToString();
                    OleDbCommand command = new OleDbCommand("SELECT  STAFF_ID, TOTAL, DATES FROM CSAS WHERE STAFF_ID = '" + StaffID + "'", connection);
                    //  OleDbCommand command = new OleDbCommand("SELECT  STAFF_ID FROM CSAS WHERE(STAFF_ID = '179264') ", connection);
                    //OleDbCommand command = new OleDbCommand("SELECT  XSell.FINAL_ID,XSell.IBK_CUST,XSell.ESTMT_CUST,XSell.CARD_NUMBER,XSell.CIS_SEGMENT, XSell.NAME_FULL FROM `\\\\B720W999\\BTCX\\BTCX`.XSell XSell WHERE(XSell.FINAL_ID = '" + legalID + "') ", connection);
                    connection.Open();

                    OleDbDataReader reader = command.ExecuteReader();
                    date3 = Convert.ToInt32(date2);
                    while (reader.Read())
                    {

                        //MessageBox.Show(reader["TOTAL"].ToString());
                        if (Convert.ToInt32(reader["DATES"]) == date3)
                        {
                            string totalPoint = reader["TOTAL"].ToString();
                            totalPoints = Convert.ToInt32(totalPoint);
                            connection.Close();
                            goto here;

                        }

                        //MessageBox.Show("foundid" + " " + totalPoints + "");



                    }

                    try
                    {
                        string my_querry = "INSERT INTO CSAS (STAFF_ID, TOTAL, DATES ) VALUES('" + StaffID + "' ,1, " + date3 + ")";

                        OleDbCommand cmd = new OleDbCommand(my_querry, connection);
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed due to" + ex.Message);
                    }
                    finally
                    {
                        reader.Close();
                    }

                }


                catch (Exception ex)
                {
                    MessageBox.Show("Error this" + ex.Message);
                }


                finally
                {

                    connection.Close();
                }

            here:
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=CSA.mdb;"))

                //using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=\\\\B720W999\\BTCX\\BTCXData.mdb;"))

                try
                {
                    connection.Open();

                    totalPoints++;
                    //MessageBox.Show(totalPoints.ToString());

                    string my_querry = "UPDATE CSAS SET TOTAL ='" + totalPoints + "' WHERE STAFF_ID = '" + StaffID + "' AND DATES=  " + date3 + " ";

                    // totalPoints = 0;
                    OleDbCommand cmd = new OleDbCommand(my_querry, connection);
                    cmd.ExecuteNonQuery();


                    string TM = agentListTM(intStaffID);
                    Console.WriteLine(TM);
                    string UH = agentListUH(intStaffID);
                    Console.WriteLine(UH);


                    OleDbCommand command = new OleDbCommand("SELECT * FROM TM  WHERE TM_NAME = '" + TM + "'", connection);
                    //  OleDbCommand command = new OleDbCommand("SELECT  STAFF_ID FROM CSAS WHERE(STAFF_ID = '179264') ", connection);
                    //OleDbCommand command = new OleDbCommand("SELECT  XSell.FINAL_ID,XSell.IBK_CUST,XSell.ESTMT_CUST,XSell.CARD_NUMBER,XSell.CIS_SEGMENT, XSell.NAME_FULL FROM `\\\\B720W999\\BTCX\\BTCX`.XSell XSell WHERE(XSell.FINAL_ID = '" + legalID + "') ", connection);
                    //connection.Open();

                    OleDbDataReader reader = command.ExecuteReader();
                    date3 = Convert.ToInt32(date2);
                    while (reader.Read())
                    {

                        pointTM = Convert.ToInt32(reader["TOTAL"]);
                        pointTM++;

                    }

                    OleDbCommand command1 = new OleDbCommand("SELECT * FROM UH  WHERE UH_NAME = '" + UH + "'", connection);
                    //  OleDbCommand command = new OleDbCommand("SELECT  STAFF_ID FROM CSAS WHERE(STAFF_ID = '179264') ", connection);
                    //OleDbCommand command = new OleDbCommand("SELECT  XSell.FINAL_ID,XSell.IBK_CUST,XSell.ESTMT_CUST,XSell.CARD_NUMBER,XSell.CIS_SEGMENT, XSell.NAME_FULL FROM `\\\\B720W999\\BTCX\\BTCX`.XSell XSell WHERE(XSell.FINAL_ID = '" + legalID + "') ", connection);
                    //connection.Open();

                    OleDbDataReader reader1 = command1.ExecuteReader();
                    date3 = Convert.ToInt32(date2);
                    while (reader1.Read())
                    {

                        pointUH = Convert.ToInt32(reader1["TOTAL"]);
                        pointUH++;
                    }

                    // totalPoints = 0;



                    my_querry = "UPDATE TM SET TOTAL = " + pointTM + ", DATES =  " + date3 + "   WHERE TM_NAME = '" + TM + "' ";
                    // totalPoints = 0;
                    OleDbCommand cmd1 = new OleDbCommand(my_querry, connection);
                    cmd1.ExecuteNonQuery();

                    my_querry = "UPDATE UH SET TOTAL = " + pointUH + ", DATES=  " + date3 + " WHERE UH_NAME = '" + UH + "'  ";
                    // totalPoints = 0;
                    OleDbCommand cmd2 = new OleDbCommand(my_querry, connection);
                    cmd2.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed due to " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
        }

        public string agentListTM(int staffID)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=Agent List.xls;Extended Properties=\"Excel 8.0;HDR=YES;\""))
            {
                try
                {
                    DateTime now = DateTime.Now;
                    date2 = now.Month.ToString();
                    date3 = Convert.ToInt32(date2);

                    //int Staff = Convert.ToInt32(Environment.UserName);

                    OleDbCommand command = new OleDbCommand("SELECT * FROM `" + MMM + "$` `" + MMM + "$` WHERE(`" + MMM + "$`.`Staff ID`= " + staffID + ")   ", connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    //`Staff ID` = '" + Staff + "'
                    while (reader.Read())
                    {
                        if (reader["Team Manager"].ToString() == null)
                        {
                            return staffID.ToString();

                        }
                        else
                        {
                            return reader["Team Manager"].ToString();
                        }


                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error" + ex.Message);
                    Console.WriteLine(ex.Message);
                }

                connection.Close();

                return null;
            }
        }

        public string agentListUH(int staffID)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=Agent List.xls;Extended Properties=\"Excel 8.0;HDR=YES;\""))
            {
                try
                {
                    DateTime now = DateTime.Now;
                    date2 = now.Month.ToString();
                    date3 = Convert.ToInt32(date2);

                    //int Staff = Convert.ToInt32(Environment.UserName);

                    OleDbCommand command = new OleDbCommand("SELECT * FROM `" + MMM + "$` `" + MMM + "$` WHERE(`" + MMM + "$`.`Staff ID`= " + staffID + ")   ", connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    //`Staff ID` = '" + Staff + "'
                    while (reader.Read())
                    {
                        if (reader["Unit Head"].ToString() == null)
                        {
                            return staffID.ToString();

                        }
                        else
                        {
                            return reader["Unit Head"].ToString();
                        }


                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error" + ex.Message);
                    Console.WriteLine(ex.Message);
                }

                connection.Close();

                return null;
            }
        }

        private void selectUserControl(object sender, EventArgs e)
        {
            Label label = sender as Label;

            if (label.Text == "Customer Profile")
            {
                lineCriteria.BackColor = Color.Silver;
                lineCustomer.BackColor = Color.DeepSkyBlue;
                //criteria1.Visible = false;
            }
            else if (label.Text == "Criteria Checking")
            {
                lineCriteria.BackColor = Color.DeepSkyBlue;
                lineCustomer.BackColor = Color.Silver;
                //criteria1.Visible = true;
                //criteria1.BringToFront();
            }
        }

        private void searchingData_KeyPress(object sender, KeyPressEventArgs e)
        {



            if (e.KeyChar == (char)13)
            {
                txtCardNo.Text = string.Empty;
                txtName.Text = string.Empty;
                legalID = txtLegalID.Text.ToString();
                //txtLegalID.Text = string.Empty;
                lblBTScript.Text = "";
                lblCXScript.Text = "";
                picRHB.BackgroundImage = null;
                picESTMT.BackgroundImage = null;

                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=BTCX.mdb;"))
                //B720w246
                //Provider = Microsoft.ACE.OLEDB.12.0; Password = ""; User ID = Admin; Data Source = D:\BTCX\BTCX.mdb; Mode = Share Deny Write; Extended Properties = ""; Jet OLEDB:System database = ""; Jet OLEDB:Registry Path = ""; Jet OLEDB:Database Password = ""; Jet OLEDB:Engine Type = 5; Jet OLEDB:Database Locking Mode = 0; Jet OLEDB:Global Partial Bulk Ops = 2; Jet OLEDB:Global Bulk Transactions = 1; Jet OLEDB:New Database Password = ""; Jet OLEDB:Create System Database = False; Jet OLEDB:Encrypt Database = False; Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False;Jet OLEDB:Support Complex Data=False;Jet OLEDB:Bypass UserInfo Validation=False;Jet OLEDB:Limited DB Caching=False;Jet OLEDB:Bypass ChoiceField Validation=False
                //using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=\\\\B720W999\\BTCX\\BTCX.mdb;"))
                {
                    try
                    {


                        OleDbCommand command = new OleDbCommand("SELECT  XSell.FINAL_ID,XSell.IBK_CUST,XSell.ESTMT_CUST,XSell.CARD_NUMBER,XSell.CIS_SEGMENT, XSell.NAME_FULL FROM `BTCX`.XSell XSell WHERE(XSell.FINAL_ID = '" + legalID + "') ", connection);
                        //OleDbCommand command = new OleDbCommand("SELECT  XSell.FINAL_ID,XSell.IBK_CUST,XSell.ESTMT_CUST,XSell.CARD_NUMBER,XSell.CIS_SEGMENT, XSell.NAME_FULL FROM `\\\\B720W999\\BTCX\\BTCX`.XSell XSell WHERE(XSell.FINAL_ID = '" + legalID + "') ", connection);
                        connection.Open();

                        OleDbDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {

                            //MessageBox.Show(reader["CUSTOMER"].ToString());
                            txtName.Text = reader["NAME_FULL"].ToString();
                            txtCardNo.Text = reader["CARD_NUMBER"].ToString();
                            string rhbnowTag = reader["IBK_CUST"].ToString();
                            string estatTag = reader["ESTMT_CUST"].ToString();

                            if (reader["IBK_CUST"].ToString() == "1")
                            {
                                picRHB.BackgroundImage = CCCApp.Properties.Resources.yes;
                                rhb = "1";
                            }
                            else
                            {
                                rhb = "0";
                                picRHB.BackgroundImage = CCCApp.Properties.Resources.png_wrong_cross_png_small_medium_large_600;
                            }
                            if (reader["ESTMT_CUST"].ToString() == "1")
                            {
                                estate = "1";
                                picESTMT.BackgroundImage = CCCApp.Properties.Resources.yes;
                            }
                            else
                            {
                                estate = "0";
                                picESTMT.BackgroundImage = CCCApp.Properties.Resources.png_wrong_cross_png_small_medium_large_600;
                                text = "Please encourage customer to do e-Statement!";
                                max = 20;
                                timer1.Start();


                            }
                        }

                        reader.Close();

                        if (txtCardNo.Text == "")
                        {

                            text = "The Legal ID does not exist, even so please do the cross selling!";
                            txtName.Text = "Potential Customer";
                            max = 10;
                            timer1.Start();

                        }



                        //insert customer in the database

                        //int staffID = 450011;
                        string staffID1 = agentList(intStaffID);
                        if (staffID1 != null)
                        {
                            insertDataMDB();
                            checks = true;
                        }

                        lblBTScript.Text = BTScript;
                        lblCXScript.Text = CXScript;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error" + ex.Message);
                    }

                }

                try
                {
                    Clipboard.SetText("1000");
                }
                catch (Exception)
                {

                }
            }

            secondLegalID = legalID;
        }

        int i;
        int max;
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (btnNotification.Text == "")
            {
                btnNotification.Text = text;
                btnNotification.Show();
            }
            else
            {
                btnNotification.Text = "";
                btnNotification.Show();
            }
            i += 1;
            if (i == max)
            {
                timer1.Stop();
                btnNotification.Text = "";
                i = 0;
                max = 0;
            }


        }

        public string checkDouble(string legalID)
        {
            int i = 0;
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=BTCXData.mdb;"))
            {
                try
                {
                    DateTime now = DateTime.Now;
                    date2 = now.Month.ToString();
                    date3 = Convert.ToInt32(date2);

                    //int Staff = Convert.ToInt32(Environment.UserName);

                    OleDbCommand command = new OleDbCommand("SELECT * FROM XSell ORDER BY DATE1 DESC ", connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    //`Staff ID` = '" + Staff + "'
                    while (reader.Read())
                    {
                        i++;
                        Console.WriteLine(reader["LEGAL_ID"].ToString());
                        Console.WriteLine(reader["STATUS"].ToString());
                        if (reader["LEGAL_ID"].ToString() == legalID && reader["STATUS"].ToString() == "checked" && i == 1)
                        {
                            return "checked";

                        }
                        else
                        {
                            return "cross selling";
                        }


                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error" + ex.Message);
                    Console.WriteLine(ex.Message);
                }

                connection.Close();

                return null;
            }
        }
    }

}

//public class Account
//{
//    public string StaffID { set; get; }
//    public DateTime Date { set; get; }


//    public string Name { set; get; }
//    public string LegalId { set; get; }
//    public string Card { set; get; }
//    public string Source { set; get; }
//}



//private void insertDataFirebase(object sender, EventArgs e)
//{
//    if (txtLegalID.Text != done)
//    {
//        Account account = new Account
//        {

//            StaffID = Environment.UserName.ToString(),
//            Date = DateTime.Now,
//            Name = txtName.Text.ToString(),
//            LegalId = txtLegalID.Text.ToString(),
//            Card = txtCardNo.Text.ToString(),
//            Source = Source(),

//        };

//        string json = JsonConvert.SerializeObject(account, Formatting.Indented);


//        var request = WebRequest.CreateHttp("https://cccapp-f5ff5.firebaseio.com/.json");
//        request.Method = "POST";
//        request.ContentType = "application/json";
//        var buffer = Encoding.UTF8.GetBytes(json);
//        request.ContentLength = buffer.Length;
//        request.GetRequestStream().Write(buffer, 0, buffer.Length);
//        var response = request.GetResponse();
//        json = (new StreamReader(response.GetResponseStream())).ReadToEnd();


//        done = txtLegalID.Text;
//    }

//}