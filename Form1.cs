using Newtonsoft.Json;
using System.Timers;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.Win32;
using System.Net;
using System.Text.RegularExpressions;
using System.Text.Json;
using System.Diagnostics;
using HtmlAgilityPack;
using static System.Net.WebRequestMethods;

namespace StreamChats
{
    public partial class Form1 : Form
    {
        private System.Timers.Timer timer;
        private string YouTubeChatURL = "";
        private string TwitchChatURL = "";
        private string FacebookChatURL = "";
        private string KickChatURL = "";

        private string YouTubeDashboardURL = "";
        private string TwitchDashboardURL = "";
        private string FacebookDashboardURL = "";
        private string KickDashboardURL = "https://kick.com/dashboard/stream";
        public Form1()
        {
            InitializeComponent();

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\StreamChats");
            if (key != null)
            {
                // Check if the value exists
                if (key.GetValue("ViewerRefreshTimer") != null)
                {
                    timer = new System.Timers.Timer();
                    string timerRegistry = key.GetValue("ViewerRefreshTimer", -1) as string;
                    timer.Interval = double.Parse(timerRegistry);
                    timer.Elapsed += OnTimerElapsed;
                }
                else
                {
                    timer = new System.Timers.Timer();
                    timer.Interval = 30000; //value is in milliseconds, 30000 is default
                    timer.Elapsed += OnTimerElapsed;
                    RegistryKey keyExist = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
                    string refreshValue = "30000";
                    keyExist.SetValue("ViewerRefreshTimer", refreshValue);
                    keyExist.Close();
                }
            }
            else
            {
                timer = new System.Timers.Timer();
                timer.Interval = 30000; //value is in milliseconds, 30000 is default
                timer.Elapsed += OnTimerElapsed;
                RegistryKey keyNoExist = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
                string refreshValue = "30000";
                keyNoExist.SetValue("ViewerRefreshTimer", refreshValue);
                keyNoExist.Close();
            }
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            // Sets proper font sizes for viewer count text
            YouTubeViewers_Label.Font = new Font(YouTubeViewers_Label.Font.FontFamily, 9, YouTubeViewers_Label.Font.Style);
            YouTubeViewers_Label.Font = new Font(YouTubeViewers_Label.Font, FontStyle.Italic);
            TwitchViewers_Label.Font = new Font(TwitchViewers_Label.Font.FontFamily, 9, TwitchViewers_Label.Font.Style);
            TwitchViewers_Label.Font = new Font(TwitchViewers_Label.Font, FontStyle.Italic);
            KickViewers_Label.Font = new Font(KickViewers_Label.Font.FontFamily, 9, KickViewers_Label.Font.Style);
            KickViewers_Label.Font = new Font(KickViewers_Label.Font, FontStyle.Italic);

            // Ensure that CoreWebView2 is initialized before performing any operations
            await InitializeWebView2Async(webView2_YouTube);
            await InitializeWebView2Async(webView2_Twitch);
            await InitializeWebView2Async(webView2_Facebook);
            await InitializeWebView2Async(webView2_Kick);

            // gets and/or sets chat box zoom values
            string[] chatPlatforms = { "YouTube", "Twitch", "Facebook", "Kick" };
            Dictionary<string, double> zoomFactors = new Dictionary<string, double>();
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\StreamChats");
            if (key != null)
            {
                foreach (string platform in chatPlatforms)
                {
                    object value = key.GetValue(platform + "ChatZoom");
                    if (value != null)
                    {
                        double zoomFactor = double.Parse(value.ToString());
                        zoomFactors.Add(platform, zoomFactor);
                    }
                }
                key.Close();
            }

            foreach (string platform in chatPlatforms)
            {
                if (zoomFactors.ContainsKey(platform))
                {
                    switch (platform)
                    {
                        case "YouTube":
                            webView2_YouTube.ZoomFactor = zoomFactors[platform];
                            break;
                        case "Twitch":
                            webView2_Twitch.ZoomFactor = zoomFactors[platform];
                            break;
                        case "Facebook":
                            webView2_Facebook.ZoomFactor = zoomFactors[platform];
                            break;
                        case "Kick":
                            webView2_Kick.ZoomFactor = zoomFactors[platform];
                            break;
                    }
                }
                else
                {
                    RegistryKey platformKey = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
                    platformKey.SetValue(platform + "ChatZoom", 1.0);
                    platformKey.Close();
                    zoomFactors.Add(platform, 1.0);
                }
            }

            // Attempts to get the currently public YouTube livestream chat of the selected YouTube channel if configured
            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "YouTubeChannelID", null) != null)
            {
                YouTubeDashboardURL = "https://studio.youtube.com/channel/" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "YouTubeChannelID", null) as string + "/livestreaming/manage";
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "YouTubeAPIKey", null) != null)
                {
                    GetYouTubeLivestream();
                }
                else
                {
                    // If no YouTube API Key set yet, nothing needs to be done
                }
            }
            else
            {
                // If no channel set yet, nothing needs to be done
            }

            // Attempts to get the Twitch chat of the selected Twitch channel if configured
            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "TwitchChannel", null) != null)
            {
                TwitchChatURL = "https://www.twitch.tv/popout/" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "TwitchChannel", null) as string + "/chat?popout=";
                TwitchDashboardURL = "https://dashboard.twitch.tv/u/" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "TwitchChannel", null) as string + "/stream-manager";
                webView2_Twitch.Source = new Uri(TwitchChatURL);
            }
            else
            {
                //Do nothing
            }

            // Attempts to get the Facebook Chat of the selected Facebook ID if configured
            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "FacebookID", null) != null)
            {
                FacebookChatURL = "https://business.facebook.com/live/producer/?source=STREAM_KEYS&entry_point=cs_global_go_live&target_id=" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "FacebookID", null) as string;
                FacebookDashboardURL = "https://business.facebook.com/live/producer/?source=STREAM_KEYS&entry_point=cs_global_go_live&target_id=" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "FacebookID", null) as string;
                webView2_Facebook.Source = new Uri(FacebookChatURL);
            }
            else
            {
                //Do nothing
            }

            // Attempts to get the Kick chat of the selected Kick channel if configured
            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "KickChannel", null) != null)
            {
                KickChatURL = "https://www.kick.com/" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "KickChannel", null) as string + "/chatroom";
                webView2_Kick.Source = new Uri(KickChatURL);
            }
            else
            {
                //Do nothing
            }
        }
        private async Task InitializeWebView2Async(Microsoft.Web.WebView2.WinForms.WebView2 webView2)
        {
            await webView2.EnsureCoreWebView2Async();
        }

        // Gets the YouTube channel ID of any YouTube channel URL that the user configures
        private void GetYouTubeChannelID()
        {
            // Read the URL value from the Windows Registry
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\StreamChats");
            if (key != null)
            {
                string urlValue = key.GetValue("YouTubeChannelURL") as string;
                if (!string.IsNullOrEmpty(urlValue))
                {
                    // Retrieve the page source of the URL
                    try
                    {
                        using (WebClient client = new WebClient())
                        {
                            string pageSource = client.DownloadString(urlValue);

                            // Search for a YouTube channel URL in the page source
                            Match match = Regex.Match(pageSource, @"https://www\.youtube\.com/channel/([a-zA-Z0-9_-]+)");
                            if (match.Success)
                            {
                                // Extract the channel ID from the matched URL
                                string channelID = match.Groups[1].Value;

                                // Set the channel ID value in the Windows Registry
                                RegistryKey newKey = Registry.CurrentUser.CreateSubKey(@"Software\StreamChats");
                                newKey.SetValue("YouTubeChannelID", channelID);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"ERROR: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // Gets the currently public YouTube livestream of the YouTube channel that the user configures
        public int GetYouTubeLivestream()
        {
            // Set up the YouTube API service
            string APIKey = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "YouTubeAPIKey", "").ToString();
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = APIKey,
                ApplicationName = this.GetType().ToString()
            });

            // Make the API call to get the live video
            string channelID = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "YouTubeChannelID", "").ToString();
            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.ChannelId = channelID;
            searchListRequest.EventType = SearchResource.ListRequest.EventTypeEnum.Live;
            searchListRequest.Type = "video";
            searchListRequest.MaxResults = 1;
            var searchListResponse = searchListRequest.Execute();

            // Set the video ID to the label
            var video = searchListResponse.Items.FirstOrDefault();
            if (video != null)
            {
                YouTubeChatURL = "https://www.youtube.com/live_chat?is_popout=1&v=" + video.Id.VideoId;
                webView2_YouTube.Source = new Uri(YouTubeChatURL);
                return 1;
            }
            else
            {
                webView2_YouTube.Source = new Uri("https://www.youtube.com/channel/" + channelID + "/live");
                return 0;
            }
        }

        // Updates the concurrent viewer count of the YouTube livestream
        public async void UpdateYouTubeViewers()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\StreamChats");
            if (key != null)
            {
                // Check if the YouTubeChannelID value exists
                if (key.GetValue("YouTubeChannelURL") != null)
                {
                    if (key.GetValue("YouTubeChannelID") != null)
                    {
                        if (key.GetValue("YouTubeAPIKey") != null)
                        {
                            string YouTubeURL = webView2_YouTube.Source.ToString();
                            var uri = new Uri(YouTubeURL);
                            string videoId = System.Web.HttpUtility.ParseQueryString(uri.Query).Get("v");

                            string APIKey = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "YouTubeAPIKey", "").ToString();
                            RegistryKey YouTubeAPIKey = Registry.CurrentUser.OpenSubKey(@"Software\StreamChats");
                            if (YouTubeAPIKey != null && YouTubeAPIKey.GetValue("YouTubeAPIKey") != null)
                            {
                                HttpClient client = new HttpClient();
                                string requestUrl = $"https://www.googleapis.com/youtube/v3/videos?part=liveStreamingDetails&id={videoId}&fields=items%2FliveStreamingDetails%2FconcurrentViewers&key={APIKey}";
                                try
                                {
                                    HttpResponseMessage response = await client.GetAsync(requestUrl);
                                    response.EnsureSuccessStatusCode();

                                    string responseBody = await response.Content.ReadAsStringAsync();
                                    dynamic json = JsonConvert.DeserializeObject(responseBody);
                                    if (json.items.Count > 0 && json.items[0].liveStreamingDetails != null)
                                    {
                                        string concurrentViewers = json.items[0].liveStreamingDetails.concurrentViewers;
                                        this.BeginInvoke(new Action(() =>
                                        {
                                            YouTubeViewers_Label.Text = "YouTube Viewers: " + concurrentViewers;
                                        }));
                                    }
                                }
                                catch (HttpRequestException ex)
                                {
                                    this.BeginInvoke(new Action(() =>
                                    {
                                        YouTubeViewers_Label.Text = $"ERROR: {ex.Message}";
                                    }));
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("ERROR: Please enter your YouTube API Key under the Security tab", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR: Could not get your YouTube channel ID from the YouTube channel URL you submitted. Please try again.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: Please enter your YouTube Channel URL under the Accounts tab", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Updates the concurrent viewer count of the Twitch livestream
        public int UpdateTwitchViewers()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\StreamChats");
            if (key != null)
            {
                // Check if the TwitchChannel value exists
                if (key.GetValue("TwitchChannel") != null)
                {
                    if (key.GetValue("TwitchAccessToken") != null && key.GetValue("TwitchClientID") != null)
                    {
                        // Set up the API request
                        string TwitchChannel = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "TwitchChannel", "").ToString();
                        string url = $"https://api.twitch.tv/helix/streams?user_login={TwitchChannel}";
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                        request.Method = "GET";
                        string TwitchAccessToken = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "TwitchAccessToken", "").ToString();
                        string TwitchClientID = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "TwitchClientID", "").ToString();
                        request.Headers.Add("Authorization", $"Bearer {TwitchAccessToken}");
                        request.Headers.Add("Client-Id", $"{TwitchClientID}");

                        try
                        {
                            // Make the API request and get the response
                            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                            Stream responseStream = response.GetResponseStream();
                            StreamReader reader = new StreamReader(responseStream);
                            string responseJson = reader.ReadToEnd();

                            // Parse the JSON response to get the viewer count
                            JsonDocument responseObj = JsonDocument.Parse(responseJson);
                            int viewerCount = responseObj.RootElement.GetProperty("data")[0].GetProperty("viewer_count").GetInt32();

                            // Set the label text to the viewer count
                            TwitchViewers_Label.Invoke((MethodInvoker)(() => TwitchViewers_Label.Text = "Twitch Viewers: " + viewerCount.ToString()));

                            // Clean up resources
                            reader.Close();
                            responseStream.Close();
                            response.Close();

                            return viewerCount;
                        }
                        catch (System.IndexOutOfRangeException)
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR: Please enter your Twitch Access Token & Twitch Client ID under the Security tab", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: Please enter your Twitch name under the Accounts tab", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                key.Close();
            }

            return -1;
        }
        public async void UpdateKickViewers()
        {
            HttpClient client = new HttpClient();

            string url = "https://kick.com/roshtein";
            string html = await client.GetStringAsync(url);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);

            HtmlNode node = doc.DocumentNode.SelectSingleNode("//*[@id='main-view']/div/div/div[1]/div/div[1]/div[2]/div/div/div[1]/div[3]/div[2]/div[1]/span/div");

            string textValue = node.InnerText;
            MessageBox.Show(textValue);
        }

        // Called every set interval to update viewer counts
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            UpdateYouTubeViewers();
            UpdateTwitchViewers();
            UpdateKickViewers();
        }
        public static string GetChatZoomFactor(string ChatBox)
        {
            string value = "";
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(@"Software\StreamChats");
                if (regKey != null)
                {
                    value = (string)regKey.GetValue(ChatBox);
                    regKey.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return value;
        }
        private void checkForYouTubeLivestreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "YouTubeChannelID", null) != null)
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "YouTubeAPIKey", null) != null)
                {
                    // Check if a YouTube livestream exists
                    int result = GetYouTubeLivestream();
                    if (result == 0)
                    {
                        MessageBox.Show("ERROR: No public livestream found on the configured YouTube channel", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        // Do nothing
                    }
                }
                else
                {
                    MessageBox.Show("ERROR: Please enter your YouTube API Key under the Security tab", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("ERROR: Please enter your YouTube Channel URL under the Accounts tab", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void checkForTwitchChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "TwitchChannel", null) != null)
            {
                webView2_Twitch.Source = new Uri("https://www.twitch.tv/popout/" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "TwitchChannel", null) as string + "/chat?popout=");

            }
            else
            {
                MessageBox.Show("ERROR: Please enter your Twitch name under the Accounts tab", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void checkForFacebookLivestreamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView2_Facebook.Source = new Uri(FacebookURL_Textbox.Text);
        }
        private void youtubeZoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double new_zoom = double.Parse(GetChatZoomFactor("YouTubeChatZoom")) + 0.1;
            webView2_YouTube.ZoomFactor = new_zoom;
            string new_key = new_zoom.ToString();
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
            key.SetValue("YouTubeChatZoom", new_key);
            key.Close();
        }
        private void youtubeZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double new_zoom = double.Parse(GetChatZoomFactor("YouTubeChatZoom")) - 0.1;
            webView2_YouTube.ZoomFactor = new_zoom;
            string new_key = new_zoom.ToString();
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
            key.SetValue("YouTubeChatZoom", new_key);
            key.Close();
        }
        private void twitchZoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double new_zoom = double.Parse(GetChatZoomFactor("TwitchChatZoom")) + 0.1;
            webView2_Twitch.ZoomFactor = new_zoom;
            string new_key = new_zoom.ToString();
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
            key.SetValue("TwitchChatZoom", new_key);
            key.Close();
        }
        private void twitchZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double new_zoom = double.Parse(GetChatZoomFactor("TwitchChatZoom")) - 0.1;
            webView2_Twitch.ZoomFactor = new_zoom;
            string new_key = new_zoom.ToString();
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
            key.SetValue("TwitchChatZoom", new_key);
            key.Close();
        }
        private void facebookZoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double new_zoom = double.Parse(GetChatZoomFactor("FacebookChatZoom")) + 0.1;
            webView2_Facebook.ZoomFactor = new_zoom;
            string new_key = new_zoom.ToString();
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
            key.SetValue("FacebookChatZoom", new_key);
            key.Close();
        }
        private void facebookZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double new_zoom = double.Parse(GetChatZoomFactor("FacebookChatZoom")) - 0.1;
            webView2_Facebook.ZoomFactor = new_zoom;
            string new_key = new_zoom.ToString();
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
            key.SetValue("FacebookChatZoom", new_key);
            key.Close();
        }
        private void kickZoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double new_zoom = double.Parse(GetChatZoomFactor("KickChatZoom")) + 0.1;
            webView2_Kick.ZoomFactor = new_zoom;
            string new_key = new_zoom.ToString();
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
            key.SetValue("KickChatZoom", new_key);
            key.Close();
        }
        private void kickZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double new_zoom = double.Parse(GetChatZoomFactor("KickChatZoom")) - 0.1;
            webView2_Kick.ZoomFactor = new_zoom;
            string new_key = new_zoom.ToString();
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
            key.SetValue("KickChatZoom", new_key);
            key.Close();
        }
        private void resetYouTubeZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView2_YouTube.ZoomFactor = 1;
            string new_zoom = "1";
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
            key.SetValue("YouTubeChatZoom", new_zoom);
            key.Close();
        }
        private void resetTwitchZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView2_Twitch.ZoomFactor = 1;
            string new_zoom = "1";
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
            key.SetValue("TwitchChatZoom", new_zoom);
            key.Close();
        }
        private void resetFacebookZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView2_Facebook.ZoomFactor = 1;
            string new_zoom = "1";
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
            key.SetValue("FacebookChatZoom", new_zoom);
            key.Close();
        }
        private void resetKickZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView2_Kick.ZoomFactor = 1;
            string new_zoom = "1";
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
            key.SetValue("KickChatZoom", new_zoom);
            key.Close();
        }
        private void openBrowserTabsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "YouTubeChannelID", null) != null)
            {
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "YouTubeAPIKey", null) != null)
                {
                    int result = GetYouTubeLivestream();
                    if (result == 0)
                    {
                        // Do nothing
                    }
                    else
                    {
                        ProcessStartInfo YouTubeChat = new ProcessStartInfo
                        {
                            FileName = YouTubeChatURL,
                            UseShellExecute = true
                        };
                        Process.Start(YouTubeChat);
                    }
                }
                else
                {
                    // Do nothing
                }
            }
            else
            {
                // Do nothing
            }

            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "TwitchChannel", null) != null)
            {
                ProcessStartInfo TwitchChat = new ProcessStartInfo
                {
                    FileName = TwitchChatURL,
                    UseShellExecute = true
                };
                Process.Start(TwitchChat);
            }
            else
            {
                // Do nothing
            }

            ProcessStartInfo FacebookChat = new ProcessStartInfo
            {
                FileName = FacebookChatURL,
                UseShellExecute = true
            };
            Process.Start(FacebookChat);

            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "KickChannel", null) != null)
            {
                ProcessStartInfo KickChat = new ProcessStartInfo
                {
                    FileName = KickChatURL,
                    UseShellExecute = true
                };
                Process.Start(KickChat);
            }
            else
            {
                // Do nothing
            }
        }
        private void openAccountDashboardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Opens YouTube Dashboard if YouTube channel ID is set
            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "YouTubeChannelID", null) != null)
            {
                ProcessStartInfo YouTubeDashboard = new ProcessStartInfo
                {
                    FileName = YouTubeDashboardURL,
                    UseShellExecute = true
                };
                Process.Start(YouTubeDashboard);
            }
            else
            {
                // Do nothing
            }

            // Opens Twitch Dashboard if Twitch channel name is set
            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "TwitchChannel", null) != null)
            {
                ProcessStartInfo TwitchDashboard = new ProcessStartInfo
                {
                    FileName = TwitchDashboardURL,
                    UseShellExecute = true
                };
                Process.Start(TwitchDashboard);
            }
            else
            {
                // Do nothing
            }

            // Opens Facebook Dashboard
            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "FacebookID", null) != null)
            {
                ProcessStartInfo FacebookDashboard = new ProcessStartInfo
                {
                    FileName = FacebookDashboardURL,
                    UseShellExecute = true
                };
                Process.Start(FacebookDashboard);
            }
            else
            {
                // Do nothing
            }

            // Opens Kick Dashboard if Kick channel name is set
            if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "KickChannel", null) != null)
            {
                ProcessStartInfo KickDashboard = new ProcessStartInfo
                {
                    FileName = KickDashboardURL,
                    UseShellExecute = true
                };
                Process.Start(KickDashboard);
            }
            else
            {
                // Do nothing
            }
        }
        private void refreshAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webView2_YouTube.Reload();
            webView2_Twitch.Reload();
            webView2_Facebook.Reload();
            webView2_Kick.Reload();
        }
        private void youTubeChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display a message box to input the YouTube channel URL.
            string channelURL = Microsoft.VisualBasic.Interaction.InputBox("Enter your YouTube channel URL\n\nCurrent YouTube Channel: " + (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\StreamChats", "YouTubeChannelURL", null), "YouTube Channel URL");

            // If the user clicked the "OK" button and entered a URL, save it to the current user's local registry.
            if (!string.IsNullOrEmpty(channelURL))
            {
                if (!channelURL.StartsWith("http://") && !channelURL.StartsWith("https://"))
                {
                    channelURL = "https://" + channelURL;
                }

                RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
                key.SetValue("YouTubeChannelURL", channelURL);
                key.Close();
                GetYouTubeChannelID();
                if (Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "YouTubeAPIKey", null) != null)
                {
                    GetYouTubeLivestream();
                }
                else
                {
                    webView2_YouTube.Source = new Uri("https://www.youtube.com/channel/" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "YouTubeChannelID", null) as string);
                }
            }
        }
        private void twitchChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display a message box to input the user's Twitch name
            string channelUrl = Microsoft.VisualBasic.Interaction.InputBox("Enter your Twitch name\n\nCurrent Twitch Channel: " + (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\StreamChats", "TwitchChannel", null), "Twitch Channel");

            // If the user clicked the "OK" button and entered a URL, save it to the current user's local registry.
            if (!string.IsNullOrEmpty(channelUrl))
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
                key.SetValue("TwitchChannel", channelUrl);
                key.Close();
                webView2_Twitch.Source = new Uri("https://www.twitch.tv/popout/" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "TwitchChannel", null) as string + "/chat?popout=");
                TwitchChatURL = "https://www.twitch.tv/popout/" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "TwitchChannel", null) as string + "/chat?popout=";
                TwitchDashboardURL = "https://dashboard.twitch.tv/u/" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "TwitchChannel", null) as string + "/stream-manager";
            }
        }
        private void facebookChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display a message box to input the user's Facebook Page ID
            string facebookID = Microsoft.VisualBasic.Interaction.InputBox("Enter your Facebook Profile/Page ID\n\nCurrent Facebook ID: " + (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\StreamChats", "FacebookID", null), "Facebook ID");

            // If the user clicked the "OK" button and entered a URL, save it to the current user's local registry.
            if (!string.IsNullOrEmpty(facebookID))
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
                key.SetValue("FacebookID", facebookID);
                key.Close();
                webView2_Facebook.Source = new Uri("https://business.facebook.com/live/producer/?source=STREAM_KEYS&entry_point=cs_global_go_live&target_id=" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "FacebookID", null) as string);
                FacebookChatURL = "https://business.facebook.com/live/producer/?source=STREAM_KEYS&entry_point=cs_global_go_live&target_id=" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "FacebookID", null) as string;
                FacebookDashboardURL = "https://business.facebook.com/live/producer/?source=STREAM_KEYS&entry_point=cs_global_go_live&target_id=" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "FacebookID", null) as string;
            }
        }
        private void kickChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display a message box to input the user's Twitch name
            string channelUrl = Microsoft.VisualBasic.Interaction.InputBox("Enter your Kick name\n\nCurrent Kick Channel: " + (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\StreamChats", "KickChannel", null), "Kick Channel");

            // If the user clicked the "OK" button and entered a URL, save it to the current user's local registry.
            if (!string.IsNullOrEmpty(channelUrl))
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
                key.SetValue("KickChannel", channelUrl);
                key.Close();
                webView2_Kick.Source = new Uri("https://kick.com/" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "KickChannel", null) as string + "/chatroom");
                KickChatURL = "https://kick.com/" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "KickChannel", null) as string + "/chatroom";
            }
        }
        private void youTubeAPIKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display a message box to input the YouTube channel URL.
            string YouTubeAPIKey = Microsoft.VisualBasic.Interaction.InputBox("Enter your YouTube API Key\n\nCurrent YouTube API Key: " + (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\StreamChats", "YouTubeAPIKey", null), "YouTube API Key");

            // If the user clicked the "OK" button and entered a URL, save it to the current user's local registry.
            if (!string.IsNullOrEmpty(YouTubeAPIKey))
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
                key.SetValue("YouTubeAPIKey", YouTubeAPIKey);
                key.Close();
            }
        }
        private void twitchAccessTokenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display a message box to input the YouTube channel URL.
            string TwitchAccessTokenKey = Microsoft.VisualBasic.Interaction.InputBox("Enter your Twitch Access Token\n\nCurrent Twitch Access Token: " + (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\StreamChats", "TwitchAccessToken", null), "Twitch Access Token");

            // If the user clicked the "OK" button and entered a URL, save it to the current user's local registry.
            if (!string.IsNullOrEmpty(TwitchAccessTokenKey))
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
                key.SetValue("TwitchAccessToken", TwitchAccessTokenKey);
                key.Close();
            }
        }
        private void twitchClientIDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display a message box to input the YouTube channel URL.
            string TwitchClientIDKey = Microsoft.VisualBasic.Interaction.InputBox("Enter your Twitch Client ID\n\nCurrent Twitch Client ID: " + (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\StreamChats", "TwitchClientID", null), "Twitch Client ID");

            // If the user clicked the "OK" button and entered a URL, save it to the current user's local registry.
            if (!string.IsNullOrEmpty(TwitchClientIDKey))
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
                key.SetValue("TwitchClientID", TwitchClientIDKey);
                key.Close();
            }
        }
        private void viewerAutoRefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Display a message box to input the amount of time between YouTube Viewer Count refreshes
            string AutoRefresh = Microsoft.VisualBasic.Interaction.InputBox("Enter amount of time (in ms) between auto viewer count updates\n\nThe lower the time, the more API requests will be made. Don't go over your API limits.\n\nCurrent Time: " + (string)Registry.GetValue("HKEY_CURRENT_USER\\Software\\StreamChats", "ViewerRefreshTimer", null) + "ms", "Auto Refresh");

            // If the user clicked the "OK" button
            if (!string.IsNullOrEmpty(AutoRefresh))
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\StreamChats");
                key.SetValue("ViewerRefreshTimer", AutoRefresh);
                string timerRegistry = key.GetValue("ViewerRefreshTimer", -1) as string;
                timer.Interval = double.Parse(timerRegistry);
                key.Close();
            }
        }
        private void resetAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to reset all Stream Chat settings?\n\nThis includes all chat settings, accounts, and security\n(this data will be deleted from your computer)", "Reset", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\StreamChats", true);
                if (key != null)
                {
                    key.DeleteSubKeyTree("");
                }
            }
        }
        private void YouTubeViewers_Label_Click(object sender, EventArgs e)
        {
            if (YouTubeViewers_Label.Text.Contains("*Click To Show Viewer Count*"))
            {
                // Check if a YouTube channel exists
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\StreamChats");
                if (key != null)
                {
                    if (key.GetValue("YouTubeChannelID") != null)
                    {
                        if (key.GetValue("YouTubeAPIKey") != null)
                        {
                            // Check if a YouTube livestream exists
                            int result = GetYouTubeLivestream();
                            if (result == 0)
                            {
                                MessageBox.Show("ERROR: No public livestream found on the configured YouTube channel", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            else
                            {
                                YouTubeViewers_Label.Font = new Font(YouTubeViewers_Label.Font.FontFamily, 10, YouTubeViewers_Label.Font.Style);
                                YouTubeViewers_Label.Font = new Font(YouTubeViewers_Label.Font, FontStyle.Regular);
                                UpdateYouTubeViewers();
                                if (timer.Enabled)
                                {
                                    // Do nothing
                                }
                                else
                                {
                                    timer.Start();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("ERROR: Please enter your YouTube API Key under the Security tab", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR: Please enter your YouTube Channel URL under the Accounts tab", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (YouTubeViewers_Label.Text.Contains("YouTube Viewers"))
            {
                YouTubeViewers_Label.Font = new Font(YouTubeViewers_Label.Font.FontFamily, 9, YouTubeViewers_Label.Font.Style);
                YouTubeViewers_Label.Font = new Font(YouTubeViewers_Label.Font, FontStyle.Italic);
                YouTubeViewers_Label.Text = ("*Click To Show Viewer Count*");
                if (timer.Enabled)
                {
                    if (TwitchViewers_Label.Text.Contains("*Click To Show Viewer Count*"))
                    {
                        timer.Stop();
                    }
                }
                else
                {
                    timer.Start();
                }
            }
        }
        private void TwitchViewers_Label_Click(object sender, EventArgs e)
        {
            if (TwitchViewers_Label.Text.Contains("*Click To Show Viewer Count*"))
            {
                // Check if a Twitch channel exists
                RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\StreamChats");
                if (key != null)
                {
                    if (key.GetValue("TwitchChannel") != null)
                    {
                        if (key != null)
                        {
                            bool twitchClientIDExists = Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "TwitchClientID", null) != null;
                            bool twitchAccessTokenExists = Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "TwitchAccessToken", null) != null;
                            if (twitchClientIDExists && twitchAccessTokenExists)
                            {
                                // Check if Twitch channel is live
                                int result = UpdateTwitchViewers();
                                if (result == 0)
                                {
                                    MessageBox.Show("ERROR: Twitch channel (" + Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\StreamChats", "TwitchChannel", null) as string + ") is not live", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {
                                    TwitchViewers_Label.Font = new Font(TwitchViewers_Label.Font.FontFamily, 10, TwitchViewers_Label.Font.Style);
                                    TwitchViewers_Label.Font = new Font(TwitchViewers_Label.Font, FontStyle.Regular);
                                    UpdateTwitchViewers();
                                    if (timer.Enabled)
                                    {
                                        // Do nothing
                                    }
                                    else
                                    {
                                        timer.Start();
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("ERROR: Please enter both your Twitch Access Token & Twitch Client ID under the Security tab", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR: Please enter your Twitch channel name under the Accounts tab", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (TwitchViewers_Label.Text.Contains("Twitch Viewers"))
            {
                TwitchViewers_Label.Font = new Font(TwitchViewers_Label.Font.FontFamily, 9, TwitchViewers_Label.Font.Style);
                TwitchViewers_Label.Font = new Font(TwitchViewers_Label.Font, FontStyle.Italic);
                TwitchViewers_Label.Text = ("*Click To Show Viewer Count*");
                if (timer.Enabled)
                {
                    if (YouTubeViewers_Label.Text.Contains("*Click To Show Viewer Count*"))
                    {
                        timer.Stop();
                    }
                }
                else
                {
                    timer.Start();
                }
            }
        }
        private void KickViewers_Label_Click(object sender, EventArgs e)
        {
            if (KickViewers_Label.Text.Contains("*Click To Show Viewer Count*"))
            {
                UpdateKickViewers();
            }
            else if (YouTubeViewers_Label.Text.Contains("YouTube Viewers"))
            {
                KickViewers_Label.Font = new Font(KickViewers_Label.Font.FontFamily, 9, KickViewers_Label.Font.Style);
                KickViewers_Label.Font = new Font(KickViewers_Label.Font, FontStyle.Italic);
                KickViewers_Label.Text = ("*Click To Show Viewer Count*");
                if (timer.Enabled)
                {
                    if (YouTubeViewers_Label.Text.Contains("*Click To Show Viewer Count*") && TwitchViewers_Label.Text.Contains("*Click To Show Viewer Count*"))
                    {
                        timer.Stop();
                    }
                }
                else
                {
                    timer.Start();
                }
            }
        }
    }
}