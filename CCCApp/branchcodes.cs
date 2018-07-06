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
    public partial class branchcodes : UserControl
    {
        string ConnString;
        public branchcodes()
        {
            InitializeComponent();

            if (Environment.UserName.ToString() != "Yusri")
            {
                ConnString = "\\\\maanetapp1\\Consumer Product\\CCCKL\\Malaysia Operations\\For Internal Use Only\\MIS Unit\\Yusri's File\\BTCX\\";
            }
            else
            {
                ConnString = "";
            }
        }
        OleDbCommand command;
        private void searchingData_KeyPress(object sender, EventArgs e)
        {
               
                string newBranch = txtSearchName.Text;
               // MessageBox.Show(newBranch);
                txtBranchName.Text = string.Empty;
                txtAdd.Text = string.Empty;
                txtBM.Text = string.Empty;
                txtABM.Text = string.Empty;
                txtTel.Text = string.Empty;

                //using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=BranchCodes.mdb;"))
                //B720w246
                //Provider = Microsoft.ACE.OLEDB.12.0; Password = ""; User ID = Admin; Data Source = D:\BTCX\BTCX.mdb; Mode = Share Deny Write; Extended Properties = ""; Jet OLEDB:System database = ""; Jet OLEDB:Registry Path = ""; Jet OLEDB:Database Password = ""; Jet OLEDB:Engine Type = 5; Jet OLEDB:Database Locking Mode = 0; Jet OLEDB:Global Partial Bulk Ops = 2; Jet OLEDB:Global Bulk Transactions = 1; Jet OLEDB:New Database Password = ""; Jet OLEDB:Create System Database = False; Jet OLEDB:Encrypt Database = False; Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;Jet OLEDB:SFP=False;Jet OLEDB:Support Complex Data=False;Jet OLEDB:Bypass UserInfo Validation=False;Jet OLEDB:Limited DB Caching=False;Jet OLEDB:Bypass ChoiceField Validation=False
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + ConnString + "BRANCHCODE.mdb;"))
                {
                    try
                    {


                    //OleDbCommand command = new OleDbCommand("SELECT  branch.BrCode,branch.TBrName,branch.TAddr1,branch.TAddr2,branch.TAddr3, branch.TPostcode FROM `BranchCodes`.branch branch WHERE(branch.TBrName LIKE '%" + newBranch + "%') ", connection);
                    if(txtSearchName.Text != "")
                    {
                        command = new OleDbCommand("SELECT * FROM BranchCodes WHERE(Branch = '" + newBranch + "') ", connection);
                        //txtSearchName.Text = string.Empty;
                        
                    }

                    if (txtSearchAdd.Text != string.Empty)
                    {
                        command = new OleDbCommand("SELECT * FROM BranchCodes WHERE(`Branch Address` LIKE '%" + txtSearchAdd.Text + "%') ", connection);
                    }





                    connection.Open();

                        OleDbDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {

                            //MessageBox.Show(reader["CUSTOMER"].ToString());
                            txtBranchName.Text = reader["Branch"].ToString();
                            txtAdd.Text = reader["Branch Address"].ToString();
                            txtBM.Text = reader["BM"].ToString();
                            txtABM.Text = reader["Asst Branch Manager"].ToString();
                            txtTel.Text = reader["General Line / Fax"].ToString();
                            lblCode.Text = reader["Branch Code"].ToString();

                        }

                       
                          reader.Close();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("Error" + ex.Message);
                    }
                
                connection.Close();
                }
         }
    }
  
}
