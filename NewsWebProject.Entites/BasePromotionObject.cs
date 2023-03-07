using Utilities.Logger;

namespace NewsWebProject.Entites
{
    public class BasePromotionObject
    {
        public Logger Logger;
        public BasePromotionObject(Logger logger)
        {
            Logger = logger;
        }
    }
}
