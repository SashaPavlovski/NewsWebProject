using Utilities.Logger;

namespace NewsWebProject.Entites
{
    public class MainManager
    {
        private static MainManager _INSTANCE;

        public Logger Logger;
        private MainManager()
        {
            Init();

            Logger.LogEvent("Exited the MainManager");
        }


        /// <summary>
        /// singleton MainManager class
        /// </summary>
        public static MainManager INSTANCE
        {
            get 
            { 
                if(_INSTANCE == null) _INSTANCE = new MainManager();
                return _INSTANCE;
            }
        }

        /// <summary>
        /// Init Entites instance classes.
        /// </summary>
        public void Init()
        {
            Logger = new Logger("");

            Logger.LogEvent("Initialize the entities classes");
        }
    }
}
