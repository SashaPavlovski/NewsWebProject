using NUnit.Framework;
using NewsWebProject.Data.Sql.RSSWebs;
using NewsWebProject.Model.Tables;


namespace NewsWebProject.Data.Sql.Test
{
    [TestFixture]
    public class GetData
    {
        DSGetRSSWebsData dsGetRSSWebsData;

        [Test]
        [Order(0)]
        public void Init()
        {
            dsGetRSSWebsData = new DSGetRSSWebsData(null);
        }


        [Test]
        [Order(1)]
        [Category("GetSqlDataRSSWebs")]
        public void GetWebsList()
        {
            dsGetRSSWebsData = new DSGetRSSWebsData(null);

            string Insert = " select *,*\r\n from [dbo].[TBRSSWebs] TB1 inner join [dbo].[TBCategories] TB2\r\n on TB1.Category_CategoryID = TB2.CategoryID";

            Assert.That(dsGetRSSWebsData.GetSql.GetData(Insert, dsGetRSSWebsData.SetValues, dsGetRSSWebsData.GetFromDataBase), !Is.Null);
        }

    }
}
