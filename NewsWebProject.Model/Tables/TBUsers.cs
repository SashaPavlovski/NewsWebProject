using System.ComponentModel.DataAnnotations;

namespace NewsWebProject.Model.Tables
{
    public record TBUsers
    {
        public TBUsers() { }

        [Key]
        public int UserID { get; set; }

        public string UserGmail { get; set; }
    }
}
