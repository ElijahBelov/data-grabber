using Common;
using HtmlAgilityPack;

namespace data_grabber.bl
{
    internal class PageParser(ILogger log, PageModel model)
    {
        private readonly ILogger log = log;
        private readonly PageModel model = model;

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
            //log.Info(model.XPath(model.Key));
            //log.Info("//div[starts-with(@class, 'stockRolldiv')]");

            //var myNodes = doc.DocumentNode.SelectNodes("//a[starts-with(@id,'menu-item-')]");

            //var nodes = doc.DocumentNode.SelectNodes(model.XPath(model.Key));
            HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[starts-with(@class, 'stockRolldiv')]");
            if (nodes.Count == 0)
            {
                log.Error("Document does not contain TICKER element");
                return PageData.Empty;
            }

            if (nodes.Count > 1)
                log.Error("Document contains multiple TICKER elements");

            string key = nodes[0].InnerText;

            return new PageData(key, "", "", "", "", "", "", DateOnly.MinValue);
        }
    }
}
