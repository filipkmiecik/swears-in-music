using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Songswears
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var EminemSwearStats = new SwearStats();
            var song = new Song("Eminem", "Stan");
            EminemSwearStats.AddSwearsFrom(song);
            //var censore = new Censore();
            //Console.WriteLine(censore.Fix(song.lyrics));
            Console.ReadLine();
        }

             class SwearStats:Censore
        {
             Dictionary<string, int> allSwears = new Dictionary<string, int>();
             public void AddSwearsFrom(Song song) {
                foreach(var word in badWords)
                {
                    var countOccurences = song.CountOccurences(word);
                }

            }
        }

        class Song
        {
            public string title;
            public string artist;
            public string lyrics;
            public Song(string band, string songName)
            {
                var browser = new WebClient();
                var url = "https://api.lyrics.ovh/v1/" + band + "/" + songName;
                var json = browser.DownloadString(url);
                var lyricsData = JsonConvert.DeserializeObject<LyricsovhAnswer>(json);

                title = songName;
                artist = band;
                lyrics = lyricsData.lyrics;

            }

            internal object CountOccurences(string word)
            {
                var pattern = "\\b" + word + "\\b";
                return Regex.Matches(lyrics, pattern, RegexOptions.IgnoreCase).Count;
            }
        }

        class LyricsovhAnswer
        {
            public string lyrics;
            public string error;
        }
    }

}
