using NewsWebProject.Dal;
using NewsWebProject.Data.Sql.RSSWebs;
using NewsWebProject.Entites.WebsData.ModelProviders;
using NewsWebProject.Model.Tables;
using Utilities.Logger;

namespace NewsWebProject.Entites.WebsData
{
    public class ReadAllNews: BaseWebsData
    {
        public List<TBRSSWebs> WebsList;

        public List<TBRSSWebs> GlobesList;

        public List<TBRSSWebs> WallaList;

        public List<TBRSSWebs> MaarivList;
        
        public List<TBRSSWebs> YnetList;

        private WebsName webName;

        private DSGetRSSWebsData getRSSWebsData;

        private IProvideData provideGlobes;

        private IProvideData provideWalla;

        private IProvideData provideMaariv;

        private IProvideData provideYnet;

        public ReadAllNews(Logger logger) : base(logger)
        {
            Init();
        }

        public void Init()
        {
            GetDataSql();

            getRSSWebsData = new DSGetRSSWebsData(this.Logger);

            provideGlobes = new MPGlobes(this.Logger, GlobesList);

            provideWalla = new MPWalla(this.Logger, WallaList);

            provideMaariv = new MPMaariv(this.Logger, MaarivList);

            provideYnet = new MPYnet(this.Logger, YnetList);
        }

        public void GetDataSql()
        {
           webName = new WebsName();

            object objectList = getRSSWebsData.GetFromDataBase();

            if(objectList != null && objectList is List<TBRSSWebs>)
            {
                WebsList = (List<TBRSSWebs>)objectList;
            }

            GlobesList = WebsList.FindAll(e => e.RSSWebName == webName.WebName1);
            WallaList = WebsList.FindAll(w => w.RSSWebName == webName.WebName4);
            MaarivList = WebsList.FindAll(m => m.RSSWebName == webName.WebName3);
            YnetList = WebsList.FindAll(y => y.RSSWebName == webName.WebName2);

        }

    }

}
