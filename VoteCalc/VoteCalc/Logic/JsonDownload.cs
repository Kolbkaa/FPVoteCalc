using Newtonsoft.Json;
using System.Net;
using System.Text;
using VoteCalc.Tools;

namespace VoteCalc.Logic
{
    public abstract class JsonDownload<T>
    {
        private readonly string _url;
        protected JsonDownload(string url)
        {
            _url = url;
        }
        protected object DownloadJson()
        {
            using (var webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                string json;

                try
                {
                    json = webClient.DownloadString(_url);
                    
                }
                catch (WebException e)
                {
                    ErrorMessage.ShowError($"Download data error.",e);
                    return null;
                }

                return (T)JsonConvert.DeserializeObject<T>(json);
            }

        }
    }
}
