using System.ComponentModel.DataAnnotations;

namespace NewsWebProject.Model.Tables
{
    public record TBCategories
    {
        public TBCategories() { }

        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
