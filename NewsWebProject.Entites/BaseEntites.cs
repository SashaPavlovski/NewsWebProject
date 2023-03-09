using Utilities.Logger;

namespace NewsWebProject.Entites
{
    public interface IGetDataSqlValues
    {
        public void Init();
        public object GetDataSql(object value);

    }
    public class BaseEntites: BasePromotionObject
    {
        public BaseEntites(Logger logger) : base(logger) { }
    }
}
