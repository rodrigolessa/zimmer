

using BSI.Zimmer.Infraestrutura.Comuns.Logging;
namespace BSI.Zimmer.Infraestrutura.Comuns.Logging
{
    /// <summary>
    /// Fábrica concreta para construção de logs
    /// </summary>
    public static class LoggerFactory
    {
        #region Members

        static ILoggerFactory _currentLogFactory = null;

        #endregion

        #region Public Methods

        public static void SetCurrent(ILoggerFactory logFactory)
        {
            _currentLogFactory = logFactory;
        }

        public static ILogger CreateLog()
        {
            return (_currentLogFactory != null) ? _currentLogFactory.Create() : null;
        }

        #endregion
    }
}
