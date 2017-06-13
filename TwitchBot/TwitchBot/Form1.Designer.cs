﻿namespace TwitchBot
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
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Custom Commands");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Commands", new System.Windows.Forms.TreeNode[] {
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
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("!who");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("!schedule");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("!points");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("!commandlist");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Custom Commands");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Whisper Commands", new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18});
            this.BotChatBox = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CommandSpamTimer = new System.Windows.Forms.Timer(this.components);
            this.ViewerBox = new System.Windows.Forms.ListBox();
            this.viewerListLabel = new System.Windows.Forms.Label();
            this.ViewerBoxTimer = new System.Windows.Forms.Timer(this.components);
            this.LoyaltyPointTimer = new System.Windows.Forms.Timer(this.components);
            this.tabSettings = new System.Windows.Forms.TabPage();
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
            this.tabSupport = new System.Windows.Forms.TabPage();
            this.feedbackBox = new System.Windows.Forms.RichTextBox();
            this.crashesTextBox = new System.Windows.Forms.RichTextBox();
            this.Crashes = new System.Windows.Forms.Label();
            this.Feedback = new System.Windows.Forms.Label();
            this.TOSlabel = new System.Windows.Forms.Label();
            this.TOStextbox = new System.Windows.Forms.TextBox();
            this.tabSettings.SuspendLayout();
            this.tabChat.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabWelcome.SuspendLayout();
            this.tabCommands.SuspendLayout();
            this.tabSupport.SuspendLayout();
            this.SuspendLayout();
            // 
            // BotChatBox
            // 
            this.BotChatBox.Location = new System.Drawing.Point(3, 262);
            this.BotChatBox.Name = "BotChatBox";
            this.BotChatBox.Size = new System.Drawing.Size(350, 37);
            this.BotChatBox.TabIndex = 1;
            this.BotChatBox.Text = "";
            this.BotChatBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BotChatBox_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(359, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 37);
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
            this.ViewerBox.Location = new System.Drawing.Point(427, 26);
            this.ViewerBox.Name = "ViewerBox";
            this.ViewerBox.Size = new System.Drawing.Size(151, 264);
            this.ViewerBox.TabIndex = 3;
            this.ViewerBox.SelectedIndexChanged += new System.EventHandler(this.ViewerBox_SelectedIndexChanged);
            // 
            // viewerListLabel
            // 
            this.viewerListLabel.AutoSize = true;
            this.viewerListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewerListLabel.Location = new System.Drawing.Point(424, 7);
            this.viewerListLabel.Name = "viewerListLabel";
            this.viewerListLabel.Size = new System.Drawing.Size(63, 16);
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
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(726, 302);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // streamerCommandListCheckBox
            // 
            this.streamerCommandListCheckBox.AutoSize = true;
            this.streamerCommandListCheckBox.Checked = true;
            this.streamerCommandListCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.streamerCommandListCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.streamerCommandListCheckBox.Location = new System.Drawing.Point(11, 227);
            this.streamerCommandListCheckBox.Name = "streamerCommandListCheckBox";
            this.streamerCommandListCheckBox.Size = new System.Drawing.Size(158, 17);
            this.streamerCommandListCheckBox.TabIndex = 14;
            this.streamerCommandListCheckBox.Text = "Streamer Command List";
            this.streamerCommandListCheckBox.UseVisualStyleBackColor = true;
            this.streamerCommandListCheckBox.CheckedChanged += new System.EventHandler(this.streamerCommandListCheckBox_CheckedChanged);
            this.streamerCommandListCheckBox.MouseEnter += new System.EventHandler(this.streamerCommandListCheckBox_MouseEnter);
            this.streamerCommandListCheckBox.MouseLeave += new System.EventHandler(this.streamerCommandListCheckBox_MouseLeave);
            // 
            // addBannedWord
            // 
            this.addBannedWord.Location = new System.Drawing.Point(161, 46);
            this.addBannedWord.Name = "addBannedWord";
            this.addBannedWord.Size = new System.Drawing.Size(110, 23);
            this.addBannedWord.TabIndex = 13;
            this.addBannedWord.Text = "Add Word";
            this.addBannedWord.UseVisualStyleBackColor = true;
            this.addBannedWord.Click += new System.EventHandler(this.addBannedWord_Click);
            // 
            // settingsDescBox
            // 
            this.settingsDescBox.Location = new System.Drawing.Point(278, 7);
            this.settingsDescBox.Multiline = true;
            this.settingsDescBox.Name = "settingsDescBox";
            this.settingsDescBox.ReadOnly = true;
            this.settingsDescBox.Size = new System.Drawing.Size(440, 289);
            this.settingsDescBox.TabIndex = 12;
            // 
            // viewerCheckBox
            // 
            this.viewerCheckBox.AutoSize = true;
            this.viewerCheckBox.Checked = true;
            this.viewerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.viewerCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewerCheckBox.Location = new System.Drawing.Point(11, 203);
            this.viewerCheckBox.Name = "viewerCheckBox";
            this.viewerCheckBox.Size = new System.Drawing.Size(88, 17);
            this.viewerCheckBox.TabIndex = 11;
            this.viewerCheckBox.Text = "Viewer List";
            this.viewerCheckBox.UseVisualStyleBackColor = true;
            this.viewerCheckBox.CheckedChanged += new System.EventHandler(this.viewerCheckBox_CheckedChanged);
            this.viewerCheckBox.MouseEnter += new System.EventHandler(this.viewerCheckBox_MouseEnter);
            this.viewerCheckBox.MouseLeave += new System.EventHandler(this.viewerCheckBox_MouseLeave);
            // 
            // unbanWordButton
            // 
            this.unbanWordButton.Location = new System.Drawing.Point(161, 203);
            this.unbanWordButton.Name = "unbanWordButton";
            this.unbanWordButton.Size = new System.Drawing.Size(111, 23);
            this.unbanWordButton.TabIndex = 10;
            this.unbanWordButton.Text = "Remove Word";
            this.unbanWordButton.UseVisualStyleBackColor = true;
            this.unbanWordButton.Click += new System.EventHandler(this.unbanWordButton_Click);
            // 
            // bannedWordsListBox
            // 
            this.bannedWordsListBox.FormattingEnabled = true;
            this.bannedWordsListBox.Location = new System.Drawing.Point(161, 75);
            this.bannedWordsListBox.Name = "bannedWordsListBox";
            this.bannedWordsListBox.Size = new System.Drawing.Size(111, 121);
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
            this.PointSystemCheckBox.Location = new System.Drawing.Point(11, 179);
            this.PointSystemCheckBox.Name = "PointSystemCheckBox";
            this.PointSystemCheckBox.Size = new System.Drawing.Size(99, 17);
            this.PointSystemCheckBox.TabIndex = 8;
            this.PointSystemCheckBox.Text = "Point System";
            this.PointSystemCheckBox.UseVisualStyleBackColor = true;
            this.PointSystemCheckBox.CheckedChanged += new System.EventHandler(this.PointSystemCheckBox_CheckedChanged);
            this.PointSystemCheckBox.MouseEnter += new System.EventHandler(this.PointSystemCheckBox_MouseEnter);
            this.PointSystemCheckBox.MouseLeave += new System.EventHandler(this.PointSystemCheckBox_MouseLeave);
            // 
            // scheduleMessageBox
            // 
            this.scheduleMessageBox.Location = new System.Drawing.Point(11, 127);
            this.scheduleMessageBox.Name = "scheduleMessageBox";
            this.scheduleMessageBox.Size = new System.Drawing.Size(133, 46);
            this.scheduleMessageBox.TabIndex = 7;
            this.scheduleMessageBox.Text = "";
            this.scheduleMessageBox.TextChanged += new System.EventHandler(this.scheduleMessageBox_TextChanged);
            this.scheduleMessageBox.MouseEnter += new System.EventHandler(this.scheduleMessageBox_MouseEnter);
            this.scheduleMessageBox.MouseLeave += new System.EventHandler(this.scheduleMessageBox_MouseLeave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "!schedule Message";
            // 
            // whoMessageBox
            // 
            this.whoMessageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.whoMessageBox.Location = new System.Drawing.Point(11, 58);
            this.whoMessageBox.Name = "whoMessageBox";
            this.whoMessageBox.Size = new System.Drawing.Size(133, 50);
            this.whoMessageBox.TabIndex = 5;
            this.whoMessageBox.Text = "";
            this.whoMessageBox.TextChanged += new System.EventHandler(this.whoMessageBox_TextChanged);
            this.whoMessageBox.MouseEnter += new System.EventHandler(this.whoMessageBox_MouseEnter);
            this.whoMessageBox.MouseLeave += new System.EventHandler(this.whoMessageBox_MouseLeave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "!who Message";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(157, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Banned Words";
            // 
            // bannedWordsBox
            // 
            this.bannedWordsBox.Location = new System.Drawing.Point(160, 19);
            this.bannedWordsBox.Name = "bannedWordsBox";
            this.bannedWordsBox.Size = new System.Drawing.Size(111, 20);
            this.bannedWordsBox.TabIndex = 2;
            this.bannedWordsBox.Text = "";
            this.bannedWordsBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.bannedWordsBox_KeyUp);
            this.bannedWordsBox.MouseEnter += new System.EventHandler(this.bannedWordsBox_MouseEnter);
            this.bannedWordsBox.MouseLeave += new System.EventHandler(this.bannedWordsBox_MouseLeave);
            // 
            // channelNameBox
            // 
            this.channelNameBox.Location = new System.Drawing.Point(11, 19);
            this.channelNameBox.Name = "channelNameBox";
            this.channelNameBox.Size = new System.Drawing.Size(133, 20);
            this.channelNameBox.TabIndex = 1;
            this.channelNameBox.Text = "theaviationbot";
            this.channelNameBox.TextChanged += new System.EventHandler(this.channelNameBox_TextChanged);
            this.channelNameBox.MouseEnter += new System.EventHandler(this.channelNameBox_MouseEnter);
            this.channelNameBox.MouseLeave += new System.EventHandler(this.channelNameBox_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
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
            this.tabChat.Location = new System.Drawing.Point(4, 22);
            this.tabChat.Name = "tabChat";
            this.tabChat.Padding = new System.Windows.Forms.Padding(3);
            this.tabChat.Size = new System.Drawing.Size(726, 302);
            this.tabChat.TabIndex = 0;
            this.tabChat.Text = "Chat";
            // 
            // viewerPointsLabel
            // 
            this.viewerPointsLabel.AutoSize = true;
            this.viewerPointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewerPointsLabel.Location = new System.Drawing.Point(585, 7);
            this.viewerPointsLabel.Name = "viewerPointsLabel";
            this.viewerPointsLabel.Size = new System.Drawing.Size(102, 16);
            this.viewerPointsLabel.TabIndex = 6;
            this.viewerPointsLabel.Text = "Viewer Points";
            // 
            // viewerPointsBox
            // 
            this.viewerPointsBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.viewerPointsBox.Location = new System.Drawing.Point(588, 26);
            this.viewerPointsBox.Multiline = true;
            this.viewerPointsBox.Name = "viewerPointsBox";
            this.viewerPointsBox.ReadOnly = true;
            this.viewerPointsBox.Size = new System.Drawing.Size(130, 98);
            this.viewerPointsBox.TabIndex = 5;
            // 
            // chatBox
            // 
            this.chatBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatBox.Location = new System.Drawing.Point(6, 6);
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(412, 250);
            this.chatBox.TabIndex = 0;
            this.chatBox.Text = "";
            this.chatBox.TextChanged += new System.EventHandler(this.chatBox_TextChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabWelcome);
            this.tabControl1.Controls.Add(this.tabChat);
            this.tabControl1.Controls.Add(this.tabCommands);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Controls.Add(this.tabSupport);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(734, 328);
            this.tabControl1.TabIndex = 5;
            // 
            // tabWelcome
            // 
            this.tabWelcome.Controls.Add(this.welcomeTextBox);
            this.tabWelcome.Location = new System.Drawing.Point(4, 22);
            this.tabWelcome.Name = "tabWelcome";
            this.tabWelcome.Size = new System.Drawing.Size(726, 302);
            this.tabWelcome.TabIndex = 5;
            this.tabWelcome.Text = "Welcome";
            this.tabWelcome.UseVisualStyleBackColor = true;
            // 
            // welcomeTextBox
            // 
            this.welcomeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.welcomeTextBox.Location = new System.Drawing.Point(0, 0);
            this.welcomeTextBox.Multiline = true;
            this.welcomeTextBox.Name = "welcomeTextBox";
            this.welcomeTextBox.ReadOnly = true;
            this.welcomeTextBox.Size = new System.Drawing.Size(726, 302);
            this.welcomeTextBox.TabIndex = 0;
            this.welcomeTextBox.Text = resources.GetString("welcomeTextBox.Text");
            // 
            // tabCommands
            // 
            this.tabCommands.Controls.Add(this.CommandsTreeView);
            this.tabCommands.Controls.Add(this.CommandsTextBox);
            this.tabCommands.Location = new System.Drawing.Point(4, 22);
            this.tabCommands.Name = "tabCommands";
            this.tabCommands.Size = new System.Drawing.Size(726, 302);
            this.tabCommands.TabIndex = 3;
            this.tabCommands.Text = "Commands";
            this.tabCommands.UseVisualStyleBackColor = true;
            // 
            // CommandsTreeView
            // 
            this.CommandsTreeView.Location = new System.Drawing.Point(3, 4);
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
            treeNode12.Name = "Custom Commands";
            treeNode12.Text = "Custom Commands";
            treeNode13.Name = "Commands";
            treeNode13.Text = "Commands";
            treeNode14.Name = "WHISPER!who";
            treeNode14.Text = "!who";
            treeNode15.Name = "WHISPER!schedule";
            treeNode15.Text = "!schedule";
            treeNode16.Name = "WHISPER!points";
            treeNode16.Text = "!points";
            treeNode17.Name = "WHISPER!commandlist";
            treeNode17.Text = "!commandlist";
            treeNode18.Name = "WHISPERCustom Commands";
            treeNode18.Text = "Custom Commands";
            treeNode19.Name = "Whisper Commands";
            treeNode19.Text = "Whisper Commands";
            this.CommandsTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode19});
            this.CommandsTreeView.Size = new System.Drawing.Size(353, 288);
            this.CommandsTreeView.TabIndex = 2;
            this.CommandsTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.CommandsTreeView_NodeMouseClick);
            // 
            // CommandsTextBox
            // 
            this.CommandsTextBox.Location = new System.Drawing.Point(362, 4);
            this.CommandsTextBox.Name = "CommandsTextBox";
            this.CommandsTextBox.ReadOnly = true;
            this.CommandsTextBox.Size = new System.Drawing.Size(356, 288);
            this.CommandsTextBox.TabIndex = 1;
            this.CommandsTextBox.Text = "A brief description of the selected command will be displayed here.";
            // 
            // tabSupport
            // 
            this.tabSupport.Controls.Add(this.TOStextbox);
            this.tabSupport.Controls.Add(this.TOSlabel);
            this.tabSupport.Controls.Add(this.feedbackBox);
            this.tabSupport.Controls.Add(this.crashesTextBox);
            this.tabSupport.Controls.Add(this.Crashes);
            this.tabSupport.Controls.Add(this.Feedback);
            this.tabSupport.Location = new System.Drawing.Point(4, 22);
            this.tabSupport.Name = "tabSupport";
            this.tabSupport.Size = new System.Drawing.Size(726, 302);
            this.tabSupport.TabIndex = 4;
            this.tabSupport.Text = "Support";
            this.tabSupport.UseVisualStyleBackColor = true;
            // 
            // feedbackBox
            // 
            this.feedbackBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.feedbackBox.Location = new System.Drawing.Point(370, 20);
            this.feedbackBox.Name = "feedbackBox";
            this.feedbackBox.ReadOnly = true;
            this.feedbackBox.Size = new System.Drawing.Size(348, 149);
            this.feedbackBox.TabIndex = 4;
            this.feedbackBox.Text = "Do you have an amazing idea for the bot or want to help us refine how the bot wor" +
    "ks?\n\nPlease send an email to aviationbot@gmail.com. We would love to here from y" +
    "ou!";
            // 
            // crashesTextBox
            // 
            this.crashesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.crashesTextBox.Location = new System.Drawing.Point(6, 20);
            this.crashesTextBox.Name = "crashesTextBox";
            this.crashesTextBox.ReadOnly = true;
            this.crashesTextBox.Size = new System.Drawing.Size(345, 268);
            this.crashesTextBox.TabIndex = 3;
            this.crashesTextBox.Text = resources.GetString("crashesTextBox.Text");
            // 
            // Crashes
            // 
            this.Crashes.AutoSize = true;
            this.Crashes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Crashes.Location = new System.Drawing.Point(104, 1);
            this.Crashes.Name = "Crashes";
            this.Crashes.Size = new System.Drawing.Size(140, 16);
            this.Crashes.TabIndex = 2;
            this.Crashes.Text = "Crashes or Issues?";
            // 
            // Feedback
            // 
            this.Feedback.AutoSize = true;
            this.Feedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Feedback.Location = new System.Drawing.Point(423, 1);
            this.Feedback.Name = "Feedback";
            this.Feedback.Size = new System.Drawing.Size(237, 16);
            this.Feedback.TabIndex = 1;
            this.Feedback.Text = "Feedback or Recommendations?";
            // 
            // TOSlabel
            // 
            this.TOSlabel.AutoSize = true;
            this.TOSlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TOSlabel.Location = new System.Drawing.Point(482, 174);
            this.TOSlabel.Name = "TOSlabel";
            this.TOSlabel.Size = new System.Drawing.Size(126, 16);
            this.TOSlabel.TabIndex = 5;
            this.TOSlabel.Text = "Terms of Service";
            // 
            // TOStextbox
            // 
            this.TOStextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TOStextbox.Location = new System.Drawing.Point(370, 193);
            this.TOStextbox.Multiline = true;
            this.TOStextbox.Name = "TOStextbox";
            this.TOStextbox.ReadOnly = true;
            this.TOStextbox.Size = new System.Drawing.Size(348, 95);
            this.TOStextbox.TabIndex = 6;
            this.TOStextbox.Text = resources.GetString("TOStextbox.Text");
            // 
            // TheAVIATIONBot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 327);
            this.Controls.Add(this.tabControl1);
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
    }
}

