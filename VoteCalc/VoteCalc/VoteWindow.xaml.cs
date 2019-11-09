using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VoteCalc.Model;

namespace VoteCalc
{
    /// <summary>
    /// Interaction logic for VoteWindow.xaml
    /// </summary>
    public partial class VoteWindow : Window
    {
        private Voter _voter;
        public VoteWindow(Voter voter)
        {
          XmlDocument xmlDocument = new XmlDocument();
            using (var webClient = new WebClient())
            {
                webClient.Headers.Add(HttpRequestHeader.Accept, "application/xml");
                var xmlString = webClient.DownloadString("http://webtask.future-processing.com:8069/candidates");
                xmlDocument.LoadXml(xmlString);
            }

            var candidate = xmlDocument.DocumentElement.SelectNodes("candidate");
            foreach (XmlNode xmlNode in candidate)
            {
                var ineText = xmlNode.InnerText;
            }
             
            //var json2 = JsonConvert.DeserializeObject((json as Array)[1]);
            _voter = voter;
            InitializeComponent();
        }
    }

     class Temp
    {
        public string PublicationDate { get; set; }
        public string Candidate { get; set; }
    }
}
