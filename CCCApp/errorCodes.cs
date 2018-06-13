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
    public partial class errorCodes : UserControl
    {
        public errorCodes()
        {
            InitializeComponent();
        }

        private void searchingData_KeyPress(object sender, KeyPressEventArgs e)
        {



            if (e.KeyChar == (char)13)
            {
                //txtSearchATM.Text = string.Empty;
                txtErrATM.Text = string.Empty;
                txtDescATM.Text = string.Empty;
                txtResATM.Text = string.Empty;



                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=\\\\maanetapp1\\Consumer Product\\CCCKL\\Malaysia Operations\\For Internal Use Only\\MIS Unit\\Yusri's File\\BTCX\\ATM.mdb;"))
                //B720w246
                //Provider = Microsoft.ACE.OLEDB.12.0; Password = ""; User ID = Admin; Data Source = D:\BTCX\BTCX.mdb; Mode = Share Deny Write; Extended Properties = ""; Jet OLEDB:System database = ""; Jet OLEDB:Registry Path = ""; Jet OLEDB:Database Password = ""; Jet OLEDB:Engine Type = 5; Jet OLEDB:Database Locking Mode = 0; Jet OLEDB:Global Partial Bulk Ops = 2; Jet OLEDB:Global Bulk Transactions = 1; Jet OLEDB:New Database Password = ""; Jet OLEDB:Create System Database = False; Jet OLEDB:Encrypt Database = False; Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False;Jet OLEDB:Support Complex Data=False;Jet OLEDB:Bypass UserInfo Validation=False;Jet OLEDB:Limited DB Caching=False;Jet OLEDB:Bypass ChoiceField Validation=False
                //using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=\\\\B720W999\\BTCX\\BTCX.mdb;"))
                {
                    try
                    {


                        OleDbCommand command = new OleDbCommand("SELECT CODE, DESCRIPTION, RESPONSE FROM `\\\\maanetapp1\\Consumer Product\\CCCKL\\Malaysia Operations\\For Internal Use Only\\MIS Unit\\Yusri's File\\BTCX\\ATM`.ATM ATM WHERE(CODE = '" + txtSearchATM.Text + "') ", connection);
                        //OleDbCommand command = new OleDbCommand("SELECT  ATM.FINAL_ID,ATM.IBK_CUST,ATM.ESTMT_CUST,ATM.CARD_NUMBER,ATM.CIS_SEGMENT, ATM.NAME_FULL FROM `\\\\B720W999\\BTCX\\BTCX`.ATM ATM WHERE(ATM.FINAL_ID = '" + legalID + "') ", connection);
                        connection.Open();

                        OleDbDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {

                            //MessageBox.Show(reader["CUSTOMER"].ToString());
                            txtErrATM.Text = reader["CODE"].ToString();
                            txtDescATM.Text = reader["DESCRIPTION"].ToString();
                            txtResATM.Text = reader["RESPONSE"].ToString();


                        }

                        reader.Close();

                        if (txtDescATM.Text == "")
                        {

                            MessageBox.Show("Error Codes does not exist!");
                            txtSearchATM.Text = "";

                        }


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

        }




            private void searchingData_KeyPressIBK(object sender, KeyPressEventArgs e)
            {



                if (e.KeyChar == (char)13)
                {
                    //txtSearchIBK.Text = string.Empty;
                    txtErrIBK.Text = string.Empty;
                    txtDescIBK.Text = string.Empty;
                    txtResIBK.Text = string.Empty;



                    using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=\\\\maanetapp1\\Consumer Product\\CCCKL\\Malaysia Operations\\For Internal Use Only\\MIS Unit\\Yusri's File\\BTCX\\IBKError.mdb;"))
                    //B720w246
                    //Provider = Microsoft.ACE.OLEDB.12.0; Password = ""; User ID = Admin; Data Source = D:\BTCX\BTCX.mdb; Mode = Share Deny Write; Extended Properties = ""; Jet OLEDB:System database = ""; Jet OLEDB:Registry Path = ""; Jet OLEDB:Database Password = ""; Jet OLEDB:Engine Type = 5; Jet OLEDB:Database Locking Mode = 0; Jet OLEDB:Global Partial Bulk Ops = 2; Jet OLEDB:Global Bulk Transactions = 1; Jet OLEDB:New Database Password = ""; Jet OLEDB:Create System Database = False; Jet OLEDB:Encrypt Database = False; Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False;Jet OLEDB:Support Complex Data=False;Jet OLEDB:Bypass UserInfo Validation=False;Jet OLEDB:Limited DB Caching=False;Jet OLEDB:Bypass ChoiceField Validation=False
                    //using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=\\\\B720W999\\BTCX\\BTCX.mdb;"))
                    {
                        try
                        {


                            OleDbCommand command = new OleDbCommand("SELECT ERR1, ERRDES,ERRDES1 FROM `\\\\maanetapp1\\Consumer Product\\CCCKL\\Malaysia Operations\\For Internal Use Only\\MIS Unit\\Yusri's File\\BTCX\\IBKError`.IBKErrorCodes IBKErrorCodes WHERE(ERR = '" + txtSearchIBK.Text + "') ", connection);
                            //OleDbCommand command = new OleDbCommand("SELECT  ATM.FINAL_ID,ATM.IBK_CUST,ATM.ESTMT_CUST,ATM.CARD_NUMBER,ATM.CIS_SEGMENT, ATM.NAME_FULL FROM `\\\\B720W999\\BTCX\\BTCX`.ATM ATM WHERE(ATM.FINAL_ID = '" + legalID + "') ", connection);
                            connection.Open();

                            OleDbDataReader reader = command.ExecuteReader();

                            while (reader.Read())
                            {

                                //MessageBox.Show(reader["CUSTOMER"].ToString());
                                txtErrIBK.Text = reader["ERR1"].ToString();
                                txtDescIBK.Text = reader["ERRDES"].ToString();
                                txtResIBK.Text = reader["ERRDES1"].ToString();


                            }

                            reader.Close();

                            if (txtDescIBK.Text == "")
                            {

                                MessageBox.Show("Error Codes does not exist!");
txtSearchIBK.Text = "";

                            }


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


            }
    }
}
