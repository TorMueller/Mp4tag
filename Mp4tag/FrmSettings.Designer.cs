namespace Mp4tag
{
    partial class FrmSettings
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
            this.tbcSettings = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.grpLoadFile = new System.Windows.Forms.GroupBox();
            this.rdoMusicVideo = new System.Windows.Forms.RadioButton();
            this.rdoMovie = new System.Windows.Forms.RadioButton();
            this.rdoTVShow = new System.Windows.Forms.RadioButton();
            this.rdoPrompt = new System.Windows.Forms.RadioButton();
            this.grpAutoUpdate = new System.Windows.Forms.GroupBox();
            this.chkAutoUpdateError = new System.Windows.Forms.CheckBox();
            this.chkAutoUpdate = new System.Windows.Forms.CheckBox();
            this.tabProxy = new System.Windows.Forms.TabPage();
            this.grpProxyAuthentication = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.rdoManualLogin = new System.Windows.Forms.RadioButton();
            this.rdoWindowsLogin = new System.Windows.Forms.RadioButton();
            this.grpProxy = new System.Windows.Forms.GroupBox();
            this.pnlProxySettings = new System.Windows.Forms.Panel();
            this.pnlSOCKS = new System.Windows.Forms.Panel();
            this.rdoSOCKSv5 = new System.Windows.Forms.RadioButton();
            this.rdoSOCKSv4 = new System.Windows.Forms.RadioButton();
            this.lblSOCKSProxyPort = new System.Windows.Forms.Label();
            this.lblFTPProxyPort = new System.Windows.Forms.Label();
            this.numSOCKSProxyPort = new System.Windows.Forms.NumericUpDown();
            this.txtSOCKSProxy = new System.Windows.Forms.TextBox();
            this.lblSOCKSProxy = new System.Windows.Forms.Label();
            this.numFTPProxyPort = new System.Windows.Forms.NumericUpDown();
            this.txtFTPProxy = new System.Windows.Forms.TextBox();
            this.lblFTPProxy = new System.Windows.Forms.Label();
            this.numSSLProxyPort = new System.Windows.Forms.NumericUpDown();
            this.lblSSLProxyPort = new System.Windows.Forms.Label();
            this.txtSSLProxy = new System.Windows.Forms.TextBox();
            this.lblSSLProxy = new System.Windows.Forms.Label();
            this.chkAllProtocols = new System.Windows.Forms.CheckBox();
            this.numHttpProxyPort = new System.Windows.Forms.NumericUpDown();
            this.lblHttpProxyPort = new System.Windows.Forms.Label();
            this.txtHttpProxy = new System.Windows.Forms.TextBox();
            this.lblHttpProxy = new System.Windows.Forms.Label();
            this.rdoManualProxy = new System.Windows.Forms.RadioButton();
            this.rdoSystemProxy = new System.Windows.Forms.RadioButton();
            this.rdoNoProxy = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabAutoEnable = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbcSettings.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.grpLoadFile.SuspendLayout();
            this.grpAutoUpdate.SuspendLayout();
            this.tabProxy.SuspendLayout();
            this.grpProxyAuthentication.SuspendLayout();
            this.grpProxy.SuspendLayout();
            this.pnlProxySettings.SuspendLayout();
            this.pnlSOCKS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSOCKSProxyPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFTPProxyPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSSLProxyPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHttpProxyPort)).BeginInit();
            this.tabAutoEnable.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcSettings
            // 
            this.tbcSettings.Controls.Add(this.tabGeneral);
            this.tbcSettings.Controls.Add(this.tabAutoEnable);
            this.tbcSettings.Controls.Add(this.tabProxy);
            this.tbcSettings.Location = new System.Drawing.Point(12, 7);
            this.tbcSettings.Name = "tbcSettings";
            this.tbcSettings.SelectedIndex = 0;
            this.tbcSettings.Size = new System.Drawing.Size(610, 410);
            this.tbcSettings.TabIndex = 0;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.grpLoadFile);
            this.tabGeneral.Controls.Add(this.grpAutoUpdate);
            this.tabGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeneral.Size = new System.Drawing.Size(602, 384);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "[General]";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // grpLoadFile
            // 
            this.grpLoadFile.Controls.Add(this.rdoMusicVideo);
            this.grpLoadFile.Controls.Add(this.rdoMovie);
            this.grpLoadFile.Controls.Add(this.rdoTVShow);
            this.grpLoadFile.Controls.Add(this.rdoPrompt);
            this.grpLoadFile.Location = new System.Drawing.Point(305, 7);
            this.grpLoadFile.Name = "grpLoadFile";
            this.grpLoadFile.Size = new System.Drawing.Size(291, 71);
            this.grpLoadFile.TabIndex = 2;
            this.grpLoadFile.TabStop = false;
            this.grpLoadFile.Text = "[All loaded files are]";
            // 
            // rdoMusicVideo
            // 
            this.rdoMusicVideo.AutoSize = true;
            this.rdoMusicVideo.Location = new System.Drawing.Point(141, 43);
            this.rdoMusicVideo.Name = "rdoMusicVideo";
            this.rdoMusicVideo.Size = new System.Drawing.Size(89, 17);
            this.rdoMusicVideo.TabIndex = 4;
            this.rdoMusicVideo.TabStop = true;
            this.rdoMusicVideo.Text = "[Music Video]";
            this.rdoMusicVideo.UseVisualStyleBackColor = true;
            // 
            // rdoMovie
            // 
            this.rdoMovie.AutoSize = true;
            this.rdoMovie.Location = new System.Drawing.Point(141, 19);
            this.rdoMovie.Name = "rdoMovie";
            this.rdoMovie.Size = new System.Drawing.Size(65, 17);
            this.rdoMovie.TabIndex = 3;
            this.rdoMovie.TabStop = true;
            this.rdoMovie.Text = "[Movies]";
            this.rdoMovie.UseVisualStyleBackColor = true;
            // 
            // rdoTVShow
            // 
            this.rdoTVShow.AutoSize = true;
            this.rdoTVShow.Location = new System.Drawing.Point(6, 43);
            this.rdoTVShow.Name = "rdoTVShow";
            this.rdoTVShow.Size = new System.Drawing.Size(75, 17);
            this.rdoTVShow.TabIndex = 2;
            this.rdoTVShow.TabStop = true;
            this.rdoTVShow.Text = "[TV Show]";
            this.rdoTVShow.UseVisualStyleBackColor = true;
            // 
            // rdoPrompt
            // 
            this.rdoPrompt.AutoSize = true;
            this.rdoPrompt.Location = new System.Drawing.Point(6, 19);
            this.rdoPrompt.Name = "rdoPrompt";
            this.rdoPrompt.Size = new System.Drawing.Size(82, 17);
            this.rdoPrompt.TabIndex = 1;
            this.rdoPrompt.TabStop = true;
            this.rdoPrompt.Text = "[Prompt Me]";
            this.rdoPrompt.UseVisualStyleBackColor = true;
            // 
            // grpAutoUpdate
            // 
            this.grpAutoUpdate.Controls.Add(this.chkAutoUpdateError);
            this.grpAutoUpdate.Controls.Add(this.chkAutoUpdate);
            this.grpAutoUpdate.Location = new System.Drawing.Point(7, 7);
            this.grpAutoUpdate.Name = "grpAutoUpdate";
            this.grpAutoUpdate.Size = new System.Drawing.Size(292, 71);
            this.grpAutoUpdate.TabIndex = 0;
            this.grpAutoUpdate.TabStop = false;
            this.grpAutoUpdate.Text = "[Automatic Update]";
            // 
            // chkAutoUpdateError
            // 
            this.chkAutoUpdateError.AutoSize = true;
            this.chkAutoUpdateError.Location = new System.Drawing.Point(7, 44);
            this.chkAutoUpdateError.Name = "chkAutoUpdateError";
            this.chkAutoUpdateError.Size = new System.Drawing.Size(270, 17);
            this.chkAutoUpdateError.TabIndex = 1;
            this.chkAutoUpdateError.Text = "[Show error message if version file cannot be found]";
            this.chkAutoUpdateError.UseVisualStyleBackColor = true;
            // 
            // chkAutoUpdate
            // 
            this.chkAutoUpdate.AutoSize = true;
            this.chkAutoUpdate.Location = new System.Drawing.Point(7, 20);
            this.chkAutoUpdate.Name = "chkAutoUpdate";
            this.chkAutoUpdate.Size = new System.Drawing.Size(169, 17);
            this.chkAutoUpdate.TabIndex = 0;
            this.chkAutoUpdate.Text = "[Check for updates on startup]";
            this.chkAutoUpdate.UseVisualStyleBackColor = true;
            // 
            // tabProxy
            // 
            this.tabProxy.Controls.Add(this.grpProxyAuthentication);
            this.tabProxy.Controls.Add(this.grpProxy);
            this.tabProxy.Location = new System.Drawing.Point(4, 22);
            this.tabProxy.Name = "tabProxy";
            this.tabProxy.Padding = new System.Windows.Forms.Padding(3);
            this.tabProxy.Size = new System.Drawing.Size(602, 384);
            this.tabProxy.TabIndex = 1;
            this.tabProxy.Text = "[Proxy]";
            this.tabProxy.UseVisualStyleBackColor = true;
            // 
            // grpProxyAuthentication
            // 
            this.grpProxyAuthentication.Controls.Add(this.textBox2);
            this.grpProxyAuthentication.Controls.Add(this.lblPassword);
            this.grpProxyAuthentication.Controls.Add(this.textBox1);
            this.grpProxyAuthentication.Controls.Add(this.lblUsername);
            this.grpProxyAuthentication.Controls.Add(this.rdoManualLogin);
            this.grpProxyAuthentication.Controls.Add(this.rdoWindowsLogin);
            this.grpProxyAuthentication.Location = new System.Drawing.Point(7, 274);
            this.grpProxyAuthentication.Name = "grpProxyAuthentication";
            this.grpProxyAuthentication.Size = new System.Drawing.Size(589, 104);
            this.grpProxyAuthentication.TabIndex = 1;
            this.grpProxyAuthentication.TabStop = false;
            this.grpProxyAuthentication.Text = "[Proxy Authentication]";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(390, 71);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(179, 20);
            this.textBox2.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(290, 74);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(94, 23);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "[Password]";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(106, 71);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(178, 20);
            this.textBox1.TabIndex = 3;
            // 
            // lblUsername
            // 
            this.lblUsername.Location = new System.Drawing.Point(6, 74);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(94, 23);
            this.lblUsername.TabIndex = 2;
            this.lblUsername.Text = "[Username]";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rdoManualLogin
            // 
            this.rdoManualLogin.AutoSize = true;
            this.rdoManualLogin.Location = new System.Drawing.Point(8, 45);
            this.rdoManualLogin.Name = "rdoManualLogin";
            this.rdoManualLogin.Size = new System.Drawing.Size(155, 17);
            this.rdoManualLogin.TabIndex = 1;
            this.rdoManualLogin.TabStop = true;
            this.rdoManualLogin.Text = "[Manual login configuration]";
            this.rdoManualLogin.UseVisualStyleBackColor = true;
            // 
            // rdoWindowsLogin
            // 
            this.rdoWindowsLogin.AutoSize = true;
            this.rdoWindowsLogin.Location = new System.Drawing.Point(8, 21);
            this.rdoWindowsLogin.Name = "rdoWindowsLogin";
            this.rdoWindowsLogin.Size = new System.Drawing.Size(122, 17);
            this.rdoWindowsLogin.TabIndex = 0;
            this.rdoWindowsLogin.TabStop = true;
            this.rdoWindowsLogin.Text = "[Use Windows login]";
            this.rdoWindowsLogin.UseVisualStyleBackColor = true;
            // 
            // grpProxy
            // 
            this.grpProxy.Controls.Add(this.pnlProxySettings);
            this.grpProxy.Controls.Add(this.rdoManualProxy);
            this.grpProxy.Controls.Add(this.rdoSystemProxy);
            this.grpProxy.Controls.Add(this.rdoNoProxy);
            this.grpProxy.Location = new System.Drawing.Point(7, 7);
            this.grpProxy.Name = "grpProxy";
            this.grpProxy.Size = new System.Drawing.Size(589, 261);
            this.grpProxy.TabIndex = 0;
            this.grpProxy.TabStop = false;
            this.grpProxy.Text = "[Proxy Settings]";
            // 
            // pnlProxySettings
            // 
            this.pnlProxySettings.Controls.Add(this.pnlSOCKS);
            this.pnlProxySettings.Controls.Add(this.lblSOCKSProxyPort);
            this.pnlProxySettings.Controls.Add(this.lblFTPProxyPort);
            this.pnlProxySettings.Controls.Add(this.numSOCKSProxyPort);
            this.pnlProxySettings.Controls.Add(this.txtSOCKSProxy);
            this.pnlProxySettings.Controls.Add(this.lblSOCKSProxy);
            this.pnlProxySettings.Controls.Add(this.numFTPProxyPort);
            this.pnlProxySettings.Controls.Add(this.txtFTPProxy);
            this.pnlProxySettings.Controls.Add(this.lblFTPProxy);
            this.pnlProxySettings.Controls.Add(this.numSSLProxyPort);
            this.pnlProxySettings.Controls.Add(this.lblSSLProxyPort);
            this.pnlProxySettings.Controls.Add(this.txtSSLProxy);
            this.pnlProxySettings.Controls.Add(this.lblSSLProxy);
            this.pnlProxySettings.Controls.Add(this.chkAllProtocols);
            this.pnlProxySettings.Controls.Add(this.numHttpProxyPort);
            this.pnlProxySettings.Controls.Add(this.lblHttpProxyPort);
            this.pnlProxySettings.Controls.Add(this.txtHttpProxy);
            this.pnlProxySettings.Controls.Add(this.lblHttpProxy);
            this.pnlProxySettings.Location = new System.Drawing.Point(1, 85);
            this.pnlProxySettings.Name = "pnlProxySettings";
            this.pnlProxySettings.Size = new System.Drawing.Size(587, 175);
            this.pnlProxySettings.TabIndex = 3;
            // 
            // pnlSOCKS
            // 
            this.pnlSOCKS.Controls.Add(this.rdoSOCKSv5);
            this.pnlSOCKS.Controls.Add(this.rdoSOCKSv4);
            this.pnlSOCKS.Location = new System.Drawing.Point(105, 140);
            this.pnlSOCKS.Name = "pnlSOCKS";
            this.pnlSOCKS.Size = new System.Drawing.Size(165, 24);
            this.pnlSOCKS.TabIndex = 57;
            // 
            // rdoSOCKSv5
            // 
            this.rdoSOCKSv5.AutoSize = true;
            this.rdoSOCKSv5.Location = new System.Drawing.Point(86, 3);
            this.rdoSOCKSv5.Name = "rdoSOCKSv5";
            this.rdoSOCKSv5.Size = new System.Drawing.Size(76, 17);
            this.rdoSOCKSv5.TabIndex = 23;
            this.rdoSOCKSv5.TabStop = true;
            this.rdoSOCKSv5.Text = "SOCKS v5";
            this.rdoSOCKSv5.UseVisualStyleBackColor = true;
            // 
            // rdoSOCKSv4
            // 
            this.rdoSOCKSv4.AutoSize = true;
            this.rdoSOCKSv4.Location = new System.Drawing.Point(3, 3);
            this.rdoSOCKSv4.Name = "rdoSOCKSv4";
            this.rdoSOCKSv4.Size = new System.Drawing.Size(76, 17);
            this.rdoSOCKSv4.TabIndex = 22;
            this.rdoSOCKSv4.TabStop = true;
            this.rdoSOCKSv4.Text = "SOCKS v4";
            this.rdoSOCKSv4.UseVisualStyleBackColor = true;
            // 
            // lblSOCKSProxyPort
            // 
            this.lblSOCKSProxyPort.AutoSize = true;
            this.lblSOCKSProxyPort.Location = new System.Drawing.Point(413, 117);
            this.lblSOCKSProxyPort.Name = "lblSOCKSProxyPort";
            this.lblSOCKSProxyPort.Size = new System.Drawing.Size(29, 13);
            this.lblSOCKSProxyPort.TabIndex = 56;
            this.lblSOCKSProxyPort.Text = "Port:";
            // 
            // lblFTPProxyPort
            // 
            this.lblFTPProxyPort.AutoSize = true;
            this.lblFTPProxyPort.Location = new System.Drawing.Point(413, 91);
            this.lblFTPProxyPort.Name = "lblFTPProxyPort";
            this.lblFTPProxyPort.Size = new System.Drawing.Size(29, 13);
            this.lblFTPProxyPort.TabIndex = 55;
            this.lblFTPProxyPort.Text = "Port:";
            // 
            // numSOCKSProxyPort
            // 
            this.numSOCKSProxyPort.Location = new System.Drawing.Point(448, 114);
            this.numSOCKSProxyPort.Name = "numSOCKSProxyPort";
            this.numSOCKSProxyPort.Size = new System.Drawing.Size(120, 20);
            this.numSOCKSProxyPort.TabIndex = 54;
            this.numSOCKSProxyPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSOCKSProxyPort.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // txtSOCKSProxy
            // 
            this.txtSOCKSProxy.Location = new System.Drawing.Point(105, 114);
            this.txtSOCKSProxy.Name = "txtSOCKSProxy";
            this.txtSOCKSProxy.Size = new System.Drawing.Size(302, 20);
            this.txtSOCKSProxy.TabIndex = 53;
            // 
            // lblSOCKSProxy
            // 
            this.lblSOCKSProxy.Location = new System.Drawing.Point(7, 117);
            this.lblSOCKSProxy.Name = "lblSOCKSProxy";
            this.lblSOCKSProxy.Size = new System.Drawing.Size(92, 23);
            this.lblSOCKSProxy.TabIndex = 52;
            this.lblSOCKSProxy.Text = "SOCKS Proxy:";
            this.lblSOCKSProxy.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numFTPProxyPort
            // 
            this.numFTPProxyPort.Location = new System.Drawing.Point(448, 88);
            this.numFTPProxyPort.Name = "numFTPProxyPort";
            this.numFTPProxyPort.Size = new System.Drawing.Size(120, 20);
            this.numFTPProxyPort.TabIndex = 51;
            this.numFTPProxyPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numFTPProxyPort.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // txtFTPProxy
            // 
            this.txtFTPProxy.Location = new System.Drawing.Point(105, 88);
            this.txtFTPProxy.Name = "txtFTPProxy";
            this.txtFTPProxy.Size = new System.Drawing.Size(302, 20);
            this.txtFTPProxy.TabIndex = 50;
            // 
            // lblFTPProxy
            // 
            this.lblFTPProxy.Location = new System.Drawing.Point(7, 91);
            this.lblFTPProxy.Name = "lblFTPProxy";
            this.lblFTPProxy.Size = new System.Drawing.Size(92, 23);
            this.lblFTPProxy.TabIndex = 49;
            this.lblFTPProxy.Text = "FTP Proxy:";
            this.lblFTPProxy.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numSSLProxyPort
            // 
            this.numSSLProxyPort.Location = new System.Drawing.Point(448, 62);
            this.numSSLProxyPort.Name = "numSSLProxyPort";
            this.numSSLProxyPort.Size = new System.Drawing.Size(120, 20);
            this.numSSLProxyPort.TabIndex = 48;
            this.numSSLProxyPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numSSLProxyPort.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // lblSSLProxyPort
            // 
            this.lblSSLProxyPort.AutoSize = true;
            this.lblSSLProxyPort.Location = new System.Drawing.Point(413, 65);
            this.lblSSLProxyPort.Name = "lblSSLProxyPort";
            this.lblSSLProxyPort.Size = new System.Drawing.Size(29, 13);
            this.lblSSLProxyPort.TabIndex = 47;
            this.lblSSLProxyPort.Text = "Port:";
            // 
            // txtSSLProxy
            // 
            this.txtSSLProxy.Location = new System.Drawing.Point(105, 62);
            this.txtSSLProxy.Name = "txtSSLProxy";
            this.txtSSLProxy.Size = new System.Drawing.Size(302, 20);
            this.txtSSLProxy.TabIndex = 46;
            // 
            // lblSSLProxy
            // 
            this.lblSSLProxy.Location = new System.Drawing.Point(7, 65);
            this.lblSSLProxy.Name = "lblSSLProxy";
            this.lblSSLProxy.Size = new System.Drawing.Size(92, 23);
            this.lblSSLProxy.TabIndex = 45;
            this.lblSSLProxy.Text = "SSL Proxy:";
            this.lblSSLProxy.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkAllProtocols
            // 
            this.chkAllProtocols.AutoSize = true;
            this.chkAllProtocols.Location = new System.Drawing.Point(108, 39);
            this.chkAllProtocols.Name = "chkAllProtocols";
            this.chkAllProtocols.Size = new System.Drawing.Size(172, 17);
            this.chkAllProtocols.TabIndex = 44;
            this.chkAllProtocols.Text = "[Use this proxy for all protocols]";
            this.chkAllProtocols.UseVisualStyleBackColor = true;
            // 
            // numHttpProxyPort
            // 
            this.numHttpProxyPort.Location = new System.Drawing.Point(448, 12);
            this.numHttpProxyPort.Name = "numHttpProxyPort";
            this.numHttpProxyPort.Size = new System.Drawing.Size(120, 20);
            this.numHttpProxyPort.TabIndex = 43;
            this.numHttpProxyPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numHttpProxyPort.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // lblHttpProxyPort
            // 
            this.lblHttpProxyPort.AutoSize = true;
            this.lblHttpProxyPort.Location = new System.Drawing.Point(413, 15);
            this.lblHttpProxyPort.Name = "lblHttpProxyPort";
            this.lblHttpProxyPort.Size = new System.Drawing.Size(29, 13);
            this.lblHttpProxyPort.TabIndex = 42;
            this.lblHttpProxyPort.Text = "Port:";
            // 
            // txtHttpProxy
            // 
            this.txtHttpProxy.Location = new System.Drawing.Point(105, 12);
            this.txtHttpProxy.Name = "txtHttpProxy";
            this.txtHttpProxy.Size = new System.Drawing.Size(302, 20);
            this.txtHttpProxy.TabIndex = 41;
            // 
            // lblHttpProxy
            // 
            this.lblHttpProxy.Location = new System.Drawing.Point(7, 15);
            this.lblHttpProxy.Name = "lblHttpProxy";
            this.lblHttpProxy.Size = new System.Drawing.Size(92, 23);
            this.lblHttpProxy.TabIndex = 40;
            this.lblHttpProxy.Text = "HTTP Proxy:";
            this.lblHttpProxy.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // rdoManualProxy
            // 
            this.rdoManualProxy.AutoSize = true;
            this.rdoManualProxy.Location = new System.Drawing.Point(8, 69);
            this.rdoManualProxy.Name = "rdoManualProxy";
            this.rdoManualProxy.Size = new System.Drawing.Size(158, 17);
            this.rdoManualProxy.TabIndex = 2;
            this.rdoManualProxy.TabStop = true;
            this.rdoManualProxy.Text = "[Manual proxy configuration]";
            this.rdoManualProxy.UseVisualStyleBackColor = true;
            // 
            // rdoSystemProxy
            // 
            this.rdoSystemProxy.AutoSize = true;
            this.rdoSystemProxy.Location = new System.Drawing.Point(8, 45);
            this.rdoSystemProxy.Name = "rdoSystemProxy";
            this.rdoSystemProxy.Size = new System.Drawing.Size(152, 17);
            this.rdoSystemProxy.TabIndex = 1;
            this.rdoSystemProxy.TabStop = true;
            this.rdoSystemProxy.Text = "[Use system proxy settings]";
            this.rdoSystemProxy.UseVisualStyleBackColor = true;
            // 
            // rdoNoProxy
            // 
            this.rdoNoProxy.AutoSize = true;
            this.rdoNoProxy.Location = new System.Drawing.Point(8, 21);
            this.rdoNoProxy.Name = "rdoNoProxy";
            this.rdoNoProxy.Size = new System.Drawing.Size(73, 17);
            this.rdoNoProxy.TabIndex = 0;
            this.rdoNoProxy.TabStop = true;
            this.rdoNoProxy.Text = "[No proxy]";
            this.rdoNoProxy.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(412, 427);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "[Save]";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(518, 427);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "[Cancel]";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabAutoEnable
            // 
            this.tabAutoEnable.Controls.Add(this.groupBox1);
            this.tabAutoEnable.Location = new System.Drawing.Point(4, 22);
            this.tabAutoEnable.Name = "tabAutoEnable";
            this.tabAutoEnable.Size = new System.Drawing.Size(602, 384);
            this.tabAutoEnable.TabIndex = 2;
            this.tabAutoEnable.Text = "[Auto Enable]";
            this.tabAutoEnable.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(590, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 462);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbcSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSettings";
            this.ShowInTaskbar = false;
            this.Text = "[Settings]";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.tbcSettings.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.grpLoadFile.ResumeLayout(false);
            this.grpLoadFile.PerformLayout();
            this.grpAutoUpdate.ResumeLayout(false);
            this.grpAutoUpdate.PerformLayout();
            this.tabProxy.ResumeLayout(false);
            this.grpProxyAuthentication.ResumeLayout(false);
            this.grpProxyAuthentication.PerformLayout();
            this.grpProxy.ResumeLayout(false);
            this.grpProxy.PerformLayout();
            this.pnlProxySettings.ResumeLayout(false);
            this.pnlProxySettings.PerformLayout();
            this.pnlSOCKS.ResumeLayout(false);
            this.pnlSOCKS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSOCKSProxyPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFTPProxyPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSSLProxyPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHttpProxyPort)).EndInit();
            this.tabAutoEnable.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcSettings;
        private System.Windows.Forms.TabPage tabGeneral;
        private System.Windows.Forms.GroupBox grpLoadFile;
        private System.Windows.Forms.RadioButton rdoMusicVideo;
        private System.Windows.Forms.RadioButton rdoMovie;
        private System.Windows.Forms.RadioButton rdoTVShow;
        private System.Windows.Forms.RadioButton rdoPrompt;
        private System.Windows.Forms.GroupBox grpAutoUpdate;
        private System.Windows.Forms.CheckBox chkAutoUpdateError;
        private System.Windows.Forms.CheckBox chkAutoUpdate;
        private System.Windows.Forms.TabPage tabProxy;
        private System.Windows.Forms.GroupBox grpProxyAuthentication;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.RadioButton rdoManualLogin;
        private System.Windows.Forms.RadioButton rdoWindowsLogin;
        private System.Windows.Forms.GroupBox grpProxy;
        private System.Windows.Forms.RadioButton rdoManualProxy;
        private System.Windows.Forms.RadioButton rdoSystemProxy;
        private System.Windows.Forms.RadioButton rdoNoProxy;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlProxySettings;
        private System.Windows.Forms.NumericUpDown numSOCKSProxyPort;
        private System.Windows.Forms.TextBox txtSOCKSProxy;
        private System.Windows.Forms.Label lblSOCKSProxy;
        private System.Windows.Forms.NumericUpDown numFTPProxyPort;
        private System.Windows.Forms.TextBox txtFTPProxy;
        private System.Windows.Forms.Label lblFTPProxy;
        private System.Windows.Forms.NumericUpDown numSSLProxyPort;
        private System.Windows.Forms.Label lblSSLProxyPort;
        private System.Windows.Forms.TextBox txtSSLProxy;
        private System.Windows.Forms.Label lblSSLProxy;
        private System.Windows.Forms.CheckBox chkAllProtocols;
        private System.Windows.Forms.NumericUpDown numHttpProxyPort;
        private System.Windows.Forms.Label lblHttpProxyPort;
        private System.Windows.Forms.TextBox txtHttpProxy;
        private System.Windows.Forms.Label lblHttpProxy;
        private System.Windows.Forms.Panel pnlSOCKS;
        private System.Windows.Forms.RadioButton rdoSOCKSv5;
        private System.Windows.Forms.RadioButton rdoSOCKSv4;
        private System.Windows.Forms.Label lblSOCKSProxyPort;
        private System.Windows.Forms.Label lblFTPProxyPort;
        private System.Windows.Forms.TabPage tabAutoEnable;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}