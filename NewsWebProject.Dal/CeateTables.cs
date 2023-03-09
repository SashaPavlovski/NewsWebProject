using NewsWebProject.Model.Tables;
using System.Data.Entity;

namespace NewsWebProject.Dal
{
    public class CeateTables: DbContext
    {
        private static CeateTables data;
        public CeateTables() : base(BaseDal.ConnectionString)
        {
            try
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<CeateTables>());
                if (Users.Count() == 0) Seed();
                Database.Connection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// singleton CeateTables class
        /// </summary>
        public static CeateTables Data
        {
            get
            {
                try
                {
                    if (data == null) data = new CeateTables();
                    return data;
                }
                catch (Exception)
                {

                    return null;
                }

            }
        }

        /// <summary>
        /// Entering the data of the categories and webs url into the tables.
        /// </summary>
        private void Seed()
        {
            CategoriesName categoriesName = new CategoriesName();

            WebsName webs = new WebsName();

            if (Users.Count() == 0)
            {
                try
                {
                    Users.Add(new TBUsers { UserGmail = "aaa@gmail.com" });

                    Categories.AddRange(new List<TBCategories>
                    {
                        new TBCategories{ CategoryName=categoriesName.CategoryName1},
                        new TBCategories{ CategoryName=categoriesName.CategoryName2},
                        new TBCategories{ CategoryName=categoriesName.CategoryName3},
                        new TBCategories{ CategoryName=categoriesName.CategoryName4},
                        new TBCategories{ CategoryName=categoriesName.CategoryName5},
                        new TBCategories{ CategoryName=categoriesName.CategoryName6},
                        new TBCategories{ CategoryName=categoriesName.CategoryName7},
                        new TBCategories{ CategoryName=categoriesName.CategoryName8},
                        new TBCategories{ CategoryName=categoriesName.CategoryName9},
                        new TBCategories{ CategoryName=categoriesName.CategoryName10},
                        new TBCategories{ CategoryName=categoriesName.CategoryName11},
                        new TBCategories{ CategoryName=categoriesName.CategoryName12},
                        new TBCategories{ CategoryName=categoriesName.CategoryName13},
                        new TBCategories{ CategoryName=categoriesName.CategoryName14},
                        new TBCategories{ CategoryName=categoriesName.CategoryName15},
                    });

                    SaveChanges();

                    RSSWebs.AddRange(new List<TBRSSWebs>
                    {
                        AddRSSWed(categoriesName.CategoryName1,webs.WebName1,"https://www.globes.co.il/webservice/rss/rssfeeder.asmx/FeederNode?iID=3220" ),
                        AddRSSWed(categoriesName.CategoryName1,webs.WebName2,"http://www.ynet.co.il/Integration/StoryRss550.xml" ),
                        AddRSSWed(categoriesName.CategoryName1,webs.WebName3,"https://www.maariv.co.il/Rss/RssFeedsRechev" ),
                        AddRSSWed(categoriesName.CategoryName1,webs.WebName4,"https://rss.walla.co.il/feed/4705" ),
                        AddRSSWed(categoriesName.CategoryName2,webs.WebName1,"https://www.globes.co.il/webservice/rss/rssfeeder.asmx/FeederNode?iid=9010" ),
                        AddRSSWed(categoriesName.CategoryName2,webs.WebName2,"http://www.ynet.co.il/Integration/StoryRss598.xml" ),
                        AddRSSWed(categoriesName.CategoryName2,webs.WebName3,"https://www.maariv.co.il/Rss/RssFeedsTayarot" ),
                        AddRSSWed(categoriesName.CategoryName2,webs.WebName4,"https://rss.walla.co.il/feed/14?type=main" ),
                        AddRSSWed(categoriesName.CategoryName3,webs.WebName1,"https://www.globes.co.il/webservice/rss/rssfeeder.asmx/FeederNode?iid=3266" ),
                        AddRSSWed(categoriesName.CategoryName3,webs.WebName2,"http://www.ynet.co.il/Integration/StoryRss4111.xml" ),
                        AddRSSWed(categoriesName.CategoryName3,webs.WebName3,"https://www.maariv.co.il/Rss/RssFeedsMivzakiChadashot" ),
                        AddRSSWed(categoriesName.CategoryName3,webs.WebName4,"https://rss.walla.co.il/feed/12864" ),
                        AddRSSWed(categoriesName.CategoryName4,webs.WebName1,"https://www.globes.co.il/webservice/rss/rssfeeder.asmx/FeederNode?iID=1225" ),
                        AddRSSWed(categoriesName.CategoryName4,webs.WebName2,"http://www.ynet.co.il/Integration/StoryRss6.xml" ),
                        AddRSSWed(categoriesName.CategoryName4,webs.WebName3,"https://www.maariv.co.il/Rss/RssFeedsKalkalaBaArez" ),
                        AddRSSWed(categoriesName.CategoryName4,webs.WebName4,"https://rss.walla.co.il/feed/2?type=main" ),
                        AddRSSWed(categoriesName.CategoryName5,webs.WebName1,"https://www.globes.co.il/webservice/rss/rssfeeder.asmx/FeederNode?iID=607" ),
                        AddRSSWed(categoriesName.CategoryName5,webs.WebName3,"https://www.maariv.co.il/Rss/RssFeedsNadlan" ),
                        AddRSSWed(categoriesName.CategoryName5,webs.WebName4,"https://rss.walla.co.il/feed/13111" ),
                        AddRSSWed(categoriesName.CategoryName6,webs.WebName2,"http://www.ynet.co.il/Integration/StoryRss3.xml" ),
                        AddRSSWed(categoriesName.CategoryName6,webs.WebName3,"https://www.maariv.co.il/Rss/RssFeedsSport" ),
                        AddRSSWed(categoriesName.CategoryName6,webs.WebName4,"https://rss.walla.co.il/feed/3?type=main" ),
                        AddRSSWed(categoriesName.CategoryName7,webs.WebName1,"https://www.globes.co.il/webservice/rss/rssfeeder.asmx/FeederNode?iID=821" ),
                        AddRSSWed(categoriesName.CategoryName7,webs.WebName2,"http://www.ynet.co.il/Integration/StoryRss5363.xml" ),
                        AddRSSWed(categoriesName.CategoryName7,webs.WebName3,"https://www.maariv.co.il/Rss/RssFeedsZarchanot" ),
                        AddRSSWed(categoriesName.CategoryName7,webs.WebName4,"https://rss.walla.co.il/feed/127" ),
                        AddRSSWed(categoriesName.CategoryName8,webs.WebName3,"https://www.maariv.co.il/Rss/RssFeedsZavaVeBetachon" ),
                        AddRSSWed(categoriesName.CategoryName8,webs.WebName4,"https://rss.walla.co.il/feed/2689" ),
                        AddRSSWed(categoriesName.CategoryName9,webs.WebName1,"https://www.globes.co.il/webservice/rss/rssfeeder.asmx/FeederNode?iID=829" ),
                        AddRSSWed(categoriesName.CategoryName9,webs.WebName3,"https://www.maariv.co.il/Rss/RssMishpat" ),
                        AddRSSWed(categoriesName.CategoryName10,webs.WebName1,"https://www.globes.co.il/webservice/rss/rssfeeder.asmx/FeederNode?iID=9917" ),
                        AddRSSWed(categoriesName.CategoryName10,webs.WebName3,"https://www.maariv.co.il/Rss/RssFeedsChadashotBaArez" ),
                        AddRSSWed(categoriesName.CategoryName10,webs.WebName4,"https://rss.walla.co.il/feed/1" ),
                        AddRSSWed(categoriesName.CategoryName11,webs.WebName2,"http://www.ynet.co.il/Integration/StoryRss4104.xml" ),
                        AddRSSWed(categoriesName.CategoryName11,webs.WebName3,"https://www.maariv.co.il/Rss/RssFeedsOfna" ),
                        AddRSSWed(categoriesName.CategoryName11,webs.WebName4,"https://rss.walla.co.il/feed/24?type=main" ),
                        AddRSSWed(categoriesName.CategoryName12,webs.WebName2,"http://www.ynet.co.il/Integration/StoryRss4879.xml" ),
                        AddRSSWed(categoriesName.CategoryName12,webs.WebName3,"https://www.maariv.co.il/Rss/RssFeedsEnvironment" ),
                        AddRSSWed(categoriesName.CategoryName12,webs.WebName4,"https://rss.walla.co.il/feed/13110" ),
                        AddRSSWed(categoriesName.CategoryName13,webs.WebName1,"https://www.globes.co.il/webservice/rss/rssfeeder.asmx/FeederNode?iID=3312" ),
                        AddRSSWed(categoriesName.CategoryName13,webs.WebName3,"https://www.maariv.co.il/Rss/RssFeedsTMI" ),
                        AddRSSWed(categoriesName.CategoryName13,webs.WebName4,"https://rss.walla.co.il/feed/22?type=main" ),
                        AddRSSWed(categoriesName.CategoryName14,webs.WebName2,"http://www.ynet.co.il/Integration/StoryRss538.xml" ),
                        AddRSSWed(categoriesName.CategoryName14,webs.WebName3,"https://www.maariv.co.il/Rss/RssFeedsTarbot" ),
                        AddRSSWed(categoriesName.CategoryName14,webs.WebName4,"https://rss.walla.co.il/feed/4?type=main" ),
                        AddRSSWed(categoriesName.CategoryName15,webs.WebName2,"http://www.ynet.co.il/Integration/StoryRss1208.xml" ),
                        AddRSSWed(categoriesName.CategoryName15,webs.WebName3,"https://www.maariv.co.il/Rss/RssFeedsBriotVeYeoz" ),
                        AddRSSWed(categoriesName.CategoryName15,webs.WebName4,"https://rss.walla.co.il/feed/139?type=main" )
                    });

                    SaveChanges();  
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Creating a new TBRSSWebs class instance.
        /// </summary>
        /// <param name="category">Name of the category</param>
        /// <param name="webName">Name of the website</param>
        /// <param name="categoryUrl">Url of the website</param>
        /// <returns>New TBRSSWebs class instance</returns>
        private TBRSSWebs AddRSSWed(string category, string webName, string categoryUrl)
        {
            try
            {
                List<TBCategories> categories = Categories.ToList();

                TBRSSWebs ReturnRSSWeb = null;

                if (categories != null && category != null && webName != null && webName != null)
                {
                    ReturnRSSWeb = new TBRSSWebs
                    {
                        Category = categories.Find(c => c.CategoryName == category),
                        RSSWebName = webName,
                        RSSWebUrl = categoryUrl,
                    };
                }

                return ReturnRSSWeb;
            }
            catch (Exception)
            {
                throw;
            }

        }


        public DbSet<TBCategories> Categories { get; set; }
        public DbSet<TBNewsItems> NewsItems { get; set; }
        public DbSet<TBRSSWebs> RSSWebs { get; set; }
        public DbSet<TBUsers> Users { get; set; }
        public DbSet<TBUsersCategories> UsersCategories { get; set; }

    }
}
