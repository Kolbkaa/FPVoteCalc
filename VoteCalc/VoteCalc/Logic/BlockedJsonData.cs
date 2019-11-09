using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteCalc.Logic
{
    class BlockedJsonData : JsonDownload<BlockedJsonData.RootObject>
    {
        public BlockedJsonData() : base(@"http://webtask.future-processing.com:8069/blocked")
        {
        }

        public List<string> GetAll()
        {
            var jsonData = DownloadJson() as RootObject;
            var blockedPesel = jsonData?.disallowed.person;

            return blockedPesel.Select(person => person.pesel).ToList();
        }

        internal class Person
        {
            public string pesel { get; set; }
        }

        internal class Disallowed
        {
            public string publicationDate { get; set; }
            public List<Person> person { get; set; }
        }

        internal class RootObject
        {
            public Disallowed disallowed { get; set; }
        }
    }
}
