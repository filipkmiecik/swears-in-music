using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Songswears
{
    class Program
    {
        static void Main(string[] args)
        {
            var songAnalysis = new SongAnalysis("Kazik", "12 groszy");
            Console.ReadLine();
        }
    }

    class SongAnalysis
    {
        public SongAnalysis(string band, string song)
        {
            var browser = new WebClient();
            var url = "https://api.lyrics.ovh/v1/"+band+"/"+song;
            var json = browser.DownloadString(url);
            Console.WriteLine(json);

        }
    }
}
