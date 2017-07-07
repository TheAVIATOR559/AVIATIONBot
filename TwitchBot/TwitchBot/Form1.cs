using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Media;
using System.Diagnostics;
using System.Xml;
using TwitchCSharp.Clients;
using TwitchCSharp.Models;

namespace TwitchBot
{
    public partial class TheAVIATIONBot : Form
    {
        #region Variables
        private static string botName = "theaviationbot";   //name of the bot
        private static string password = "oauth:ca71lcbh4ahwcssvgn1nko7idek3hu";    //oauth password required to connect to twitch chat
        private static string TwitchClientID = "dgluivxepk3wmyzyavgpt1rzjbja8x";    //client ID of the bot, necessary to distinguish from normal viewer
        public static string channelName = "theaviationbot";    //channel the bot will connect to. Default to self for safe initialization
        public static string whoMessage = "A brief description about yourself and your channel.";   //message about the user/channel. Used in the !who command
        public static string scheduleMessage = "Your streaming schedule.";  //user's streaming schedule. Used in the !schedule command
        public static List<string> bannedWordsList = new List<string>();     //list of words user wants banned from chat. 'Pauper consilio' added for safe initialization
        public static bool PointSystem = true;    //bool controlling the function of the Point System. User can enable/disable at runtime.
        public static bool viewerListVisible = true;    //bool controlling visibility of viewer list
        public static bool streamerCommandList = true;  //bool controlling detail level of !commandlist
        public static string socialMessage = "Your social connections like twitter, discord, youtube.";    //user's social connections. Used in !social command
        public static bool socialCommandTimer = true;
        public static string adminName = "theaviator559";
        public static int numberOfCustomCommands;
        public static int numberOfPolls;
        public static int numberOfGiveaways;
        public static int numberOfQuotes;
        public static int numberOfSounds;
        public static int numberOfBannedWords;
        public static int numberOfTimesOpened;
        public static Dictionary<int, string> quotesDict = new Dictionary<int, string>();
        public static string streamStartTime = "";

        TwitchReadOnlyClient APIClient = new TwitchReadOnlyClient(TwitchClientID);
        TwitchROChat chatClient = new TwitchROChat(TwitchClientID);

        IrcClient irc = new IrcClient("irc.chat.twitch.tv", 6667, botName, password);
        NetworkStream serverStream = default(NetworkStream);
        string readData = "";
        Thread chatThread;

