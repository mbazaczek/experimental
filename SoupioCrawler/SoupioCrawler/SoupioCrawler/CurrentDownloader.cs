using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;


namespace SoupioCrawler
{
    static class CurrentDownloader
    {
        public static WebClient downloader { get; set; }
    }
}
