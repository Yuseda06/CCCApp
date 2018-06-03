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

        private void manualAdd_Load(object sender, EventArgs e)
        {

            list = txtName.AutoCompleteCustomSource;
            txtName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtName.AutoCompleteMode = AutoCompleteMode.Suggest;

            //intStaffID = Convert.ToInt32(Environment.UserName);
            //strStaffID = Environment.UserName.ToString();


            strStaffID = "195613";
            intStaffID = 195613;



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
            string connstr = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=Agent List.xls;Extended Properties=\"Excel 8.0; HDR = YES;\"";
            OleDbConnection conn = new OleDbConnection(connstr);
            string cmd = "Select `" + MMM + "$`.WFM FROM `" + MMM + "$` `" + MMM + "$`";
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

        public manualAdd()
        {

            InitializeComponent();

            try
            {
                MMM = DateTime.Now.ToString("MMM").Replace('-', '/');
                //strStaffID = agentList(intStaffID);
                
            }
            catch (Exception)
            {
                MMM = DateTime.Now.AddMonths(-1).ToString("MMM").Replace('-', '/');
            }

            //if (strStaffID == null)
            //{
            //    MMM = DateTime.Now.AddMonths(-1).ToString("MMM").Replace('-', '/');
            //}



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

        private void Check(object sender, EventArgs e)
        {
            
            OleDbCommand command;
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=AddOn.mdb;"))
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
                             StatusManual1  = "Approved";
                        }
                        if (cbDeclined.Checked)
                        {
                             StatusManual2 = "Declined";
                        }

                        command = new OleDbCommand("SELECT * FROM AddOn WHERE (`Months` = " + date3 + " OR `Months` = " + date4 + ") AND ( `Status` = '" + StatusManual + "' OR `Status` = '" + StatusManual1 + "' OR `Status` = '" + StatusManual2 + "') ORDER BY Date1 DESC", connection);

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

            }
        }
        int loginHours;
        int notReady;
        string fTime;
        string tTime;
        string updatedBy;

        private void Submit(object sender, EventArgs e)
        {


            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=AddOn.mdb;"))
            {
                OleDbCommand command;
                try
                {

                    DateTime now = DateTime.Now;
       

                    date2 = now.Month.ToString();
                    date3 = Convert.ToInt32(date2);
                    date4 = Convert.ToInt32(dateTimePicker1.Value.Month);
                    DateTime nnow = DateTime.Now;
                    string dates = Convert.ToString(dateTimePicker1.Value);

                    string staffID = strStaffID;

                    if (isCSA == false )
                    {
                        staffID = agentListWFM(txtName.Text);
                        status = "Approved";
                        updatedBy = Environment.UserName;
                    }
                    else
                    {
                        if(agentListWFM(txtName.Text) == staffID)
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
                    fTime =  FromH.Text + ":" + FromM.Text + " " + FAM.Text;
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

                    connection.Open();


                    command = new OleDbCommand("INSERT INTO AddOn (`Date1`, `Staff ID`, `Agent Name`, `Not Ready`, `Login Hour`, `AHT`, `DC`, `Inbound`, `Reason / Remarks`, `Approved By`,`Status`, `From`, `To`,`Months`,`MIS`) VALUES" +
                                                               " ('" + dates + "','" + staffID + "','" + name + "'," + notReady + "," + loginHours + ",'" + aht + "','" + discount + "','" + inbound + "','" + remarks + "', '" + updatedBy + "' ,'" + status + "' ,'" + fTime + "' ,'" + tTime + "'," + date4 + ",0)", connection);
 


                    command.ExecuteNonQuery();
                    connection.Close();
                    // MessageBox.Show("Your manual add is successfully submitted!");

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
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=Agent List.xls;Extended Properties=\"Excel 8.0;HDR=YES;\""))
            {
                try
                {
                    DateTime now = DateTime.Now;
                    date2 = now.Month.ToString();
                    date3 = Convert.ToInt32(date2);

                    //int Staff = Convert.ToInt32(Environment.UserName);

                    OleDbCommand command = new OleDbCommand("SELECT `" + MMM + "$`.WFM,`" + MMM + "$`.`Staff ID` FROM `" + MMM + "$` `" + MMM + "$` WHERE(`" + MMM + "$`.`Staff ID`= " + staffID + ")   ", connection);
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
            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=Agent List.xls;Extended Properties=\"Excel 8.0;HDR=YES;\""))
            {
                try
                {
                    DateTime now = DateTime.Now;
                    date2 = now.Month.ToString();
                    date3 = Convert.ToInt32(date2);

                    //int Staff = Convert.ToInt32(Environment.UserName);

                    OleDbCommand command = new OleDbCommand("SELECT `" + MMM + "$`.WFM,`" + MMM + "$`.`Staff ID` FROM `" + MMM + "$` `" + MMM + "$` WHERE(`" + MMM + "$`.WFM= '" + Name + "')   ", connection);
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


        OleDbCommand command;
        string query;

        private void deleteitems(object sender, EventArgs e)
        {


            //DateTime thisMonth = DateTime.Today.AddDays((DateTime.Today.Day - 1) * -1);

            // listViewM.Items.Clear();

            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=AddOn.mdb;"))
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
                            DialogResult dialogResult = MessageBox.Show("Are sure you want to delete the item, once deleted it cannot be retrieved!!!", "Deleting Manual Add", MessageBoxButtons.YesNo);
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
                           

                             query = "DELETE FROM `AddOn` WHERE ID= " + dt + " AND (Status = '"  + StatusManual + "' OR Status ='" + StatusManual1 + "' OR Status = '" + StatusManual2 + "')";
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
                txtNameList.Text= listViewS.SelectedItems[0].SubItems[5].Text;
                txtLH.Text = listViewS.SelectedItems[0].SubItems[6].Text;
                txtNRT.Text = listViewS.SelectedItems[0].SubItems[7].Text;
                txtAHT.Text= listViewS.SelectedItems[0].SubItems[8].Text;
                txtDC.Text= listViewS.SelectedItems[0].SubItems[9].Text;
                txtINB.Text= listViewS.SelectedItems[0].SubItems[10].Text;
                txtReason.Text = listViewS.SelectedItems[0].SubItems[11].Text;


            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
  
                dateTimePicker1.Value = DateTime.Now;
       
        }


        private void approve(object sender, EventArgs e)
        {


            //DateTime thisMonth = DateTime.Today.AddDays((DateTime.Today.Day - 1) * -1);

            // listViewM.Items.Clear();

            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=AddOn.mdb;"))
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
                        updatedBy = Environment.UserName;
                        string my_querry = "UPDATE AddOn SET Status ='Approved', `Approved By` = '" + updatedBy + "', `Login Hour` = " + Convert.ToInt32(txtLH.Text) + ", `Not Ready` = " + Convert.ToInt32(txtNRT.Text) + ", AHT = '" + txtAHT.Text + "', DC = '" + txtDC.Text + "', Inbound = '" + txtINB.Text + "', `Reason / Remarks` = '" + txtReason.Text + "' WHERE ID = " + dt + "";

                        // totalPoints = 0;
                        try
                        {
                            using (OleDbCommand command = new OleDbCommand(my_querry, connection))
                            {
                                // consider checking the return value here if the delete command was successful
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

        private void decline(object sender, EventArgs e)
        {


            //DateTime thisMonth = DateTime.Today.AddDays((DateTime.Today.Day - 1) * -1);

            // listViewM.Items.Clear();

            using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=AddOn.mdb;"))
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
                        updatedBy = Environment.UserName;
                        string my_querry = "UPDATE AddOn SET Status ='Declined', `Approved By` = '" + updatedBy + "', `Login Hour` = " + Convert.ToInt32(txtLH.Text) + ", `Not Ready` = " + Convert.ToInt32(txtNRT.Text) + ", AHT = '" + txtAHT.Text + "', DC = '" + txtDC.Text + "', Inbound = '" + txtINB.Text + "', `Reason / Remarks` = '" + txtReason.Text + "' WHERE ID = " + dt + "";

                        // totalPoints = 0;
                        try
                        {
                            using (OleDbCommand command = new OleDbCommand(my_querry, connection))
                            {
                                // consider checking the return value here if the delete command was successful
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

        //checkManualAdd();
        //MessageBox.Show("You will see the new data with your next restart of the application", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);


        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    Button t = Application.OpenForms["MainForm"].Controls["btnNotification"] as Button;
        //    //notf = "Selected Item has just been removed!";


        //        if (t.Text == "")
        //        {
        //            t.Text = notf;
        //        }
        //        else
        //        {
        //            t.Text = "";
        //        }

        //}

        //private void txtRemarks_Click(object sender, EventArgs e)
        //{
        //    cbOther.Checked = true;
        //}


    }

}
