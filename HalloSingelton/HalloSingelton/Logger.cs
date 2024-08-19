
namespace HalloSingelton
{
    internal class Logger
    {
        static Logger _instance = null;
        static object _instanceLock = new object();
        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_instanceLock)
                    {
                        if (_instance == null)
                            _instance = new Logger();
                    }
                }
                return _instance;
            }
        }

        private Logger()
        {
            LogInfo("CTOR Logger");
        }

        internal void LogInfo(string message)
        {
            Console.WriteLine($"[INFO] {DateTime.Now:g} {message}");
        }

    }
}
