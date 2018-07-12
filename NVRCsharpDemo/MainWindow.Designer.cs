namespace NVRCsharpDemo
{
    partial class MainWindow
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
            if (m_lPlayHandle >= 0)
            {
                CHCNetSDK.NET_DVR_StopPlayBack(m_lPlayHandle);
            }
            if (m_lDownHandle >= 0)
            {
                CHCNetSDK.NET_DVR_StopGetFile(m_lDownHandle);

            }
            if (m_lUserID >= 0)
            {
                CHCNetSDK.NET_DVR_Logout(m_lUserID);
            }
            if (m_bInitSDK == true)
            {
                CHCNetSDK.NET_DVR_Cleanup();
            }

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
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUserName = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.VideoPlayWnd = new System.Windows.Forms.PictureBox();
            this.listViewIPChannel = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelSound = new System.Windows.Forms.Label();
            this.btnSound = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.btnResume = new System.Windows.Forms.Button();
            this.labelReverse = new System.Windows.Forms.Label();
            this.btnReverse = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelPause = new System.Windows.Forms.Label();
            this.btnFrame = new System.Windows.Forms.Button();
            this.btnFast = new System.Windows.Forms.Button();
            this.btnSlow = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.btnBMP = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonStopRefresh = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.listViewFinish = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxAuthCode = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBoxTestLineNo = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.DownloadProgressBar2 = new System.Windows.Forms.ProgressBar();
            this.buttonFlash = new System.Windows.Forms.Button();
            this.checkBoxAutoRefresh = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePickerJcKssj = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerJcJssj = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listViewCar = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnStopDownload = new System.Windows.Forms.Button();
            this.btnDownloadName = new System.Windows.Forms.Button();
            this.btnDownloadTime = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.btnPlaybackTime = new System.Windows.Forms.Button();
            this.btnStopPlayback = new System.Windows.Forms.Button();
            this.btnPlaybackName = new System.Windows.Forms.Button();
            this.listViewFile = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearch = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.timerDownload = new System.Windows.Forms.Timer(this.components);
            this.PlaybackprogressBar = new System.Windows.Forms.ProgressBar();
            this.timerPlayback = new System.Windows.Forms.Timer(this.components);
            this.btn_Exit = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.DownloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBoxChB8 = new System.Windows.Forms.ComboBox();
            this.comboBoxChF8 = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.comboBoxChB7 = new System.Windows.Forms.ComboBox();
            this.comboBoxChF7 = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.comboBoxChB6 = new System.Windows.Forms.ComboBox();
            this.comboBoxChF6 = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.comboBoxChB5 = new System.Windows.Forms.ComboBox();
            this.comboBoxChF5 = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.comboBoxChB4 = new System.Windows.Forms.ComboBox();
            this.comboBoxChF4 = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.comboBoxChB3 = new System.Windows.Forms.ComboBox();
            this.comboBoxChF3 = new System.Windows.Forms.ComboBox();
            this.label29 = new System.Windows.Forms.Label();
            this.comboBoxChB2 = new System.Windows.Forms.ComboBox();
            this.comboBoxChF2 = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.comboBoxChB1 = new System.Windows.Forms.ComboBox();
            this.comboBoxChF1 = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.timerDownload2 = new System.Windows.Forms.Timer(this.components);
            this.buttonSyncTime = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayWnd)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(599, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 12);
            this.label8.TabIndex = 27;
            this.label8.Text = "密码";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(406, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 26;
            this.label7.Text = "用户名";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 25;
            this.label6.Text = "设备端口";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 24;
            this.label5.Text = "设备IP";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxPassword.Location = new System.Drawing.Point(671, 21);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(112, 21);
            this.textBoxPassword.TabIndex = 23;
            this.textBoxPassword.Text = "12345";
            // 
            // textBoxUserName
            // 
            this.textBoxUserName.Location = new System.Drawing.Point(472, 21);
            this.textBoxUserName.Name = "textBoxUserName";
            this.textBoxUserName.Size = new System.Drawing.Size(114, 21);
            this.textBoxUserName.TabIndex = 22;
            this.textBoxUserName.Text = "admin";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(293, 19);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(112, 21);
            this.textBoxPort.TabIndex = 21;
            this.textBoxPort.Text = "8000";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(87, 19);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(114, 21);
            this.textBoxIP.TabIndex = 20;
            this.textBoxIP.Text = "172.6.22.18";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(789, 14);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(102, 31);
            this.btnLogin.TabIndex = 19;
            this.btnLogin.Text = "登录";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Device IP";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(406, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "User Name";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(597, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(219, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Device Port";
            // 
            // VideoPlayWnd
            // 
            this.VideoPlayWnd.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.VideoPlayWnd.Location = new System.Drawing.Point(211, 57);
            this.VideoPlayWnd.Name = "VideoPlayWnd";
            this.VideoPlayWnd.Size = new System.Drawing.Size(458, 320);
            this.VideoPlayWnd.TabIndex = 30;
            this.VideoPlayWnd.TabStop = false;
            // 
            // listViewIPChannel
            // 
            this.listViewIPChannel.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.listViewIPChannel.FullRowSelect = true;
            this.listViewIPChannel.GridLines = true;
            this.listViewIPChannel.Location = new System.Drawing.Point(4, 57);
            this.listViewIPChannel.MultiSelect = false;
            this.listViewIPChannel.Name = "listViewIPChannel";
            this.listViewIPChannel.Size = new System.Drawing.Size(197, 287);
            this.listViewIPChannel.TabIndex = 32;
            this.listViewIPChannel.UseCompatibleStateImageBehavior = false;
            this.listViewIPChannel.View = System.Windows.Forms.View.Details;
            this.listViewIPChannel.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewIPChannel_ItemSelectionChanged);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "通道 Channel";
            this.ColumnHeader1.Width = 90;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "状态 Status";
            this.ColumnHeader2.Width = 90;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelSound);
            this.groupBox2.Controls.Add(this.btnSound);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.btnResume);
            this.groupBox2.Controls.Add(this.labelReverse);
            this.groupBox2.Controls.Add(this.btnReverse);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.labelPause);
            this.groupBox2.Controls.Add(this.btnFrame);
            this.groupBox2.Controls.Add(this.btnFast);
            this.groupBox2.Controls.Add(this.btnSlow);
            this.groupBox2.Controls.Add(this.btnPause);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.btnBMP);
            this.groupBox2.Location = new System.Drawing.Point(211, 384);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 69);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            // 
            // labelSound
            // 
            this.labelSound.AutoSize = true;
            this.labelSound.Location = new System.Drawing.Point(336, 49);
            this.labelSound.Name = "labelSound";
            this.labelSound.Size = new System.Drawing.Size(53, 12);
            this.labelSound.TabIndex = 52;
            this.labelSound.Text = "打开声音";
            // 
            // btnSound
            // 
            this.btnSound.Location = new System.Drawing.Point(330, 18);
            this.btnSound.Name = "btnSound";
            this.btnSound.Size = new System.Drawing.Size(66, 23);
            this.btnSound.TabIndex = 51;
            this.btnSound.Text = "Sound";
            this.btnSound.UseVisualStyleBackColor = true;
            this.btnSound.Click += new System.EventHandler(this.btnSound_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(179, 50);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(77, 12);
            this.label25.TabIndex = 50;
            this.label25.Text = "恢复正常速度";
            // 
            // btnResume
            // 
            this.btnResume.Location = new System.Drawing.Point(172, 18);
            this.btnResume.Name = "btnResume";
            this.btnResume.Size = new System.Drawing.Size(85, 23);
            this.btnResume.TabIndex = 49;
            this.btnResume.Text = "Normal Speed";
            this.btnResume.UseVisualStyleBackColor = true;
            this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // labelReverse
            // 
            this.labelReverse.AutoSize = true;
            this.labelReverse.Location = new System.Drawing.Point(263, 49);
            this.labelReverse.Name = "labelReverse";
            this.labelReverse.Size = new System.Drawing.Size(65, 12);
            this.labelReverse.TabIndex = 48;
            this.labelReverse.Text = "切换为倒放";
            // 
            // btnReverse
            // 
            this.btnReverse.Location = new System.Drawing.Point(256, 18);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(75, 23);
            this.btnReverse.TabIndex = 47;
            this.btnReverse.Text = "Reverse";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.button1_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(132, 49);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(29, 12);
            this.label23.TabIndex = 46;
            this.label23.Text = "单帧";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(90, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 45;
            this.label11.Text = "快放";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 44;
            this.label9.Text = "慢放";
            // 
            // labelPause
            // 
            this.labelPause.AutoSize = true;
            this.labelPause.Location = new System.Drawing.Point(11, 49);
            this.labelPause.Name = "labelPause";
            this.labelPause.Size = new System.Drawing.Size(29, 12);
            this.labelPause.TabIndex = 43;
            this.labelPause.Text = "暂停";
            // 
            // btnFrame
            // 
            this.btnFrame.Location = new System.Drawing.Point(123, 18);
            this.btnFrame.Name = "btnFrame";
            this.btnFrame.Size = new System.Drawing.Size(50, 23);
            this.btnFrame.TabIndex = 42;
            this.btnFrame.Text = "|>";
            this.btnFrame.UseVisualStyleBackColor = true;
            this.btnFrame.Click += new System.EventHandler(this.btnFrame_Click);
            // 
            // btnFast
            // 
            this.btnFast.Location = new System.Drawing.Point(83, 18);
            this.btnFast.Name = "btnFast";
            this.btnFast.Size = new System.Drawing.Size(41, 23);
            this.btnFast.TabIndex = 41;
            this.btnFast.Text = ">>";
            this.btnFast.UseVisualStyleBackColor = true;
            this.btnFast.Click += new System.EventHandler(this.btnFast_Click);
            // 
            // btnSlow
            // 
            this.btnSlow.Location = new System.Drawing.Point(43, 18);
            this.btnSlow.Name = "btnSlow";
            this.btnSlow.Size = new System.Drawing.Size(41, 23);
            this.btnSlow.TabIndex = 40;
            this.btnSlow.Text = "<<";
            this.btnSlow.UseVisualStyleBackColor = true;
            this.btnSlow.Click += new System.EventHandler(this.btnSlow_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(7, 18);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(37, 23);
            this.btnPause.TabIndex = 39;
            this.btnPause.Text = "||";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(403, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 12);
            this.label14.TabIndex = 38;
            this.label14.Text = "BMP抓图";
            // 
            // btnBMP
            // 
            this.btnBMP.Location = new System.Drawing.Point(396, 18);
            this.btnBMP.Name = "btnBMP";
            this.btnBMP.Size = new System.Drawing.Size(56, 23);
            this.btnBMP.TabIndex = 36;
            this.btnBMP.Text = "BMP";
            this.btnBMP.UseVisualStyleBackColor = true;
            this.btnBMP.Click += new System.EventHandler(this.btnBMP_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.buttonSyncTime);
            this.groupBox3.Controls.Add(this.btnLogin);
            this.groupBox3.Controls.Add(this.textBoxUserName);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxPassword);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(4, -1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1010, 52);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            // 
            // dateTimeStart
            // 
            this.dateTimeStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeStart.Location = new System.Drawing.Point(4, 47);
            this.dateTimeStart.Name = "dateTimeStart";
            this.dateTimeStart.Size = new System.Drawing.Size(158, 21);
            this.dateTimeStart.TabIndex = 42;
            this.dateTimeStart.UseWaitCursor = true;
            this.dateTimeStart.Value = new System.DateTime(2014, 2, 28, 14, 43, 28, 0);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonStopRefresh);
            this.groupBox4.Controls.Add(this.label36);
            this.groupBox4.Controls.Add(this.groupBox11);
            this.groupBox4.Controls.Add(this.label35);
            this.groupBox4.Controls.Add(this.groupBox10);
            this.groupBox4.Controls.Add(this.listViewFinish);
            this.groupBox4.Controls.Add(this.richTextBox1);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.textBoxAuthCode);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.textBoxTestLineNo);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.DownloadProgressBar2);
            this.groupBox4.Controls.Add(this.buttonFlash);
            this.groupBox4.Controls.Add(this.checkBoxAutoRefresh);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.dateTimePickerJcKssj);
            this.groupBox4.Controls.Add(this.dateTimePickerJcJssj);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.listViewCar);
            this.groupBox4.Location = new System.Drawing.Point(675, 47);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(472, 617);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            // 
            // buttonStopRefresh
            // 
            this.buttonStopRefresh.Enabled = false;
            this.buttonStopRefresh.Location = new System.Drawing.Point(398, 103);
            this.buttonStopRefresh.Name = "buttonStopRefresh";
            this.buttonStopRefresh.Size = new System.Drawing.Size(72, 29);
            this.buttonStopRefresh.TabIndex = 80;
            this.buttonStopRefresh.Text = "终止上传";
            this.buttonStopRefresh.Click += new System.EventHandler(this.button3_Click);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(10, 137);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(65, 12);
            this.label36.TabIndex = 79;
            this.label36.Text = "待处理记录";
            // 
            // groupBox11
            // 
            this.groupBox11.Location = new System.Drawing.Point(6, 138);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(455, 10);
            this.groupBox11.TabIndex = 78;
            this.groupBox11.TabStop = false;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(10, 442);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(65, 12);
            this.label35.TabIndex = 77;
            this.label35.Text = "已完成记录";
            // 
            // groupBox10
            // 
            this.groupBox10.Location = new System.Drawing.Point(6, 443);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(455, 10);
            this.groupBox10.TabIndex = 76;
            this.groupBox10.TabStop = false;
            // 
            // listViewFinish
            // 
            this.listViewFinish.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader16,
            this.columnHeader17});
            this.listViewFinish.FullRowSelect = true;
            this.listViewFinish.GridLines = true;
            this.listViewFinish.Location = new System.Drawing.Point(6, 459);
            this.listViewFinish.Name = "listViewFinish";
            this.listViewFinish.Size = new System.Drawing.Size(460, 152);
            this.listViewFinish.TabIndex = 75;
            this.listViewFinish.UseCompatibleStateImageBehavior = false;
            this.listViewFinish.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ID";
            this.columnHeader6.Width = 170;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "VideoFrontUrl";
            this.columnHeader16.Width = 140;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "VideoBackUrl";
            this.columnHeader17.Width = 140;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 339);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(460, 96);
            this.richTextBox1.TabIndex = 74;
            this.richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(384, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 29);
            this.button1.TabIndex = 73;
            this.button1.Text = "保存";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBoxAuthCode
            // 
            this.textBoxAuthCode.Location = new System.Drawing.Point(239, 35);
            this.textBoxAuthCode.Name = "textBoxAuthCode";
            this.textBoxAuthCode.Size = new System.Drawing.Size(140, 21);
            this.textBoxAuthCode.TabIndex = 71;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(194, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 12);
            this.label17.TabIndex = 72;
            this.label17.Text = "授权码";
            // 
            // textBoxTestLineNo
            // 
            this.textBoxTestLineNo.Location = new System.Drawing.Point(78, 35);
            this.textBoxTestLineNo.Name = "textBoxTestLineNo";
            this.textBoxTestLineNo.Size = new System.Drawing.Size(110, 21);
            this.textBoxTestLineNo.TabIndex = 69;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 70;
            this.label19.Text = "检测站编号";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(167, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 67;
            this.label16.Text = "联网设置";
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(12, 13);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(451, 10);
            this.groupBox5.TabIndex = 66;
            this.groupBox5.TabStop = false;
            // 
            // DownloadProgressBar2
            // 
            this.DownloadProgressBar2.Location = new System.Drawing.Point(6, 327);
            this.DownloadProgressBar2.Name = "DownloadProgressBar2";
            this.DownloadProgressBar2.Size = new System.Drawing.Size(460, 12);
            this.DownloadProgressBar2.TabIndex = 65;
            // 
            // buttonFlash
            // 
            this.buttonFlash.Location = new System.Drawing.Point(326, 103);
            this.buttonFlash.Name = "buttonFlash";
            this.buttonFlash.Size = new System.Drawing.Size(72, 29);
            this.buttonFlash.TabIndex = 64;
            this.buttonFlash.Text = "开始上传";
            this.buttonFlash.Click += new System.EventHandler(this.buttonFlash_Click);
            // 
            // checkBoxAutoRefresh
            // 
            this.checkBoxAutoRefresh.AutoSize = true;
            this.checkBoxAutoRefresh.Location = new System.Drawing.Point(328, 86);
            this.checkBoxAutoRefresh.Name = "checkBoxAutoRefresh";
            this.checkBoxAutoRefresh.Size = new System.Drawing.Size(72, 16);
            this.checkBoxAutoRefresh.TabIndex = 63;
            this.checkBoxAutoRefresh.Text = "自动刷新";
            this.checkBoxAutoRefresh.UseVisualStyleBackColor = true;
            this.checkBoxAutoRefresh.CheckedChanged += new System.EventHandler(this.checkBoxAutoRefresh_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 68);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 12);
            this.label10.TabIndex = 62;
            this.label10.Text = "检测时间段";
            // 
            // dateTimePickerJcKssj
            // 
            this.dateTimePickerJcKssj.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePickerJcKssj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerJcKssj.Location = new System.Drawing.Point(7, 109);
            this.dateTimePickerJcKssj.Name = "dateTimePickerJcKssj";
            this.dateTimePickerJcKssj.Size = new System.Drawing.Size(157, 21);
            this.dateTimePickerJcKssj.TabIndex = 57;
            this.dateTimePickerJcKssj.UseWaitCursor = true;
            this.dateTimePickerJcKssj.Value = new System.DateTime(2014, 2, 28, 14, 43, 28, 0);
            // 
            // dateTimePickerJcJssj
            // 
            this.dateTimePickerJcJssj.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimePickerJcJssj.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerJcJssj.Location = new System.Drawing.Point(166, 109);
            this.dateTimePickerJcJssj.Name = "dateTimePickerJcJssj";
            this.dateTimePickerJcJssj.Size = new System.Drawing.Size(156, 21);
            this.dateTimePickerJcJssj.TabIndex = 58;
            this.dateTimePickerJcJssj.Value = new System.DateTime(2014, 2, 28, 14, 40, 31, 0);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(48, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 59;
            this.label12.Text = "开始时间";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(202, 90);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 60;
            this.label13.Text = "结束时间";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(8, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(451, 10);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            // 
            // listViewCar
            // 
            this.listViewCar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader14,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader11});
            this.listViewCar.FullRowSelect = true;
            this.listViewCar.GridLines = true;
            this.listViewCar.Location = new System.Drawing.Point(6, 154);
            this.listViewCar.Name = "listViewCar";
            this.listViewCar.Size = new System.Drawing.Size(460, 172);
            this.listViewCar.TabIndex = 50;
            this.listViewCar.UseCompatibleStateImageBehavior = false;
            this.listViewCar.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "ID";
            this.columnHeader9.Width = 170;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "检测时间";
            this.columnHeader10.Width = 150;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "状态";
            this.columnHeader14.Width = 130;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "检测开始时间";
            this.columnHeader7.Width = 150;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "检测结束时间";
            this.columnHeader8.Width = 150;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "线号";
            // 
            // btnStopDownload
            // 
            this.btnStopDownload.Enabled = false;
            this.btnStopDownload.Location = new System.Drawing.Point(327, 177);
            this.btnStopDownload.Name = "btnStopDownload";
            this.btnStopDownload.Size = new System.Drawing.Size(125, 29);
            this.btnStopDownload.TabIndex = 60;
            this.btnStopDownload.Text = "Stop Download";
            this.btnStopDownload.UseVisualStyleBackColor = true;
            this.btnStopDownload.Click += new System.EventHandler(this.btnStopDownload_Click);
            // 
            // btnDownloadName
            // 
            this.btnDownloadName.Location = new System.Drawing.Point(326, 121);
            this.btnDownloadName.Name = "btnDownloadName";
            this.btnDownloadName.Size = new System.Drawing.Size(126, 29);
            this.btnDownloadName.TabIndex = 59;
            this.btnDownloadName.Text = "Download By Name";
            this.btnDownloadName.UseVisualStyleBackColor = true;
            this.btnDownloadName.Click += new System.EventHandler(this.btnDownloadName_Click);
            // 
            // btnDownloadTime
            // 
            this.btnDownloadTime.Location = new System.Drawing.Point(326, 37);
            this.btnDownloadTime.Name = "btnDownloadTime";
            this.btnDownloadTime.Size = new System.Drawing.Size(126, 29);
            this.btnDownloadTime.TabIndex = 58;
            this.btnDownloadTime.Text = "Download By Time";
            this.btnDownloadTime.UseVisualStyleBackColor = true;
            this.btnDownloadTime.Click += new System.EventHandler(this.btnDownloadTime_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(109, 12);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(95, 12);
            this.label20.TabIndex = 56;
            this.label20.Text = "按时间回放/下载";
            // 
            // btnPlaybackTime
            // 
            this.btnPlaybackTime.Location = new System.Drawing.Point(326, 9);
            this.btnPlaybackTime.Name = "btnPlaybackTime";
            this.btnPlaybackTime.Size = new System.Drawing.Size(126, 29);
            this.btnPlaybackTime.TabIndex = 55;
            this.btnPlaybackTime.Text = "PlayBack By Time";
            this.btnPlaybackTime.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPlaybackTime.UseVisualStyleBackColor = true;
            this.btnPlaybackTime.Click += new System.EventHandler(this.btnPlaybackTime_Click);
            // 
            // btnStopPlayback
            // 
            this.btnStopPlayback.Enabled = false;
            this.btnStopPlayback.Location = new System.Drawing.Point(327, 149);
            this.btnStopPlayback.Name = "btnStopPlayback";
            this.btnStopPlayback.Size = new System.Drawing.Size(125, 29);
            this.btnStopPlayback.TabIndex = 53;
            this.btnStopPlayback.Text = "Stop PlayBack";
            this.btnStopPlayback.UseVisualStyleBackColor = true;
            this.btnStopPlayback.Click += new System.EventHandler(this.btnStopPlayback_Click);
            // 
            // btnPlaybackName
            // 
            this.btnPlaybackName.Location = new System.Drawing.Point(326, 93);
            this.btnPlaybackName.Name = "btnPlaybackName";
            this.btnPlaybackName.Size = new System.Drawing.Size(126, 29);
            this.btnPlaybackName.TabIndex = 51;
            this.btnPlaybackName.Text = "PlayBack By Name";
            this.btnPlaybackName.UseVisualStyleBackColor = true;
            this.btnPlaybackName.Click += new System.EventHandler(this.btnPlaybackName_Click);
            // 
            // listViewFile
            // 
            this.listViewFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listViewFile.FullRowSelect = true;
            this.listViewFile.GridLines = true;
            this.listViewFile.Location = new System.Drawing.Point(3, 92);
            this.listViewFile.Name = "listViewFile";
            this.listViewFile.Size = new System.Drawing.Size(320, 113);
            this.listViewFile.TabIndex = 49;
            this.listViewFile.UseCompatibleStateImageBehavior = false;
            this.listViewFile.View = System.Windows.Forms.View.Details;
            this.listViewFile.SelectedIndexChanged += new System.EventHandler(this.listViewFile_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "File Name";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Starting Time";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ending Time";
            this.columnHeader5.Width = 120;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(326, 65);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(126, 29);
            this.btnSearch.TabIndex = 48;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(203, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 12);
            this.label18.TabIndex = 46;
            this.label18.Text = "结束时间";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(45, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 44;
            this.label15.Text = "开始时间";
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimeEnd.Location = new System.Drawing.Point(167, 47);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(156, 21);
            this.dateTimeEnd.TabIndex = 43;
            this.dateTimeEnd.Value = new System.DateTime(2014, 2, 28, 14, 40, 31, 0);
            // 
            // groupBox7
            // 
            this.groupBox7.Location = new System.Drawing.Point(10, 10);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(289, 10);
            this.groupBox7.TabIndex = 46;
            this.groupBox7.TabStop = false;
            // 
            // timerDownload
            // 
            this.timerDownload.Tick += new System.EventHandler(this.timerProgress_Tick);
            // 
            // PlaybackprogressBar
            // 
            this.PlaybackprogressBar.Location = new System.Drawing.Point(211, 381);
            this.PlaybackprogressBar.Name = "PlaybackprogressBar";
            this.PlaybackprogressBar.Size = new System.Drawing.Size(458, 10);
            this.PlaybackprogressBar.TabIndex = 43;
            // 
            // timerPlayback
            // 
            this.timerPlayback.Tick += new System.EventHandler(this.timerPlayback_Tick);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(1020, 14);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(127, 30);
            this.btn_Exit.TabIndex = 44;
            this.btn_Exit.Text = "退出 Exit";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.DownloadProgressBar);
            this.groupBox9.Controls.Add(this.label20);
            this.groupBox9.Controls.Add(this.btnDownloadName);
            this.groupBox9.Controls.Add(this.btnStopDownload);
            this.groupBox9.Controls.Add(this.dateTimeStart);
            this.groupBox9.Controls.Add(this.dateTimeEnd);
            this.groupBox9.Controls.Add(this.btnDownloadTime);
            this.groupBox9.Controls.Add(this.label15);
            this.groupBox9.Controls.Add(this.label18);
            this.groupBox9.Controls.Add(this.btnPlaybackName);
            this.groupBox9.Controls.Add(this.btnPlaybackTime);
            this.groupBox9.Controls.Add(this.btnSearch);
            this.groupBox9.Controls.Add(this.listViewFile);
            this.groupBox9.Controls.Add(this.groupBox7);
            this.groupBox9.Controls.Add(this.btnStopPlayback);
            this.groupBox9.Location = new System.Drawing.Point(211, 451);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(458, 213);
            this.groupBox9.TabIndex = 45;
            this.groupBox9.TabStop = false;
            // 
            // DownloadProgressBar
            // 
            this.DownloadProgressBar.Location = new System.Drawing.Point(3, 74);
            this.DownloadProgressBar.Name = "DownloadProgressBar";
            this.DownloadProgressBar.Size = new System.Drawing.Size(320, 12);
            this.DownloadProgressBar.TabIndex = 61;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button2);
            this.groupBox6.Controls.Add(this.comboBoxChB8);
            this.groupBox6.Controls.Add(this.comboBoxChF8);
            this.groupBox6.Controls.Add(this.label31);
            this.groupBox6.Controls.Add(this.comboBoxChB7);
            this.groupBox6.Controls.Add(this.comboBoxChF7);
            this.groupBox6.Controls.Add(this.label32);
            this.groupBox6.Controls.Add(this.comboBoxChB6);
            this.groupBox6.Controls.Add(this.comboBoxChF6);
            this.groupBox6.Controls.Add(this.label33);
            this.groupBox6.Controls.Add(this.comboBoxChB5);
            this.groupBox6.Controls.Add(this.comboBoxChF5);
            this.groupBox6.Controls.Add(this.label34);
            this.groupBox6.Controls.Add(this.comboBoxChB4);
            this.groupBox6.Controls.Add(this.comboBoxChF4);
            this.groupBox6.Controls.Add(this.label30);
            this.groupBox6.Controls.Add(this.comboBoxChB3);
            this.groupBox6.Controls.Add(this.comboBoxChF3);
            this.groupBox6.Controls.Add(this.label29);
            this.groupBox6.Controls.Add(this.comboBoxChB2);
            this.groupBox6.Controls.Add(this.comboBoxChF2);
            this.groupBox6.Controls.Add(this.label28);
            this.groupBox6.Controls.Add(this.comboBoxChB1);
            this.groupBox6.Controls.Add(this.comboBoxChF1);
            this.groupBox6.Controls.Add(this.label27);
            this.groupBox6.Controls.Add(this.label26);
            this.groupBox6.Controls.Add(this.label24);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Location = new System.Drawing.Point(4, 350);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(197, 314);
            this.groupBox6.TabIndex = 47;
            this.groupBox6.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(41, 277);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 29);
            this.button2.TabIndex = 85;
            this.button2.Text = "保存";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // comboBoxChB8
            // 
            this.comboBoxChB8.FormattingEnabled = true;
            this.comboBoxChB8.Location = new System.Drawing.Point(126, 231);
            this.comboBoxChB8.Name = "comboBoxChB8";
            this.comboBoxChB8.Size = new System.Drawing.Size(63, 20);
            this.comboBoxChB8.TabIndex = 84;
            // 
            // comboBoxChF8
            // 
            this.comboBoxChF8.FormattingEnabled = true;
            this.comboBoxChF8.Location = new System.Drawing.Point(54, 231);
            this.comboBoxChF8.Name = "comboBoxChF8";
            this.comboBoxChF8.Size = new System.Drawing.Size(63, 20);
            this.comboBoxChF8.TabIndex = 83;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(18, 234);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(17, 12);
            this.label31.TabIndex = 82;
            this.label31.Text = "08";
            // 
            // comboBoxChB7
            // 
            this.comboBoxChB7.FormattingEnabled = true;
            this.comboBoxChB7.Location = new System.Drawing.Point(126, 205);
            this.comboBoxChB7.Name = "comboBoxChB7";
            this.comboBoxChB7.Size = new System.Drawing.Size(63, 20);
            this.comboBoxChB7.TabIndex = 81;
            // 
            // comboBoxChF7
            // 
            this.comboBoxChF7.FormattingEnabled = true;
            this.comboBoxChF7.Location = new System.Drawing.Point(54, 205);
            this.comboBoxChF7.Name = "comboBoxChF7";
            this.comboBoxChF7.Size = new System.Drawing.Size(63, 20);
            this.comboBoxChF7.TabIndex = 80;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(18, 208);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(17, 12);
            this.label32.TabIndex = 79;
            this.label32.Text = "07";
            // 
            // comboBoxChB6
            // 
            this.comboBoxChB6.FormattingEnabled = true;
            this.comboBoxChB6.Location = new System.Drawing.Point(126, 179);
            this.comboBoxChB6.Name = "comboBoxChB6";
            this.comboBoxChB6.Size = new System.Drawing.Size(63, 20);
            this.comboBoxChB6.TabIndex = 78;
            // 
            // comboBoxChF6
            // 
            this.comboBoxChF6.FormattingEnabled = true;
            this.comboBoxChF6.Location = new System.Drawing.Point(54, 179);
            this.comboBoxChF6.Name = "comboBoxChF6";
            this.comboBoxChF6.Size = new System.Drawing.Size(63, 20);
            this.comboBoxChF6.TabIndex = 77;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(18, 182);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(17, 12);
            this.label33.TabIndex = 76;
            this.label33.Text = "06";
            // 
            // comboBoxChB5
            // 
            this.comboBoxChB5.FormattingEnabled = true;
            this.comboBoxChB5.Location = new System.Drawing.Point(126, 153);
            this.comboBoxChB5.Name = "comboBoxChB5";
            this.comboBoxChB5.Size = new System.Drawing.Size(63, 20);
            this.comboBoxChB5.TabIndex = 75;
            // 
            // comboBoxChF5
            // 
            this.comboBoxChF5.FormattingEnabled = true;
            this.comboBoxChF5.Location = new System.Drawing.Point(54, 153);
            this.comboBoxChF5.Name = "comboBoxChF5";
            this.comboBoxChF5.Size = new System.Drawing.Size(63, 20);
            this.comboBoxChF5.TabIndex = 74;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(18, 156);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(17, 12);
            this.label34.TabIndex = 73;
            this.label34.Text = "05";
            // 
            // comboBoxChB4
            // 
            this.comboBoxChB4.FormattingEnabled = true;
            this.comboBoxChB4.Location = new System.Drawing.Point(126, 127);
            this.comboBoxChB4.Name = "comboBoxChB4";
            this.comboBoxChB4.Size = new System.Drawing.Size(63, 20);
            this.comboBoxChB4.TabIndex = 72;
            // 
            // comboBoxChF4
            // 
            this.comboBoxChF4.FormattingEnabled = true;
            this.comboBoxChF4.Location = new System.Drawing.Point(54, 127);
            this.comboBoxChF4.Name = "comboBoxChF4";
            this.comboBoxChF4.Size = new System.Drawing.Size(63, 20);
            this.comboBoxChF4.TabIndex = 71;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(18, 130);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(17, 12);
            this.label30.TabIndex = 70;
            this.label30.Text = "04";
            // 
            // comboBoxChB3
            // 
            this.comboBoxChB3.FormattingEnabled = true;
            this.comboBoxChB3.Location = new System.Drawing.Point(126, 101);
            this.comboBoxChB3.Name = "comboBoxChB3";
            this.comboBoxChB3.Size = new System.Drawing.Size(63, 20);
            this.comboBoxChB3.TabIndex = 69;
            // 
            // comboBoxChF3
            // 
            this.comboBoxChF3.FormattingEnabled = true;
            this.comboBoxChF3.Location = new System.Drawing.Point(54, 101);
            this.comboBoxChF3.Name = "comboBoxChF3";
            this.comboBoxChF3.Size = new System.Drawing.Size(63, 20);
            this.comboBoxChF3.TabIndex = 68;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(18, 104);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(17, 12);
            this.label29.TabIndex = 67;
            this.label29.Text = "03";
            // 
            // comboBoxChB2
            // 
            this.comboBoxChB2.FormattingEnabled = true;
            this.comboBoxChB2.Location = new System.Drawing.Point(126, 75);
            this.comboBoxChB2.Name = "comboBoxChB2";
            this.comboBoxChB2.Size = new System.Drawing.Size(63, 20);
            this.comboBoxChB2.TabIndex = 66;
            // 
            // comboBoxChF2
            // 
            this.comboBoxChF2.FormattingEnabled = true;
            this.comboBoxChF2.Location = new System.Drawing.Point(54, 75);
            this.comboBoxChF2.Name = "comboBoxChF2";
            this.comboBoxChF2.Size = new System.Drawing.Size(63, 20);
            this.comboBoxChF2.TabIndex = 65;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(18, 78);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(17, 12);
            this.label28.TabIndex = 64;
            this.label28.Text = "02";
            // 
            // comboBoxChB1
            // 
            this.comboBoxChB1.FormattingEnabled = true;
            this.comboBoxChB1.Location = new System.Drawing.Point(126, 49);
            this.comboBoxChB1.Name = "comboBoxChB1";
            this.comboBoxChB1.Size = new System.Drawing.Size(63, 20);
            this.comboBoxChB1.TabIndex = 63;
            // 
            // comboBoxChF1
            // 
            this.comboBoxChF1.FormattingEnabled = true;
            this.comboBoxChF1.Location = new System.Drawing.Point(54, 49);
            this.comboBoxChF1.Name = "comboBoxChF1";
            this.comboBoxChF1.Size = new System.Drawing.Size(63, 20);
            this.comboBoxChF1.TabIndex = 62;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(18, 52);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(17, 12);
            this.label27.TabIndex = 61;
            this.label27.Text = "01";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(130, 22);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(53, 12);
            this.label26.TabIndex = 60;
            this.label26.Text = "后通道号";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(61, 22);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 12);
            this.label24.TabIndex = 59;
            this.label24.Text = "前通道号";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(15, 22);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(29, 12);
            this.label22.TabIndex = 58;
            this.label22.Text = "线号";
            // 
            // groupBox8
            // 
            this.groupBox8.Location = new System.Drawing.Point(7, 21);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(181, 10);
            this.groupBox8.TabIndex = 57;
            this.groupBox8.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(13, 351);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(53, 12);
            this.label21.TabIndex = 57;
            this.label21.Text = "通道设置";
            // 
            // timerDownload2
            // 
            this.timerDownload2.Tick += new System.EventHandler(this.timerDownload2_Tick);
            // 
            // buttonSyncTime
            // 
            this.buttonSyncTime.Enabled = false;
            this.buttonSyncTime.Location = new System.Drawing.Point(897, 14);
            this.buttonSyncTime.Name = "buttonSyncTime";
            this.buttonSyncTime.Size = new System.Drawing.Size(102, 31);
            this.buttonSyncTime.TabIndex = 28;
            this.buttonSyncTime.Text = "同步时间";
            this.buttonSyncTime.Click += new System.EventHandler(this.buttonSyncTime_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 668);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.PlaybackprogressBar);
            this.Controls.Add(this.listViewIPChannel);
            this.Controls.Add(this.VideoPlayWnd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NVR Video download and upload";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VideoPlayWnd)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUserName;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox VideoPlayWnd;
        private System.Windows.Forms.ListView listViewIPChannel;
        private System.Windows.Forms.ColumnHeader ColumnHeader1;
        private System.Windows.Forms.ColumnHeader ColumnHeader2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dateTimeStart;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dateTimeEnd;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView listViewFile;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button btnPlaybackName;
        private System.Windows.Forms.Button btnStopPlayback;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnPlaybackTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnBMP;
        private System.Windows.Forms.Button btnFast;
        private System.Windows.Forms.Button btnSlow;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnFrame;
        private System.Windows.Forms.Label labelPause;
        private System.Windows.Forms.Label labelReverse;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btnResume;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button btnDownloadName;
        private System.Windows.Forms.Button btnDownloadTime;
        private System.Windows.Forms.Button btnStopDownload;
        private System.Windows.Forms.Timer timerDownload;
        private System.Windows.Forms.ProgressBar PlaybackprogressBar;
        private System.Windows.Forms.Timer timerPlayback;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Label labelSound;
        private System.Windows.Forms.Button btnSound;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button buttonFlash;
        private System.Windows.Forms.CheckBox checkBoxAutoRefresh;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePickerJcKssj;
        private System.Windows.Forms.DateTimePicker dateTimePickerJcJssj;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewCar;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ProgressBar DownloadProgressBar;
        private System.Windows.Forms.ProgressBar DownloadProgressBar2;
        private System.Windows.Forms.TextBox textBoxAuthCode;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBoxTestLineNo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox comboBoxChB8;
        private System.Windows.Forms.ComboBox comboBoxChF8;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox comboBoxChB7;
        private System.Windows.Forms.ComboBox comboBoxChF7;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.ComboBox comboBoxChB6;
        private System.Windows.Forms.ComboBox comboBoxChF6;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.ComboBox comboBoxChB5;
        private System.Windows.Forms.ComboBox comboBoxChF5;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.ComboBox comboBoxChB4;
        private System.Windows.Forms.ComboBox comboBoxChF4;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox comboBoxChB3;
        private System.Windows.Forms.ComboBox comboBoxChF3;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox comboBoxChB2;
        private System.Windows.Forms.ComboBox comboBoxChF2;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox comboBoxChB1;
        private System.Windows.Forms.ComboBox comboBoxChF1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ListView listViewFinish;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.Button buttonStopRefresh;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Timer timerDownload2;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.Button buttonSyncTime;
    }
}

