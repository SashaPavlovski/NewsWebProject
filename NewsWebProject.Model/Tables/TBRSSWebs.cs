using System.ComponentModel.DataAnnotations;

namespace NewsWebProject.Model.Tables
{
    public record TBRSSWebs
    {
        public TBRSSWebs() { }

        [Key]
        public int RSSWebID { get; set; }
        public string RSSWebName { get; set; }
        public string RSSWebUrl { get; set; }
        public TBCategories Category { get; set; }
    }
}
