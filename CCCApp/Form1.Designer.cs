namespace CCCApp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSurvey = new System.Windows.Forms.Button();
            this.btnSystemLink = new System.Windows.Forms.Button();
            this.btnErr = new System.Windows.Forms.Button();
            this.btnSRGuide = new System.Windows.Forms.Button();
            this.btnBranchCodes = new System.Windows.Forms.Button();
            this.btnCalculator = new System.Windows.Forms.Button();
            this.btnCrossSell = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.crosssell1 = new CCCApp.crosssell();
            this.errorCodes1 = new CCCApp.errorCodes();
            this.manualAdd1 = new CCCApp.manualAdd();
            this.branchcodes1 = new CCCApp.branchcodes();
            this.calculator1 = new CCCApp.calculator();
            this.dashboard1 = new CCCApp.dashboard();
            this.systemLink1 = new CCCApp.systemLink();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.survey1 = new CCCApp.survey();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.panel1.Controls.Add(this.btnSurvey);
            this.panel1.Controls.Add(this.btnSystemLink);
            this.panel1.Controls.Add(this.btnErr);
            this.panel1.Controls.Add(this.btnSRGuide);
            this.panel1.Controls.Add(this.btnBranchCodes);
            this.panel1.Controls.Add(this.btnCalculator);
            this.panel1.Controls.Add(this.btnCrossSell);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 540);
            this.panel1.TabIndex = 0;
            // 
            // btnSurvey
            // 
            this.btnSurvey.FlatAppearance.BorderSize = 0;
            this.btnSurvey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSurvey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSurvey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSurvey.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSurvey.ForeColor = System.Drawing.Color.White;
            this.btnSurvey.Image = global::CCCApp.Properties.Resources.survey_icon_20;
            this.btnSurvey.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSurvey.Location = new System.Drawing.Point(0, 443);
            this.btnSurvey.Name = "btnSurvey";
            this.btnSurvey.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnSurvey.Size = new System.Drawing.Size(200, 45);
            this.btnSurvey.TabIndex = 18;
            this.btnSurvey.Text = "   Survey";
            this.btnSurvey.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSurvey.UseVisualStyleBackColor = true;
            this.btnSurvey.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Menu_Clicked);
            this.btnSurvey.MouseEnter += new System.EventHandler(this.menuHover);
            this.btnSurvey.MouseLeave += new System.EventHandler(this.menuleave);
            // 
            // btnSystemLink
            // 
            this.btnSystemLink.FlatAppearance.BorderSize = 0;
            this.btnSystemLink.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSystemLink.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSystemLink.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSystemLink.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSystemLink.ForeColor = System.Drawing.Color.White;
            this.btnSystemLink.Image = global::CCCApp.Properties.Resources.link_3_20;
            this.btnSystemLink.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSystemLink.Location = new System.Drawing.Point(0, 392);
            this.btnSystemLink.Name = "btnSystemLink";
            this.btnSystemLink.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnSystemLink.Size = new System.Drawing.Size(200, 45);
            this.btnSystemLink.TabIndex = 17;
            this.btnSystemLink.Text = "   System Links";
            this.btnSystemLink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSystemLink.UseVisualStyleBackColor = true;
            this.btnSystemLink.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Menu_Clicked);
            this.btnSystemLink.MouseEnter += new System.EventHandler(this.menuHover);
            this.btnSystemLink.MouseLeave += new System.EventHandler(this.menuleave);
            // 
            // btnErr
            // 
            this.btnErr.FlatAppearance.BorderSize = 0;
            this.btnErr.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnErr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnErr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErr.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnErr.ForeColor = System.Drawing.Color.White;
            this.btnErr.Image = global::CCCApp.Properties.Resources.error_2_20_error;
            this.btnErr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnErr.Location = new System.Drawing.Point(0, 341);
            this.btnErr.Name = "btnErr";
            this.btnErr.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnErr.Size = new System.Drawing.Size(200, 45);
            this.btnErr.TabIndex = 15;
            this.btnErr.Text = "   Error Codes";
            this.btnErr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnErr.UseVisualStyleBackColor = true;
            this.btnErr.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Menu_Clicked);
            this.btnErr.MouseEnter += new System.EventHandler(this.menuHover);
            this.btnErr.MouseLeave += new System.EventHandler(this.menuleave);
            // 
            // btnSRGuide
            // 
            this.btnSRGuide.FlatAppearance.BorderSize = 0;
            this.btnSRGuide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnSRGuide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSRGuide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSRGuide.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSRGuide.ForeColor = System.Drawing.Color.White;
            this.btnSRGuide.Image = global::CCCApp.Properties.Resources.view_details_20_blue;
            this.btnSRGuide.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSRGuide.Location = new System.Drawing.Point(0, 290);
            this.btnSRGuide.Name = "btnSRGuide";
            this.btnSRGuide.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnSRGuide.Size = new System.Drawing.Size(200, 45);
            this.btnSRGuide.TabIndex = 14;
            this.btnSRGuide.Text = "   Manual Add On";
            this.btnSRGuide.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSRGuide.UseVisualStyleBackColor = true;
            this.btnSRGuide.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Menu_Clicked);
            this.btnSRGuide.MouseEnter += new System.EventHandler(this.menuHover);
            this.btnSRGuide.MouseLeave += new System.EventHandler(this.menuleave);
            // 
            // btnBranchCodes
            // 
            this.btnBranchCodes.FlatAppearance.BorderSize = 0;
            this.btnBranchCodes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnBranchCodes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnBranchCodes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBranchCodes.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBranchCodes.ForeColor = System.Drawing.Color.White;
            this.btnBranchCodes.Image = global::CCCApp.Properties.Resources.bank_4_20_blue;
            this.btnBranchCodes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBranchCodes.Location = new System.Drawing.Point(0, 239);
            this.btnBranchCodes.Name = "btnBranchCodes";
            this.btnBranchCodes.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnBranchCodes.Size = new System.Drawing.Size(200, 45);
            this.btnBranchCodes.TabIndex = 13;
            this.btnBranchCodes.Text = "   Branch Codes";
            this.btnBranchCodes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBranchCodes.UseVisualStyleBackColor = true;
            this.btnBranchCodes.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Menu_Clicked);
            this.btnBranchCodes.MouseEnter += new System.EventHandler(this.menuHover);
            this.btnBranchCodes.MouseLeave += new System.EventHandler(this.menuleave);
            // 
            // btnCalculator
            // 
            this.btnCalculator.FlatAppearance.BorderSize = 0;
            this.btnCalculator.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnCalculator.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCalculator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalculator.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalculator.ForeColor = System.Drawing.Color.White;
            this.btnCalculator.Image = global::CCCApp.Properties.Resources.calculator_5_20_blue;
            this.btnCalculator.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalculator.Location = new System.Drawing.Point(0, 188);
            this.btnCalculator.Name = "btnCalculator";
            this.btnCalculator.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnCalculator.Size = new System.Drawing.Size(200, 45);
            this.btnCalculator.TabIndex = 12;
            this.btnCalculator.Text = "   Calculator";
            this.btnCalculator.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCalculator.UseVisualStyleBackColor = true;
            this.btnCalculator.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Menu_Clicked);
            this.btnCalculator.MouseEnter += new System.EventHandler(this.menuHover);
            this.btnCalculator.MouseLeave += new System.EventHandler(this.menuleave);
            // 
            // btnCrossSell
            // 
            this.btnCrossSell.FlatAppearance.BorderSize = 0;
            this.btnCrossSell.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnCrossSell.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnCrossSell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrossSell.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrossSell.ForeColor = System.Drawing.Color.White;
            this.btnCrossSell.Image = global::CCCApp.Properties.Resources.chat_4_20_blue;
            this.btnCrossSell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCrossSell.Location = new System.Drawing.Point(0, 137);
            this.btnCrossSell.Name = "btnCrossSell";
            this.btnCrossSell.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnCrossSell.Size = new System.Drawing.Size(200, 45);
            this.btnCrossSell.TabIndex = 11;
            this.btnCrossSell.Text = "   Cross Sell";
            this.btnCrossSell.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCrossSell.UseVisualStyleBackColor = true;
            this.btnCrossSell.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Menu_Clicked);
            this.btnCrossSell.MouseEnter += new System.EventHandler(this.menuHover);
            this.btnCrossSell.MouseLeave += new System.EventHandler(this.menuleave);
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Silver;
            this.btnDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Image = global::CCCApp.Properties.Resources.trophy_2_20;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 86);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(200, 45);
            this.btnDashboard.TabIndex = 10;
            this.btnDashboard.Text = "   Leaderboard";
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = true;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            this.btnDashboard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Menu_Clicked);
            this.btnDashboard.MouseEnter += new System.EventHandler(this.menuHover);
            this.btnDashboard.MouseLeave += new System.EventHandler(this.menuleave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(112, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Centre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(112, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Care / Call";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(112, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::CCCApp.Properties.Resources.RHB_Bank_New_1;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(25, 26);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(86, 35);
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label4.Location = new System.Drawing.Point(211, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 21);
            this.label4.TabIndex = 19;
            this.label4.Text = "TOGETHER WE PROGRESS";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "I\'m here if you want me back!";
            this.notifyIcon1.BalloonTipTitle = ".....";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "CCC App";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Silver;
            this.pictureBox4.Location = new System.Drawing.Point(200, 535);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(740, 10);
            this.pictureBox4.TabIndex = 26;
            this.pictureBox4.TabStop = false;
            // 
            // button2
            // 
            this.button2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button2.BackgroundImage = global::CCCApp.Properties.Resources.settings_24_xl;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(865, 12);
            this.button2.Name = "button2";
            this.button2.Padding = new System.Windows.Forms.Padding(5);
            this.button2.Size = new System.Drawing.Size(20, 20);
            this.button2.TabIndex = 17;
            this.button2.Text = "   ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.MouseEnter += new System.EventHandler(this.enlarge);
            this.button2.MouseLeave += new System.EventHandler(this.enlarge);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackgroundImage = global::CCCApp.Properties.Resources.power_2_xl;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(908, 12);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(5);
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 15;
            this.button1.Text = "   ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseEnter += new System.EventHandler(this.enlarge);
            this.button1.MouseLeave += new System.EventHandler(this.enlarge);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Silver;
            this.pictureBox1.Location = new System.Drawing.Point(194, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(10, 541);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBox2.Location = new System.Drawing.Point(-4, 43);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(940, 3);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(939, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2, 543);
            this.panel2.TabIndex = 28;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Location = new System.Drawing.Point(204, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 2);
            this.panel3.TabIndex = 29;
            // 
            // crosssell1
            // 
            this.crosssell1.BackColor = System.Drawing.Color.White;
            this.crosssell1.Location = new System.Drawing.Point(206, 47);
            this.crosssell1.Name = "crosssell1";
            this.crosssell1.Size = new System.Drawing.Size(733, 496);
            this.crosssell1.TabIndex = 20;
            this.crosssell1.Visible = false;
            // 
            // errorCodes1
            // 
            this.errorCodes1.BackColor = System.Drawing.Color.White;
            this.errorCodes1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.errorCodes1.Location = new System.Drawing.Point(206, 47);
            this.errorCodes1.Name = "errorCodes1";
            this.errorCodes1.Size = new System.Drawing.Size(733, 481);
            this.errorCodes1.TabIndex = 27;
            // 
            // manualAdd1
            // 
            this.manualAdd1.BackColor = System.Drawing.Color.White;
            this.manualAdd1.Location = new System.Drawing.Point(206, 47);
            this.manualAdd1.Name = "manualAdd1";
            this.manualAdd1.Size = new System.Drawing.Size(733, 493);
            this.manualAdd1.TabIndex = 25;
            this.manualAdd1.Visible = false;
            // 
            // branchcodes1
            // 
            this.branchcodes1.BackColor = System.Drawing.Color.White;
            this.branchcodes1.Location = new System.Drawing.Point(206, 47);
            this.branchcodes1.Name = "branchcodes1";
            this.branchcodes1.Size = new System.Drawing.Size(733, 496);
            this.branchcodes1.TabIndex = 23;
            this.branchcodes1.Visible = false;
            // 
            // calculator1
            // 
            this.calculator1.BackColor = System.Drawing.Color.White;
            this.calculator1.Location = new System.Drawing.Point(207, 44);
            this.calculator1.Name = "calculator1";
            this.calculator1.Size = new System.Drawing.Size(733, 496);
            this.calculator1.TabIndex = 22;
            this.calculator1.Visible = false;
            // 
            // dashboard1
            // 
            this.dashboard1.BackColor = System.Drawing.Color.White;
            this.dashboard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.dashboard1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboard1.Location = new System.Drawing.Point(206, 47);
            this.dashboard1.Name = "dashboard1";
            this.dashboard1.Size = new System.Drawing.Size(733, 496);
            this.dashboard1.TabIndex = 21;
            this.dashboard1.Visible = false;
            // 
            // systemLink1
            // 
            this.systemLink1.BackColor = System.Drawing.Color.White;
            this.systemLink1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("systemLink1.BackgroundImage")));
            this.systemLink1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.systemLink1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.systemLink1.Location = new System.Drawing.Point(203, 44);
            this.systemLink1.Name = "systemLink1";
            this.systemLink1.Size = new System.Drawing.Size(736, 496);
            this.systemLink1.TabIndex = 30;
            this.systemLink1.Visible = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // survey1
            // 
            this.survey1.BackColor = System.Drawing.Color.White;
            this.survey1.Location = new System.Drawing.Point(207, 47);
            this.survey1.Name = "survey1";
            this.survey1.Size = new System.Drawing.Size(729, 482);
            this.survey1.TabIndex = 31;
            this.survey1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(940, 540);
            this.Controls.Add(this.survey1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.crosssell1);
            this.Controls.Add(this.errorCodes1);
            this.Controls.Add(this.manualAdd1);
            this.Controls.Add(this.branchcodes1);
            this.Controls.Add(this.calculator1);
            this.Controls.Add(this.dashboard1);
            this.Controls.Add(this.systemLink1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CCCApp";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_Resize);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button btnCalculator;
        private System.Windows.Forms.Button btnCrossSell;
        private System.Windows.Forms.Button btnSRGuide;
        private System.Windows.Forms.Button btnBranchCodes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private crosssell crosssell1;
        private dashboard dashboard1;
        private calculator calculator1;
        private branchcodes branchcodes1;
        private manualAdd manualAdd1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Button btnErr;
        private errorCodes errorCodes1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSystemLink;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private systemLink systemLink1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button btnSurvey;
        private survey survey1;
    }
}

