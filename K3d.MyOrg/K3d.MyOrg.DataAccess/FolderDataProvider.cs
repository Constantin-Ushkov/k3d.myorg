using K3d.MyOrg.Core.Logging;
using K3d.MyOrg.DataAccess.Cache;
using K3d.MyOrg.DataAccess.Interface;
using K3d.MyOrg.DataAccess.Interface.Spendings;
using K3d.MyOrg.DataAccess.Spendings;

namespace K3d.MyOrg.DataAccess
{
    public class FolderDataProvider : IDataProvider, IDisposable
    {
        private bool _isDisposed;
        private readonly string _baseFolder;
        private readonly ILogger _logger;
        private readonly DataCache _cache;

        public ISpendingsDataProvider SpendingsDataProvider { get; }

        public FolderDataProvider(ILogger logger, string baseFolder)
        {
            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));

            _baseFolder = baseFolder;
            _cache = new DataCache(_logger, _baseFolder);

            SpendingsDataProvider = new SpendingsDataProvider();
        }

        public void Open()
        {
            _logger.Info("Opening data provider with base folder: {0}", _baseFolder);
            _cache.Load(_baseFolder);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _isDisposed = true;
            }
        }
    }
}
