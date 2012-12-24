using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;


namespace SoupioCrawler
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter soup username you wish to crawl:");
            string username = Console.ReadLine();
            string url = "http://"+username+".soup.io";
            System.IO.Directory.CreateDirectory(username);
            //string dir = "C:\\soup\\";
            string dir = username + "/";
            int downloadThreads = 10;

            int i=0;
            int count=0;
            int downloadedImages = 0;
            int ommitedImages = 0;
            int busy = 0;

            List<WebClient> downloaders = new List<WebClient>();

            for (int j = 1; j <= downloadThreads; j++)
            {
                WebClient webClient = new WebClient();
                downloaders.Add(webClient);
                Console.WriteLine("spawning downloader "+j);
                //CurrentDownloader.downloader = webClient;
            }

            SoupPage page = new SoupPage(url);
            while (url != "")
            {
                page.LoadPage(url);
                url = page.GetMoreLink();                     
                foreach (SoupImage img in page.GetImgs())
                {
                    busy = 1;
                    while (busy == 1)
                    {
                        foreach (WebClient d in downloaders)
                        {
                            if (d.IsBusy == false)
                            {
                                CurrentDownloader.downloader = d;
                               // Console.WriteLine("Downloader avaliable");
                                busy = 0;
                            }
                            else
                            {
                               // Console.WriteLine("Download thread limit reached. Waiting for downloaders to complete...");
                                System.Threading.Thread.Sleep(100);
                            }
                        }
                    }
                    count++;
                    //Console.WriteLine(img.id + " # " + img.src + " # h=" + img.height);
                    Uri uri = new Uri(img.src);
                    string filename = Path.GetFileName(uri.LocalPath);
                    string path=dir + img.id + "_" + filename;
                    if (!File.Exists(path))
                    {
                        Console.WriteLine("downloading: " + filename);
                        CurrentDownloader.downloader.DownloadFileAsync(uri, path);
                        downloadedImages++;
                    }
                    else
                    {
                        Console.WriteLine("file exists: " + filename);
                        ommitedImages++;
                    }
                }           
                //Console.WriteLine(url);
                Console.WriteLine("IMAGES:"+count+" / DOWNLOADED:"+downloadedImages+" / OMMITED:"+ommitedImages+" / PAGE:"+i);
                i++;
                //Console.Read();
            }
            Console.WriteLine("Crawl complete. Press any key to terminate the program.");
            Console.Read();
        }
    }
}
