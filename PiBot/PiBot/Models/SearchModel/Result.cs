namespace PiBot.Models.SearchModel
{
    public class Result
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string[] Type { get; set; }
        public DetailedDescription DetailedDescription { get; set; }
        public string Id { get; set; }
        public Image Image { get; set; }

    }
}