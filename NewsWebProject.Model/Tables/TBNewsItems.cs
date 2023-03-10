using System.ComponentModel.DataAnnotations;

namespace NewsWebProject.Model.Tables
{
    public record TBNewsItems
    {
        public TBNewsItems() { }

        [Key]
        public int NewsItemID { get; set; }

        public string NewsItemTitle { get; set; }

        public string NewsItemDescription { get; set; }

        public string NewsItemImage { get; set; }

        public string NewsItemUrl { get; set; }

        public int NewsItemEntriesCount { get; set; } = 0;
        public TBRSSWebs RSSWeb { get; set; }
        public bool Active { get; set; } = true;
        public DateTime NewsItemDate { get; set; }
    }
}