        List<string> modList = new List<string>();  //list containing usernames of streamer and moderators
        List<string> viewerList = new List<string>();   //list containing usernames of viewers/staff/global mods/admins
        IniFile PointsIni = new IniFile(Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\")) + "Points.ini");   //ini file containing each viewer's points

        List<Command> commandList = new List<Command>();    //list containing custom commands the user has added
        List<string> commandListString = new List<string>();    //list of custom commands converted to strings. Used for saving custom commands between uses.
        
        bool commandSpamFilter = false;    //bool controlling if a command can be spammed in chat or not
        List<CommandSpamUser> commandSpamUsers = new List<CommandSpamUser>();   //list containing users who use a command. Used to prevent single user command spam

        #endregion

        #region Form Open/Close
        public TheAVIATIONBot()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Loads User Settings via XML
            XmlDocument settings = new XmlDocument();
            try
            {
                settings.Load(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\") + "settings.xml");
                channelNameBox.Text = settings.SelectSingleNode("Settings/Channel_Name/text()").InnerText.Trim();
                channelName = settings.SelectSingleNode("Settings/Channel_Name/text()").InnerText.Trim();
                whoMessageBox.Text = settings.SelectSingleNode("Settings/Who_Message/text()").InnerText.Trim();
                whoMessage = settings.SelectSingleNode("Settings/Who_Message/text()").InnerText.Trim();
                scheduleMessageBox.Text = settings.SelectSingleNode("Settings/Schedule_Message/text()").InnerText.Trim();
                scheduleMessage = settings.SelectSingleNode("Settings/Schedule_Message/text()").InnerText.Trim();
                PointSystemCheckBox.Checked = XmlConvert.ToBoolean(settings.SelectSingleNode("Settings/Point_System/text()").InnerText.Trim());
                PointSystem = XmlConvert.ToBoolean(settings.SelectSingleNode("Settings/Point_System/text()").InnerText.Trim());
                viewerListVisible = XmlConvert.ToBoolean(settings.SelectSingleNode("Settings/Viewer_List_Visible/text()").InnerText.Trim());
                viewerCheckBox.Checked = XmlConvert.ToBoolean(settings.SelectSingleNode("Settings/Viewer_List_Visible/text()").InnerText.Trim());
                socialMessage = settings.SelectSingleNode("Settings/Social_Message/text()").InnerText.Trim();
                socialMessageTextBox.Text = settings.SelectSingleNode("Settings/Social_Message/text()").InnerText.Trim();
                socialMessageTimer.Enabled = XmlConvert.ToBoolean(settings.SelectSingleNode("Settings/Social_Message_Timer/text()").InnerText.Trim());
                streamerCommandList = XmlConvert.ToBoolean(settings.SelectSingleNode("Settings/Streamer_Command_List/text()").InnerText.Trim());
                streamerCommandListCheckBox.Checked = XmlConvert.ToBoolean(settings.SelectSingleNode("Settings/Streamer_Command_List/text()").InnerText.Trim());
                numberOfPolls = XmlConvert.ToInt32(settings.SelectSingleNode("Settings/Number_of_Polls/text()").InnerText.Trim());
                numberOfGiveaways = XmlConvert.ToInt32(settings.SelectSingleNode("Settings/Number_of_Giveaways/text()").InnerText.Trim());
                numberOfTimesOpened = XmlConvert.ToInt32(settings.SelectSingleNode("Settings/Number_of_Times_Opened/text()").InnerText.Trim());

                XmlNodeList bannedWords = settings.SelectNodes("Settings/Banned_Words/Word");
                foreach (XmlNode word in bannedWords)
                {
                    bannedWordsList.Add(word.InnerText.Trim());
                }

                XmlNodeList commands = settings.SelectNodes("Settings/Commands/Command");
                foreach (XmlNode comm in commands)
                {
                    CommandLoading(comm.InnerText.Trim());
                }

                XmlNodeList quotes = settings.SelectNodes("Settings/Quotes/Quote");
                foreach(XmlNode quote in quotes)
                {
                    int quoteKey = XmlConvert.ToInt32(quote.Attributes["Number"].Value);
                    quotesDict.Add(quoteKey, quote.InnerText.Trim());
                }
            }
            catch
            {
                XmlNode rootNode = settings.CreateElement("Settings");
                settings.AppendChild(rootNode);

                XmlNode channelNameNode = settings.CreateElement("Channel_Name");
                channelNameNode.InnerText = channelName;
                rootNode.AppendChild(channelNameNode);

                XmlNode whoMessageNode = settings.CreateElement("Who_Message");
                whoMessageNode.InnerText = whoMessage;
                rootNode.AppendChild(whoMessageNode);

                XmlNode scheduleMessageNode = settings.CreateElement("Schedule_Message");
                scheduleMessageNode.InnerText = scheduleMessage;
                rootNode.AppendChild(scheduleMessageNode);

                XmlNode bannedWordsNode = settings.CreateElement("Banned_Words");
                rootNode.AppendChild(bannedWordsNode);

                XmlNode commandsNode = settings.CreateElement("Commands");
                rootNode.AppendChild(commandsNode);

                XmlNode socialMessageNode = settings.CreateElement("Social_Message");
                socialMessageNode.InnerText = socialMessage;
                rootNode.AppendChild(socialMessageNode);

                XmlNode numberofPollsNode = settings.CreateElement("Number_of_Polls");
                numberofPollsNode.InnerText = numberOfPolls.ToString();
                rootNode.AppendChild(numberofPollsNode);

                XmlNode numberofGiveawaysNode = settings.CreateElement("Number_of_Giveaways");
                numberofGiveawaysNode.InnerText = numberOfGiveaways.ToString();
                rootNode.AppendChild(numberofGiveawaysNode);

                XmlNode numberofTimesOpenedNode = settings.CreateElement("Number_of_Times_Opened");
                numberofTimesOpenedNode.InnerText = numberOfTimesOpened.ToString();
                rootNode.AppendChild(numberofTimesOpenedNode);

                XmlNode pointSystemNode = settings.CreateElement("Point_System");
                pointSystemNode.InnerText = PointSystem.ToString().ToLower();
                rootNode.AppendChild(pointSystemNode);

                XmlNode viewerListVisibleNode = settings.CreateElement("Viewer_List_Visible");
                viewerListVisibleNode.InnerText = viewerListVisible.ToString().ToLower();
                rootNode.AppendChild(viewerListVisibleNode);

                XmlNode streamerCommandListNode = settings.CreateElement("Streamer_Command_List");
                streamerCommandListNode.InnerText = streamerCommandList.ToString().ToLower();
                rootNode.AppendChild(streamerCommandListNode);

                XmlNode socialMessageTimerNode = settings.CreateElement("Social_Message_Timer");
                socialMessageTimerNode.InnerText = socialCommandTimer.ToString().ToLower();
                rootNode.AppendChild(socialMessageTimerNode);

                XmlNode quotesNode = settings.CreateElement("Quotes");
                rootNode.AppendChild(quotesNode);

                settings.Save(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\") + "settings.xml");
            }
            #endregion

            //join channel and begin timers
            irc.joinRoom(channelName);
            chatThread = new Thread(getMessage);
            chatThread.Start();
            CommandSpamTimer.Start();
            viewerListUpdate();
            ViewerBoxTimer.Start();
            ViewerBoxTimer_Tick(null, null);
            socialMessageTimer.Start();

            //add words from list to client display
            foreach (string word in bannedWordsList)
            {
                bannedWordsListBox.Items.Add(word);
            }

            //loads quotes into the quoteListBox
            foreach (KeyValuePair<int, string> quote in quotesDict)
            {
                quoteListBox.Items.Add(quote.Key + " -- " + quote.Value);
            }

            //comfirmation of successfully joining channel
            numberOfTimesOpened++;
            irc.sendChatMessage("/me has joined the channel.");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //notification of leaving channel
            irc.sendChatMessage("/me has left the channel.");

            #region Saving user Settings via XML
            XmlDocument settingsDoc = new XmlDocument();
            settingsDoc.Load(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\") + "settings.xml");

            settingsDoc.SelectSingleNode("Settings/Channel_Name/text()").InnerText = channelName;
            settingsDoc.SelectSingleNode("Settings/Who_Message/text()").InnerText = whoMessage;
            settingsDoc.SelectSingleNode("Settings/Schedule_Message/text()").InnerText = scheduleMessage;

            XmlNode bannedWordsNode = settingsDoc.SelectSingleNode("Settings/Banned_Words");
            bannedWordsNode.RemoveAll();
            foreach(string word in bannedWordsList)
            {
                XmlNode wordNode = settingsDoc.CreateElement("Word");
                wordNode.InnerText = word;
                bannedWordsNode.AppendChild(wordNode);
            }

            XmlNode commandsNode = settingsDoc.SelectSingleNode("Settings/Commands");
            commandsNode.RemoveAll();
            foreach(Command comm in commandList)
            {
                XmlNode commandNode = settingsDoc.CreateElement("Command");
                commandNode.InnerText = comm.Save();
                commandsNode.AppendChild(commandNode);
            }

            settingsDoc.SelectSingleNode("Settings/Social_Message/text()").InnerText = socialMessage;
            settingsDoc.SelectSingleNode("Settings/Number_of_Polls/text()").InnerText = numberOfPolls.ToString();
            settingsDoc.SelectSingleNode("Settings/Number_of_Giveaways/text()").InnerText = numberOfGiveaways.ToString();
            settingsDoc.SelectSingleNode("Settings/Number_of_Times_Opened/text()").InnerText = numberOfTimesOpened.ToString();
            settingsDoc.SelectSingleNode("Settings/Point_System/text()").InnerText = PointSystem.ToString().ToLower();
            settingsDoc.SelectSingleNode("Settings/Viewer_List_Visible/text()").InnerText = viewerListVisible.ToString().ToLower();
            settingsDoc.SelectSingleNode("Settings/Streamer_Command_List/text()").InnerText = streamerCommandList.ToString().ToLower();
            settingsDoc.SelectSingleNode("Settings/Social_Message_Timer/text()").InnerText = socialCommandTimer.ToString().ToLower();

            XmlNode quotesNode = settingsDoc.SelectSingleNode("Settings/Quotes");
            quotesNode.RemoveAll();
            foreach(KeyValuePair<int, string> quote in quotesDict)
            {
                XmlNode quoteNode = settingsDoc.CreateElement("Quote");
                XmlAttribute attribute = settingsDoc.CreateAttribute("Number");
                attribute.Value = quote.Key.ToString();
                quoteNode.Attributes.Append(attribute);
                quoteNode.InnerText = quote.Value;
                quotesNode.AppendChild(quoteNode);
            }

            settingsDoc.Save(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\") + "settings.xml");
            #endregion

            //leave channel and close client
            irc.leaveRoom();
            serverStream.Dispose();
            Environment.Exit(0);
        }
        #endregion

        #region Message Handling
        private void getMessage()
        {
            serverStream = irc.tcpClient.GetStream();
            int buffSize = 0;
            byte[] inStream = new byte[10025];
            buffSize = irc.tcpClient.ReceiveBufferSize;

            while (true)
            {
                try
                {
                    readData = irc.readMessage();
                    msg();
                }
                catch (Exception e)
                {

                }
            }
        }

        private void msg()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(msg));
            }
            else
            {
                chatBox.Text = chatBox.Text + readData.ToString() + Environment.NewLine;  //shows everything that happens in chat

                //separators to segment message into useful parts
                string[] separator = new string[] { "#" + channelNameBox.Text + " :" };
                string[] whisperSeparator = new string[] { botName + " :" };
                string[] singleSep = new string[] { ":", "!" };

                //getting the room id
                if(readData.Contains("room-id"))
                {
                    string[] roomIDSep = new string[] { "room-id=" };

                    string temp = readData.Split(roomIDSep, StringSplitOptions.None)[1];
                    int semiColonLoc = temp.IndexOf(";");
                    int stringEndLoc = temp.Length - semiColonLoc;
                    string roomID = temp.Remove(semiColonLoc, stringEndLoc);

                    irc.getStartTime(roomID);
                }

                //chat messages
                if (readData.Contains("PRIVMSG"))
                {
                    string userName = readData.Split(singleSep, StringSplitOptions.None)[1];
                    string message = readData.Split(separator, StringSplitOptions.None)[1];

                    //if the message is a command
                    if (message[0] == '!')
                    {
                        commands(userName, message);
                    }

                    //if anyone not in modList says a banned word
                    if(!modList.Contains(userName))
                    {
                        if (BannedWordFilter(userName, message))
                        {
                            return;
                        }
                    }
                    
                    //displays each message to the client chat
                    chatBox.Text = chatBox.Text + userName + " : " + message + Environment.NewLine;

                    int num = chatBox.Lines.Count();
                    if(chatBox.Lines.Count() > 51)
                    {
                        var foos = new List<string>(chatBox.Lines);
                        foos.RemoveAt(0);
                        chatBox.Lines = foos.ToArray();
                    }

                }

                //if a whisper is received
                if(readData.Contains("WHISPER"))
                {
                    string userName = readData.Split(singleSep, StringSplitOptions.None)[1];
                    string message = readData.Split(whisperSeparator, StringSplitOptions.None)[1];

                    //if the whisper contains a command
                    if(message[0] == '!')
                    {
                        whisperCommands(userName, message);
                    }
                    else
                    {
                        irc.sendWhisper(userName, "MrDestructoid I am a bot. That means that your messages are not read by a human and therefore will only respond with this message. MrDestructoid");
                    }

                    //displays whispers to client chat
                    chatBox.Text = chatBox.Text + "W> " + userName + " whispers " + botName + " : " + message + Environment.NewLine;
                    int num = chatBox.Lines.Count();
                    if (chatBox.Lines.Count() > 51)
                    {
                        var foos = new List<string>(chatBox.Lines);
                        foos.RemoveAt(0);
                        chatBox.Lines = foos.ToArray();
                    }
                }

                //Twitch ping response
                if (readData.Contains("PING"))
                {
                    irc.PingResponse();
                }
            }
        }
        #endregion

        #region Commands and Whispers
        private void commands(string username, string message)
        {
            //splits the command and forces to lower case
            string command = message.Split(new[] { ' ', '!' }, StringSplitOptions.None)[1];     //!command parameter1 parameter2 etc
            command = command.ToLower();

            #region !who
            if (command == "who")    //!who  ::  A brief description of who the user is and what their channel is about.
            {
                irc.sendChatMessage(whoMessage);
            }
            #endregion

            #region !schedule
            else if (command == "schedule")  //!schedule  ::  The users streaming schedule
            {
                irc.sendChatMessage(scheduleMessage);
            }
            #endregion

            #region !addcom
            else if (command == "addcom")    //!addcom name permlevel outputmessage  ::  allows the user to add custom commands
            {
                //only moderators and the streamer/user can use this command
                if (modList.Contains(username))
                {
                    //splits the message into command name, permission level, and output message
                    string commandName = message.Split(new string[] { " " }, StringSplitOptions.None)[1];
                    string permLevelString = message.Split(new string[] { " " }, StringSplitOptions.None)[2];
                    int spaceLocation = message.IndexOf(permLevelString);
                    spaceLocation += permLevelString.Length + 1;
                    string outputMessage = message.Substring(spaceLocation);
                    permLevelString = permLevelString.ToUpper();

                    AddCommand(commandName, outputMessage, permLevelString);
                }
            }
            #endregion

            #region !remcom
            else if (command == "remcom")    //!remcom name  ::  Allows the user to remove a custom command
            {
                //only moderators and the streamer/user can use this command
                if (modList.Contains(username))
                {
                    //splits the command to remove from the message and removes it
                    string commandName = message.Split(new string[] { " " }, StringSplitOptions.None)[1];

                    RemoveCommand(commandName);
                }
            }
            #endregion

            #region !editcom
            else if (command == "editcom")   //!editcom name newoutput  ::  Allows the user to edit a custom command
            {
                //only moderators and the streamer/user can use this command
                if (modList.Contains(username))
                {
                    //splits the message into command to edit and what to change to output to
                    string commandName = message.Split(new string[] { " " }, StringSplitOptions.None)[1];
                    int spaceLocation = message.IndexOf(commandName);
                    spaceLocation += commandName.Length + 1;
                    string newOutputMessage = message.Substring(spaceLocation);

                    EditCommand(commandName, newOutputMessage);
                }
            }
            #endregion

            #region !reward
            else if (command == "reward")    //!reward name amount  ::  Part of the Point System. Allows the user to add a specified number of points to a viewer
            {
                //if the Point System is enabled
                if (PointSystem)
                {
                    //only moderators and the streamer/user can use this command
                    if (modList.Contains(username))
                    {
                        string recipent = message.Split(new string[] { " " }, StringSplitOptions.None)[1];

                        //prevents adding points to self
                        if (recipent == username)
                        {
                            return;
                        }

                        //if user adds '@' before specified recipient
                        if (recipent[0] == '@')
                        {
                            recipent = recipent.Split(new[] { '@' }, StringSplitOptions.None)[1];
                        }

                        //splits message into points to add and checks if value is valid
                        string pointsToTransferString = message.Split(new string[] { " " }, StringSplitOptions.None)[2];
                        double pointsToTransfer = 0;
                        bool validNumber = double.TryParse(pointsToTransferString.Split(new[] { ' ' }, StringSplitOptions.None)[0], out pointsToTransfer);

                        if (!validNumber)
                        {
                            irc.sendChatMessage("That is not a valid number of points.");
                        }

                        //prevents recipient from having negative points
                        if (pointsToTransfer > 0)
                        {
                            AddPoints(recipent, pointsToTransfer);
                            irc.sendChatMessage(recipent + " has been awarded " + pointsToTransfer + " points.");
                        }
                    }
                }
            }
            #endregion

            #region !charge
            else if (command == "charge")    //!charge name amount  ::  Allows the user to deduct a specified number of points from a viewer
            {
                //if the Point System is enabled
                if (PointSystem)
                {
                    //only moderators and the streamer/user can use this command
                    if (modList.Contains(username))
                    {
                        //prevents user from deducting points from themself
                        string recipent = message.Split(new string[] { " " }, StringSplitOptions.None)[1];
                        if (recipent == username)
                        {
                            return;
                        }

                        //removes '@' if it is before recipient
                        if (recipent[0] == '@')
                        {
                            recipent = recipent.Split(new[] { '@' }, StringSplitOptions.None)[1];
                        }

                        //grabs points to deduct from message and checks if value is valid
                        string pointsToTransferString = message.Split(new string[] { " " }, StringSplitOptions.None)[2];
                        double pointsToTransfer = 0;
                        bool validNumber = double.TryParse(pointsToTransferString.Split(new[] { ' ' }, StringSplitOptions.None)[0], out pointsToTransfer);

                        if (!validNumber)
                        {
                            irc.sendChatMessage("That is not a valid number of points.");
                        }

                        //prevents recpient from having negative points
                        if (pointsToTransfer > 0)
                        {
                            AddPoints(recipent, -pointsToTransfer);
                            irc.sendChatMessage(recipent + " has been charged " + pointsToTransfer + " points.");
                        }
                    }
                }
            }
            #endregion

            #region !points
            else if (command == "points")    //!points  ::  Allows the user to see how many points they have
            {
                //if the Point System is enabled
                if (PointSystem)
                {
                    //prevents this command from being spammed
                    if (!commandSpamFilter)
                    {
                        foreach (CommandSpamUser singleUser in commandSpamUsers)
                        {
                            if (username == singleUser.userName)
                            {
                                return;
                            }
                        }

                        commandSpamFilter = true;

                        #region Single User Command Spam Prevention
                        CommandSpamUser user = new CommandSpamUser();
                        user.userName = username;
                        user.timeOfMessage = DateTime.Now;
                        commandSpamUsers.Add(user);
                        #endregion

                        //finds the user's point value and returns that number to the user
                        string yourPoints = PointsIni.IniReadValue("#" + channelNameBox.Text + "." + username, "Points");
                        if (yourPoints == "")
                        {
                            yourPoints = "0";
                            AddPoints(username, 0);
                            irc.sendChatMessage(username + " has no points.");
                        }
                        else
                        {
                            irc.sendChatMessage(username + " has " + yourPoints + " points.");
                        }
                    }
                }
            }
            #endregion

            #region !social
            else if (command == "social")    //!social  ::  Displays the user's social connections or the contents of the socialMessageBox
            {
                #region Command Spam Prevention
                //prevents this command from being spammed
                if (!commandSpamFilter)
                {
                    foreach (CommandSpamUser singleUser in commandSpamUsers)
                    {
                        if (username == singleUser.userName)
                        {
                            return;
                        }
                    }

                    commandSpamFilter = true;

                    #region Single User Command Spam Prevention
                    CommandSpamUser user = new CommandSpamUser();
                    user.userName = username;
                    user.timeOfMessage = DateTime.Now;
                    commandSpamUsers.Add(user);
                    #endregion
                    #endregion

                    irc.sendChatMessage(socialMessage);
                }
            }
            #endregion

            #region !commandlist
            else if (command == "commandlist")   //!commandlist  ::  Provides the user with a list of all available commands for the channel
            {
                #region Command Spam Prevention
                //prevents this command from being spammed
                if (!commandSpamFilter)
                {
                    foreach (CommandSpamUser singleUser in commandSpamUsers)
                    {
                        if (username == singleUser.userName)
                        {
                            return;
                        }
                    }

                    commandSpamFilter = true;

                    #region Single User Command Spam Prevention
                    CommandSpamUser user = new CommandSpamUser();
                    user.userName = username;
                    user.timeOfMessage = DateTime.Now;
                    commandSpamUsers.Add(user);
                    #endregion
                    #endregion

                    #region Streamer Commands
                    //if streamer commands are to be displayed in chat
                    if (streamerCommandList)
                    {
                        string streamerCommands = "";

                        //adds every custom command to string streamerCommands
                        foreach (Command comm in commandList)
                        {
                            if (comm.GetPermLevel() == "streamer")
                            {
                                streamerCommands += "!" + comm.GetName() + ", ";
                            }
                            if (comm.GetPermLevel() == "mods")
                            {
                                streamerCommands += "!" + comm.GetName() + ", ";
                            }
                            if (comm.GetPermLevel() == "viewers")
                            {
                                streamerCommands += "!" + comm.GetName() + ", ";
                            }
                        }

                        //outputs every command available in the channel. Changes is Point System is enabled or disabled
                        if (PointSystem)
                        {
                            irc.sendChatMessage(channelName + " can use: !addcom, !editcom, !remcom, !who, !schedule, !banword, !unbanword, !reward, !charge, !points, " + streamerCommands);
                        }
                        else
                        {
                            irc.sendChatMessage(channelName + " can use: !addcom, !editcom, !remcom, !banword, !unbanword, !who, !schedule, " + streamerCommands);
                        }
                    }
                    #endregion

                    #region Mod Commands
                    //adds every custom command that moderators have access to to string modCommands
                    string modCommands = "";

                    foreach (Command comm in commandList)
                    {
                        if (comm.GetPermLevel() == "mods")
                        {
                            modCommands += "!" + comm.GetName() + ", ";
                        }
                        if (comm.GetPermLevel() == "viewers")
                        {
                            modCommands += "!" + comm.GetName() + ", ";
                        }
                    }

                    //outputs every command moderators can use. Changes if Point System is enabled or disabled
                    if (PointSystem)
                    {
                        irc.sendChatMessage("Mods can use: !addcom, !editcom, !remcom, !banword, !unbanword, !who, !schedule, !points, !reward, !charge, " + modCommands);
                    }
                    else
                    {
                        irc.sendChatMessage("Mods can use: !addcom, !editcom, !remcom, !banword, !unbanword, !who, !schedule, " + modCommands);
                    }

                    #endregion

                    #region Viewer Commands
                    //adds every custom command that viewers can use to string viewerCommands
                    string viewerCommands = "";

                    foreach (Command comm in commandList)
                    {
                        if (comm.GetPermLevel() == "viewers")
                        {
                            viewerCommands += "!" + comm.GetName() + ", ";
                        }
                    }

                    //outputs every command viewers can use. Changes if Point System is enabled or disabled
                    if (PointSystem)
                    {
                        irc.sendChatMessage("Viewers can use: !who, !schedule, !points, " + viewerCommands);
                    }
                    else
                    {
                        irc.sendChatMessage("Viewers can use: !who, !schedule, " + viewerCommands);
                    }
                    #endregion

                }
            }
            #endregion

            #region !banword
            else if (command == "banword")  //!banword wordToBan  ::  Allows user to ban a specified word from chat
            {
                //only moderators and the streamer/user can use this command
                if (modList.Contains(username))
                {
                    //splits the message into the word to ban, adds the word to the list and returns verification
                    string wordToBan = message.Split(new string[] { " " }, StringSplitOptions.None)[1];

                    bannedWordsList.Add(wordToBan);
                    bannedWordsListBox.Items.Add(wordToBan);

                    irc.sendChatMessage("That word has been successfully added to the banned word list.");
                }
            }
            #endregion

            #region !unbanword
            else if (command == "unbanword")    //!unbanword wordToUnban  ::  Allows the user to unban a word from chat
            {
                //only moderators and the streamer/user can use this command
                if (modList.Contains(username))
                {
                    //splits the message into the word to ban, finds the word, removes it, and returns verification
                    string wordToUnban = message.Split(new string[] { " " }, StringSplitOptions.None)[1];

                    if (bannedWordsList.Contains(wordToUnban))
                    {
                        bannedWordsList.Remove(wordToUnban);
                        bannedWordsListBox.Items.Remove(wordToUnban);

                        irc.sendChatMessage("That word has been unbanned.");
                    }
                    else
                    {
                        irc.sendChatMessage("That word has not been banned.");
                    }

                }
            }
            #endregion

            #region !shoutout
            else if(command == "shoutout")
            {
                if(modList.Contains(username))
                {
                    string person = message.Split(new string[] { " " }, StringSplitOptions.None)[1];

                    irc.sendChatMessage(person + " is an amazing person. Go follow them at twitch.tv/" + person);
                }
            }
            #endregion

            #region !quote
            else if(command == "quote")
            {
                Random rand = new Random();

                string quote = quotesDict[rand.Next(1, quotesDict.Count)];
                irc.sendChatMessage(quote);
            }
            #endregion

            #region !addquote
            else if(command == "addquote")
            {
                if(modList.Contains(username))
                {
                    string quoteToAdd = message.Split(new string[] { " " }, StringSplitOptions.None)[1];

                    quotesDict.Add(quotesDict.Count + 1, quoteToAdd);
                    quoteListBox.Items.Add(quotesDict.Count + " -- " + quoteToAdd);
                    irc.sendChatMessage("Quote #" + quotesDict.Count + " has been added.");
                }
            }
            #endregion

            #region Custom Commands
            else    //custom commands added by user
            {
                #region Command Spam Prevention
                //prevents any custom commands from being spammed
                if (!commandSpamFilter)
                {
                    foreach (CommandSpamUser singleUser in commandSpamUsers)
                    {
                        if (username == singleUser.userName)
                        {
                            return;
                        }
                    }

                    commandSpamFilter = true;

                    #region Single User Command Spam Prevention
                    CommandSpamUser user = new CommandSpamUser();
                    user.userName = username;
                    user.timeOfMessage = DateTime.Now;
                    commandSpamUsers.Add(user);
                    #endregion
                    #endregion

                    //loops through commandList until it finds the command to run
                    foreach (Command comm in commandList)
                    {
                        if (command == comm.GetName())
                        {
                            //if the user has the matching permission level
                            if (comm.GetPermLevel() == "streamer")
                            {
                                if (username == channelName)
                                {
                                    irc.sendChatMessage(comm.GetOutPutMessage());
                                }
                            }
                            else if (comm.GetPermLevel() == "mods")
                            {
                                if (modList.Contains(username))
                                {
                                    irc.sendChatMessage(comm.GetOutPutMessage());
                                }
                            }
                            else if (comm.GetPermLevel() == "viewers")
                            {
                                if (viewerList.Contains(username) || modList.Contains(username))
                                {
                                    irc.sendChatMessage(comm.GetOutPutMessage());
                                }
                            }
                        }
                    }
                }
            }
            #endregion

        }

        private void whisperCommands(string username, string message)
        {
            //splits the whisper into the command and forces it to lower case
            string command = message.Split(new[] { ' ', '!' }, StringSplitOptions.None)[1];     // /w recipient !command parameter1 parameter2 etc
            command = command.ToLower();

            #region !who
            if (command == "who")    //!who  ::  A brief description about the user and their channel
            {
                irc.sendWhisper(username, whoMessage);
            }
            #endregion

            #region !schedule
            else if (command == "schedule")  //!schedule  ::  The streamers streaming schedule
            {
                irc.sendWhisper(username, scheduleMessage);
            }
            #endregion

            #region !points
            else if (command == "points")    //!points  ::  Allows the user to see how many points they have
            {
                //if the Point System is enabled
                if (PointSystem)
                {
                    //prevents this command from being spammed
                    if (!commandSpamFilter)
                    {
                        foreach (CommandSpamUser singleUser in commandSpamUsers)
                        {
                            if (username == singleUser.userName)
                            {
                                return;
                            }
                        }

                        commandSpamFilter = true;

                        #region Single User Command Spam Prevention
                        CommandSpamUser user = new CommandSpamUser();
                        user.userName = username;
                        user.timeOfMessage = DateTime.Now;
                        commandSpamUsers.Add(user);
                        #endregion

                        //finds the users points and returns that value
                        string yourPoints = PointsIni.IniReadValue("#" + channelNameBox.Text + "." + username, "Points");
                        if (yourPoints == "")
                        {
                            yourPoints = "0";
                            AddPoints(username, 0);
                            irc.sendWhisper(username, "You have no points.");
                        }
                        else
                        {
                            irc.sendWhisper(username, "You have " + yourPoints + " points.");
                        }
                    }
                }
            }
            #endregion

            #region !commandlist
            else if (command == "commandlist")   //!commandlist  ::  Lists all the commands available for the channel
            {
                #region Command Spam Prevention
                //prevents this command from being spammed via whisper
                if (!commandSpamFilter)
                {
                    foreach (CommandSpamUser singleUser in commandSpamUsers)
                    {
                        if (username == singleUser.userName)
                        {
                            return;
                        }
                    }

                    commandSpamFilter = true;

                    #region Single User Command Spam Prevention
                    CommandSpamUser user = new CommandSpamUser();
                    user.userName = username;
                    user.timeOfMessage = DateTime.Now;
                    commandSpamUsers.Add(user);
                    #endregion
                    #endregion

                    #region Streamer Commands
                    if (username == channelName)
                    {
                        irc.sendWhisper(username, "You are the streamer. You have access to all whisper commands and should not" +
                            "need to whisper me for commands since you can see every command in the Commands tab.");
                    }
                    #endregion

                    #region Mod Commands
                    //adds each custom command to string modCommands
                    string modCommands = "";

                    foreach (Command comm in commandList)
                    {
                        if (comm.GetPermLevel() == "mods")
                        {
                            modCommands += "!" + comm.GetName() + ", ";
                        }
                        if (comm.GetPermLevel() == "viewers")
                        {
                            modCommands += "!" + comm.GetName() + ", ";
                        }
                    }

                    //if the user is a moderator and not the streamer, display all commands they have access to
                    if (modList.Contains(username))
                    {
                        if (username != channelName)
                        {
                            if (PointSystem)
                            {
                                irc.sendWhisper(username, "You are a mod so you can use the following commands: !who, !schedule, !points, !commandlist, " + modCommands);
                            }
                            else
                            {
                                irc.sendWhisper(username, "You are a mod so you can use the following commands: !who, !schedule, !commandlist, " + modCommands);
                            }
                        }
                    }
                    #endregion

                    #region Viewer Commands
                    //adds each custom command that viewers have access to to string viewerCommands
                    string viewerCommands = "";

                    foreach (Command comm in commandList)
                    {
                        if (comm.GetPermLevel() == "viewers")
                        {
                            viewerCommands += "!" + comm.GetName() + ", ";
                        }
                    }

                    //displays all commands viewers have access to
                    if (viewerList.Contains(username))
                    {
                        if (PointSystem)
                        {
                            irc.sendWhisper(username, "You are a viewer so you can use the following commands: !who, !schedule, !points, !commandlist, " + viewerCommands);
                        }
                        else
                        {
                            irc.sendWhisper(username, "You are a viewer so you can use the following commands: !who, !schedule, !commandlist, " + viewerCommands);
                        }
                    }
                    #endregion
                }
            }
            #endregion

            #region !stats
            else if(command == "stats")
            {
                if(username == adminName)
                {
                    numberOfCustomCommands = commandList.Count;
                    numberOfBannedWords = bannedWordsList.Count;
                    numberOfQuotes = quotesDict.Count;     
                    //numberOfSounds = soundList.Count;   //NOT IMPLEMENTED
                    string socialTimerMessage;
                    string viewerListVisibleMessage;
                    string pointMessage;

                    if (PointSystem)
                    {
                        pointMessage = "The Point System is enabled";
                    }
                    else
                    {
                        pointMessage = "The Point System is disabled";
                    }

                    if (viewerListVisible)
                    {
                        viewerListVisibleMessage = "The Viewer List is visible";
                    }
                    else
                    {
                        viewerListVisibleMessage = "The Viewer List is not visible";
                    }

                    if(socialCommandTimer)
                    {
                        socialTimerMessage = "The social command timer is enabled";
                    }
                    else
                    {
                        socialTimerMessage = "The social command timer is disabled";
                    }

                    string statsMessagePart1 = "TheAVIATIONBot stats for " + channelName + " MrDestructoid "
                        + "Number of Custom Commands: " + numberOfCustomCommands + " MrDestructoid "
                        + "Number of Polls: " + numberOfPolls + " SYSTEM NOT IMPLEMENTED YET" + " MrDestructoid "
                        + "Number of Giveaways: " + numberOfGiveaways + " SYSTEM NOT IMPLEMENTED YET" + " MrDestructoid "
                        + "Number of Quotes: " + numberOfQuotes + " MrDestructoid "
                        + "Number of Sounds" + numberOfSounds + " SYSTEM NOT IMPLEMENTED YET" + " MrDestructoid "
                        + "Number of Banned Words: " + numberOfBannedWords + " MrDestructoid "
                        + "Number of Time the Bot has been Used: " + numberOfTimesOpened + " MrDestructoid";

                    string statsMessagePart2 = pointMessage + " MrDestructoid "
                        + viewerListVisibleMessage + " MrDestructoid "
                        + socialTimerMessage + " MrDestructoid";

                    irc.sendWhisper(username, statsMessagePart1);
                    irc.sendWhisper(username, statsMessagePart2);
                }
            }
            #endregion

            #region Custom Commands
            else    //custom commands added by user
            {
                #region Command Spam Prevention
                //prevents any custom command from being spammed
                if (!commandSpamFilter)
                {
                    foreach (CommandSpamUser singleUser in commandSpamUsers)
                    {
                        if (username == singleUser.userName)
                        {
                            return;
                        }
                    }

                    commandSpamFilter = true;

                    #region Single User Command Spam Prevention
                    CommandSpamUser user = new CommandSpamUser();
                    user.userName = username;
                    user.timeOfMessage = DateTime.Now;
                    commandSpamUsers.Add(user);
                    #endregion
                    #endregion

                    //loops through commandList until it finds the command to run
                    foreach (Command comm in commandList)
                    {
                        if (command == comm.GetName())
                        {
                            //if the user has the matching permission level
                            if (comm.GetPermLevel() == "streamer")
                            {
                                if (username == channelName)
                                {
                                    irc.sendWhisper(username, comm.GetOutPutMessage());
                                }
                            }
                            else if (comm.GetPermLevel() == "mods")
                            {
                                if (modList.Contains(username))
                                {
                                    irc.sendWhisper(username, comm.GetOutPutMessage());
                                }
                            }
                            else if (comm.GetPermLevel() == "viewers")
                            {
                                if (viewerList.Contains(username) || modList.Contains(username))
                                {
                                    irc.sendWhisper(username, comm.GetOutPutMessage());
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }
        #endregion

        #region Misc Functions
        private bool BannedWordFilter(string username, string message)
        {
            //loops through banned word list to see if the message contains a banned word and times out the person who said the word
            foreach (string word in bannedWordsList)
            {
                if(message.Contains(word))
                {
                    string command = "/timeout " + username + " 10";
                    irc.sendChatMessage(command);
                    irc.sendChatMessage(username + " Please watch your language.");
                    return true;
                }
            }
            return false;
        }

        private void AddPoints(string username, double points)
        {
            double finalNumber = 0;
            try
            {
                //finds the point value of the user and adds the specified amount to it.
                string[] separator = new string[] { @"\r\n" };
                username = username.Trim().ToLower();
                string pointsOfUser = PointsIni.IniReadValue("#" + channelNameBox.Text + "." + username, "Points");
                double numberofPoints = double.Parse(pointsOfUser);
                finalNumber = Convert.ToDouble(numberofPoints + points);
                
                //if the user already has points, write the new total to the ini file
                if(finalNumber > 0)
                {
                    PointsIni.IniWriteValue("#" + channelNameBox.Text + "." + username, "Points", finalNumber.ToString());
                }

                //if the user does not have any points or has less than zero points, add them to the ini with 0 points
                if(finalNumber <= 0)
                {
                    PointsIni.IniWriteValue("#" + channelNameBox.Text + "." + username, "Points", "0");
                }
            }
            catch(Exception e)
            {
                //write username's points to the ini file
                if(points > 0)
                {
                    PointsIni.IniWriteValue("#" + channelNameBox.Text + "." + username, "Points", points.ToString());
                }
            }
        }
        
        private void AddCommand(string name, string outputMessage, string permLevel)
        {
            //create a new command, add it to the list, and provide verification
            commandList.Add(new Command(name, outputMessage, permLevel));

            irc.sendChatMessage("Command !" + name + " has successfully added.");
        }

        private void RemoveCommand(string commandToRemove)
        {  
            //loop through commandList until it finds the command to remove, remove it and provide verification
            foreach(Command comm in commandList)
            {
                if(comm.GetName() == commandToRemove)
                {
                    commandList.Remove(comm);
                    irc.sendChatMessage("Command !" + commandToRemove + " has been removed.");
                    return;
                }
            }
        }

        private void EditCommand(string name, string message)
        {
            //loop through commandList until it finds the command to edit, edit the command's output and provide verification
            foreach(Command comm in commandList)
            {
                if(name == comm.GetName())
                {
                    comm.SetOutputMessage(message);
                }
                irc.sendChatMessage("Command !" + comm.GetName() + " has been updated. It now reads: " + comm.GetOutPutMessage());
            }
        }

        private void CommandsTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //gets the name and text of the selected node and displays the text of the node
            string selectedNode = e.Node.Text;
            string selectedNodeName = e.Node.Name;
            CommandsTextBox.Clear();
            CommandsTextBox.Text += selectedNode +  Environment.NewLine;
            CommandsTextBox.Text += Environment.NewLine;

            #region Command Descriptions
            //The descriptions of each node in the Commands Tree

            #region Commands
            //if the selected node is 'Commands', display its description
            if (selectedNodeName == "Commands")
            {
                CommandsTextBox.Text += "These are commands that viewers can enter in chat using '!command'.";
            }
            #endregion

            #region !who
            //if the selected node is '!who', display its description
            if (selectedNodeName == "!who")
            {
                CommandsTextBox.Text += "This is a quick description about who you are and what your channel is about.";
            }
            #endregion

            #region !schedule
            //if the selected node is '!schedule', display its description
            if (selectedNodeName == "!schedule")
            {
                CommandsTextBox.Text += "This is your stream schedule. My creator recommends including the days of the week and what" +
                    " times during those days that you stream.";
            }
            #endregion

            #region !addcom
            //if the selected node is '!addcom', display its description
            if (selectedNodeName == "!addcom")
            {
                CommandsTextBox.Text += "This command allows you to add custom commands to your channel. This command is a bit complex" +
                    "This command has four main sections: " + Environment.NewLine +
                    "(1) !addcom :: This is tells me that you want to add a new command." + Environment.NewLine +
                    "(2) Name :: This section tells me what you want to name the command. Each command must have a unique name or I will get confused." + Environment.NewLine +
                    "(3) Permission Level :: This section tells me who you want to be able to use the command(streamer, mod, viewer). Streamer can use all commands regardless of permission level. Mods can use permission levels of mod or viewer. Viewer can only use viewer permission level commands." + Environment.NewLine +
                    "(4) Message :: This section tells me what you want me to say in response to the command." + Environment.NewLine +
                    "Here is an example of how to use this command:" + Environment.NewLine +
                    "!addcom game viewer " + channelName + " is playing Dark Souls 3 and dying every five feet. :(";
            }
            #endregion

            #region !editcom
            //if the selected node is '!editcom', display its description
            if (selectedNodeName == "!editcom")
            {
                CommandsTextBox.Text += "This command allows you to edit one of the custom commands that you gave me using the !addcom command." + Environment.NewLine +
                    "If you want to edit the !who or !schedule commands you can do so in the Settings tab." + Environment.NewLine +
                    "This command is much simpler than the !addcom command with only three sections:" + Environment.NewLine +
                    "(1) !editcom :: This tells me that you want to edit a command." + Environment.NewLine +
                    "(2) Name :: This section tells me what command you want to change." + Environment.NewLine +
                    "(3) Message :: This section tells me what you want the commands new message to be." + Environment.NewLine +
                    "Here is an example of how to use this command:" + Environment.NewLine +
                    "!editcom game " + channelName + " is now playing Stardew Valley because " + channelName + " rage quit Dark Souls 3. SMOrc";
            }
            #endregion

            #region !remcom
            //if the selected node is '!remcom', display its description
            if (selectedNodeName == "!remcom")
            {
                CommandsTextBox.Text += "This command allows you to remove one of the custom commands that you gave me using the !addcom command." + Environment.NewLine +
                    "Unfortunately you cannot remove any of the out of the box commands but you can disable the point system and all of its associated commands." + Environment.NewLine +
                    "Here is an example of how to use this command:" + Environment.NewLine +
                    "!remcom game";
            }
            #endregion

            #region !points
            //if the selected node is '!points', display its description
            if (selectedNodeName == "!points")
            {
                CommandsTextBox.Text += "I am capable of rewarding viewers with points. Using this command viewers are capable of seeing" +
                    " their points. This command can be disabled be unchecking the Point System check box in the settings tab.";
            }
            #endregion

            #region !reward
            //if the selected node is '!reward', display its description
            if (selectedNodeName == "!reward")
            {
                CommandsTextBox.Text += "This command allows you to give a specific viewer points, and no whoever uses the command" +
                    " cannot give themselves points." +
                    "This command can be used by yourself or your mods since it has the permission level of MOD. There is an upper" +
                    " limit of how many points any one person can have but that number is so large that you shouldn't need to worry" +
                    " about it. This command can be disable by unchecking the Point System check box in the settings tab and has three sections:" + Environment.NewLine +
                    "(1) !reward :: This tells me that you wish to reward someone in chat with points." + Environment.NewLine +
                    "(2) viewer :: This section tells me who you wish to give points to." + Environment.NewLine +
                    "(3) amount :: This section tells me how many points you wish to give to the person in section (2)." + Environment.NewLine +
                    "Here is an example of how to use this command:" + Environment.NewLine +
                    "!reward (viewer in chat) 100";
            }
            #endregion

            #region !charge
            //if the selected node is '!charge', display its description
            if (selectedNodeName == "!charge")
            {
                CommandsTextBox.Text += "This command allows you or your mods to deduct points from someone in chat. There is an" + 
                    " upper limit to how many points you can deduct the the number is so large that you shouldn't have to worry" + 
                    " about it. You can deduct the entirety of someone's points but their points will never fall below zero." + 
                    " This command can be disable by unchecking the Point System check box in the settings tab. This command has three sections:" + Environment.NewLine +
                    "(1) !charge :: This tells me that you wish to deduct points from someone." + Environment.NewLine +
                    "(2) viewer :: This section tells me who you wish to deduct the points from." + Environment.NewLine +
                    "(3) amount :: This section tells me how many points you wish to deduct." + Environment.NewLine +
                    "Here is an example of how to use this command:" + Environment.NewLine +
                    "!charge (viewer in chat) 100";
            }
            #endregion

            #region !commandlist
            //if the selected node is '!commandlist', display its description
            if (selectedNodeName == "!commandlist")
            {
                CommandsTextBox.Text += "This command lists all of the commands for your channel. That include the ones my creator " +
                    "has equipped me with out of the box as well as ones that you have added through the !addcom command.";
            }
            #endregion

            #region !banword
            //if the selected node is '!banword', display its description
            if (selectedNodeName == "!banword")
            {
                CommandsTextBox.Text += "This command allows you to ban a specific word from being said in chat and is intended " +
                    "to be used by your moderators as the Banned Words section of the Settings tab allows you to add or remove words from " +
                    "the banned words list. Due to how I was created, it is currently impossible for the list of banned words to be empty. " +
                    "In response to this, my creator has added the phrase 'pauper consilio' to the list and asks that you do not remove it " +
                    "from the list. This command has two sections: " + Environment.NewLine +
                    "(1) !banword :: This tells me that you wish to ban a word." + Environment.NewLine +
                    "(2) word :: This section tells me what word you want banned." + Environment.NewLine +
                    "Here is an example of how to use this command: " + Environment.NewLine +
                    "!banword elephant";
            }
            #endregion

            #region !unbanword
            //if the selected node is '!unbanword', display its description
            if (selectedNodeName == "!unbanword")
            {
                CommandsTextBox.Text += "This command allows you to unban a specific word from being said in chat and is intended " +
                    "to be used by your moderators as the Banned Words section of the Settings tab allows you to add or remove words from " +
                    "the banned words list. Due to how I was created, it is currently impossible for the list of banned words to be empty. " +
                    "In response to this, my creator has added the phrase 'pauper consilio' to the list and asks that you do not remove it " +
                    "from the list. This command has two sections: " + Environment.NewLine +
                    "(1) !unbanword :: This tells me that you wish to unban a word." + Environment.NewLine +
                    "(2) word :: This section tells me what word you want to remove from the banned word list." + Environment.NewLine +
                    "Here is an example of how to use this command: " + Environment.NewLine +
                    "!unbanword elephant";
            }
            #endregion

            #region !social
            if(selectedNodeName == "!social")
            {
                CommandsTextBox.Text += "This command gives your viewers a link to whatever social media you want them to follow you on." +
                    Environment.NewLine + "This commands message can be changed under the settings tab.";
            }
            #endregion

            #region Custom Commands
            //if the selected node is 'Custom Commands', display its description
            if (selectedNodeName == "Custom Commands")
            {
                CommandsTextBox.Text += "These are commands that you have added for your channel. Here is a list of commands you have added:" + Environment.NewLine;
                foreach (Command comm in commandList)
                {
                    CommandsTextBox.Text += "!" + comm.GetName() + " : " + comm.GetOutPutMessage() + Environment.NewLine;
                }
            }

            #endregion

            #endregion

            #region Whisper Command Descriptions
            //The descriptions of each node in the Whisper Commands Tree

            #region Whisper Commands
            //if the selected node is 'Whisper Commands', display its description
            if (selectedNodeName == "Whisper Commands")
            {
                CommandsTextBox.Text += "These are commands that viewers can whisper to the bot using '/w theaviationbot !command'. " + 
                    "Only certain commands can be whispered to the bot, these commands were selected because my creator finds that" + 
                    " viewers have a tendency to spam them in chat and no one likes a spammy chat, not even me and I am a bot.";
            }
            #endregion

            #region !who
            //if the selected node is 'WHISPER!who', display its description
            if (selectedNodeName == "WHISPER!who")
            {
                CommandsTextBox.Text += "This is a quick description about who you are and what your channel is about.";
            }
            #endregion

            #region !schedule
            //if the selected node is 'WHISPER!schedule', display its description
            if (selectedNodeName == "WHISPER!schedule")
            {
                CommandsTextBox.Text += "This is your stream schedule. My creator recommends including the days of the week and what" + 
                    " times during those days that you stream.";
            }
            #endregion

            #region !points
            //if the selected node is 'WHISPER!points', display its description
            if (selectedNodeName == "WHISPER!points")
            {
                CommandsTextBox.Text += "I am capable of rewarding viewers with points. Using this command viewers are capable of seeing" + 
                    " their points. This command can be disabled along with any associated commands by unchecking the Point System check box in the settings tab.";
            }
            #endregion

            #region !commandlist
            //if the selected node is 'WHISPER!commandlist', display its description
            if (selectedNodeName == "WHISPER!commandlist")
            {
                CommandsTextBox.Text += "This command lists all of the commands for your channel. That include the ones my creator " + 
                    "has equipped my with out of the box as well as ones that you have added through the !addcom command.";
            }
            #endregion

            #region Custom Commands
            //if the selected node is 'WHISPERCustom Commands', display its description
            if (selectedNodeName == "WHISPERCustom Commands")
            {
                CommandsTextBox.Text += "These are commands that you have added for your channel. Here is a list of commands you have added:" + Environment.NewLine;
                foreach(Command comm in commandList)
                {
                    CommandsTextBox.Text += "!" + comm.GetName() + " : " + comm.GetOutPutMessage() + Environment.NewLine;
                }
            }
            #endregion

            #endregion
        }

        private void PointSystemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //enables or disables the Point System
            if (PointSystemCheckBox.Checked)
            {
                PointSystem = true;
            }
            else if (!PointSystemCheckBox.Checked)
            {
                PointSystem = false;
                LoyaltyPointTimer.Enabled = false;
            }
        }

        private void bannedWordsBox_KeyUp(object sender, KeyEventArgs e)
        {
            //Adds a word to the banned word list
            if (e.KeyCode == Keys.Enter)
            {
                string bannedWord = bannedWordsBox.Text;
                bannedWordsBox.Clear();
                bannedWord = bannedWord.TrimEnd('\n');

                bannedWordsList.Add(bannedWord);
                bannedWordsListBox.Items.Add(bannedWord);
            }
        }

        private void unbanWordButton_Click(object sender, EventArgs e)
        {
            //removes selected word from the banned word list
            string wordToRemove = bannedWordsListBox.SelectedItem.ToString();
            bannedWordsListBox.Items.Remove(bannedWordsListBox.SelectedItem);
            bannedWordsList.Remove(wordToRemove);
        }

        public void CommandLoading(string commandToLoad)
        {
            //converts command strings to commands and adds to the command list
            string name = "";
            string outputMessage = "";
            string permLevel = "";

            int spaceLocation = commandToLoad.IndexOf(' ');
            name = commandToLoad.Substring(0, spaceLocation);
            outputMessage = commandToLoad.Split(new string[] { " " }, StringSplitOptions.None)[1];
            permLevel = commandToLoad.Split(new string[] { " " }, StringSplitOptions.None)[2];

            commandList.Add(new Command(name, outputMessage, permLevel));
        }

        private void viewerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //makes the viewer box and related items visible or invisble
            //also disables certain functionaly tied to the viewer box
            if (viewerCheckBox.Checked)
            {
                viewerListVisible = true;
                ViewerBox.Visible = true;
                ViewerBoxTimer.Enabled = true;
                viewerListLabel.Visible = true;
                viewerPointsLabel.Visible = true;
                viewerPointsBox.Visible = true;
            }
            else if (!viewerCheckBox.Checked)
            {
                viewerListVisible = false;
                ViewerBoxTimer.Enabled = false;
                ViewerBox.Visible = false;
                viewerListLabel.Visible = false;
                viewerPointsBox.Visible = false;
                viewerPointsLabel.Visible = false;
            }
        }

        private void addBannedWord_Click(object sender, EventArgs e)
        {
            //adds a word to the banned word list
            string wordToBan = bannedWordsBox.Text;

            bannedWordsList.Add(wordToBan);
            bannedWordsListBox.Items.Add(wordToBan);
            bannedWordsBox.Clear();
        }

        private void ViewerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //displays the selected viewers points
            viewerPointsBox.Clear();
            string selectedviewer = ViewerBox.SelectedItem.ToString();
            selectedviewer = selectedviewer.Remove(selectedviewer.Length - 2, 2);

            string userPoints = PointsIni.IniReadValue("#" + channelNameBox.Text + "." + selectedviewer, "Points");
            if(userPoints == "")
            {
                userPoints = "0";
                AddPoints(selectedviewer, 0);

            }
            viewerPointsBox.Text += selectedviewer + " has " + userPoints + " points.";
        }

        private void streamerCommandListCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //enables or disables part of !commandlist
            if (streamerCommandListCheckBox.Checked)
            {
                streamerCommandList = true;
            }
            else if (!streamerCommandListCheckBox.Checked)
            {
                streamerCommandList = false;
            }
        }

        private void socialMessageTimer_Tick(object sender, EventArgs e)
        {
            irc.sendChatMessage(socialMessage);
        }

        private void socialCommandCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (socialCommandCheckBox.Checked)
            {
                socialMessageTimer.Enabled = true;
                socialCommandTimer = true;
            }
            else if (!socialCommandCheckBox.Checked)
            {
                socialMessageTimer.Enabled = false;
                socialCommandTimer = false;
            }
        }

        private void channelNameUpdateButton_Click(object sender, EventArgs e)
        {
            channelName = channelNameBox.Text;
        }

        private void whoMessageUpdateButton_Click(object sender, EventArgs e)
        {
            whoMessage = whoMessageBox.Text;
        }

        private void scheduleMessageUpdateButton_Click(object sender, EventArgs e)
        {
            scheduleMessage = scheduleMessageBox.Text;
        }

        private void socialMessageUpdateButton_Click(object sender, EventArgs e)
        {
            socialMessage = socialMessageTextBox.Text;
        }

        private void joinChannelButton_Click(object sender, EventArgs e)
        {
            irc.joinRoom(channelName);

            //irc.sendChatMessage("/me JOIN CONFIRMATION");
        }

        private void rejoinChannelButton_Click(object sender, EventArgs e)
        {
            irc.joinRoom(channelName);

            //irc.sendChatMessage("/me REJOIN CONFIRMATION");
        }

        private void quoteAddButton_Click(object sender, EventArgs e)
        {
            string quoteToAddValue = quoteAddBox.Text;
            int quotetoAddKey = quotesDict.Count + 1;

            quotesDict.Add(quotetoAddKey, quoteToAddValue);

            quoteListBox.Items.Add(quotetoAddKey + " -- " + quoteToAddValue);
            quoteAddBox.Clear();
        }
        #endregion

        #region Bot Chat Handling
        private void chatBox_TextChanged(object sender, EventArgs e)
        {
            //auto scrolls client chat
            chatBox.SelectionStart = chatBox.Text.Length;
            chatBox.ScrollToCaret();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sends a chat message when button is pressed
            irc.sendChatMessage(BotChatBox.Text);
            BotChatBox.Clear();
        }

        private void BotChatBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //sends chat message when enter is pressed
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                irc.sendChatMessage(BotChatBox.Text);
                BotChatBox.Clear();
            }
        }
        #endregion

