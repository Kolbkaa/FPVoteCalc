using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VoteCalc.Logic
{
    public class JsonDownload<T>
    {
        private readonly string _url;
        protected JsonDownload(string url)
        {
            _url = url;
        }
        public object DownloadJson()
        {
            using (var webClient = new WebClient())
            {
                var json = webClient.DownloadString(_url);

                return (T)JsonConvert.DeserializeObject<T>(json);
            }

        }
    }
}
