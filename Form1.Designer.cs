namespace StreamChats
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.chatsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.youTubeChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForLivestreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetZoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twitchChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForLivestreamToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resetZoomToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.facebookChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForLivestreamToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.resetZoomToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.kickChatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.resetZoomToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.openBrowserTabsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAccountDashboardsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.youTubeChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twitchChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facebookChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kickChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.securityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.youTubeAPIKeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twitchAccessTokenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twitchClientIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewCountPanel = new System.Windows.Forms.TableLayoutPanel();
            this.YouTubeViewers_Label = new System.Windows.Forms.Label();
            this.TwitchViewers_Label = new System.Windows.Forms.Label();
            this.FacebookURL_Textbox = new System.Windows.Forms.TextBox();
            this.KickViewers_Label = new System.Windows.Forms.Label();
            this.browserPanel = new System.Windows.Forms.TableLayoutPanel();
            this.webView2_YouTube = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.webView2_Twitch = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.webView2_Facebook = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.webView2_Kick = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip.SuspendLayout();
            this.viewCountPanel.SuspendLayout();
            this.browserPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webView2_YouTube)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView2_Twitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView2_Facebook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView2_Kick)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chatsToolStripMenuItem,
            this.accountsToolStripMenuItem,
            this.securityToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1256, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // chatsToolStripMenuItem
            // 
            this.chatsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.youTubeChatToolStripMenuItem,
            this.twitchChatToolStripMenuItem,
            this.facebookChatToolStripMenuItem,
            this.kickChatToolStripMenuItem,
            this.openBrowserTabsToolStripMenuItem,
            this.openAccountDashboardsToolStripMenuItem,
            this.refreshAllToolStripMenuItem});
            this.chatsToolStripMenuItem.Name = "chatsToolStripMenuItem";
            this.chatsToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.chatsToolStripMenuItem.Text = "Chats";
            // 
            // youTubeChatToolStripMenuItem
            // 
            this.youTubeChatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForLivestreamToolStripMenuItem,
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.resetZoomToolStripMenuItem});
            this.youTubeChatToolStripMenuItem.Name = "youTubeChatToolStripMenuItem";
            this.youTubeChatToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.youTubeChatToolStripMenuItem.Text = "YouTube Chat";
            // 
            // checkForLivestreamToolStripMenuItem
            // 
            this.checkForLivestreamToolStripMenuItem.Name = "checkForLivestreamToolStripMenuItem";
            this.checkForLivestreamToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.checkForLivestreamToolStripMenuItem.Text = "Check For Livestream";
            this.checkForLivestreamToolStripMenuItem.Click += new System.EventHandler(this.checkForYouTubeLivestreamToolStripMenuItem_Click);
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.youtubeZoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.youtubeZoomOutToolStripMenuItem_Click);
            // 
            // resetZoomToolStripMenuItem
            // 
            this.resetZoomToolStripMenuItem.Name = "resetZoomToolStripMenuItem";
            this.resetZoomToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.resetZoomToolStripMenuItem.Text = "Reset Zoom";
            this.resetZoomToolStripMenuItem.Click += new System.EventHandler(this.resetYouTubeZoomToolStripMenuItem_Click);
            // 
            // twitchChatToolStripMenuItem
            // 
            this.twitchChatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForLivestreamToolStripMenuItem1,
            this.zoomInToolStripMenuItem1,
            this.zoomOutToolStripMenuItem1,
            this.resetZoomToolStripMenuItem1});
            this.twitchChatToolStripMenuItem.Name = "twitchChatToolStripMenuItem";
            this.twitchChatToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.twitchChatToolStripMenuItem.Text = "Twitch Chat";
            // 
            // checkForLivestreamToolStripMenuItem1
            // 
            this.checkForLivestreamToolStripMenuItem1.Name = "checkForLivestreamToolStripMenuItem1";
            this.checkForLivestreamToolStripMenuItem1.Size = new System.Drawing.Size(197, 24);
            this.checkForLivestreamToolStripMenuItem1.Text = "Go To Channel Chat";
            this.checkForLivestreamToolStripMenuItem1.Click += new System.EventHandler(this.checkForTwitchChannelToolStripMenuItem_Click);
            // 
            // zoomInToolStripMenuItem1
            // 
            this.zoomInToolStripMenuItem1.Name = "zoomInToolStripMenuItem1";
            this.zoomInToolStripMenuItem1.Size = new System.Drawing.Size(197, 24);
            this.zoomInToolStripMenuItem1.Text = "Zoom In";
            this.zoomInToolStripMenuItem1.Click += new System.EventHandler(this.twitchZoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem1
            // 
            this.zoomOutToolStripMenuItem1.Name = "zoomOutToolStripMenuItem1";
            this.zoomOutToolStripMenuItem1.Size = new System.Drawing.Size(197, 24);
            this.zoomOutToolStripMenuItem1.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem1.Click += new System.EventHandler(this.twitchZoomOutToolStripMenuItem_Click);
            // 
            // resetZoomToolStripMenuItem1
            // 
            this.resetZoomToolStripMenuItem1.Name = "resetZoomToolStripMenuItem1";
            this.resetZoomToolStripMenuItem1.Size = new System.Drawing.Size(197, 24);
            this.resetZoomToolStripMenuItem1.Text = "Reset Zoom";
            this.resetZoomToolStripMenuItem1.Click += new System.EventHandler(this.resetTwitchZoomToolStripMenuItem_Click);
            // 
            // facebookChatToolStripMenuItem
            // 
            this.facebookChatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkForLivestreamToolStripMenuItem2,
            this.zoomInToolStripMenuItem2,
            this.zoomOutToolStripMenuItem2,
            this.resetZoomToolStripMenuItem2});
            this.facebookChatToolStripMenuItem.Name = "facebookChatToolStripMenuItem";
            this.facebookChatToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.facebookChatToolStripMenuItem.Text = "Facebook Chat";
            // 
            // checkForLivestreamToolStripMenuItem2
            // 
            this.checkForLivestreamToolStripMenuItem2.Name = "checkForLivestreamToolStripMenuItem2";
            this.checkForLivestreamToolStripMenuItem2.Size = new System.Drawing.Size(152, 24);
            this.checkForLivestreamToolStripMenuItem2.Text = "Go To URL";
            this.checkForLivestreamToolStripMenuItem2.Click += new System.EventHandler(this.checkForFacebookLivestreamToolStripMenuItem_Click);
            // 
            // zoomInToolStripMenuItem2
            // 
            this.zoomInToolStripMenuItem2.Name = "zoomInToolStripMenuItem2";
            this.zoomInToolStripMenuItem2.Size = new System.Drawing.Size(152, 24);
            this.zoomInToolStripMenuItem2.Text = "Zoom In";
            this.zoomInToolStripMenuItem2.Click += new System.EventHandler(this.facebookZoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem2
            // 
            this.zoomOutToolStripMenuItem2.Name = "zoomOutToolStripMenuItem2";
            this.zoomOutToolStripMenuItem2.Size = new System.Drawing.Size(152, 24);
            this.zoomOutToolStripMenuItem2.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem2.Click += new System.EventHandler(this.facebookZoomOutToolStripMenuItem_Click);
            // 
            // resetZoomToolStripMenuItem2
            // 
            this.resetZoomToolStripMenuItem2.Name = "resetZoomToolStripMenuItem2";
            this.resetZoomToolStripMenuItem2.Size = new System.Drawing.Size(152, 24);
            this.resetZoomToolStripMenuItem2.Text = "Reset Zoom";
            this.resetZoomToolStripMenuItem2.Click += new System.EventHandler(this.resetFacebookZoomToolStripMenuItem_Click);
            // 
            // kickChatToolStripMenuItem
            // 
            this.kickChatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem3,
            this.zoomOutToolStripMenuItem3,
            this.resetZoomToolStripMenuItem3});
            this.kickChatToolStripMenuItem.Name = "kickChatToolStripMenuItem";
            this.kickChatToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.kickChatToolStripMenuItem.Text = "Kick Chat";
            // 
            // zoomInToolStripMenuItem3
            // 
            this.zoomInToolStripMenuItem3.Name = "zoomInToolStripMenuItem3";
            this.zoomInToolStripMenuItem3.Size = new System.Drawing.Size(152, 24);
            this.zoomInToolStripMenuItem3.Text = "Zoom In";
            this.zoomInToolStripMenuItem3.Click += new System.EventHandler(this.kickZoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem3
            // 
            this.zoomOutToolStripMenuItem3.Name = "zoomOutToolStripMenuItem3";
            this.zoomOutToolStripMenuItem3.Size = new System.Drawing.Size(152, 24);
            this.zoomOutToolStripMenuItem3.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem3.Click += new System.EventHandler(this.kickZoomOutToolStripMenuItem_Click);
            // 
            // resetZoomToolStripMenuItem3
            // 
            this.resetZoomToolStripMenuItem3.Name = "resetZoomToolStripMenuItem3";
            this.resetZoomToolStripMenuItem3.Size = new System.Drawing.Size(152, 24);
            this.resetZoomToolStripMenuItem3.Text = "Reset Zoom";
            this.resetZoomToolStripMenuItem3.Click += new System.EventHandler(this.resetKickZoomToolStripMenuItem_Click);
            // 
            // openBrowserTabsToolStripMenuItem
            // 
            this.openBrowserTabsToolStripMenuItem.Name = "openBrowserTabsToolStripMenuItem";
            this.openBrowserTabsToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.openBrowserTabsToolStripMenuItem.Text = "Open Account Chats";
            this.openBrowserTabsToolStripMenuItem.Click += new System.EventHandler(this.openBrowserTabsToolStripMenuItem_Click);
            // 
            // openAccountDashboardsToolStripMenuItem
            // 
            this.openAccountDashboardsToolStripMenuItem.Name = "openAccountDashboardsToolStripMenuItem";
            this.openAccountDashboardsToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.openAccountDashboardsToolStripMenuItem.Text = "Open Account Dashboards";
            this.openAccountDashboardsToolStripMenuItem.Click += new System.EventHandler(this.openAccountDashboardsToolStripMenuItem_Click);
            // 
            // refreshAllToolStripMenuItem
            // 
            this.refreshAllToolStripMenuItem.Name = "refreshAllToolStripMenuItem";
            this.refreshAllToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.refreshAllToolStripMenuItem.Text = "Refresh All Chats";
            this.refreshAllToolStripMenuItem.Click += new System.EventHandler(this.refreshAllToolStripMenuItem_Click);
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.youTubeChannelToolStripMenuItem,
            this.twitchChannelToolStripMenuItem,
            this.facebookChannelToolStripMenuItem,
            this.kickChannelToolStripMenuItem});
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(72, 21);
            this.accountsToolStripMenuItem.Text = "Accounts";
            // 
            // youTubeChannelToolStripMenuItem
            // 
            this.youTubeChannelToolStripMenuItem.Name = "youTubeChannelToolStripMenuItem";
            this.youTubeChannelToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.youTubeChannelToolStripMenuItem.Text = "YouTube Channel";
            this.youTubeChannelToolStripMenuItem.Click += new System.EventHandler(this.youTubeChannelToolStripMenuItem_Click);
            // 
            // twitchChannelToolStripMenuItem
            // 
            this.twitchChannelToolStripMenuItem.Name = "twitchChannelToolStripMenuItem";
            this.twitchChannelToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.twitchChannelToolStripMenuItem.Text = "Twitch Channel";
            this.twitchChannelToolStripMenuItem.Click += new System.EventHandler(this.twitchChannelToolStripMenuItem_Click);
            // 
            // facebookChannelToolStripMenuItem
            // 
            this.facebookChannelToolStripMenuItem.Name = "facebookChannelToolStripMenuItem";
            this.facebookChannelToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.facebookChannelToolStripMenuItem.Text = "Facebook Channel";
            this.facebookChannelToolStripMenuItem.Click += new System.EventHandler(this.facebookChannelToolStripMenuItem_Click);
            // 
            // kickChannelToolStripMenuItem
            // 
            this.kickChannelToolStripMenuItem.Name = "kickChannelToolStripMenuItem";
            this.kickChannelToolStripMenuItem.Size = new System.Drawing.Size(188, 24);
            this.kickChannelToolStripMenuItem.Text = "Kick Channel";
            this.kickChannelToolStripMenuItem.Click += new System.EventHandler(this.kickChannelToolStripMenuItem_Click);
            // 
            // securityToolStripMenuItem
            // 
            this.securityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.youTubeAPIKeyToolStripMenuItem,
            this.twitchAccessTokenToolStripMenuItem,
            this.twitchClientIDToolStripMenuItem});
            this.securityToolStripMenuItem.Name = "securityToolStripMenuItem";
            this.securityToolStripMenuItem.Size = new System.Drawing.Size(65, 21);
            this.securityToolStripMenuItem.Text = "Security";
            // 
            // youTubeAPIKeyToolStripMenuItem
            // 
            this.youTubeAPIKeyToolStripMenuItem.Name = "youTubeAPIKeyToolStripMenuItem";
            this.youTubeAPIKeyToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.youTubeAPIKeyToolStripMenuItem.Text = "YouTube API Key";
            this.youTubeAPIKeyToolStripMenuItem.Click += new System.EventHandler(this.youTubeAPIKeyToolStripMenuItem_Click);
            // 
            // twitchAccessTokenToolStripMenuItem
            // 
            this.twitchAccessTokenToolStripMenuItem.Name = "twitchAccessTokenToolStripMenuItem";
            this.twitchAccessTokenToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.twitchAccessTokenToolStripMenuItem.Text = "Twitch Access Token";
            this.twitchAccessTokenToolStripMenuItem.Click += new System.EventHandler(this.twitchAccessTokenToolStripMenuItem_Click);
            // 
            // twitchClientIDToolStripMenuItem
            // 
            this.twitchClientIDToolStripMenuItem.Name = "twitchClientIDToolStripMenuItem";
            this.twitchClientIDToolStripMenuItem.Size = new System.Drawing.Size(198, 24);
            this.twitchClientIDToolStripMenuItem.Text = "Twitch Client ID";
            this.twitchClientIDToolStripMenuItem.Click += new System.EventHandler(this.twitchClientIDToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoRefreshToolStripMenuItem,
            this.resetAllToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(66, 21);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // autoRefreshToolStripMenuItem
            // 
            this.autoRefreshToolStripMenuItem.Name = "autoRefreshToolStripMenuItem";
            this.autoRefreshToolStripMenuItem.Size = new System.Drawing.Size(246, 24);
            this.autoRefreshToolStripMenuItem.Text = "Viewer Count (Auto Refresh)";
            this.autoRefreshToolStripMenuItem.Click += new System.EventHandler(this.viewerAutoRefreshToolStripMenuItem_Click);
            // 
            // resetAllToolStripMenuItem
            // 
            this.resetAllToolStripMenuItem.Name = "resetAllToolStripMenuItem";
            this.resetAllToolStripMenuItem.Size = new System.Drawing.Size(246, 24);
            this.resetAllToolStripMenuItem.Text = "Reset";
            this.resetAllToolStripMenuItem.Click += new System.EventHandler(this.resetAllToolStripMenuItem_Click);
            // 
            // viewCountPanel
            // 
            this.viewCountPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(21)))), ((int)(((byte)(27)))));
            this.viewCountPanel.ColumnCount = 4;
            this.viewCountPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.viewCountPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.viewCountPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.viewCountPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.viewCountPanel.Controls.Add(this.YouTubeViewers_Label, 0, 0);
            this.viewCountPanel.Controls.Add(this.TwitchViewers_Label, 1, 0);
            this.viewCountPanel.Controls.Add(this.FacebookURL_Textbox, 2, 0);
            this.viewCountPanel.Controls.Add(this.KickViewers_Label, 3, 0);
            this.viewCountPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.viewCountPanel.Location = new System.Drawing.Point(0, 25);
            this.viewCountPanel.Name = "viewCountPanel";
            this.viewCountPanel.RowCount = 1;
            this.viewCountPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.viewCountPanel.Size = new System.Drawing.Size(1256, 32);
            this.viewCountPanel.TabIndex = 2;
            // 
            // YouTubeViewers_Label
            // 
            this.YouTubeViewers_Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.YouTubeViewers_Label.AutoSize = true;
            this.YouTubeViewers_Label.Font = new System.Drawing.Font("Roboto", 8.830189F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.YouTubeViewers_Label.ForeColor = System.Drawing.Color.White;
            this.YouTubeViewers_Label.Location = new System.Drawing.Point(69, 8);
            this.YouTubeViewers_Label.Name = "YouTubeViewers_Label";
            this.YouTubeViewers_Label.Size = new System.Drawing.Size(176, 15);
            this.YouTubeViewers_Label.TabIndex = 0;
            this.YouTubeViewers_Label.Text = "*Click To Show Viewer Count*";
            this.YouTubeViewers_Label.Click += new System.EventHandler(this.YouTubeViewers_Label_Click);
            // 
            // TwitchViewers_Label
            // 
            this.TwitchViewers_Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TwitchViewers_Label.AutoSize = true;
            this.TwitchViewers_Label.Font = new System.Drawing.Font("Roboto", 8.830189F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.TwitchViewers_Label.ForeColor = System.Drawing.Color.White;
            this.TwitchViewers_Label.Location = new System.Drawing.Point(383, 8);
            this.TwitchViewers_Label.Name = "TwitchViewers_Label";
            this.TwitchViewers_Label.Size = new System.Drawing.Size(176, 15);
            this.TwitchViewers_Label.TabIndex = 1;
            this.TwitchViewers_Label.Text = "*Click To Show Viewer Count*";
            this.TwitchViewers_Label.Click += new System.EventHandler(this.TwitchViewers_Label_Click);
            // 
            // FacebookURL_Textbox
            // 
            this.FacebookURL_Textbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FacebookURL_Textbox.Location = new System.Drawing.Point(631, 3);
            this.FacebookURL_Textbox.Name = "FacebookURL_Textbox";
            this.FacebookURL_Textbox.Size = new System.Drawing.Size(308, 26);
            this.FacebookURL_Textbox.TabIndex = 2;
            // 
            // KickViewers_Label
            // 
            this.KickViewers_Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.KickViewers_Label.AutoSize = true;
            this.KickViewers_Label.Font = new System.Drawing.Font("Roboto", 8.830189F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.KickViewers_Label.ForeColor = System.Drawing.Color.White;
            this.KickViewers_Label.Location = new System.Drawing.Point(1011, 8);
            this.KickViewers_Label.Name = "KickViewers_Label";
            this.KickViewers_Label.Size = new System.Drawing.Size(176, 15);
            this.KickViewers_Label.TabIndex = 3;
            this.KickViewers_Label.Text = "*Click To Show Viewer Count*";
            this.KickViewers_Label.Click += new System.EventHandler(this.KickViewers_Label_Click);
            // 
            // browserPanel
            // 
            this.browserPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(13)))), ((int)(((byte)(16)))));
            this.browserPanel.ColumnCount = 4;
            this.browserPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.browserPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.browserPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.browserPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.browserPanel.Controls.Add(this.webView2_YouTube, 0, 0);
            this.browserPanel.Controls.Add(this.webView2_Twitch, 1, 0);
            this.browserPanel.Controls.Add(this.webView2_Facebook, 2, 0);
            this.browserPanel.Controls.Add(this.webView2_Kick, 3, 0);
            this.browserPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserPanel.Location = new System.Drawing.Point(0, 57);
            this.browserPanel.Name = "browserPanel";
            this.browserPanel.RowCount = 1;
            this.browserPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.browserPanel.Size = new System.Drawing.Size(1256, 785);
            this.browserPanel.TabIndex = 3;
            // 
            // webView2_YouTube
            // 
            this.webView2_YouTube.AllowExternalDrop = true;
            this.webView2_YouTube.CreationProperties = null;
            this.webView2_YouTube.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView2_YouTube.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView2_YouTube.Location = new System.Drawing.Point(3, 3);
            this.webView2_YouTube.Name = "webView2_YouTube";
            this.webView2_YouTube.Size = new System.Drawing.Size(308, 779);
            this.webView2_YouTube.Source = new System.Uri("https://www.youtube.com", System.UriKind.Absolute);
            this.webView2_YouTube.TabIndex = 0;
            this.webView2_YouTube.ZoomFactor = 1D;
            // 
            // webView2_Twitch
            // 
            this.webView2_Twitch.AllowExternalDrop = true;
            this.webView2_Twitch.CreationProperties = null;
            this.webView2_Twitch.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView2_Twitch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView2_Twitch.Location = new System.Drawing.Point(317, 3);
            this.webView2_Twitch.Name = "webView2_Twitch";
            this.webView2_Twitch.Size = new System.Drawing.Size(308, 779);
            this.webView2_Twitch.Source = new System.Uri("https://www.twitch.tv/", System.UriKind.Absolute);
            this.webView2_Twitch.TabIndex = 1;
            this.webView2_Twitch.ZoomFactor = 1D;
            // 
            // webView2_Facebook
            // 
            this.webView2_Facebook.AllowExternalDrop = true;
            this.webView2_Facebook.CreationProperties = null;
            this.webView2_Facebook.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView2_Facebook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView2_Facebook.Location = new System.Drawing.Point(631, 3);
            this.webView2_Facebook.Name = "webView2_Facebook";
            this.webView2_Facebook.Size = new System.Drawing.Size(308, 779);
            this.webView2_Facebook.Source = new System.Uri("https://business.facebook.com/", System.UriKind.Absolute);
            this.webView2_Facebook.TabIndex = 2;
            this.webView2_Facebook.ZoomFactor = 1D;
            // 
            // webView2_Kick
            // 
            this.webView2_Kick.AllowExternalDrop = true;
            this.webView2_Kick.CreationProperties = null;
            this.webView2_Kick.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView2_Kick.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView2_Kick.Location = new System.Drawing.Point(945, 3);
            this.webView2_Kick.Name = "webView2_Kick";
            this.webView2_Kick.Size = new System.Drawing.Size(308, 779);
            this.webView2_Kick.Source = new System.Uri("https://kick.com/", System.UriKind.Absolute);
            this.webView2_Kick.TabIndex = 3;
            this.webView2_Kick.ZoomFactor = 1D;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 842);
            this.Controls.Add(this.browserPanel);
            this.Controls.Add(this.viewCountPanel);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Roboto", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Stream Chats";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.viewCountPanel.ResumeLayout(false);
            this.viewCountPanel.PerformLayout();
            this.browserPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webView2_YouTube)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView2_Twitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView2_Facebook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView2_Kick)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem accountsToolStripMenuItem;
        private ToolStripMenuItem securityToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private TableLayoutPanel viewCountPanel;
        private TableLayoutPanel browserPanel;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2_YouTube;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2_Twitch;
        private Label YouTubeViewers_Label;
        private Label TwitchViewers_Label;
        private ToolStripMenuItem youTubeChannelToolStripMenuItem;
        private ToolStripMenuItem twitchChannelToolStripMenuItem;
        private ToolStripMenuItem youTubeAPIKeyToolStripMenuItem;
        private ToolStripMenuItem twitchAccessTokenToolStripMenuItem;
        private ToolStripMenuItem twitchClientIDToolStripMenuItem;
        private ToolStripMenuItem autoRefreshToolStripMenuItem;
        private ToolStripMenuItem chatsToolStripMenuItem;
        private ToolStripMenuItem refreshAllToolStripMenuItem;
        private ToolStripMenuItem youTubeChatToolStripMenuItem;
        private ToolStripMenuItem zoomInToolStripMenuItem;
        private ToolStripMenuItem zoomOutToolStripMenuItem;
        private ToolStripMenuItem twitchChatToolStripMenuItem;
        private ToolStripMenuItem zoomInToolStripMenuItem1;
        private ToolStripMenuItem zoomOutToolStripMenuItem1;
        private ToolStripMenuItem facebookChatToolStripMenuItem;
        private ToolStripMenuItem zoomInToolStripMenuItem2;
        private ToolStripMenuItem zoomOutToolStripMenuItem2;
        private ToolStripMenuItem resetAllToolStripMenuItem;
        private ToolStripMenuItem resetZoomToolStripMenuItem;
        private ToolStripMenuItem resetZoomToolStripMenuItem1;
        private ToolStripMenuItem resetZoomToolStripMenuItem2;
        private ToolStripMenuItem checkForLivestreamToolStripMenuItem;
        private ToolStripMenuItem checkForLivestreamToolStripMenuItem1;
        private ToolStripMenuItem checkForLivestreamToolStripMenuItem2;
        private ToolStripMenuItem openBrowserTabsToolStripMenuItem;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2_Facebook;
        private TextBox FacebookURL_Textbox;
        private ToolStripMenuItem kickChatToolStripMenuItem;
        private ToolStripMenuItem zoomInToolStripMenuItem3;
        private ToolStripMenuItem zoomOutToolStripMenuItem3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2_Kick;
        private Label KickViewers_Label;
        private ToolStripMenuItem resetZoomToolStripMenuItem3;
        private ToolStripMenuItem kickChannelToolStripMenuItem;
        private ToolStripMenuItem openAccountDashboardsToolStripMenuItem;
        private ToolStripMenuItem facebookChannelToolStripMenuItem;
    }
}