        #region Timers
        private void CommandSpamTimer_Tick(object sender, EventArgs e)
        {
            //prevents individual users from spamming commands
            commandSpamFilter = false;

            List<CommandSpamUser> temp = commandSpamUsers;
            foreach(CommandSpamUser user in temp)
            {
                TimeSpan duration = DateTime.Now - user.timeOfMessage;

                if(duration > TimeSpan.FromSeconds(20))
                {
                    commandSpamUsers.Remove(user);
                    return;
                }
            }
        }

        private void ViewerBoxTimer_Tick(object sender, EventArgs e)
        {
            //updates the viewer list every tick
            chatBox.Text += "Checking the viewer list..." + Environment.NewLine;
            viewerListUpdate();
        }

        private void viewerListUpdate()
        {
            //clears viewer box and adds all viewers to the box and certain lists
            ViewerBox.Items.Clear();
            Chatters allChatters = chatClient.GetChatters(channelName);

            foreach(string admin in allChatters.Admins)
            {
                ViewerBox.Items.Add(admin + Environment.NewLine);
                if(!viewerList.Contains(admin))
                {
                    viewerList.Add(admin);
                }
                
            }

            foreach (string staff in allChatters.Staff)
            {
                ViewerBox.Items.Add(staff + Environment.NewLine);
                if(!viewerList.Contains(staff))
                {
                    viewerList.Add(staff);
                }
            }

            foreach (string globalMod in allChatters.GlobalMods)
            {
                ViewerBox.Items.Add(globalMod + Environment.NewLine);
                if(!viewerList.Contains(globalMod))
                {
                    viewerList.Add(globalMod);
                }
            }

            foreach (string mod in allChatters.Moderators)
            {
                ViewerBox.Items.Add(mod + Environment.NewLine);
                if(!modList.Contains(mod))
                {
                    modList.Add(mod);
                }
            }

            foreach (string viewer in allChatters.Viewers)
            {
                ViewerBox.Items.Add(viewer + Environment.NewLine);
                if(!viewerList.Contains(viewer))
                {
                    viewerList.Add(viewer);
                }
            }
        }

