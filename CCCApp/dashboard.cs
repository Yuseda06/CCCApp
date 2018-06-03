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
using ExcelDataReader;

namespace CCCApp
{
    public partial class dashboard : UserControl
    {
        Label[] labels = new Label[10];
        Button[] buttons = new Button[10];
        Label[] labelCSA = new Label[10];

        Label[] lblTM = new Label[3];
        Button[] btnTM = new Button[3];
        Label[] lblScoreTM = new Label[3];

        Label[] lblUH = new Label[3];
        Button[] btnUH = new Button[3];
        Label[] lblScoreUH = new Label[3];

        int intStaffID;
        string StaffID;

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
        public dashboard()
        {
            InitializeComponent();

            setDate();

            checkingID();

            lblTM[0] = lblTM1;
            lblTM[1] = lblTM2;
            lblTM[2] = lblTM3;

            btnTM[0] = btnTM1;
            btnTM[1] = btnTM2;
            btnTM[2] = btnTM3;

            lblScoreTM[0] = lblScoreTM1;
            lblScoreTM[1] = lblScoreTM2;
            lblScoreTM[2] = lblScoreTM3;


            lblUH[0] = lblUH1;
            lblUH[1] = lblUH2;
            lblUH[2] = lblUH3;

            btnUH[0] = btnUH1;
            btnUH[1] = btnUH2;
            btnUH[2] = btnUH3;

            lblScoreUH[0] = lblScoreUH1;
            lblScoreUH[1] = lblScoreUH2;
            lblScoreUH[2] = lblScoreUH3;



            labels[0] = lblScore1;
            labels[1] = lblScore2;
            labels[2] = lblScore3;
            labels[3] = lblScore4;
            labels[4] = lblScore5;
            labels[5] = lblScore6;
            labels[6] = lblScore7;
            labels[7] = lblScore8;
            labels[8] = lblScore9;
            labels[9] = lblScore10;

            buttons[0] = btn1;
            buttons[1] = btn2;
            buttons[2] = btn3;
            buttons[3] = btn4;
            buttons[4] = btn5;
            buttons[5] = btn6;
            buttons[6] = btn7;
            buttons[7] = btn8;
            buttons[8] = btn9;
            buttons[9] = btn10;

            labelCSA[0] = lblCSA1;
            labelCSA[1] = lblCSA2;
            labelCSA[2] = lblCSA3;
            labelCSA[3] = lblCSA4;
            labelCSA[4] = lblCSA5;
            labelCSA[5] = lblCSA6;
            labelCSA[6] = lblCSA7;
            labelCSA[7] = lblCSA8;
            labelCSA[8] = lblCSA9;
            labelCSA[9] = lblCSA10;

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

        int x = 0;
        string date2;
        int date3;
        static string You;
        static string tm;
        static string uh;
        string staffID;
        string MMM;

        private void setDate()
        {
            //DateTime moment = new DateTime();
            //int months = moment.Month;
            //int years = moment.Year;

            //lblMonth.Text = months + ", " + years;
            lblMonth.Text = DateTime.Now.ToString("MMM  yyyy").Replace('-', '/') + ", Cross Selling Champs";

        }

        private void pressEnter()
        {


            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=CSA.mdb;"))
            {
                try
                {

                    DateTime now = DateTime.Now;
                    date2 = now.Month.ToString();
                    date3 = Convert.ToInt32(date2);
                    connection.Open();

                    //OleDbCommand command7 = new OleDbCommand("SELECT  * FROM CSAS WHERE DATES = " + date3 + " ", connection);
                    //OleDbDataReader reader7 = command7.ExecuteReader();
                    //Console.WriteLine(reader7["STAFF_ID"].ToString());
                    //if (reader7["STAFF_ID"].ToString() == StaffID)
                    //{
                    //    You = Convert.ToString(agentList(intStaffID));
                    //}


                    OleDbCommand command = new OleDbCommand("SELECT  * FROM CSAS WHERE DATES = " + date3 + " ORDER BY TOTAL DESC", connection);
                    OleDbDataReader reader = command.ExecuteReader();



                    for (int i = 0; i < 10; i++)
                    {

                        while (reader.Read())
                        {

                            try
                            {

                                intStaffID = Convert.ToInt32(reader["STAFF_ID"]);
                                staffID = Convert.ToString(agentList(intStaffID));

                                goto here;
                            }
                            catch (Exception)
                            {
                                staffID = reader["STAFF_ID"].ToString();
                            }



                            here:
                            labelCSA[i].Text = staffID;
                            Console.WriteLine(staffID);



                            //Console.WriteLine(labelCSA[i].Text);
                            labels[i].Text = reader["TOTAL"].ToString();
                            //Console.WriteLine(labels[i].Text);

                            x = Convert.ToInt32(labels[i].Text) * 2;
                            buttons[i].Size = new Size(30 + x, 5);
                            x = 0;
                            break;
                        }

                    }

                    OleDbCommand command1 = new OleDbCommand("SELECT  * FROM TM WHERE DATES = " + date3 + " ORDER BY TOTAL DESC", connection);
                    OleDbDataReader reader1 = command1.ExecuteReader();

                    for (int i = 0; i < 3; i++)
                    {
                        while (reader1.Read())
                        {
                            string TM = reader1["TM_NAME"].ToString();
                            int scoreTM = Convert.ToInt32(reader1["TOTAL"]);

                            if (StaffID == reader1["STAFF_ID"].ToString())
                            {
                                You = TM;
                            }

                            if (scoreTM != 0)
                            {
                                lblTM[i].Text = TM;
                            }

                            Console.WriteLine(labelCSA[i].Text);
                            lblScoreTM[i].Text = reader1["TOTAL"].ToString();
                            Console.WriteLine(labels[i].Text);

                            x = Convert.ToInt32(labels[i].Text) / 5;
                            btnTM[i].Size = new Size(30 + x, 5);
                            x = 0;
                            break;
                        }

                    }



                    OleDbCommand command2 = new OleDbCommand("SELECT  * FROM UH WHERE DATES = " + date3 + " ORDER BY TOTAL DESC", connection);
                    OleDbDataReader reader2 = command2.ExecuteReader();



                    for (int i = 0; i < 3; i++)
                    {
                        while (reader2.Read())
                        {
                            string UH = reader2["UH_NAME"].ToString();
                            int scoreUH = Convert.ToInt32(reader2["TOTAL"]);

                            if (StaffID == reader2["STAFF_ID"].ToString())
                            {
                                You = UH;
                            }

                            if (scoreUH != 0)
                            {
                                lblUH[i].Text = UH;
                            }

                            Console.WriteLine(labelCSA[i].Text);
                            lblScoreUH[i].Text = reader2["TOTAL"].ToString();
                            Console.WriteLine(labels[i].Text);

                            x = Convert.ToInt32(labels[i].Text) / 15;
                            btnUH[i].Size = new Size(30 + x, 5);
                            x = 0;

                            break;
                        }

                    }

                    reader.Close();
                    reader1.Close();
                    reader2.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
                connection.Close();

            }
        }

        int o;

        private void pressEnter1()
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=CSA.mdb;"))
            {
                try
                {
                    DateTime now = DateTime.Now;
                    date2 = now.Month.ToString();
                    date3 = Convert.ToInt32(date2);
                    o = 0;
                    // Staff = Environment.UserName.ToString();
                    // string Staff = "403066";

                    connection.Open();
                    OleDbCommand command = new OleDbCommand("SELECT * FROM CSAS WHERE DATES = " + date3 + "  ORDER BY TOTAL DESC", connection);
                    OleDbDataReader reader = command.ExecuteReader();




                    while (reader.Read())
                    {
                        o++;

                        Console.WriteLine(reader["STAFF_ID"].ToString());
                        if (reader["STAFF_ID"].ToString() == StaffID)
                        {
                            intStaffID = Convert.ToInt32(reader["STAFF_ID"]);
                            staffID = Convert.ToString(agentList(intStaffID));
                            lblCurrentScore.Text = o.ToString();
                            lblCurrentScore.Text = "" + staffID + " You are currently at TOP ( " + lblCurrentScore.Text + " ) with total scores of ( " + reader["TOTAL"].ToString() + " )";


                            goto final;
                            //MessageBox.Show(reader["TOTAL"].ToString());
                        }

                    }


                    reader.Close();

                    OleDbCommand command1 = new OleDbCommand("SELECT * FROM TM WHERE DATES = " + date3 + "  ORDER BY TOTAL DESC", connection);
                    OleDbDataReader reader1 = command1.ExecuteReader();
                    o = 0;
                    while (reader1.Read())
                    {
                        o++;
                        Console.WriteLine(reader1["STAFF_ID"].ToString());
                        if (reader1["STAFF_ID"].ToString() == StaffID)
                        {

                            lblCurrentScore.Text = o.ToString();
                            lblCurrentScore.Text = "" + reader1["TM_NAME"].ToString() + " You are currently at TOP ( " + lblCurrentScore.Text + " ) with total scores of ( " + reader1["TOTAL"].ToString() + " )";

                            goto final;
                            //MessageBox.Show(reader["TOTAL"].ToString());
                        }


                    }

                    reader1.Close();

                    OleDbCommand command2 = new OleDbCommand("SELECT * FROM UH WHERE DATES = " + date3 + "  ORDER BY TOTAL DESC", connection);
                    OleDbDataReader reader2 = command2.ExecuteReader();
                    o = 0;
                    while (reader2.Read())
                    {
                        o++;
                        Console.WriteLine(reader2["STAFF_ID"].ToString());
                        if (reader2["STAFF_ID"].ToString() == StaffID)
                        {

                            lblCurrentScore.Text = o.ToString();
                            lblCurrentScore.Text = "" + reader2["UH_NAME"].ToString() + " You are currently at TOP ( " + lblCurrentScore.Text + " ) with total scores of ( " + reader2["TOTAL"].ToString() + " )";


                            //MessageBox.Show(reader["TOTAL"].ToString());
                        }



                    }

                    reader2.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //MessageBox.Show("Error" + ex.Message);
                }
                final:
                connection.Close();


            }
        }

        private void updateScore(object sender, EventArgs e)
        {

            pressEnter();
            pressEnter1();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            pressEnter();
            pressEnter1();
        }
    }

}
















//private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
//{
//    MessageBox.Show("testing");
//}





//private void pressEnter(object sender, KeyEventArgs e)
//{
//    if (e.KeyCode == Keys.Enter)
//    {


//        String name = txtName.Text.ToString();


//                String szFilePath = "C:\\Users\\Yusri\\Desktop\\XSell_BTCX_" + MMM + "2018_v1.xls";

//                String ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = '" + szFilePath + "';Extended Properties=\"Excel 8.0;HDR=YES;\"";

//                using (OleDbConnection conn = new OleDbConnection(ConnectionString))

//                {
//                    conn.Open();
//                    OleDbDataAdapter objDA = new System.Data.OleDb.OleDbDataAdapter
//                    ("select NAME_FULL from [XSell$] WHERE(NAME_FULL LIKE '%" + name + "%') ", conn);
//                    DataSet excelDataSet = new DataSet();
//                    objDA.Fill(excelDataSet);

//                    String whate = objDA.ToString();
//                    int count = 1;
//                    foreach (DataRow dr in excelDataSet.Tables[0].Rows)

//                    {
//                        count = count + 1;
//                        MessageBox.Show(excelDataSet.Tables[0].Rows[count]["NAME_FULL"].ToString());
//                    }


//                    dataGridView1.DataSource = excelDataSet.Tables[0];
//                }
//            }
//        }

//        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            if (e.KeyChar == (char)13)
//            {


//                String name = txtName.Text.ToString();

//                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:\\Users\\Yusri\\Desktop\\BTCX.mdb;"))
//                {
//                    try
//                    {


//                        OleDbCommand command = new OleDbCommand("SELECT  XSell.FINAL_ID,XSell.CARD_NUMBER,XSell.CIS_SEGMENT, XSell.NAME_FULL FROM `C:\\Users\\Yusri\\Desktop\\BTCX`.XSell XSel WHERE(XSell.NAME_FULL = '%" + name + "%') ", connection);
//                        connection.Open();
//                        OleDbDataReader reader = command.ExecuteReader();

//                        while (reader.Read())
//                        {

//                            //MessageBox.Show(reader["CUSTOMER"].ToString());
//                            label1.Text = reader["FINAL_ID"].ToString();
//                            label2.Text = reader["CARD_NUMBER"].ToString();
//                            label3.Text = reader["CIS_SEGMENT"].ToString();
//                            label4.Text = reader["NAME_FULL"].ToString();
//                        }
//                        reader.Close();
//                    }
//                    catch (Exception ex)
//                    {
//                        MessageBox.Show("Error" + ex.Message);
//                    }

//                }
//            }
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            string connetionString = null;
//            string server = "db4free.net";
//            string database = "cccapp";
//            string username = "rhb179264";
//            string password = "luke1982";

//            String name = txtName.Text.ToString();
//            MySqlConnection cnn;
//            //MessageBox.Show(name.ToString());
//            connetionString = "server=" + server + ";PORT=3306;database=" + database + ";uid=" + username + ";pwd=" + password + ";";
//            cnn = new MySqlConnection(connetionString);

//            String oldRecord = label1.Text.ToString();

//            try
//            {
//                MySqlCommand command = new MySqlCommand("SELECT XSell.FINAL_ID,XSell.CARD_NUMBER,XSell.CIS_SEGMENT, XSell.NAME_FULL FROM `XSell` WHERE (XSell.FINAL_ID = '" + name + "') ", cnn);
//                cnn.Open();
//                MySqlDataReader reader = command.ExecuteReader();
//                //MessageBox.Show("Connection Open ! ");
//                        while (reader.Read())
//                        {

//                            label1.Text = reader["FINAL_ID"].ToString();
//                            label2.Text = reader["CARD_NUMBER"].ToString();
//                            label3.Text = reader["CIS_SEGMENT"].ToString();
//                            label4.Text = reader["NAME_FULL"].ToString();
//                        }

//                String newRecord = label1.Text.ToString();

//                if(oldRecord == newRecord)
//                {
//                    MessageBox.Show("Customer is not under the list");
//                }

//                cnn.Close();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Can not open connection ! " + ex.Message.ToString());
//            }
//        }
//    }
//}


//        OleDbCommand command = new OleDbCommand("SELECT  XSell.FINAL_ID,XSell.CARD_NUMBER,XSell.CIS_SEGMENT ,XSell.NAME_FULL FROM `C:\\Users\\Yusri\\Desktop\\BTCX`.XSell XSell WHERE(XSell.NAME_FULL LIKE '%" + name + "%') ", connection);
//        connection.Open();
//        OleDbDataReader reader = command.ExecuteReader();

//        while (reader.Read())
//        {

//            //MessageBox.Show(reader["CUSTOMER"].ToString());
//            label1.Text = reader["FINAL_ID"].ToString();
//            label2.Text = reader["CARD_NUMBER"].ToString();
//            label3.Text = reader["CIS_SEGMENT"].ToString();
//            label4.Text = reader["NAME_FULL"].ToString();
//        }
//        reader.Close();