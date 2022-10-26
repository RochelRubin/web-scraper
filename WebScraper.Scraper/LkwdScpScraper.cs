using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace WebScraper.Scraper
{
    public static class LkwdScpScraper
    {
        public static List<LkwdScpItm> Scrape()
        {
            var html = GetLkwdScpHtml();
            return ParseLkwdScpHtml(html);
        }

        private static List<LkwdScpItm> ParseLkwdScpHtml(string html)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            var resultDivs = document.QuerySelectorAll(".post");
            var items = new List<LkwdScpItm>();
            foreach (var div in resultDivs)
            {
                var item = new LkwdScpItm();
                var titleSpan = div.QuerySelector("h2");
                if (titleSpan == null)
                {
                    continue;
                }
                if (titleSpan != null)
                {
                    item.Title = titleSpan.TextContent;
                }

                var text = div.QuerySelector("p");
                if (text != null)
                {
                    item.Text = text.TextContent;
                }

                var imageTag = div.QuerySelector(".aligncenter.size-large");
                if (imageTag != null)
                {
                    item.ImageUrl = imageTag.Attributes["src"].Value;
                }

                var linkTag = div.QuerySelector("a");
                if (linkTag != null)
                {
                    item.Link = $"{linkTag.Attributes["href"].Value}";
                }

                items.Add(item);
            }

            return items;
        }

        private static string GetLkwdScpHtml()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
            };
            using var client = new HttpClient(handler);
            var url = $"https://thelakewoodscoop.com/";
            var html = client.GetStringAsync(url).Result;
            return html;
        }
    }
}