        private void LoyaltyPointTimer_Tick(object sender, EventArgs e)
        {
            //adds one point to every viewer every tick
            foreach(string userName in ViewerBox.Items)
            {
                AddPoints(userName, 1);
            }
        }
        #endregion

        #region Settings Description
        //displays information about what setting the mouse is over to the settingsDescBox
        private void channelNameBox_MouseEnter(object sender, EventArgs e)
        {
            settingsDescBox.Clear();
            settingsDescBox.Text += "Channel" + Environment.NewLine + Environment.NewLine;

            settingsDescBox.Text += "This is the channel that the bot will connect to upon startup." +
                "Any changes to this field will require the bot to restart.";
        }

        private void channelNameBox_MouseLeave(object sender, EventArgs e)
        {
            settingsDescBox.Clear();
        }

        private void whoMessageBox_MouseEnter(object sender, EventArgs e)
        {
            settingsDescBox.Clear();
            settingsDescBox.Text += "!who Message" + Environment.NewLine + Environment.NewLine;

            settingsDescBox.Text += "A brief description of who you are and what your channel is about.";
        }

        private void whoMessageBox_MouseLeave(object sender, EventArgs e)
        {
            settingsDescBox.Clear();
        }

        private void scheduleMessageBox_MouseEnter(object sender, EventArgs e)
        {
            settingsDescBox.Clear();
            settingsDescBox.Text += "!schedule Message" + Environment.NewLine + Environment.NewLine;

            settingsDescBox.Text += "Enter your streaming schedule in this field.";
        }

