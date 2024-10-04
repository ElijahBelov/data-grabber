using Common;
using HtmlAgilityPack;
using System.Globalization;

namespace data_grabber.bl
{
    internal class PageParser
    {
        private static PageParser? instance = null;

        private readonly ILogger log;

        private PageParser(ILogger log)
        {
            this.log = log;
        }

        public PageData Parse(StreamReader source)
        {
            try
            {
                return TryParse(source);
            }
            catch (Exception e)
            {
                log.Fatal("Failed to read the HTML document", e);
                return PageData.Empty;
            }
        }

        public static PageParser Get(ILogger log)
        {
            instance ??= new(log);
            return instance;
        }

        private PageData TryParse(StreamReader source)
        {
            HtmlDocument doc = new();
            doc.Load(source.BaseStream);
            return ParseDoc(doc);
        }

        private PageData ParseDoc(HtmlDocument doc)
        {
            try
            {
                return TryParseDoc(doc);
            }
            catch (Exception e)
            {
                log.Fatal("Failed to parse the HTML document", e);
                return PageData.Empty;
            }
        }

        private PageData TryParseDoc(HtmlDocument doc)
        {
            string? key = GetKey(doc);
            if (key == null)
            {
                log.Error("Document does not contain TICKER element");
                return PageData.Empty;
            }

            int rating = GetRating(doc);

            HtmlNodeCollection nodes2 = doc.DocumentNode.SelectNodes("//ul[starts-with(@class, 'smartRating')]//li[2]");
            if (nodes2.Count < 6)
                log.Warn("Document is missing some ratings");

            int composite = Int32.Parse(nodes2[0].InnerText.Trim());
            int eps = Int32.Parse(nodes2[1].InnerText.Trim());
            int rs = Int32.Parse(nodes2[2].InnerText.Trim());
            string grouprs = nodes2[3].InnerText.Trim();
            string smr = nodes2[4].InnerText.Trim();
            string ac = nodes2[5].InnerText.Trim();

            DateOnly epsdate = GetEPSDate(doc);

            return new PageData(key, rating, composite, eps, rs, grouprs, smr, ac, epsdate);
        }

        private static string? GetKey(HtmlDocument doc)
        {
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[starts-with(@class, 'stockRolldiv')]");
            return nodes.Count == 0 ? null : nodes[0].InnerText;
        }

        private int GetRating(HtmlDocument doc)
        {
            try
            {
                return TryGetRating(doc);
            }
            catch (Exception e)
            {
                log.Warn("Could not get rating", e);
                return -1;
            }
        }

        private int TryGetRating(HtmlDocument doc)
        {
            HtmlNodeCollection nodes = doc.DocumentNode
                .SelectNodes("//span[starts-with(@id, 'ctl00_ctl00_secondaryContent_leftContent_GrpLeaders_lblRankN')]//text()");

            if (nodes.Count == 0)
            {
                log.Warn("No rating");
                return -1;
            }

            return nodes.Count > 0 ? Int32.Parse(nodes[0].InnerText.Trim()) : -1;
        }

        private DateOnly GetEPSDate(HtmlDocument doc)
        {
            try
            {
                return TryGetEPSDate(doc);
            }
            catch (Exception e)
            {
                log.Warn("Could not read EPS Date", e);
                return DateOnly.MinValue;
            }
        }

        private DateOnly TryGetEPSDate(HtmlDocument doc)
        {
            HtmlNode dateTitleNode = doc.DocumentNode.SelectSingleNode("//div[starts-with(@class, 'companyContent')]//ul[2]//li[1]");
            if (dateTitleNode == null || dateTitleNode.InnerHtml.Trim() != "EPS Due Date")
            {
                log.Warn("Missing EPS Date");
                return DateOnly.MinValue;
            }

            HtmlNode dateNode = doc.DocumentNode.SelectSingleNode("//div[starts-with(@class, 'companyContent')]//ul[2]//li[2]");
            if (dateNode == null)
            {
                log.Warn("Missing EPS Date");
                return DateOnly.MinValue;
            }

            return DateOnly.ParseExact(dateNode.InnerText.Trim(), "MM/d/yyyy", new CultureInfo("en-US"), DateTimeStyles.None);
        }
    }
}
