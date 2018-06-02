using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using Microsoft.Win32;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace CCCApp
{

    public partial class MainForm : Form
    {
        
        

        public MainForm()
        {
            InitializeComponent();

        }


     




        private void MainForm_Load(object sender, EventArgs e)
        {
            crosssell1.Visible = true;
            btnCrossSell.BackColor = Color.DeepSkyBlue;

            btnSystemLink.Image = Properties.Resources.link_3_20;
            btnDashboard.Image = Properties.Resources.trophy_2_20;
            btnCalculator.Image = Properties.Resources.calculator__5_xl;
            btnCrossSell.Image = Properties.Resources.chat_4_xl__1_;
            btnBranchCodes.Image = Properties.Resources.bank_4_xl;
            btnSRGuide.Image = Properties.Resources.view_details_xl;
            btnErr.Image = Properties.Resources.error_20;

            //       using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:\\Users\\Yusri\\Desktop\\BTCX.mdb;"))
            //{

            //    OleDbCommand command = new OleDbCommand("SELECT DISTINCT XSell.CUSTOMER FROM `C:\\Users\\Yusri\\Desktop\\BTCX`.XSell XSell WHERE(XSell.LEGAL_ID = '1234') ", connection);
            //    connection.Open();
            //    OleDbDataReader reader = command.ExecuteReader();

            //    while (reader.Read())
            //    {

            //        //MessageBox.Show(reader["CUSTOMER"].ToString());

            //    }
            //    reader.Close();
            //}
        }

        
         private void Menu_Clicked(object sender, MouseEventArgs e)
         {
            Button click = sender as Button;
            dashboard1.Visible = false;
            crosssell1.Visible = false;
            calculator1.Visible = false;
            branchcodes1.Visible = false;
            manualAdd1.Visible = false;
            errorCodes1.Visible = false;
            systemLink1.Visible = false;
            

            btnDashboard.BackColor = Color.FromArgb(0, 174, 219);
            btnCrossSell.BackColor = Color.FromArgb(0, 174, 219);
            btnCalculator.BackColor = Color.FromArgb(0, 174, 219);
            btnBranchCodes.BackColor = Color.FromArgb(0, 174, 219);
            btnSRGuide.BackColor = Color.FromArgb(0, 174, 219);
            btnErr.BackColor = Color.FromArgb(0, 174, 219);
            btnSystemLink.BackColor = Color.FromArgb(0, 174, 219);

            btnSystemLink.Image = Properties.Resources.link_3_20;
            btnDashboard.Image = Properties.Resources.trophy_2_20;
            btnCalculator.Image = Properties.Resources.calculator__5_xl;
            btnCrossSell.Image = Properties.Resources.chat_4_xl__1_;
            btnBranchCodes.Image = Properties.Resources.bank_4_xl;
            btnSRGuide.Image = Properties.Resources.view_details_xl;
            btnErr.Image = Properties.Resources.error_20;



            if (click==btnDashboard)
            {
                dashboard1.Visible = true;
                btnDashboard.BackColor = Color.DeepSkyBlue;
                btnDashboard.Image = Properties.Resources.trophy_2_20_blue;

            }
            else if(click == btnCrossSell)
            {
                crosssell1.Visible = true;
                btnCrossSell.BackColor = Color.DeepSkyBlue;
                btnCrossSell.Image = Properties.Resources.chat_4_20_blue;
            }
            else if (click == btnCalculator)
            {
                calculator1.Visible = true;
                btnCalculator.BackColor = Color.DeepSkyBlue;
                btnCalculator.Image = Properties.Resources.calculator_5_20_blue;
            }
            else if (click == btnBranchCodes)
            {
                branchcodes1.Visible = true;
                btnBranchCodes.BackColor = Color.DeepSkyBlue;
                btnBranchCodes.Image = Properties.Resources.bank_4_20_blue;
            }
            else if (click == btnSRGuide)
            {
                btnSRGuide.BackColor = Color.DeepSkyBlue;
                manualAdd1.Visible = true;
                btnSRGuide.Image = Properties.Resources.view_details_20_blue;
            }
            else if (click == btnErr)
            {
                btnErr.BackColor = Color.DeepSkyBlue;
                errorCodes1.Visible = true;
                btnErr.Image = Properties.Resources.error_2_20_error;
            }
            else if (click == btnSystemLink)
            {
                btnSystemLink.BackColor = Color.DeepSkyBlue;
                systemLink1.Visible = true;
                btnSystemLink.Image = Properties.Resources.link_3_20_blue;
            }

        }


       


        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
        Point lastPoint;
        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Environment.Exit(1);
            this.WindowState = FormWindowState.Minimized;
        }

        private void menuHover(object sender, EventArgs e)
        {
            Button hovered = sender as Button;

            hovered.BackgroundImage = Properties.Resources.onHover;
         
            hovered.Font = new Font("Century Gothic", 9);
            


        }

        private void menuleave(object sender, EventArgs e)
        {
            Button leave = sender as Button;

            leave.BackgroundImage = null;
            leave.Font = new Font("Century Gothic", 8);
            //leave.ForeColor = Color.White;

        }
     
        private void enlarge (object sender, EventArgs e)
        {
            Button n = sender as Button;

            if (n.Height.Equals(20))
            {
                n.Size = new Size(30, 30);
                
                n.Location = new Point(n.Location.X - 5, n.Location.Y - 5);

            } else if (n.Height.Equals(30))
            {
                n.Size = new Size(20, 20);
                n.Location = new Point(n.Location.X + 5, n.Location.Y + 5);
            }
            

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            
            notifyIcon1.Visible = false;

            
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
            }
        }

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    string url = @"S:\Malaysia Operations\For Internal Use Only\RHB Now\RHB Online Banking V3\Home.html";

    
        //}




    }
}