        private void scheduleMessageBox_MouseLeave(object sender, EventArgs e)
        {
            settingsDescBox.Clear();
        }

        private void PointSystemCheckBox_MouseEnter(object sender, EventArgs e)
        {
            settingsDescBox.Clear();
            settingsDescBox.Text += "Point System" + Environment.NewLine + Environment.NewLine;

            settingsDescBox.Text += "This check box enables or disables the point system for the bot." +
                "The bot will track and automatically add points to viewers every minute." +
                "There are three commands associated with this system: !points, !reward, !charge." +
                "Please check the Commands tab for more information on those commands.";
        }

        private void PointSystemCheckBox_MouseLeave(object sender, EventArgs e)
        {
            settingsDescBox.Clear();
        }

        private void viewerCheckBox_MouseEnter(object sender, EventArgs e)
        {
            settingsDescBox.Clear();
            settingsDescBox.Text += "Viewer List" + Environment.NewLine + Environment.NewLine;

            settingsDescBox.Text += "This check box will show or hide the viewer list.";
        }

        private void viewerCheckBox_MouseLeave(object sender, EventArgs e)
        {
            settingsDescBox.Clear();
        }

        private void bannedWordsBox_MouseEnter(object sender, EventArgs e)
        {
            settingsDescBox.Clear();
            settingsDescBox.Text += "Banned Word Addition Field" + Environment.NewLine + Environment.NewLine;

            settingsDescBox.Text += "This field allows you to add words to the banned word list." +
                "Once you have entered the word, press enter or the 'Add Word' button." +
                "Words can also be added to or removed from the list via twitch chat using the !banword or !unbanword commands.";
        }

