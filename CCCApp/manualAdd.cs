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
using System.Globalization;
using Outlook = Microsoft.Office.Interop.Outlook;



namespace CCCApp
{
    public partial class manualAdd : UserControl
    {
        private string aht;
        private string discount;
        private string inbound;
        private string status;
        public string notf;
        public string remarks;
        int x = 0;
        string date2;
        int date3;
        int date4;
        int intStaffID;
        string strStaffID;
        string[] arr;
        AutoCompleteStringCollection list;
        bool check = true;
        bool isCSA;
        string MMM;
        string ConnString;
        OleDbCommand command;
        string subject, mailTos, mailReason;
        string apo = "'";

        private void CreateMailItem(object sender, EventArgs e)
        {
            //MessageBox.Show(name);
            Button btn = sender as Button;

            if (btn.Text == "Approved" || btn.Text == "Declined")
            {
                subject = "Your Manual Add on has been " + btn.Text + "";
                mailTos = txtNameList.Text;
                mailReason = txtReason.Text;

            }
            else
            {
                subject = "Manual Add On Request";
                mailTos = "CCC Team Manager";
                mailReason = remarks;
            }


            string body = "Name : " + txtName.Text +
            Environment.NewLine + "<br />  From: \n" + fTime +
            Environment.NewLine + "<br /> To: " + tTime +
            Environment.NewLine + "<br />  Login Hour: " + loginHours +
            Environment.NewLine + "<br />  Not Ready: " + notReady +
            Environment.NewLine + "<br /> Discounted: " + aht + inbound + discount +
            Environment.NewLine + "<br />  Remarks: " + mailReason +
            Environment.NewLine + "<br />  Date: " + dates +
            Environment.NewLine +
            Environment.NewLine + "<br /> <br />  <a href=\'\\\\maanetapp1\\Consumer Product\\CCCKL\\Malaysia Operations\\For Internal Use Only\\(BTCX FORM)\\CCCApp.lnk'> Open the CCCApp for more details</a>";

            Outlook.Application app = new Outlook.Application();
            Outlook.MailItem mailItem = app.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Subject = subject;
            mailItem.To = mailTos;
            mailItem.HTMLBody = body;
            //mailItem.Attachments.Add(logPath);//logPath is a string holding path to the log.txt file
            //mailItem.Importance = Outlook.OlImportance.olImportanceHigh;
            mailItem.Send();


        }

        private void manualAdd_Load(object sender, EventArgs e)
        {

            list = txtName.AutoCompleteCustomSource;
            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtName.AutoCompleteMode = AutoCompleteMode.Suggest;


            if (Environment.UserName.ToString() == "Yusri")
            {
                strStaffID = "19333";
                intStaffID = 19333;
            }
            else
            {
                intStaffID = Convert.ToInt32(Environment.UserName);
                strStaffID = Environment.UserName.ToString();
            }

            if (Environment.UserName.ToString() != "Yusri")
            {
                ConnString = "\\\\maanetapp1\\Consumer Product\\CCCKL\\Malaysia Operations\\For Internal Use Only\\MIS Unit\\Yusri's File\\BTCX\\";
            }
            else
            {
                ConnString = "";
            }



            lblStaffID.Text = Environment.UserName.ToString();
            lblStaffID.Text = strStaffID;
            txtName.Text = strStaffID;


            try
            {
                string staffID = agentList(intStaffID);
                txtName.Text = staffID;

                if (txtName.Text != string.Empty)
                {
                    isCSA = true;
                    btnRemove.BackColor = Color.FromArgb(0, 174, 219);

                }
                else
                {
                    isCSA = false;
                    cbPending.Checked = true;
                    cbApproved.Checked = true;
                    cbDeclined.Checked = true;
                    cbMIS.Checked = true;

                    btnRemove.BackColor = Color.Red;
                    btnApprove.Visible = true;
                    btnDecline.Visible = true;
                    cbDeclined.Visible = true;
                    cbApproved.Visible = true;
                    cbPending.Visible = true;
                }

            }
            catch (Exception)
            {

                txtName.Text = lblStaffID.Text;
            }

        }

