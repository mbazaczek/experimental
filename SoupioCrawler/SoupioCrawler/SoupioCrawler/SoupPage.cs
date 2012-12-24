using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace SoupioCrawler
{
    class SoupPage
    {
        private int minHeight = 64;
        private HtmlWeb webGet;
        private HtmlDocument document;
        private string url;
        private string basicUrl;

        public SoupPage(string basicUrl) {
            this.basicUrl = basicUrl;
        }

        public void LoadPage(string url) {
            webGet = new HtmlWeb();
            document = webGet.Load(url);
            Console.WriteLine("loading page: "+url);
            this.url = url;
        }

        public List<SoupImage> GetImgs()
        {
            List<SoupImage> imgs = new List<SoupImage>();
            var imgTags = document.DocumentNode.SelectNodes("//img");
            if (imgTags != null)
            {
                foreach (var tag in imgTags)
                {
                    if (tag.Attributes["height"] != null)
                    {
                        if (Convert.ToInt32(tag.Attributes["height"].Value) > minHeight)
                        {
                            SoupImage img = new SoupImage();
                            img.src = tag.Attributes["src"].Value;
                            img.height = tag.Attributes["height"].Value;
                            if (tag.ParentNode.ParentNode.ParentNode.ParentNode.Id != "")//diffrent nest levels ;< dunno at which depth we are
                            {                        
                                img.id=tag.ParentNode.ParentNode.ParentNode.ParentNode.Id;
                            }
                            else
                            {
                                img.id = tag.ParentNode.ParentNode.ParentNode.ParentNode.ParentNode.Id;     
                            }
                            imgs.Add(img);
                        }
                    }
                }
            }

            return imgs;
        }

        public string GetMoreLink()
        {
            var imgTags = document.DocumentNode.SelectNodes("//a");
            if (imgTags != null)
            {
                foreach (var tag in imgTags)
                {
                    if (tag.Attributes["name"] != null)
                    {
                        if (tag.Attributes["name"].Value == "more")
                        {
                            return (basicUrl+tag.Attributes["href"].Value);
                        }                                   
                    }
                }
            }
            return "";

        }
    }
}