        private void bannedWordsBox_MouseLeave(object sender, EventArgs e)
        {
            settingsDescBox.Clear();
        }

        private void bannedWordsListBox_MouseEnter(object sender, EventArgs e)
        {
            settingsDescBox.Clear();
            settingsDescBox.Text += "Banned Word List" + Environment.NewLine + Environment.NewLine;

            settingsDescBox.Text += "This lists all the words that you have banned from chat.";
        }

        private void bannedWordsListBox_MouseLeave(object sender, EventArgs e)
        {
            settingsDescBox.Clear();
        }
        
        private void streamerCommandListCheckBox_MouseEnter(object sender, EventArgs e)
        {
            settingsDescBox.Clear();
            settingsDescBox.Text += "Streamer Commands List" + Environment.NewLine + Environment.NewLine;

            settingsDescBox.Text += "This check box will enable or disable part of !commandlist, which displays all available commands" +
                "in three sections: commands you(the streamer) can use, commands you or your mods can use, and commands that anyone" +
                "can use. This check box will determine whether the bot writes in chat the commands that only you can use.";
        }

        private void streamerCommandListCheckBox_MouseLeave(object sender, EventArgs e)
        {
            settingsDescBox.Clear();
        }

        private void socialMessageTextBox_MouseEnter(object sender, EventArgs e)
        {
            settingsDescBox.Clear();

            settingsDescBox.Text += "!social message" + Environment.NewLine + Environment.NewLine;

            settingsDescBox.Text += "This box allows you to enter a custom message for all of your social media accounts for viewers to follow you on.";
        }

