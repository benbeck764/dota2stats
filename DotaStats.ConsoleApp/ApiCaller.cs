using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using DotaStats.Core.Configuration;
using DotaStats.Model.Dota2API.Hero;
using DotaStats.Model.Dota2API.Item;
using DotaStats.Model.Dota2API.MatchDetails;
using DotaStats.Model.Dota2API.MatchHistory;
using DotaStats.Model.Extensions;
using DotaStats.Services;
using Newtonsoft.Json;

namespace DotaStats.ConsoleApp
{
    public static class ApiCaller
    {
        public static string DevKey { get; } = "F99837D4DF07828F1C85C71700B0F9BD";
        public static string AccountId { get; } = "111871881";
        public static int NumHeroes { get; } = 112;
        public static string Format { get; } = "JSON";
        public static string Language { get; } = "en";

        public static string MatchHistoryUri { get; } = "https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/v001/";
        public static string MatchDetailsUri { get; } = "https://api.steampowered.com/IDOTA2Match_570/GetMatchDetails/v001/";
        public static string HeroesInfoUri { get; } = "https://api.steampowered.com/IEconDOTA2_570/GetHeroes/v1/";
        public static string ItemsInfoUri { get; } = "http://api.steampowered.com/IEconDOTA2_570/GetGameItems/v1";

        public static string HeroImagesUri { get; } = "http://cdn.dota2.com/apps/dota2/images/heroes/";
        public static string ItemImagesUri { get; } = "http://cdn.dota2.com/apps/dota2/images/items/";


        private static Services.IServices Services { get; }

        static ApiCaller()
        {
            Services = Services ?? ServiceFactory.Create(DotaStatsApplication.Environment.ServiceDependencies);
        }

        public static async Task GetMatchHistory()
        {
            for (var heroId = 1; heroId <= NumHeroes; heroId++)
            {
                var apiUrlMatchHistory = MatchHistoryUri + $"?key={DevKey}" + $"&account_id={AccountId}" + $"&format={Format}" + $"&hero_id={heroId}";
                var requestMatchHistory = HttpManager.InitHttpRequest(HttpMethod.Get, null, apiUrlMatchHistory);

                var responseMatchHistory = HttpManager.SendRequest(requestMatchHistory).Result;
                var jsonResultMatchHistory = HttpManager.GetResult(responseMatchHistory).Result;

                var matchHistoryResult = JsonConvert.DeserializeObject<MatchHistoryResponse>(jsonResultMatchHistory);

                foreach (var match in matchHistoryResult.Result.Matches)
                {
                    var apiUriMatchDetails = MatchDetailsUri + $"?key={DevKey}" + $"&match_id={match.MatchId}" + $"&format={Format}";
                    var requestMatchDetails = HttpManager.InitHttpRequest(HttpMethod.Get, null, apiUriMatchDetails);

                    var responseMatchDetails = HttpManager.SendRequest(requestMatchDetails).Result;
                    var jsonResultMatchDetails = HttpManager.GetResult(responseMatchDetails).Result;

                    var matchDetailsResult = JsonConvert.DeserializeObject<MatchDetailsResponse>(jsonResultMatchDetails);

                    Console.WriteLine(matchDetailsResult.ToJson());
                    await Services.Matches.Upsert(match, matchDetailsResult.Result);
                }
            }
        }

        public static async Task GetItems()
        {
            var apiUrlItemInfo = ItemsInfoUri + $"?key={DevKey}" + $"&format={Format}" + $"&Language={Language}";
            var requestItemInfo = HttpManager.InitHttpRequest(HttpMethod.Get, null, apiUrlItemInfo);

            var responseItemInfo = HttpManager.SendRequest(requestItemInfo).Result;
            var jsonResultItems = HttpManager.GetResult(responseItemInfo).Result;

            var itemsResult = JsonConvert.DeserializeObject<ItemsResponse>(jsonResultItems);

            foreach (var item in itemsResult.Result.Items)
            {
                Console.WriteLine(item.ToJson());
                await Services.Items.Upsert(item);
            }
        }

        public static async Task GetHeroes()
        {
            var apiUrlHeroInfo = HeroesInfoUri + $"?key={DevKey}" + $"&format={Format}" + $"&Language={Language}";
            var requestHeroInfo = HttpManager.InitHttpRequest(HttpMethod.Get, null, apiUrlHeroInfo);

            var responseHeroInfo = HttpManager.SendRequest(requestHeroInfo).Result;
            var jsonResultHeroes = HttpManager.GetResult(responseHeroInfo).Result;

            var heroesResult = JsonConvert.DeserializeObject<HeroesResponse>(jsonResultHeroes);

            foreach (var hero in heroesResult.Result.Heroes)
            {
                Console.WriteLine(hero.ToJson());
                await Services.Heroes.Upsert(hero);
            }
        }

        public static void GetHeroImages()
        {
            var apiUrlHeroInfo = HeroesInfoUri + $"?key={DevKey}" + $"&format={Format}" + $"&Language={Language}";
            var requestHeroInfo = HttpManager.InitHttpRequest(HttpMethod.Get, null, apiUrlHeroInfo);

            var responseHeroInfo = HttpManager.SendRequest(requestHeroInfo).Result;
            var jsonResultHeroes = HttpManager.GetResult(responseHeroInfo).Result;

            var heroesResult = JsonConvert.DeserializeObject<HeroesResponse>(jsonResultHeroes);

            foreach (var hero in heroesResult.Result.Heroes)
            {
                var heroName = hero.Name.Replace("npc_dota_hero_", "");

                //var imageType = "vert.jpg";
                //var imageType = "full.png";
                //var imageType = "lg.png";
                var imageType = "sb.png";

                var apiUrlHeroImage = HeroImagesUri + $"{heroName}_{imageType}";
                var requestHeroImage = HttpManager.InitHttpRequest(HttpMethod.Get, null, apiUrlHeroImage);
                var response = HttpManager.SendRequest(requestHeroImage).Result;

                var folder = imageType.Split('.').First();
                var extension = imageType.Split('.').Last();

                var image = Image.FromStream(response.Content.ReadAsStreamAsync().Result);
                image.Save($@"C:\Users\bbeck\Pictures\DotA2\{folder}\{heroName}.{extension}");
            }
        }

        public static void GetItemImages()
        {
            var apiUrlItemInfo = ItemsInfoUri + $"?key={DevKey}" + $"&format={Format}" + $"&Language={Language}";
            var requestItemInfo = HttpManager.InitHttpRequest(HttpMethod.Get, null, apiUrlItemInfo);

            var responseItemInfo = HttpManager.SendRequest(requestItemInfo).Result;
            var jsonResultItems = HttpManager.GetResult(responseItemInfo).Result;

            var itemsResult = JsonConvert.DeserializeObject<ItemsResponse>(jsonResultItems);

            foreach (var item in itemsResult.Result.Items)
            {
                var itemName = item.Name.Replace("item_", "");

                var apiUrlItemImage = ItemImagesUri + $"{itemName}_lg.png";
                var requestItemImage = HttpManager.InitHttpRequest(HttpMethod.Get, null, apiUrlItemImage);
                var response = HttpManager.SendRequest(requestItemImage).Result;

                if (response.StatusCode != HttpStatusCode.OK) continue;
                var image = Image.FromStream(response.Content.ReadAsStreamAsync().Result);
                image.Save($@"C:\Users\bbeck\Pictures\DotA2\items\{itemName}.png");
            }
        }

        public static async Task DeleteHeroes()
        {
            for (var i = 1; i <= 114; i++)
            {
                await Services.Heroes.Delete(i);
            }
        }
    }
}
