namespace MyMangoDbAjaxProject.Dal.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string SliderCollectionName { get; set; }
        public string AboutCollectionName { get; set; }
        public string ServicesCollectionName { get; set; }
        public string FourImagesCollectionName { get; set; }
        public string TestimonialCollectionName { get; set; }
        public string BlogCollectionName { get; set; }
        public string FooterCollectionName { get; set; }
        public string ContactCollectionName { get; set; }



	}
}