        private void socialMessageTextBox_MouseLeave(object sender, EventArgs e)
        {
            settingsDescBox.Clear();
        }

        private void socialCommandCheckBox_MouseEnter(object sender, EventArgs e)
        {
            settingsDescBox.Clear();

            settingsDescBox.Text += "!social Command Timer" + Environment.NewLine + Environment.NewLine;

            settingsDescBox.Text += "This checkbox will enable or disable the timer that automatically runs the !social command every 10 minutes.";
        }

        private void socialCommandCheckBox_MouseLeave(object sender, EventArgs e)
        {
            settingsDescBox.Clear();
        }


        #endregion
    }

    #region Classes
    class IrcClient
    {
        private string userName;    //Bot's username (if different from user's name)
        private string channel;     //channel the bot will be used in

        public TcpClient tcpClient;     
        private StreamReader inputStream;
        private StreamWriter outputStream; 

        public IrcClient(string ip, int port, string userName, string password)
        {
            tcpClient = new TcpClient(ip, port);
            inputStream = new StreamReader(tcpClient.GetStream());
            outputStream = new StreamWriter(tcpClient.GetStream());

            outputStream.WriteLine("PASS " + password);
            outputStream.WriteLine("NICK " + userName);
            outputStream.WriteLine("USER " + userName + " 8 * :" + userName);
            outputStream.WriteLine("CAP REQ :twitch.tv/membership");
            outputStream.WriteLine("CAP REQ :twitch.tv/commands");
            outputStream.WriteLine("CAP REQ :twitch.tv/tags");
            outputStream.Flush();
        }

        public void joinRoom(string channel)
        {
            this.channel = channel;
            outputStream.WriteLine("JOIN #" + channel);
            outputStream.Flush();
        }

        public void leaveRoom()
        {
            outputStream.Close();
            inputStream.Close();
        }

        public void sendIrcMessage(string message)
        {
            outputStream.WriteLine(message);
            outputStream.Flush();
        }

        public void sendChatMessage(string message)
        {
            sendIrcMessage(":" + userName + "!" + userName + "@" + userName + ".tmi.twitch.tv PRIVMSG #" + channel + " :" + message);
        }

        public void sendWhisper(string recipient, string message)
        {
            sendChatMessage("/w " + recipient + " " + message);
        }

        public void PingResponse()
        {
            sendIrcMessage("PONG tmi.twitch.tv\r\n");
        }

        public string readMessage()
        {
            string message = "";
            message = inputStream.ReadLine();
            return message;
        }

        public string getStartTime(string roomID)
        {
            string response = "";

            sendIrcMessage("https://api.twitch.tv/kraken/streams/");

            response = inputStream.ReadLine();

            //read in the start time and find delta from current time

            return response;
        }


    }

    class IniFile
    {
        public string path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public IniFile(string IniPath)
        {
            path = IniPath;
        }

        public void IniWriteValue(string Section, string Key, string value)
        {
            WritePrivateProfileString(Section, Key, value, this.path);
        }

        public string IniReadValue(string Section, string Key)
        {
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString(Section, Key, "", temp, 255, this.path);
            return temp.ToString();
        }
    }

    class CommandSpamUser
    {
        public string userName;
        public DateTime timeOfMessage;
    }

    class Command
    {
        #region Data Members
        enum PermissionLevel
        {
            STREAMER,
            MOD,
            VIEWER
        }

        private string m_name;
        private string m_outputMessage;
        private PermissionLevel m_permLevel;
        #endregion

        #region Getters
        public string GetName()
        {
            return m_name;
        }

        public string GetOutPutMessage()
        {
            return m_outputMessage;
        }

        public string GetPermLevel()
        {
            if (m_permLevel == PermissionLevel.STREAMER)
            {
                return "STREAMER";
            }
            else if (m_permLevel == PermissionLevel.MOD)
            {
                return "MOD";
            }
            else if(m_permLevel == PermissionLevel.VIEWER)
            {
                return "VIEWER";
            }
            else
            {
                return "VIEWER";
            }

            //return permLevel;
        }
        #endregion

        #region Setters
        public void SetName(string newName)
        {
            m_name = newName;
        }

        public void SetOutputMessage(string newMessage)
        {
            m_outputMessage = newMessage;
        }

        public void SetPermLevel(string newPermLevel)
        {
            if (newPermLevel == "STREAMER")
            {
                m_permLevel = PermissionLevel.STREAMER;
            }
            else if (newPermLevel == "MOD")
            {
                m_permLevel = PermissionLevel.MOD;
            }
            else
            {
                m_permLevel = PermissionLevel.VIEWER;
            }
        }
        #endregion

        public Command(string name, string outputMessage, string permLevel)
        {
            m_name = name;
            m_outputMessage = outputMessage;

            if(permLevel == "STREAMER")
            {
                m_permLevel = PermissionLevel.STREAMER;
            }
            else if(permLevel == "MOD")
            {
                m_permLevel = PermissionLevel.MOD;
            }
            else
            {
                m_permLevel = PermissionLevel.VIEWER;
            }
        }

        public string Save()
        {
            string commandstring = "";

            commandstring = m_name + " " + m_outputMessage + " " + GetPermLevel();

            return commandstring;
        }
        
    }
    #endregion
}
