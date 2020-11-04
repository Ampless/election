using Discord;
using Discord.WebSocket;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        private DiscordSocketClient _client;

        public async Task MainAsync()
        {
            _client = new DiscordSocketClient();
            await _client.LoginAsync(TokenType.Bot, File.ReadAllText("../../../.secret"));
            await _client.StartAsync();
            await _client.SetGameAsync("chrissx Media");
            _client.MessageReceived += async (msg) => {
                try
                {
                    if (!msg.Content.ToUpper().StartsWith("!E")) return;
                    var http = new HttpClient();
                    http.DefaultRequestHeaders.Clear();
                    http.DefaultRequestHeaders.Add("Authorization", "www.nbcnews.com");
                    http.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.111 Safari/537.36");
                    http.DefaultRequestHeaders.Add("Cookie", "AMCVS_A8AB776A5245B4220A490D44%40AdobeOrg=1; s_cc=true; next-i18next=en; BI_UI_referrer=direct; BI_UI_previousPage=https://www.nbcnews.com/politics/2020-elections/president-results; prevVal_pn=nbcnews%3Aelections%3Apresident-results; s_vnum=1607044202009%26vn%3D2; s_invisit=true; AMCV_A8AB776A5245B4220A490D44%40AdobeOrg=1585540135%7CMCIDTS%7C18571%7CMCMID%7C08977743571107197810457389123662361727%7CMCAID%7CNONE%7CMCOPTOUT-1604466232s%7CNONE%7CvVersion%7C4.4.0; akaas_NBCNews=1605323107~rv=89~id=28c8bcc37ba810d8b97dd0eceb1ac561~rn=");
                    var res = await http.GetAsync("https://www.nbcnews.com/politics/2020-elections/president-results?format=json");
                    var jsonRoot = JObject.Parse(await res.Content.ReadAsStringAsync());
                    var jsonKek = jsonRoot["bopElectoralCollege"]["values"];
                    foreach(var c in jsonKek.Children())
                    {
                        if (c["party"] != null)
                            await msg.Channel.SendMessageAsync(c["party"] + ": " + c["value"]);
                    }
                }
                catch(Exception e)
                {
                    await msg.Channel.SendMessageAsync(e.ToString());
                }
            };
            _client.MessageReceived += async (msg) => {
                try
                {
                    if (!msg.Content.ToUpper().StartsWith("!F")) return;
                    for (int i = 0; i < 100; i++)
                    {
                        await msg.Channel.SendMessageAsync("<@" + msg.MentionedUsers.First().Id + ">");
                    }
                }
                catch (Exception e)
                {
                    await msg.Channel.SendMessageAsync(e.ToString());
                }
            };
            await Task.Delay(-1);
        }
    }
}
