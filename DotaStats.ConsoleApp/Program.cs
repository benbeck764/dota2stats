using System;
using System.Threading.Tasks;
using DotaStats.Core.SharedData;

namespace DotaStats.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var idk = Items.GetItems();

            //GetMatchHistory().Wait();
            //GetHeroes().Wait();
            //GetHeroImages();
            //DeleteHeroes().Wait();
            //GetItems().Wait();
            GetItemImages();
            Console.ReadLine();
        }

        private static async Task GetMatchHistory()
        {
            await ApiCaller.GetMatchHistory();
        }

        private static async Task GetHeroes()
        {
            await ApiCaller.GetHeroes();
        }

        private static async Task GetItems()
        {
            await ApiCaller.GetItems();
        }

        private static void GetItemImages()
        {
            ApiCaller.GetItemImages();
        }

        private static void GetHeroImages()
        {
            ApiCaller.GetHeroImages();
        }

        private static async Task DeleteHeroes()
        {
            await ApiCaller.DeleteHeroes();
        }
    }
}
