# StreamChats
A very simple program that puts YouTube, Twitch, &amp; Facebook chats side-by-side to easily read when multistreaming

# REQUIREMENTS:

You need your own YouTube Data v3 API Key (https://console.cloud.google.com/apis/api/youtube.googleapis.com/metrics) and your own Twitch Access Token & Twitch Client Secret. (https://dev.twitch.tv/console, https://twitchtokengenerator.com)

# Known Issues:

-Facebook chat isn't working since that requires FB to review & approve my developer app which I haven't bothered to follow through on

-The security on this is BAD. All sensitive data (API keys & secrets) are stored in plain text in the current users registry editor. Once I learn how to do hash functions or whatever, I can improve this
