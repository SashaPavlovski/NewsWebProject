using NUnit.Framework;
using NewsWebProject.Entites.WebsData.ModelProviders;
using NewsWebProject.Data.Sql.RSSWebs;
using NewsWebProject.Model.Tables;

namespace NewsWebProject.Entites.Test
{
    [TestFixture]
    internal class GetCategoryNews
    {
        DSGetRSSWebsData getRSSWebsData;

        MPGlobes provideGlobes;

        List<TBRSSWebs> WebsList;

        List<TBRSSWebs> GlobesList;


        [Test]
        [SetUp]
        public void Init()
        {
            getRSSWebsData = new DSGetRSSWebsData(null);

            GetRSSWebs();

            GetGlobesCategoriesNews();

            Console.ReadLine();
        }

        [Test]
        public void GetRSSWebs()
        {
            object objectList = getRSSWebsData.GetData(null);

            if (objectList != null && objectList is List<TBRSSWebs>)
            {
                WebsList = (List<TBRSSWebs>)objectList;
            }

            GlobesList = WebsList.FindAll(e => e.RSSWebName == "גלובוס");

        }

        [Test]
        [Category("GlobesCategoriesNews")]
        public void GetGlobesCategoriesNews()
        {
            provideGlobes = new MPGlobes(null, GlobesList);

        }
    }
}