        String[] GetList(string s)
        {
            string connstr = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + ConnString + "AgentList.mdb";
            OleDbConnection conn = new OleDbConnection(connstr);

            string cmd = "Select WFM FROM  " + MMM + "";
            OleDbDataAdapter da = new OleDbDataAdapter(cmd, conn);
            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds);
            }
            catch (Exception)
            {


            }


            int count = ds.Tables[0].Rows.Count;

            arr = new string[count];

            try
            {
                int check = int.Parse(s);
                for (int i = 0; i < count; i++)
                {
                    arr[i] = ds.Tables[0].Rows[i]["Staff ID"].ToString();
                }
            }
            catch
            {
                for (int i = 0; i < count; i++)
                {
                    arr[i] = ds.Tables[0].Rows[i]["WFM"].ToString();
                }
            }
            return arr;

        }

        private void txtName_textChanged(object sender, EventArgs e)
        {
            if (GetList(txtName.Text).Length > 0)
            {
                list.Clear();
                list.AddRange(arr);
            }
            txtName.AutoCompleteCustomSource = list;
        }

        private void txtName_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if ((e.KeyCode == Keys.Up) || (e.KeyCode == Keys.Down))
                check = false;
            else
                check = true;
        }

        bool isMIS;
        int intStaff;
        string strStaff;

        public manualAdd()
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


            try
            {
                MMM = DateTime.Now.ToString("MMM").Replace('-', '/');
                //strStaffID = agentList(intStaffID);

            }
            catch (Exception)
            {
                MMM = DateTime.Now.AddMonths(-1).ToString("MMM").Replace('-', '/');
            }



            try
            {
                intStaff = Convert.ToInt32(Environment.UserName);

            }
            catch (Exception)
            {
                strStaff = Environment.UserName.ToString();
            }

            if (intStaff == 179264 || intStaff == 179494 || intStaff == 183813 || strStaff == "Yusri")
            {
                isMIS = true;
                btnAdjust.Visible = true;
                cbMIS.Visible = true;
            }



        }

        OleDbDataReader reader;

        void switchTime(object sender, EventArgs e)
        {
            TextBox tx = sender as TextBox;

            if (tx.Text == "AM")
            {
                tx.Text = "PM";
            }
            else
            {
                tx.Text = "AM";
            }
        }
        string StatusManual, StatusManual1, StatusManual2;
        int MISManual;

        private void Check(object sender, EventArgs e)
        {

            OleDbCommand command;
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + ConnString + "AddOn.mdb;"))
            {


                try
                {

                    DateTime now = DateTime.Now;
                    date2 = now.Month.ToString();
                    date3 = Convert.ToInt32(date2);
                    date4 = date3 - 1;

                    // Staff = Environment.UserName.ToString();
                    // string Staff = "403066";
                    //int idstaff = Convert.ToInt32(Environment.UserName);

                    connection.Open();



                    try
                    {
                        command = new OleDbCommand("SELECT * FROM AddOn WHERE `Staff ID` = '" + strStaffID + "' AND ( `Months` = " + date3 + " OR `Months` = " + date4 + ") ORDER BY Date1 DESC", connection);

                    }
                    catch (Exception)
                    {
                        //command = new OleDbCommand("SELECT * FROM AddOn ", connection);
                        command = new OleDbCommand("SELECT * FROM AddOn WHERE `Staff ID` = '" + strStaffID + "' AND `Months` = " + date3 + " OR `Months` = " + date4 + " ORDER BY Date1 DESC", connection);

                    }

                    if (isCSA == false)
                    {

                        if (cbPending.Checked)
                        {
                            StatusManual = "Pending";

                        }
                        if (cbApproved.Checked)
                        {
                            StatusManual1 = "Approved";
                        }
                        if (cbDeclined.Checked)
                        {
                            StatusManual2 = "Declined";
                        }

                        if (cbMIS.Checked)
                        {
                            MISManual = 0;
                        }

                        command = new OleDbCommand("SELECT * FROM AddOn WHERE (`Months` = " + date3 + " OR `Months` = " + date4 + ") AND ( `Status` = '" + StatusManual + "' OR `Status` = '" + StatusManual1 + "' OR `Status` = '" + StatusManual2 + "') AND (`MIS` = " + MISManual + ") ORDER BY Date1 DESC", connection);

                    }


                    reader = command.ExecuteReader();


                    listViewS.Items.Clear();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["Date1"].ToString());
                        item.SubItems.Add(reader["Status"].ToString());
                        item.SubItems.Add(reader["From"].ToString());
                        item.SubItems.Add(reader["To"].ToString());
                        item.SubItems.Add(reader["Agent Name"].ToString());
                        item.SubItems.Add(reader["Staff ID"].ToString());
                        item.SubItems.Add(reader["Login Hour"].ToString());
                        item.SubItems.Add(reader["Not Ready"].ToString());
                        item.SubItems.Add(reader["AHT"].ToString());
                        item.SubItems.Add(reader["DC"].ToString());
                        item.SubItems.Add(reader["Inbound"].ToString());
                        item.SubItems.Add(reader["Reason / Remarks"].ToString());
                        item.SubItems.Add(reader["Approved By"].ToString());
                        item.SubItems.Add(reader["ID"].ToString());
                        item.SubItems.Add(reader["MIS"].ToString());

                        listViewS.Items.Add(item);



                    }


                    listViewS.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    listViewS.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //MessageBox.Show("Error" + ex.Message);
                }

                connection.Close();


                StatusManual = string.Empty;
                StatusManual1 = string.Empty;
                StatusManual2 = string.Empty;
                MISManual = 1;


            }
        }
        int loginHours;
        int notReady;
        string fTime;
        string tTime;
        string updatedBy;
        string dates;
        string datePicker;
        int countManualAddItem;

        private void Submit(object sender, EventArgs e)
        {


            if (txtLoginHours.Text != "")
            {
                countManualAddItem = countManualAddItem + 1;
            }

            if (txtNotReady.Text != "")
            {
                countManualAddItem = countManualAddItem + 1;
            }

            if (cbAHT.Checked)
            {
                countManualAddItem = countManualAddItem + 1;
            }

            if (cbDiscount.Checked)
            {
                countManualAddItem = countManualAddItem + 1;
            }

            if (cbInbound.Checked)
            {
                countManualAddItem = countManualAddItem + 1;
            }

            if (countManualAddItem > 1)
            {


                MessageBox.Show("Please select only one item at particular request, you may re-submit should you have more!");
                countManualAddItem = 0;
                txtNotReady.Text = "";
                txtLoginHours.Text = "";
                cbInbound.Checked = false;
                cbDiscount.Checked = false;
                cbAHT.Checked = false;
                return;
            }


            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + ConnString + "AddOn.mdb;"))
            {
                OleDbCommand command;
                try
                {

                    DateTime now = DateTime.Now;


                    date2 = now.Month.ToString();
                    date3 = Convert.ToInt32(date2);
                    date4 = Convert.ToInt32(dateTimePicker1.Value.Month);
                    DateTime nnow = DateTime.Now;
                    dates = Convert.ToString(dateTimePicker1.Value);
                    datePicker = dateTimePicker1.Value.ToString("dd/MM/yyyy");


                    string staffID = strStaffID;

                    if (isCSA == false)
                    {
                        staffID = agentListWFM(txtName.Text);
                        status = "Approved";
                        updatedBy = Environment.UserName;
                    }
                    else
                    {
                        if (agentListWFM(txtName.Text) == staffID)
                        {
                            status = "Pending";
                            updatedBy = "";
                        }
                        else
                        {
                            goto here;
                        }


                    }

                    string newDate = dateTimePicker1.Value.ToString("dd/MM/yyyy");
                    //DateTime date1 = Convert.ToDateTime(newDate);
                    //String dates = date1.Day + "/" + date1.Month + "/" + date1.Year;
                    //string fromTime = FromH.Text + "." + FromM.Text + " " + FAM.Text;
                    //string toTime = ToH.Text + "." + ToM.Text + " " + TAM.Text;

                    //DateTime lll = DateTime.Parse(fromTime, "hh:mm zzz");
                    fTime = FromH.Text + ":" + FromM.Text + " " + FAM.Text;
                    tTime = ToH.Text + ":" + ToM.Text + " " + TAM.Text;


                    //string date4 = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    //DateTime test = DateTime.ParseExact(fTime, "hh:mm tt", CultureInfo.InvariantCulture);


                    //MessageBox.Show(testdate);
                    string name = txtName.Text;

                    try
                    {
                        loginHours = Convert.ToInt32(txtLoginHours.Text);

                    }
                    catch (Exception)
                    {

                        loginHours = 0;
                    }


                    try
                    {
                        notReady = Convert.ToInt32(txtNotReady.Text);
                    }
                    catch (Exception)
                    {

                        notReady = 0;
                    }



                    if (cbAHT.Checked)
                    {
                        aht = "1";
                    }
                    else
                    {
                        aht = "0";
                    }

                    if (cbDiscount.Checked)
                    {
                        discount = "1";
                    }
                    else
                    {
                        discount = "0";
                    }

                    if (cbInbound.Checked)
                    {
                        inbound = "1";
                    }
                    else
                    {
                        inbound = "0";
                    }

                    if (cbCoaching.Checked)
                    {
                        remarks += "Coaching, ";
                    }
                    if (cbPCProb.Checked)
                    {
                        remarks += "PC Problems, ";
                    }
                    if (cbONYX.Checked)
                    {
                        remarks += "ONYX, ";
                    }
                    if (cbChangePC.Checked)
                    {
                        remarks += "Change PC, ";
                    }
                    if (cbBriefing.Checked)
                    {
                        remarks += "Briefing, ";
                    }
                    if (cbTraining.Checked)
                    {
                        remarks += "Training, ";
                    }

                    if (cbTransferCall.Checked)
                    {
                        remarks += "Transfer Call, ";
                    }

                    if (cbComplaint.Checked)
                    {
                        remarks += "Complaint, ";
                    }

                    if (cbRestartPC.Checked)
                    {
                        remarks += "Restart PC, ";
                    }


                    remarks += txtRemarks.Text.ToString();

                    // Staff = Environment.UserName.ToString();
                    // string Staff = "403066";




                    if (loginHours > 49 || notReady > 49)
                    {
                        inbound = "1";
                    }


                    connection.Open();


                    command = new OleDbCommand("INSERT INTO AddOn (`Date1`, `Date2`, `Staff ID`, `Agent Name`, `Not Ready`, `Login Hour`, `AHT`, `DC`, `Inbound`, `Reason / Remarks`, `Approved By`,`Status`, `From`, `To`,`Months`,`MIS`) VALUES" +
                                                               " ('" + dates + "', '" + datePicker + "' , '" + staffID + "','" + name.Replace("'", "''") + "'," + notReady + "," + loginHours + ",'" + aht + "','" + discount + "','" + inbound + "','" + remarks + "', '" + updatedBy + "' ,'" + status + "' ,'" + fTime + "' ,'" + tTime + "'," + date4 + ",0)", connection);



                    command.ExecuteNonQuery();
                    connection.Close();
                    // MessageBox.Show("Your manual add is successfully submitted!");

                    CreateMailItem(sender, e);

                    txtLoginHours.Text = "";
                    //txtName.Text = null;
                    txtNotReady.Text = "";
                    txtRemarks.Text = "";
                    remarks = "";
                    inbound = "";
                    aht = "";
                    discount = "";
                    notReady = 0;
                    loginHours = 0;
                    cbAHT.Checked = false;
                    cbDiscount.Checked = false;
                    cbInbound.Checked = false;
                    cbTransferCall.Checked = false;
                    cbONYX.Checked = false;
                    cbPCProb.Checked = false;
                    cbTransferCall.Checked = false;
                    cbBriefing.Checked = false;
                    cbChangePC.Checked = false;
                    cbOther.Checked = false;
                    cbCoaching.Checked = false;
                    cbRestartPC.Checked = false;
                    cbComplaint.Checked = false;
                    cbTraining.Checked = false;

                    Check(sender, e);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot save due to " + ex.Message.ToString());
                }
                here:
                connection.Close();

            }

        }



        public string agentList(int staffID)
        {
            //using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + ConnString + "Agent List.xls;Extended Properties=\"Excel 8.0;HDR=YES;;\""))
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + ConnString + "AgentList.mdb;"))

            {
                try
                {
                    DateTime now = DateTime.Now;
                    date2 = now.Month.ToString();
                    date3 = Convert.ToInt32(date2);

                    //int Staff = Convert.ToInt32(Environment.UserName);

                    //OleDbCommand command = new OleDbCommand("SELECT `" + MMM + "$`.WFM FROM `" + MMM + "$` `" + MMM + "$` WHERE(`" + MMM + "$`.`Staff ID`= " + staffID + ")   ", connection);
                    OleDbCommand command = new OleDbCommand("SELECT WFM, `Staff ID` FROM " + MMM + " WHERE(`Staff ID`= " + staffID + ")   ", connection);

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

        public string agentListWFM(string Name)
        {
            //using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + ConnString + "Agent List.xls;Extended Properties=\"Excel 8.0;HDR=YES;;\""))
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + ConnString + "AgentList.mdb;"))

            {
                try
                {
                    DateTime now = DateTime.Now;
                    date2 = now.Month.ToString();
                    date3 = Convert.ToInt32(date2);

                    OleDbCommand command = new OleDbCommand("SELECT WFM,`Staff ID` FROM `" + MMM + "` WHERE(WFM= '" + Name.Replace("'", "''") + "')", connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    //`Staff ID` = '" + Staff + "'
                    while (reader.Read())
                    {
                        if (reader["WFM"].ToString() != null)
                        {
                            return reader["Staff ID"].ToString();

                        }
                        else
                        {
                            return "Unable to locate Staff ID, Contact MIS";

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


        //private void checkManual_Click(object sender, EventArgs e)
        //{

        //    checkManualAdd();


        //    notf = "Your manual add record for this month!";
        //    timer1.Start();


        //}



        string query;

        private void deleteitems(object sender, EventArgs e)
        {


            //DateTime thisMonth = DateTime.Today.AddDays((DateTime.Today.Day - 1) * -1);

            // listViewM.Items.Clear();

            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + ConnString + "AddOn.mdb;"))
            {

                {
                    connection.Open();
                    foreach (var index in listViewS.SelectedItems)
                    {
                        // Modify this to get the 'cashier_id' from you listView at the specified row index...
                        // You should also consider using a prepared query...
                        //MessageBox.Show(index.ToString());
                        string id = listViewS.SelectedItems[0].SubItems[13].Text;
                        int dt = Convert.ToInt32(id);

                        if (isCSA == false)
                        {
                            DialogResult dialogResult = MessageBox.Show("Are you sure to remove the item, once deleted it cannot be retrieved!!!", "Deleting Manual Add", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                //do something
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                goto here;
                            }

                            StatusManual = "Pending";

                            StatusManual1 = "Approved";

                            StatusManual2 = "Declined";


                            query = "DELETE FROM `AddOn` WHERE ID= " + dt + " AND (Status = '" + StatusManual + "' OR Status ='" + StatusManual1 + "' OR Status = '" + StatusManual2 + "')";
                        }
                        else
                        {
                            query = "DELETE FROM `AddOn` WHERE ID= " + dt + " AND Status = 'Pending' ";
                        }


                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            // consider checking the return value here if the delete command was successful
                            command.ExecuteNonQuery();
                        }
                    }
                }
                here:
                connection.Close();
                Check(sender, e);

            }

        }


        int LH;
        int NRT;
        string AHT;
        string DC;
        string INB;

        public void addItemsInListview(object sender, EventArgs e)
        {
            foreach (var index in listViewS.SelectedItems)
            {

                LH = Convert.ToInt32(listViewS.SelectedItems[0].SubItems[6].Text);
                NRT = Convert.ToInt32(listViewS.SelectedItems[0].SubItems[7].Text);
                AHT = listViewS.SelectedItems[0].SubItems[8].Text;
                DC = listViewS.SelectedItems[0].SubItems[9].Text;
                INB = listViewS.SelectedItems[0].SubItems[10].Text;

                txtDate.Text = listViewS.SelectedItems[0].SubItems[0].Text;
                txtStatus.Text = listViewS.SelectedItems[0].SubItems[1].Text;
                txtStaffID.Text = listViewS.SelectedItems[0].SubItems[4].Text;
                txtNameList.Text = listViewS.SelectedItems[0].SubItems[5].Text;
                txtLH.Text = listViewS.SelectedItems[0].SubItems[6].Text;
                txtNRT.Text = listViewS.SelectedItems[0].SubItems[7].Text;
                txtAHT.Text = listViewS.SelectedItems[0].SubItems[8].Text;
                txtDC.Text = listViewS.SelectedItems[0].SubItems[9].Text;
                txtINB.Text = listViewS.SelectedItems[0].SubItems[10].Text;
                txtReason.Text = listViewS.SelectedItems[0].SubItems[11].Text;


            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value.ToString("dd") == DateTime.Now.Date.ToString("dd"))
            {
                dates = DateTime.Now.ToString();
            }
            else
            {
                dates = Convert.ToString(dateTimePicker1.Value);
            }


        }

        private void listViewS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        int dt;
        private void approve(object sender, EventArgs e)
        {


            //DateTime thisMonth = DateTime.Today.AddDays((DateTime.Today.Day - 1) * -1);

            // listViewM.Items.Clear();

            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + ConnString + "AddOn.mdb;"))
            {

                {
                    connection.Open();
                    foreach (var index in listViewS.SelectedItems)
                    {
                        // Modify this to get the 'cashier_id' from you listView at the specified row index...
                        // You should also consider using a prepared query...
                        //MessageBox.Show(index.ToString());
                        string id = listViewS.SelectedItems[0].SubItems[13].Text;



                        dt = Convert.ToInt32(id);
                        updatedBy = Environment.UserName;
                        string my_querry = "UPDATE AddOn SET Status ='Approved', `Approved By` = '" + updatedBy + "', `Login Hour` = " + Convert.ToInt32(txtLH.Text) + ", `Not Ready` = " + Convert.ToInt32(txtNRT.Text) + ", AHT = '" + txtAHT.Text + "', DC = '" + txtDC.Text + "', Inbound = '" + txtINB.Text + "', `Reason / Remarks` = '" + txtReason.Text + "' WHERE ID = " + dt + "";

                        // totalPoints = 0;
                        try
                        {
                            using (OleDbCommand command = new OleDbCommand(my_querry, connection))
                            {
                                // consider checking the return value here if the delete command was successful
                                command.ExecuteNonQuery();
                                CreateMailItem(sender, e);

                            }
                        }
                        catch (Exception)
                        {


                        }
                    }

                    connection.Close();
                    Check(sender, e);
                }

            }

        }

        private void decline(object sender, EventArgs e)
        {


            //DateTime thisMonth = DateTime.Today.AddDays((DateTime.Today.Day - 1) * -1);

            // listViewM.Items.Clear();

            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + ConnString + "AddOn.mdb;"))
            {

                {
                    connection.Open();
                    foreach (var index in listViewS.SelectedItems)
                    {
                        // Modify this to get the 'cashier_id' from you listView at the specified row index...
                        // You should also consider using a prepared query...
                        //MessageBox.Show(index.ToString());
                        string id = listViewS.SelectedItems[0].SubItems[13].Text;
                        dt = Convert.ToInt32(id);
                        updatedBy = Environment.UserName;
                        string my_querry = "UPDATE AddOn SET Status ='Declined', `Approved By` = '" + updatedBy + "', `Login Hour` = " + Convert.ToInt32(txtLH.Text) + ", `Not Ready` = " + Convert.ToInt32(txtNRT.Text) + ", AHT = '" + txtAHT.Text + "', DC = '" + txtDC.Text + "', Inbound = '" + txtINB.Text + "', `Reason / Remarks` = '" + txtReason.Text + "' WHERE ID = " + dt + "";

                        // totalPoints = 0;
                        try
                        {
                            using (OleDbCommand command = new OleDbCommand(my_querry, connection))
                            {
                                // consider checking the return value here if the delete command was successful
                                command.ExecuteNonQuery();
                                CreateMailItem(sender, e);
                            }
                        }
                        catch (Exception)
                        {


                        }
                    }

                    connection.Close();
                    Check(sender, e);
                }

            }

        }


        string dateAdjust = DateTime.Now.ToString("dd/MM/yyyy");

        private void adjust(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=" + ConnString + "AddOn.mdb;"))
            {

                {

                    connection.Open();

                    string my_querry = "UPDATE AddOn SET MIS = 1 WHERE Status = 'Approved' AND Date2 <>  '" + dateAdjust + "'";

                    try
                    {
                        using (command = new OleDbCommand(my_querry, connection))
                        {
                            command.ExecuteNonQuery();

                        }
                    }
                    catch (Exception)
                    {

                    }

                }

                connection.Close();
                Check(sender, e);
            }
        }


    }

}
