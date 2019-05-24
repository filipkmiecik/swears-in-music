using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Songswears
{
    class Program
    {
        static void Main(string[] args)
        {
            // var songAnalysis = new SongAnalysis("Kazik", "12 groszy");
            var tekst = "oh shit waddup";
            var censore = new Censore();
            Console.WriteLine(censore.Fix(tekst));
            Console.ReadLine();
        }



        class Censore
    {
        string[] badWords;

        public Censore()
        {
            var profanitiesFile = File.ReadAllText("profanities.txt");
            profanitiesFile = profanitiesFile.Replace("*", "");
            profanitiesFile = profanitiesFile.Replace("(", "");
            profanitiesFile = profanitiesFile.Replace(")", "");
            profanitiesFile = profanitiesFile.Replace("\"", "");
            badWords = profanitiesFile.Split(',');

            public Fix(string tekst)
            {
                tekst = ReplaceBadWord(tekst);
            }

            private static string ReplaceBadWord(string tekst, string word)
            {
                var pattern = "\\b"+ReplaceBadWord+"\\b";
                    return Regex.Replace(tekst, pattern, "__");
            }
        }

    class SongAnalysis
    {
        public SongAnalysis(string band, string song)
        {
            var browser = new WebClient();
            var url = "https://api.lyrics.ovh/v1/"+band+"/"+song;
            var json = browser.DownloadString(url);
            var lyrics = JsonConvert.DeserializeObject<LyricsovhAnswer>(json);
            Console.WriteLine(lyrics.lyrics);

        }
    }

    class LyricsovhAnswer
    {
        public string lyrics;
        public string error; 
    }
}
