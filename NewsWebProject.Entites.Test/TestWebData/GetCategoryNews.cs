using NUnit.Framework;
using NewsWebProject.Entites.WebsData.ModelProviders;
using NewsWebProject.Data.Sql.RSSWebs;
using NewsWebProject.Model.Tables;
using NewsWebProject.Dal;

namespace NewsWebProject.Entites.Test.TestWebData
{
    [TestFixture]
    internal class GetCategoryNews
    {
        DSGetRSSWebsData getRSSWebsData;

        MPGlobes provideGlobes;

        MPWalla provideWalla;

        MPMaariv provideMaariv;

        MPYnet provideYnet;

        List<TBRSSWebs> WebsList;

        List<TBRSSWebs> GlobesList;

        List<TBRSSWebs> WallaList;

        List<TBRSSWebs> MaarivList;

        List<TBRSSWebs> YnetList;

        public class WebsName
        {
            public readonly string WebName1 = "גלובוס";
            public readonly string WebName2 = "ynet";
            public readonly string WebName3 = "מעריב";
            public readonly string WebName4 = "וואלה";
        }

        [Test]
        [SetUp]
        public void Init()
        {
            getRSSWebsData = new DSGetRSSWebsData(null);
            GetRSSWebs();
            GetGlobesCategoriesNews2();
        }

        //[Test]
        //[Category("GetRSSWebs")]
       // [Order(1)]

        public void GetRSSWebs()
        {
            object objectList = getRSSWebsData.GetData(null);

            if (objectList != null && objectList is List<TBRSSWebs>)
            {
                WebsList = (List<TBRSSWebs>)objectList;
            }

            WebsName name = new WebsName();
            GlobesList = WebsList.FindAll(e => e.RSSWebName == name.WebName1);
            YnetList = WebsList.FindAll(e => e.RSSWebName == name.WebName2);
            MaarivList = WebsList.FindAll(e => e.RSSWebName == name.WebName3);
            WallaList = WebsList.FindAll(e => e.RSSWebName == name.WebName4);


        }

        //[Test]
        //[Category("GetGlobesCategoriesNews1")]
        //[Order(2)]
        //public void GetGlobesCategoriesNews1()
        //{
        //    provideGlobes = new MPGlobes(null, GlobesList);

        //}

        //[Test]
        //[Category("GetGlobesCategoriesNews2")]
       // [Order(3)]
        public void GetGlobesCategoriesNews2()
        { 

            provideWalla = new MPWalla(null, WallaList);
            Console.ReadLine();
        }

        //[Test]
        //[Category("GetGlobesCategoriesNews3")]
        //[Order(4)]
        //public void GetGlobesCategoriesNews3()
        //{

        //    provideMaariv = new MPMaariv(null, MaarivList);

        //}

        //[Test]
        //[Category("GetGlobesCategoriesNews4")]
        //[Order(5)]
        //public void GetGlobesCategoriesNews4()
        //{

        //    provideYnet = new MPYnet(null, YnetList);

        //}
    }
}
