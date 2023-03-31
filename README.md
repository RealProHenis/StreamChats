# StreamChats
A very simple program that puts YouTube, Twitch, Facebook, & Kick chats side-by-side to easily read when multistreaming. I hate the lack of customization on alternative restreaming chat programs, so I decided to make this instead

## Optional Features:
### To get live viewer counts for YouTube, you need your own YouTube API Key. Follow the instructions below:

- Go to https://console.cloud.google.com
- Click "Select a project" dropdown in the upper left, then click "New Project" (call it whatever you want)
- Wait for project to be created, then click "Select Project"
- On the left sidebar, hover over "APIs & Services", then click "Enabled APIs & Services"
- Click "Enable APIs & Services"
- Search "youtube" and click "YouTube Data API v3"
- Click "Enable" and wait for the API to be enabled
- Click the "Credentials" tab on the left sidebar (under APIs & Services)
- Click "Create Credentials" at the top, then click "API key"
- Once your API Key is created, copy it and go to Stream Chats -> Security -> YouTube API Key and paste it

### To get live viewer counts for Twitch, you need your own Twitch App. Follow the instructions below:
(https://dev.twitch.tv/console, https://twitchtokengenerator.com)

# Known Issues:

-Facebook chat isn't auto integrated since that requires FB to review & approve my developer app which I haven't bothered to follow through on and tbh have no idea how to do. For now, manually paste your Facebook popout chat in text box, and then Chats -> Facebook Chats -> Go To URL

-Kick Viewers doesn't do anything

-The security on this is BAD. All data (including API keys & secrets) are stored in plain text in the current users registry editor. (Computer\HKEY_CURRENT_USER\Software\StreamChats) Once I learn how to do hash functions or whatever, I can improve this
