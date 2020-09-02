using System.IO;
using System.Net;

namespace CatAlog_App.GUI.Infrastructure.Services
{
    /// <summary>
    /// Contains methods for working with web
    /// </summary>
    public class HttpManager
    {
        /// <summary>
        /// Uploading a file to the specified address
        /// </summary>
        /// <param name="url">Addres to downloaded file</param>
        /// <returns>Memory strem</returns>
        public MemoryStream DownloadFile(string url)
        {
            using WebClient webClient = new WebClient();
            byte[] arr = webClient.DownloadData(url);
            return new MemoryStream(arr);
        }
    }
}
