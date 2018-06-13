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

namespace CCCApp
{
    public partial class survey : UserControl
    {
        string my_querry;
        string legalID;
        string issue;
        string reason;
        string balOnly;
        string RHBNow;
        string reasonCallingCCC;


        //int staffID = 179264;
        int staffID = Convert.ToInt32(Environment.UserName);

        void reset()
        {
            legalID = "";
            issue = "";
            reason = "";
            balOnly = "";
            RHBNow = "";
            reasonCallingCCC = "";
            cbCheckBalOnly.Checked = false;
            cbForgotPassword.Checked = false;
            cbIBK.Checked = false;
            cbIDBlocked.Checked = false;
            cbMBK.Checked = false;
            cbREF3.Checked = false;
            cbREF1.Checked = false;
            cbREF2.Checked = false;
            cbREF3.Checked = false;
            cbREF4.Checked = false;
            cbREF5.Checked = false;
            cbREF6.Checked = false;
            cbREF7.Checked = false;
            cbREF8.Checked = false;
            cbREF9.Checked = false;
            cbREF10.Checked = false;
            cbREF11.Checked = false;

            cbForgot1.Checked = false;
            cbForgot2.Checked = false;
            cbForgot3.Checked = false;
            cbForgotOther.Checked = false;

            cbOtherThanBal.Checked = false;
            checkBox1.Checked = false;
            checkBox15.Checked = false;
            checkBox19.Checked = false;
            checkBox2.Checked = false;
            checkBox20.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox8.Checked = false;
            txtCCLegalID.Text = "";
            txtIBKLegalID.Text = "";
            txtIBKReason.Text = "";
            txtOtherThanBal.Text = "";
            txtReasonCallingCCC.Text = "";
            txtRefLegalID.Text = "";
            txtRefRemarks.Text = "";
            
            

        }

        void selection(object sender, EventArgs e)
        {

            CheckBox cb = sender as CheckBox;

            if (cb == cbIDBlocked)
            {
              
                cbForgotPassword.Checked = false;
                cbIDBlocked.Checked = true;

            } else if (cb == cbForgotPassword)
            {
                cbForgotPassword.Checked = true;
                cbIDBlocked.Checked = false;

            } else if( cb == cbIBK)
            {

                cbMBK.Checked = false;
                cbIBK.Checked = true;

            } else if (cb == cbOtherThanBal)
            {

                cbOtherThanBal.Checked = true;
                cbCheckBalOnly.Checked = false;

            }
            else if (cb == cbCheckBalOnly)
            {

                cbCheckBalOnly.Checked = true;
                cbOtherThanBal.Checked = false;

            }

            else if (cb == cbMBK)
            {

                cbMBK.Checked = true;
                cbIBK.Checked = false;

            }


        }

