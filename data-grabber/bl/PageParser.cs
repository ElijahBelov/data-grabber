using HtmlAgilityPack;

namespace data_grabber.bl
{
    internal class PageParser(PageModel model)
    {
        private readonly PageModel model = model;

        public void Parse(StreamReader source, DataWriter output)
        {
            HtmlDocument doc = new();
            doc.Load(source.BaseStream);

            var myNodes = doc.DocumentNode.SelectNodes("//a[starts-with(@id,'menu-item-')]");
        }
    }
}
