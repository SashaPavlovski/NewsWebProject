using NUnit.Framework;
using NewsWebProject.Data.Sql.RSSWebs;

namespace NewsWebProject.Data.Sql.Test
{
    [TestFixture]
    public class GetData
    {
        DSGetRSSWebsData dsGetRSSWebsData;

        [Test]
        [SetUp]
        public void Init()
        {
            dsGetRSSWebsData = new DSGetRSSWebsData(null);
        }


        [Test]
        [Category("GetSqlDataRSSWebs")]
        public void GetWebsList()
        {
            string Insert = " select *,*\r\n from [dbo].[TBRSSWebs] TB1 inner join [dbo].[TBCategories] TB2\r\n on TB1.Category_CategoryID = TB2.CategoryID";

            Assert.That(dsGetRSSWebsData.GetSql.GetData(Insert, dsGetRSSWebsData.SetValues, dsGetRSSWebsData.GetFromDataBase), !Is.Null);
        }

    }
}
