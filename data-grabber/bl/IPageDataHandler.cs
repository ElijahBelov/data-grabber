namespace data_grabber.bl
{
    internal interface IPageDataHandler
    {
        void Start();

        void Handle(PageData data);

        void End();
    }
}
