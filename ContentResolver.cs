using System;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.Web;

namespace WebViewFreeze
{
    sealed class ContentResolver : IUriToStreamResolver
    {
        public IAsyncOperation<IInputStream> UriToStreamAsync(Uri uri)
        {
            if (uri == default)
            {
                throw new ArgumentNullException(nameof(uri));
            }
            var path = uri.AbsolutePath;
            return GetContentAsync(path).AsAsyncOperation();
        }

        private async Task<IInputStream> GetContentAsync(string uriPath)
        {
            try
            {
                var localUri = new Uri($"ms-appx://{uriPath}");
                var file = await StorageFile.GetFileFromApplicationUriAsync(localUri);
                using (var stream = await file.OpenReadAsync())
                {
                    return stream.GetInputStreamAt(0);
                }
            }
            finally { }
        }
    }
}
