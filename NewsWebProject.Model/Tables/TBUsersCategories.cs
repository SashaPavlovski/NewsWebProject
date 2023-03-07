using System.ComponentModel.DataAnnotations;

namespace NewsWebProject.Model.Tables
{
    public record TBUsersCategories
    {
        public TBUsersCategories() { }

        [Key]

        public int UserCategoryID { get; set; }
        public TBUsers User { get; set; }
        public TBCategories Category { get; set; }
        public bool Active { get; set; }
    }
}
