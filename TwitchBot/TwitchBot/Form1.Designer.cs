namespace TwitchBot
{
    partial class TheAVIATIONBot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TheAVIATIONBot));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("!who");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("!schedule");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("!addcom");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("!editcom");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("!remcom");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("!points");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("!reward");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("!charge");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("!commandlist");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("!banword");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("!unbanword");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("!social");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("!shoutout");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("!quote");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("!addquote");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Custom Commands");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Commands", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("!who");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("!schedule");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("!points");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("!commandlist");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("!stats");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Custom Commands");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Whisper Commands", new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23});
            this.BotChatBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CommandSpamTimer = new System.Windows.Forms.Timer(this.components);
            this.ViewerBox = new System.Windows.Forms.ListBox();
            this.viewerListLabel = new System.Windows.Forms.Label();
            this.ViewerBoxTimer = new System.Windows.Forms.Timer(this.components);
            this.LoyaltyPointTimer = new System.Windows.Forms.Timer(this.components);
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.socialMessageUpdateButton = new System.Windows.Forms.Button();
            this.scheduleMessageUpdateButton = new System.Windows.Forms.Button();
            this.whoMessageUpdateButton = new System.Windows.Forms.Button();
            this.channelNameUpdateButton = new System.Windows.Forms.Button();
            this.rejoinChannelButton = new System.Windows.Forms.Button();
            this.joinChannelButton = new System.Windows.Forms.Button();
            this.socialMessageLabel = new System.Windows.Forms.Label();
            this.socialMessageTextBox = new System.Windows.Forms.RichTextBox();
            this.socialCommandCheckBox = new System.Windows.Forms.CheckBox();
            this.streamerCommandListCheckBox = new System.Windows.Forms.CheckBox();
            this.addBannedWord = new System.Windows.Forms.Button();
            this.settingsDescBox = new System.Windows.Forms.TextBox();
            this.viewerCheckBox = new System.Windows.Forms.CheckBox();
            this.unbanWordButton = new System.Windows.Forms.Button();
            this.bannedWordsListBox = new System.Windows.Forms.ListBox();
            this.PointSystemCheckBox = new System.Windows.Forms.CheckBox();
            this.scheduleMessageBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.whoMessageBox = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bannedWordsBox = new System.Windows.Forms.RichTextBox();
            this.channelNameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabChat = new System.Windows.Forms.TabPage();
            this.viewerPointsLabel = new System.Windows.Forms.Label();
            this.viewerPointsBox = new System.Windows.Forms.TextBox();
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabWelcome = new System.Windows.Forms.TabPage();
            this.welcomeTextBox = new System.Windows.Forms.TextBox();
            this.tabCommands = new System.Windows.Forms.TabPage();
            this.CommandsTreeView = new System.Windows.Forms.TreeView();
            this.CommandsTextBox = new System.Windows.Forms.RichTextBox();
            this.tabQuote = new System.Windows.Forms.TabPage();
            this.quoteListBox = new System.Windows.Forms.ListBox();
            this.quoteAddButton = new System.Windows.Forms.Button();
            this.quoteAddBox = new System.Windows.Forms.TextBox();
            this.tabSupport = new System.Windows.Forms.TabPage();
            this.TOStextbox = new System.Windows.Forms.TextBox();
            this.TOSlabel = new System.Windows.Forms.Label();
            this.feedbackBox = new System.Windows.Forms.RichTextBox();
            this.crashesTextBox = new System.Windows.Forms.RichTextBox();
            this.Crashes = new System.Windows.Forms.Label();
            this.Feedback = new System.Windows.Forms.Label();
            this.socialMessageTimer = new System.Windows.Forms.Timer(this.components);
            this.tabSettings.SuspendLayout();
            this.tabChat.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabWelcome.SuspendLayout();
            this.tabCommands.SuspendLayout();
            this.tabQuote.SuspendLayout();
            this.tabSupport.SuspendLayout();
            this.SuspendLayout();
            // 
            // BotChatBox
            // 
            this.BotChatBox.Location = new System.Drawing.Point(4, 322);
            this.BotChatBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BotChatBox.Name = "BotChatBox";
            this.BotChatBox.Size = new System.Drawing.Size(465, 45);
            this.BotChatBox.TabIndex = 1;
            this.BotChatBox.Text = "";
            this.BotChatBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BotChatBox_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(479, 322);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 46);
            this.button1.TabIndex = 2;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CommandSpamTimer
            // 
            this.CommandSpamTimer.Interval = 1000;
            this.CommandSpamTimer.Tick += new System.EventHandler(this.CommandSpamTimer_Tick);
            // 
            // ViewerBox
            // 
            this.ViewerBox.FormattingEnabled = true;
            this.ViewerBox.ItemHeight = 16;
            this.ViewerBox.Location = new System.Drawing.Point(569, 32);
            this.ViewerBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ViewerBox.Name = "ViewerBox";
            this.ViewerBox.Size = new System.Drawing.Size(200, 324);
            this.ViewerBox.TabIndex = 3;
            this.ViewerBox.SelectedIndexChanged += new System.EventHandler(this.ViewerBox_SelectedIndexChanged);
            // 
            // viewerListLabel
            // 
            this.viewerListLabel.AutoSize = true;
            this.viewerListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewerListLabel.Location = new System.Drawing.Point(565, 9);
            this.viewerListLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.viewerListLabel.Name = "viewerListLabel";
            this.viewerListLabel.Size = new System.Drawing.Size(76, 20);
            this.viewerListLabel.TabIndex = 4;
            this.viewerListLabel.Text = "Viewers";
            // 
            // ViewerBoxTimer
            // 
            this.ViewerBoxTimer.Interval = 180000;
            this.ViewerBoxTimer.Tick += new System.EventHandler(this.ViewerBoxTimer_Tick);
            // 
            // LoyaltyPointTimer
            // 
            this.LoyaltyPointTimer.Interval = 60000;
            this.LoyaltyPointTimer.Tick += new System.EventHandler(this.LoyaltyPointTimer_Tick);
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.socialMessageUpdateButton);
            this.tabSettings.Controls.Add(this.scheduleMessageUpdateButton);
            this.tabSettings.Controls.Add(this.whoMessageUpdateButton);
            this.tabSettings.Controls.Add(this.channelNameUpdateButton);
            this.tabSettings.Controls.Add(this.rejoinChannelButton);
            this.tabSettings.Controls.Add(this.joinChannelButton);
            this.tabSettings.Controls.Add(this.socialMessageLabel);
            this.tabSettings.Controls.Add(this.socialMessageTextBox);
            this.tabSettings.Controls.Add(this.socialCommandCheckBox);
            this.tabSettings.Controls.Add(this.streamerCommandListCheckBox);
            this.tabSettings.Controls.Add(this.addBannedWord);
            this.tabSettings.Controls.Add(this.settingsDescBox);
            this.tabSettings.Controls.Add(this.viewerCheckBox);
            this.tabSettings.Controls.Add(this.unbanWordButton);
            this.tabSettings.Controls.Add(this.bannedWordsListBox);
            this.tabSettings.Controls.Add(this.PointSystemCheckBox);
            this.tabSettings.Controls.Add(this.scheduleMessageBox);
            this.tabSettings.Controls.Add(this.label5);
            this.tabSettings.Controls.Add(this.whoMessageBox);
            this.tabSettings.Controls.Add(this.label4);
            this.tabSettings.Controls.Add(this.label3);
            this.tabSettings.Controls.Add(this.bannedWordsBox);
            this.tabSettings.Controls.Add(this.channelNameBox);
            this.tabSettings.Controls.Add(this.label2);
            this.tabSettings.Location = new System.Drawing.Point(4, 25);
            this.tabSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabSettings.Size = new System.Drawing.Size(971, 375);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // socialMessageUpdateButton
            // 
            this.socialMessageUpdateButton.Location = new System.Drawing.Point(197, 236);
            this.socialMessageUpdateButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.socialMessageUpdateButton.Name = "socialMessageUpdateButton";
            this.socialMessageUpdateButton.Size = new System.Drawing.Size(71, 28);
            this.socialMessageUpdateButton.TabIndex = 23;
            this.socialMessageUpdateButton.Text = "Update";
            this.socialMessageUpdateButton.UseVisualStyleBackColor = true;
            this.socialMessageUpdateButton.Click += new System.EventHandler(this.socialMessageUpdateButton_Click);
            // 
            // scheduleMessageUpdateButton
            // 
            this.scheduleMessageUpdateButton.Location = new System.Drawing.Point(197, 156);
            this.scheduleMessageUpdateButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scheduleMessageUpdateButton.Name = "scheduleMessageUpdateButton";
            this.scheduleMessageUpdateButton.Size = new System.Drawing.Size(71, 28);
            this.scheduleMessageUpdateButton.TabIndex = 22;
            this.scheduleMessageUpdateButton.Text = "Update";
            this.scheduleMessageUpdateButton.UseVisualStyleBackColor = true;
            this.scheduleMessageUpdateButton.Click += new System.EventHandler(this.scheduleMessageUpdateButton_Click);
            // 
            // whoMessageUpdateButton
            // 
            this.whoMessageUpdateButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.whoMessageUpdateButton.Location = new System.Drawing.Point(197, 71);
            this.whoMessageUpdateButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.whoMessageUpdateButton.Name = "whoMessageUpdateButton";
            this.whoMessageUpdateButton.Size = new System.Drawing.Size(71, 28);
            this.whoMessageUpdateButton.TabIndex = 21;
            this.whoMessageUpdateButton.Text = "Update";
            this.whoMessageUpdateButton.UseVisualStyleBackColor = true;
            this.whoMessageUpdateButton.Click += new System.EventHandler(this.whoMessageUpdateButton_Click);
            // 
            // channelNameUpdateButton
            // 
            this.channelNameUpdateButton.Location = new System.Drawing.Point(197, 22);
            this.channelNameUpdateButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.channelNameUpdateButton.Name = "channelNameUpdateButton";
            this.channelNameUpdateButton.Size = new System.Drawing.Size(71, 27);
            this.channelNameUpdateButton.TabIndex = 20;
            this.channelNameUpdateButton.Text = "Update";
            this.channelNameUpdateButton.UseVisualStyleBackColor = true;
            this.channelNameUpdateButton.Click += new System.EventHandler(this.channelNameUpdateButton_Click);
            // 
            // rejoinChannelButton
            // 
            this.rejoinChannelButton.Location = new System.Drawing.Point(15, 336);
            this.rejoinChannelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rejoinChannelButton.Name = "rejoinChannelButton";
            this.rejoinChannelButton.Size = new System.Drawing.Size(100, 28);
            this.rejoinChannelButton.TabIndex = 19;
            this.rejoinChannelButton.Text = "Rejoin Channel";
            this.rejoinChannelButton.UseVisualStyleBackColor = true;
            this.rejoinChannelButton.Click += new System.EventHandler(this.rejoinChannelButton_Click);
            // 
            // joinChannelButton
            // 
            this.joinChannelButton.Location = new System.Drawing.Point(15, 304);
            this.joinChannelButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.joinChannelButton.Name = "joinChannelButton";
            this.joinChannelButton.Size = new System.Drawing.Size(100, 28);
            this.joinChannelButton.TabIndex = 18;
            this.joinChannelButton.Text = "Join Channel";
            this.joinChannelButton.UseVisualStyleBackColor = true;
            this.joinChannelButton.Click += new System.EventHandler(this.joinChannelButton_Click);
            // 
            // socialMessageLabel
            // 
            this.socialMessageLabel.AutoSize = true;
            this.socialMessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.socialMessageLabel.Location = new System.Drawing.Point(11, 217);
            this.socialMessageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.socialMessageLabel.Name = "socialMessageLabel";
            this.socialMessageLabel.Size = new System.Drawing.Size(123, 17);
            this.socialMessageLabel.TabIndex = 17;
            this.socialMessageLabel.Text = "!social Message";
            // 
            // socialMessageTextBox
            // 
            this.socialMessageTextBox.Location = new System.Drawing.Point(15, 236);
            this.socialMessageTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.socialMessageTextBox.Name = "socialMessageTextBox";
            this.socialMessageTextBox.Size = new System.Drawing.Size(176, 59);
            this.socialMessageTextBox.TabIndex = 16;
            this.socialMessageTextBox.Text = "";
            this.socialMessageTextBox.MouseEnter += new System.EventHandler(this.socialMessageTextBox_MouseEnter);
            this.socialMessageTextBox.MouseLeave += new System.EventHandler(this.socialMessageTextBox_MouseLeave);
            // 
            // socialCommandCheckBox
            // 
            this.socialCommandCheckBox.AutoSize = true;
            this.socialCommandCheckBox.Checked = true;
            this.socialCommandCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.socialCommandCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.socialCommandCheckBox.Location = new System.Drawing.Point(288, 270);
            this.socialCommandCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.socialCommandCheckBox.Name = "socialCommandCheckBox";
            this.socialCommandCheckBox.Size = new System.Drawing.Size(197, 21);
            this.socialCommandCheckBox.TabIndex = 15;
            this.socialCommandCheckBox.Text = "!social Command Timer";
            this.socialCommandCheckBox.UseVisualStyleBackColor = true;
            this.socialCommandCheckBox.CheckedChanged += new System.EventHandler(this.socialCommandCheckBox_CheckedChanged);
            this.socialCommandCheckBox.MouseEnter += new System.EventHandler(this.socialCommandCheckBox_MouseEnter);
            this.socialCommandCheckBox.MouseLeave += new System.EventHandler(this.socialCommandCheckBox_MouseLeave);
            // 
            // streamerCommandListCheckBox
            // 
            this.streamerCommandListCheckBox.AutoSize = true;
            this.streamerCommandListCheckBox.Checked = true;
            this.streamerCommandListCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.streamerCommandListCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.streamerCommandListCheckBox.Location = new System.Drawing.Point(288, 298);
            this.streamerCommandListCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.streamerCommandListCheckBox.Name = "streamerCommandListCheckBox";
            this.streamerCommandListCheckBox.Size = new System.Drawing.Size(202, 21);
            this.streamerCommandListCheckBox.TabIndex = 14;
            this.streamerCommandListCheckBox.Text = "Streamer Command List";
            this.streamerCommandListCheckBox.UseVisualStyleBackColor = true;
            this.streamerCommandListCheckBox.CheckedChanged += new System.EventHandler(this.streamerCommandListCheckBox_CheckedChanged);
            this.streamerCommandListCheckBox.MouseEnter += new System.EventHandler(this.streamerCommandListCheckBox_MouseEnter);
            this.streamerCommandListCheckBox.MouseLeave += new System.EventHandler(this.streamerCommandListCheckBox_MouseLeave);
            // 
            // addBannedWord
            // 
            this.addBannedWord.Location = new System.Drawing.Point(441, 20);
            this.addBannedWord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addBannedWord.Name = "addBannedWord";
            this.addBannedWord.Size = new System.Drawing.Size(87, 28);
            this.addBannedWord.TabIndex = 13;
            this.addBannedWord.Text = "Add Word";
            this.addBannedWord.UseVisualStyleBackColor = true;
            this.addBannedWord.Click += new System.EventHandler(this.addBannedWord_Click);
            // 
            // settingsDescBox
            // 
            this.settingsDescBox.Location = new System.Drawing.Point(576, -1);
            this.settingsDescBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.settingsDescBox.Multiline = true;
            this.settingsDescBox.Name = "settingsDescBox";
            this.settingsDescBox.ReadOnly = true;
            this.settingsDescBox.Size = new System.Drawing.Size(391, 372);
            this.settingsDescBox.TabIndex = 12;
            // 
            // viewerCheckBox
            // 
            this.viewerCheckBox.AutoSize = true;
            this.viewerCheckBox.Checked = true;
            this.viewerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewerCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewerCheckBox.Location = new System.Drawing.Point(288, 241);
            this.viewerCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.viewerCheckBox.Name = "viewerCheckBox";
            this.viewerCheckBox.Size = new System.Drawing.Size(109, 21);
            this.viewerCheckBox.TabIndex = 11;
            this.viewerCheckBox.Text = "Viewer List";
            this.viewerCheckBox.UseVisualStyleBackColor = true;
            this.viewerCheckBox.CheckedChanged += new System.EventHandler(this.viewerCheckBox_CheckedChanged);
            this.viewerCheckBox.MouseEnter += new System.EventHandler(this.viewerCheckBox_MouseEnter);
            this.viewerCheckBox.MouseLeave += new System.EventHandler(this.viewerCheckBox_MouseLeave);
            // 
            // unbanWordButton
            // 
            this.unbanWordButton.Location = new System.Drawing.Point(441, 52);
            this.unbanWordButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.unbanWordButton.Name = "unbanWordButton";
            this.unbanWordButton.Size = new System.Drawing.Size(113, 28);
            this.unbanWordButton.TabIndex = 10;
            this.unbanWordButton.Text = "Remove Word";
            this.unbanWordButton.UseVisualStyleBackColor = true;
            this.unbanWordButton.Click += new System.EventHandler(this.unbanWordButton_Click);
            // 
            // bannedWordsListBox
            // 
            this.bannedWordsListBox.FormattingEnabled = true;
            this.bannedWordsListBox.ItemHeight = 16;
            this.bannedWordsListBox.Location = new System.Drawing.Point(288, 52);
            this.bannedWordsListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bannedWordsListBox.Name = "bannedWordsListBox";
            this.bannedWordsListBox.Size = new System.Drawing.Size(147, 148);
            this.bannedWordsListBox.TabIndex = 9;
            this.bannedWordsListBox.MouseEnter += new System.EventHandler(this.bannedWordsListBox_MouseEnter);
            this.bannedWordsListBox.MouseLeave += new System.EventHandler(this.bannedWordsListBox_MouseLeave);
            // 
            // PointSystemCheckBox
            // 
            this.PointSystemCheckBox.AutoSize = true;
            this.PointSystemCheckBox.Checked = true;
            this.PointSystemCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PointSystemCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PointSystemCheckBox.Location = new System.Drawing.Point(288, 213);
            this.PointSystemCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PointSystemCheckBox.Name = "PointSystemCheckBox";
            this.PointSystemCheckBox.Size = new System.Drawing.Size(124, 21);
            this.PointSystemCheckBox.TabIndex = 8;
            this.PointSystemCheckBox.Text = "Point System";
            this.PointSystemCheckBox.UseVisualStyleBackColor = true;
            this.PointSystemCheckBox.CheckedChanged += new System.EventHandler(this.PointSystemCheckBox_CheckedChanged);
            this.PointSystemCheckBox.MouseEnter += new System.EventHandler(this.PointSystemCheckBox_MouseEnter);
            this.PointSystemCheckBox.MouseLeave += new System.EventHandler(this.PointSystemCheckBox_MouseLeave);
            // 
            // scheduleMessageBox
            // 
            this.scheduleMessageBox.Location = new System.Drawing.Point(15, 156);
            this.scheduleMessageBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.scheduleMessageBox.Name = "scheduleMessageBox";
            this.scheduleMessageBox.Size = new System.Drawing.Size(176, 56);
            this.scheduleMessageBox.TabIndex = 7;
            this.scheduleMessageBox.Text = "";
            this.scheduleMessageBox.MouseEnter += new System.EventHandler(this.scheduleMessageBox_MouseEnter);
            this.scheduleMessageBox.MouseLeave += new System.EventHandler(this.scheduleMessageBox_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 137);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "!schedule Message";
            // 
            // whoMessageBox
            // 
            this.whoMessageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.whoMessageBox.Location = new System.Drawing.Point(15, 71);
            this.whoMessageBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.whoMessageBox.Name = "whoMessageBox";
            this.whoMessageBox.Size = new System.Drawing.Size(176, 61);
            this.whoMessageBox.TabIndex = 5;
            this.whoMessageBox.Text = "";
            this.whoMessageBox.MouseEnter += new System.EventHandler(this.whoMessageBox_MouseEnter);
            this.whoMessageBox.MouseLeave += new System.EventHandler(this.whoMessageBox_MouseLeave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "!who Message";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(284, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Banned Words";
            // 
            // bannedWordsBox
            // 
            this.bannedWordsBox.Location = new System.Drawing.Point(288, 23);
            this.bannedWordsBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bannedWordsBox.Name = "bannedWordsBox";
            this.bannedWordsBox.Size = new System.Drawing.Size(147, 24);
            this.bannedWordsBox.TabIndex = 2;
            this.bannedWordsBox.Text = "";
            this.bannedWordsBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bannedWordsBox_KeyUp);
            this.bannedWordsBox.MouseEnter += new System.EventHandler(this.bannedWordsBox_MouseEnter);
            this.bannedWordsBox.MouseLeave += new System.EventHandler(this.bannedWordsBox_MouseLeave);
            // 
            // channelNameBox
            // 
            this.channelNameBox.Location = new System.Drawing.Point(15, 23);
            this.channelNameBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.channelNameBox.Name = "channelNameBox";
            this.channelNameBox.Size = new System.Drawing.Size(176, 22);
            this.channelNameBox.TabIndex = 1;
            this.channelNameBox.Text = "theaviationbot";
            this.channelNameBox.MouseEnter += new System.EventHandler(this.channelNameBox_MouseEnter);
            this.channelNameBox.MouseLeave += new System.EventHandler(this.channelNameBox_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 4);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Channel";
            // 
            // tabChat
            // 
            this.tabChat.BackColor = System.Drawing.Color.Transparent;
            this.tabChat.Controls.Add(this.viewerPointsLabel);
            this.tabChat.Controls.Add(this.viewerPointsBox);
            this.tabChat.Controls.Add(this.chatBox);
            this.tabChat.Controls.Add(this.button1);
            this.tabChat.Controls.Add(this.ViewerBox);
            this.tabChat.Controls.Add(this.viewerListLabel);
            this.tabChat.Controls.Add(this.BotChatBox);
            this.tabChat.Location = new System.Drawing.Point(4, 25);
            this.tabChat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabChat.Name = "tabChat";
            this.tabChat.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabChat.Size = new System.Drawing.Size(971, 375);
            this.tabChat.TabIndex = 0;
            this.tabChat.Text = "Chat";
            // 
            // viewerPointsLabel
            // 
            this.viewerPointsLabel.AutoSize = true;
            this.viewerPointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewerPointsLabel.Location = new System.Drawing.Point(780, 9);
            this.viewerPointsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.viewerPointsLabel.Name = "viewerPointsLabel";
            this.viewerPointsLabel.Size = new System.Drawing.Size(125, 20);
            this.viewerPointsLabel.TabIndex = 6;
            this.viewerPointsLabel.Text = "Viewer Points";
            // 
            // viewerPointsBox
            // 
            this.viewerPointsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.viewerPointsBox.Location = new System.Drawing.Point(784, 32);
            this.viewerPointsBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.viewerPointsBox.Multiline = true;
            this.viewerPointsBox.Name = "viewerPointsBox";
            this.viewerPointsBox.ReadOnly = true;
            this.viewerPointsBox.Size = new System.Drawing.Size(173, 121);
            this.viewerPointsBox.TabIndex = 5;
            // 
            // chatBox
            // 
            this.chatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatBox.Location = new System.Drawing.Point(8, 7);
            this.chatBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(548, 307);
            this.chatBox.TabIndex = 0;
            this.chatBox.Text = "";
            this.chatBox.TextChanged += new System.EventHandler(this.chatBox_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabWelcome);
            this.tabControl1.Controls.Add(this.tabChat);
            this.tabControl1.Controls.Add(this.tabCommands);
            this.tabControl1.Controls.Add(this.tabQuote);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabSupport);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(979, 404);
            this.tabControl1.TabIndex = 5;
            // 
            // tabWelcome
            // 
            this.tabWelcome.Controls.Add(this.welcomeTextBox);
            this.tabWelcome.Location = new System.Drawing.Point(4, 25);
            this.tabWelcome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabWelcome.Name = "tabWelcome";
            this.tabWelcome.Size = new System.Drawing.Size(971, 375);
            this.tabWelcome.TabIndex = 5;
            this.tabWelcome.Text = "Welcome";
            this.tabWelcome.UseVisualStyleBackColor = true;
            // 
            // welcomeTextBox
            // 
            this.welcomeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.welcomeTextBox.Location = new System.Drawing.Point(0, 0);
            this.welcomeTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.welcomeTextBox.Multiline = true;
            this.welcomeTextBox.Name = "welcomeTextBox";
            this.welcomeTextBox.ReadOnly = true;
            this.welcomeTextBox.Size = new System.Drawing.Size(968, 372);
            this.welcomeTextBox.TabIndex = 0;
            this.welcomeTextBox.Text = resources.GetString("welcomeTextBox.Text");
            // 
            // tabCommands
            // 
            this.tabCommands.Controls.Add(this.CommandsTreeView);
            this.tabCommands.Controls.Add(this.CommandsTextBox);
            this.tabCommands.Location = new System.Drawing.Point(4, 25);
            this.tabCommands.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabCommands.Name = "tabCommands";
            this.tabCommands.Size = new System.Drawing.Size(971, 375);
            this.tabCommands.TabIndex = 3;
            this.tabCommands.Text = "Commands";
            this.tabCommands.UseVisualStyleBackColor = true;
            // 
            // CommandsTreeView
            // 
            this.CommandsTreeView.Location = new System.Drawing.Point(4, 5);
            this.CommandsTreeView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CommandsTreeView.Name = "CommandsTreeView";
            treeNode1.Name = "!who";
            treeNode1.Text = "!who";
            treeNode2.Name = "!schedule";
            treeNode2.Text = "!schedule";
            treeNode3.Name = "!addcom";
            treeNode3.Text = "!addcom";
            treeNode4.Name = "!editcom";
            treeNode4.Text = "!editcom";
            treeNode5.Name = "!remcom";
            treeNode5.Text = "!remcom";
            treeNode6.Name = "!points";
            treeNode6.Text = "!points";
            treeNode7.Name = "!reward";
            treeNode7.Text = "!reward";
            treeNode8.Name = "!charge";
            treeNode8.Text = "!charge";
            treeNode9.Name = "!commandlist";
            treeNode9.Text = "!commandlist";
            treeNode10.Name = "!banword";
            treeNode10.Text = "!banword";
            treeNode11.Name = "!unbanword";
            treeNode11.Text = "!unbanword";
            treeNode12.Name = "!social";
            treeNode12.Text = "!social";
            treeNode13.Name = "!shoutout";
            treeNode13.Text = "!shoutout";
            treeNode14.Name = "!quote";
            treeNode14.Text = "!quote";
            treeNode15.Name = "!addquote";
            treeNode15.Text = "!addquote";
            treeNode16.Name = "Custom Commands";
            treeNode16.Text = "Custom Commands";
            treeNode17.Name = "Commands";
            treeNode17.Text = "Commands";
            treeNode18.Name = "WHISPER!who";
            treeNode18.Text = "!who";
            treeNode19.Name = "WHISPER!schedule";
            treeNode19.Text = "!schedule";
            treeNode20.Name = "WHISPER!points";
            treeNode20.Text = "!points";
            treeNode21.Name = "WHISPER!commandlist";
            treeNode21.Text = "!commandlist";
            treeNode22.Name = "!stats";
            treeNode22.Text = "!stats";
            treeNode23.Name = "WHISPERCustom Commands";
            treeNode23.Text = "Custom Commands";
            treeNode24.Name = "Whisper Commands";
            treeNode24.Text = "Whisper Commands";
            this.CommandsTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode24});
            this.CommandsTreeView.Size = new System.Drawing.Size(469, 354);
            this.CommandsTreeView.TabIndex = 2;
            this.CommandsTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.CommandsTreeView_NodeMouseClick);
            // 
            // CommandsTextBox
            // 
            this.CommandsTextBox.Location = new System.Drawing.Point(483, 5);
            this.CommandsTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CommandsTextBox.Name = "CommandsTextBox";
            this.CommandsTextBox.ReadOnly = true;
            this.CommandsTextBox.Size = new System.Drawing.Size(473, 354);
            this.CommandsTextBox.TabIndex = 1;
            this.CommandsTextBox.Text = "A brief description of the selected command will be displayed here.";
            // 
            // tabQuote
            // 
            this.tabQuote.Controls.Add(this.quoteListBox);
            this.tabQuote.Controls.Add(this.quoteAddButton);
            this.tabQuote.Controls.Add(this.quoteAddBox);
            this.tabQuote.Location = new System.Drawing.Point(4, 25);
            this.tabQuote.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabQuote.Name = "tabQuote";
            this.tabQuote.Size = new System.Drawing.Size(971, 375);
            this.tabQuote.TabIndex = 6;
            this.tabQuote.Text = "Quotes";
            this.tabQuote.UseVisualStyleBackColor = true;
            // 
            // quoteListBox
            // 
            this.quoteListBox.FormattingEnabled = true;
            this.quoteListBox.ItemHeight = 16;
            this.quoteListBox.Location = new System.Drawing.Point(0, 0);
            this.quoteListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.quoteListBox.Name = "quoteListBox";
            this.quoteListBox.Size = new System.Drawing.Size(967, 340);
            this.quoteListBox.TabIndex = 4;
            // 
            // quoteAddButton
            // 
            this.quoteAddButton.Location = new System.Drawing.Point(11, 343);
            this.quoteAddButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.quoteAddButton.Name = "quoteAddButton";
            this.quoteAddButton.Size = new System.Drawing.Size(128, 26);
            this.quoteAddButton.TabIndex = 2;
            this.quoteAddButton.Text = "Add Quote";
            this.quoteAddButton.UseVisualStyleBackColor = true;
            this.quoteAddButton.Click += new System.EventHandler(this.quoteAddButton_Click);
            // 
            // quoteAddBox
            // 
            this.quoteAddBox.Location = new System.Drawing.Point(147, 343);
            this.quoteAddBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.quoteAddBox.Name = "quoteAddBox";
            this.quoteAddBox.Size = new System.Drawing.Size(816, 22);
            this.quoteAddBox.TabIndex = 1;
            // 
            // tabSupport
            // 
            this.tabSupport.Controls.Add(this.TOStextbox);
            this.tabSupport.Controls.Add(this.TOSlabel);
            this.tabSupport.Controls.Add(this.feedbackBox);
            this.tabSupport.Controls.Add(this.crashesTextBox);
            this.tabSupport.Controls.Add(this.Crashes);
            this.tabSupport.Controls.Add(this.Feedback);
            this.tabSupport.Location = new System.Drawing.Point(4, 25);
            this.tabSupport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabSupport.Name = "tabSupport";
            this.tabSupport.Size = new System.Drawing.Size(971, 375);
            this.tabSupport.TabIndex = 4;
            this.tabSupport.Text = "Support";
            this.tabSupport.UseVisualStyleBackColor = true;
            // 
            // TOStextbox
            // 
            this.TOStextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TOStextbox.Location = new System.Drawing.Point(493, 238);
            this.TOStextbox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TOStextbox.Multiline = true;
            this.TOStextbox.Name = "TOStextbox";
            this.TOStextbox.ReadOnly = true;
            this.TOStextbox.Size = new System.Drawing.Size(464, 117);
            this.TOStextbox.TabIndex = 6;
            this.TOStextbox.Text = resources.GetString("TOStextbox.Text");
            this.TOStextbox.Visible = false;
            // 
            // TOSlabel
            // 
            this.TOSlabel.AutoSize = true;
            this.TOSlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TOSlabel.Location = new System.Drawing.Point(643, 214);
            this.TOSlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TOSlabel.Name = "TOSlabel";
            this.TOSlabel.Size = new System.Drawing.Size(153, 20);
            this.TOSlabel.TabIndex = 5;
            this.TOSlabel.Text = "Terms of Service";
            this.TOSlabel.Visible = false;
            // 
            // feedbackBox
            // 
            this.feedbackBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.feedbackBox.Location = new System.Drawing.Point(493, 25);
            this.feedbackBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.feedbackBox.Name = "feedbackBox";
            this.feedbackBox.ReadOnly = true;
            this.feedbackBox.Size = new System.Drawing.Size(464, 183);
            this.feedbackBox.TabIndex = 4;
            this.feedbackBox.Text = "Do you have an amazing idea for the bot or want to help us refine how the bot wor" +
    "ks?\n\nPlease send an email to aviationbot@gmail.com. We would love to here from y" +
    "ou!";
            // 
            // crashesTextBox
            // 
            this.crashesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.crashesTextBox.Location = new System.Drawing.Point(8, 25);
            this.crashesTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.crashesTextBox.Name = "crashesTextBox";
            this.crashesTextBox.ReadOnly = true;
            this.crashesTextBox.Size = new System.Drawing.Size(460, 330);
            this.crashesTextBox.TabIndex = 3;
            this.crashesTextBox.Text = resources.GetString("crashesTextBox.Text");
            // 
            // Crashes
            // 
            this.Crashes.AutoSize = true;
            this.Crashes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Crashes.Location = new System.Drawing.Point(139, 1);
            this.Crashes.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Crashes.Name = "Crashes";
            this.Crashes.Size = new System.Drawing.Size(173, 20);
            this.Crashes.TabIndex = 2;
            this.Crashes.Text = "Crashes or Issues?";
            // 
            // Feedback
            // 
            this.Feedback.AutoSize = true;
            this.Feedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Feedback.Location = new System.Drawing.Point(564, 1);
            this.Feedback.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Feedback.Name = "Feedback";
            this.Feedback.Size = new System.Drawing.Size(282, 20);
            this.Feedback.TabIndex = 1;
            this.Feedback.Text = "Feedback or Recommendations?";
            // 
            // socialMessageTimer
            // 
            this.socialMessageTimer.Interval = 600000;
            this.socialMessageTimer.Tick += new System.EventHandler(this.socialMessageTimer_Tick);
            // 
            // TheAVIATIONBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 402);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TheAVIATIONBot";
            this.Text = "TheAVIATIONBot";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            this.tabChat.ResumeLayout(false);
            this.tabChat.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabWelcome.ResumeLayout(false);
            this.tabWelcome.PerformLayout();
            this.tabCommands.ResumeLayout(false);
            this.tabQuote.ResumeLayout(false);
            this.tabQuote.PerformLayout();
            this.tabSupport.ResumeLayout(false);
            this.tabSupport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox BotChatBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer CommandSpamTimer;
        private System.Windows.Forms.ListBox ViewerBox;
        private System.Windows.Forms.Label viewerListLabel;
        private System.Windows.Forms.Timer ViewerBoxTimer;
        private System.Windows.Forms.Timer LoyaltyPointTimer;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.TabPage tabChat;
        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCommands;
        private System.Windows.Forms.RichTextBox CommandsTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox bannedWordsBox;
        private System.Windows.Forms.TextBox channelNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox PointSystemCheckBox;
        private System.Windows.Forms.RichTextBox scheduleMessageBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox whoMessageBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TreeView CommandsTreeView;
        private System.Windows.Forms.ListBox bannedWordsListBox;
        private System.Windows.Forms.Button unbanWordButton;
        private System.Windows.Forms.TabPage tabSupport;
        private System.Windows.Forms.Label Crashes;
        private System.Windows.Forms.Label Feedback;
        private System.Windows.Forms.RichTextBox feedbackBox;
        private System.Windows.Forms.RichTextBox crashesTextBox;
        private System.Windows.Forms.CheckBox viewerCheckBox;
        private System.Windows.Forms.TabPage tabWelcome;
        private System.Windows.Forms.TextBox settingsDescBox;
        private System.Windows.Forms.Button addBannedWord;
        private System.Windows.Forms.TextBox welcomeTextBox;
        private System.Windows.Forms.TextBox viewerPointsBox;
        private System.Windows.Forms.Label viewerPointsLabel;
        private System.Windows.Forms.CheckBox streamerCommandListCheckBox;
        private System.Windows.Forms.TextBox TOStextbox;
        private System.Windows.Forms.Label TOSlabel;
        private System.Windows.Forms.Label socialMessageLabel;
        private System.Windows.Forms.RichTextBox socialMessageTextBox;
        private System.Windows.Forms.CheckBox socialCommandCheckBox;
        private System.Windows.Forms.Timer socialMessageTimer;
        private System.Windows.Forms.Button socialMessageUpdateButton;
        private System.Windows.Forms.Button scheduleMessageUpdateButton;
        private System.Windows.Forms.Button whoMessageUpdateButton;
        private System.Windows.Forms.Button channelNameUpdateButton;
        private System.Windows.Forms.Button rejoinChannelButton;
        private System.Windows.Forms.Button joinChannelButton;
        private System.Windows.Forms.TabPage tabQuote;
        private System.Windows.Forms.ListBox quoteListBox;
        private System.Windows.Forms.Button quoteAddButton;
        private System.Windows.Forms.TextBox quoteAddBox;
    }
}

