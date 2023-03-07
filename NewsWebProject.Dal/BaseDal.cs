using System.Data.Entity;
using System.Data.SqlClient;

namespace NewsWebProject.Dal
{
    public class BaseDal
    {
        public static string ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=NewsWebProject;Data Source=localhost\\SQLEXPRESS";

    }
    public class WebsName
    {
        public readonly string WebName1 = "גלובוס";
        public readonly string WebName2 = "ynet";
        public readonly string WebName3 = "מעריב";
        public readonly string WebName4 = "וואלה";
    }

    public class CategoriesName
    {
        public readonly string CategoryName1 = "רכב";
        public readonly string CategoryName2 = "תיירות";
        public readonly string CategoryName3 = "קריירה";
        public readonly string CategoryName4 = "כלכלה";
        public readonly string CategoryName5 = "נדלן ותשתיות";
        public readonly string CategoryName6 = "ספורט";
        public readonly string CategoryName7 = "צרכנות";
        public readonly string CategoryName8 = "צבא וביטחון";
        public readonly string CategoryName9 = "דין וחשבון";
        public readonly string CategoryName10 = "בארץ";
        public readonly string CategoryName11 = "אופנה";
        public readonly string CategoryName12 = "איכות הסביבה";
        public readonly string CategoryName13 = "סלבס";
        public readonly string CategoryName14 = "תרבות";
        public readonly string CategoryName15 = "בריאות";
    }
}
