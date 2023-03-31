# StreamChats
A simple program that puts YouTube, Twitch, Facebook, & Kick chats side-by-side to easily read when multistreaming. I hate the lack of customization on alternative restreaming chat programs, so I decided to make this instead

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

- Go to https://dev.twitch.tv/console and login with your Twitch account
- Click "Register Your Application"
- Under the name field, enter anything you want (Twitch Application names must be unqiue)
- Add this OAuth Redirect URL: https://twitchtokengenerator.com
- Under Category, choose "Application Integration"
- Click "Create" and you should be redirected to your Developer Applications page
- Click "Manage" for the application you just created
- Copy the Client ID and paste it into StreamChats -> Security -> Twitch Client ID
- Under Client Secret, click "New Secret" and copy Client Secret and paste it into StreamChats -> Security -> Twitch Client Secret
- Open a new browser tab, and go to https://twitchtokengenerator.com
- If you get a popup that asks what you're there for, click "Custom Scope Token"
- Under the heading "Use My Client Secret and Client ID", paste your Client ID and Client Secret from your Twitch Developer App into their respective fields
- Scroll down under "Available Token Scopes" and choose yes for the "user:read:broadcast" scope
- Then scroll down to the bottom of the page and click "Generate Token!"
- You should get asked to authorize your Twitch account with the Twitch Developer App you created earlier. If that all matches, click "Authorize"
- If you're successful, you should be redirected back to Twitch Token Generator and asked to verify the captcha
- If you complete the captcha successfully, under the "Generated Tokens" heading, you should see your newly generated "Access Token" and "Refresh Token"
- Copy both the "Access Token" and "Refresh Token" from Twitch Token Generator, and paste it into StreamChats -> Security -> Twitch Access Token/Twitch Refresh Token
- Once that's done, you're all set! You should now be able to click to see your Twitch viewer count when your channel is live
- Please note that the Twitch Access Token you generated only lasts 4 hours. When it expires, you will have to click Security -> Refresh Access Token

# Known Issues:

-Facebook chat isn't auto integrated since that requires Facebook to review & approve my developer app which I haven't bothered to follow through on and tbh have no idea how to do. For now, manually paste your Facebook popout chat in text box, and then Chats -> Facebook Chats -> Go To URL

-Can't get Kick viewer count

-All data (including API keys & secrets) are stored in plain text in the current users registry editor. (Computer\HKEY_CURRENT_USER\Software\StreamChats) Once I learn how to do hash functions or whatever, I can improve this