        public void insertSurvey(object sender, EventArgs e)
        {
            Button button = sender as Button;

            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=\\\\maanetapp1\\Consumer Product\\CCCKL\\Malaysia Operations\\For Internal Use Only\\MIS Unit\\Yusri's File\\BTCX\\SURVEY.mdb;"))
            
            try
                {

                    DateTime now = DateTime.Now;

                    if (button.Name == "btnCC")
                    {
                        legalID = txtCCLegalID.Text;


                        if (cbCheckBalOnly.Checked == true)
                        {
                            balOnly = "Balance Only";
                        }
                        if (cbOtherThanBal.Checked == true)
                        {
                            balOnly = txtOtherThanBal.Text;
                        }


                        if (checkBox1.Checked == true)
                        {
                            reasonCallingCCC = checkBox1.Text;
                            RHBNow = "YES";
                        }
                        else  if (checkBox2.Checked == true)
                        {
                            reasonCallingCCC = checkBox2.Text;
                            RHBNow = "YES";
                        } else if (checkBox3.Checked == true)
                        {
                            reasonCallingCCC = checkBox3.Text;
                            RHBNow = "YES";
                        } else if (checkBox4.Checked == true)
                        {
                            reasonCallingCCC = checkBox4.Text;
                            RHBNow = "YES";
                        }
                        else if (checkBox5.Checked == true)
                        {
                            reasonCallingCCC = txtReasonCallingCCC.Text;
                            RHBNow = "YES";
                        }
                        else if (checkBox6.Checked == true)
                        {
                            reasonCallingCCC = checkBox6.Text;
                            RHBNow = "YES";
                        }
                        else if (checkBox8.Checked == true)
                        {
                            reasonCallingCCC = checkBox8.Text;
                            RHBNow = "YES";
                        }
                       

                        if (RHBNow == null)
                        {
                            RHBNow = "NO";
                        }


                        my_querry = "INSERT INTO CC (DATE1, LEGAL_ID, BALANCE_INQUIRY, RHBNOW, REASON, STAFF_ID ) VALUES('" + now + "', '" + legalID + "', '" + balOnly + "', '" + RHBNow + "' , '" + reasonCallingCCC.Replace("'", "''") + "', " + staffID + ")";
                    }
                    if (button.Name == "btnReflex")
                    {
                        legalID = txtRefLegalID.Text;

                        if (cbREF1.Checked == true)
                        {
                            issue = cbREF1.Text;
                        }

                        else if (cbREF2.Checked == true)
                        {
                            issue = cbREF2.Text;
                        }

                        else if (cbREF3.Checked == true)
                        {
                            issue = cbREF3.Text;
                        }

                        else if (cbREF4.Checked == true)
                        {
                            issue = cbREF4.Text;
                        }

                        else if (cbREF5.Checked == true)
                        {
                            issue = cbREF5.Text;
                        }

                        else if (cbREF6.Checked == true)
                        {
                            issue = cbREF6.Text;
                        }
                        else if (cbREF7.Checked == true)
                        {
                            issue = cbREF7.Text;
                        }
                        else if (cbREF8.Checked == true)
                        {
                            issue = cbREF8.Text;
                        }
                        else if (cbREF9.Checked == true)
                        {
                            issue = cbREF9.Text;
                        }
                        else if (cbREF10.Checked == true)
                        {
                            issue = cbREF10.Text;
                        }
                        else if (cbREF11.Checked == true)
                        {
                            issue = txtRefRemarks.Text;
                        }

                         

                        my_querry = "INSERT INTO REFLEX (DATE1, LEGAL_ID, ISSUE, REMARKS, STAFF_ID ) VALUES('" + now + "', '" + legalID + "', 'Reflex Navigation' , '" + issue.Replace("'", "''") + "', " + staffID + ")";
                    }
                    if (button.Name == "btnIBK")
                    {
                        legalID = txtIBKLegalID.Text;

                        if(cbForgotPassword.Checked == true)
                        {
                            issue = "Forgot Password";
                            cbIDBlocked.Checked = false;

                        }else if (cbIDBlocked.Checked == true)
                        {
                            issue = "ID Blocked";
                            cbForgotPassword.Checked = false;
                        }

                        if (cbForgot1.Checked == true)
                        {
                            reason = cbForgot1.Text;
                        }
                        if (cbForgot2.Checked == true)
                        {
                            reason = cbForgot2.Text;
                        }
                        if (cbForgot3.Checked == true)
                        {
                            reason = cbForgot3.Text;
                        }
                        if (cbForgotOther.Checked == true)
                        {
                            reason = txtIBKReason.Text;
                        }

                                       
                        my_querry = "INSERT INTO IBK (DATE1, LEGAL_ID, ISSUE, REASON, STAFF_ID ) VALUES('" + now + "', '" + legalID + "', '" + issue + "' , '" + reason.Replace("'", "''") + "', " + staffID + ")";
                    }

                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand(my_querry, connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Received!");
                    reset();

                }


                catch (Exception ex)
                {
                    MessageBox.Show("Error this " + ex.Message);
                }


                finally
                {
                    connection.Close();
                
                }
        }
        public survey()
        {
            InitializeComponent();
            lineCC.BackColor = Color.DeepSkyBlue;
            lineIBK.BackColor = Color.Silver;
            lineReflex.BackColor = Color.Silver;
        }

        void enterLeave(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label.Font.Size ==10)
            {
                label.Font = new Font("Century Gothic",11);
                label.Location = new Point(label.Location.X - 2, label.Location.Y - 2);
            }
            else
            {
                label.Font = new Font("Century Gothic", 10);
                label.Location = new Point(label.Location.X + 2, label.Location.Y + 2);
            }


        }

        private void selectUserControl(object sender, EventArgs e)
        {
            Label label = sender as Label;


            if (label.Text == "Credit Card")
            {
                lineCC.BackColor = Color.DeepSkyBlue;
                lineIBK.BackColor = Color.Silver;
                lineReflex.BackColor = Color.Silver;

                panelCC.Visible = true;
                panelIBK.Visible = false;
                panelReflex.Visible = false;
           
            }
            else if (label.Text == "RHB Now")
            {
                lineCC.BackColor = Color.Silver;
                lineIBK.BackColor = Color.DeepSkyBlue;
                lineReflex.BackColor = Color.Silver;

                panelCC.Visible = false;
                panelIBK.Visible = true;
                panelReflex.Visible = false;

            }
            else if (label.Text == "Reflex")
            {
                lineCC.BackColor = Color.Silver;
                lineIBK.BackColor = Color.Silver;
                lineReflex.BackColor = Color.DeepSkyBlue;

                panelCC.Visible = false;
                panelIBK.Visible = false;
                panelReflex.Visible = true;

            }
        }
    }
}
