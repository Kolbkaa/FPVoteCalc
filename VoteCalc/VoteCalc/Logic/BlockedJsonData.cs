using System.Collections.Generic;
using System.Linq;

namespace VoteCalc.Logic
{
    internal class BlockedJsonData : JsonDownload<BlockedJsonData.RootObject>
    {
        public BlockedJsonData() : base(@"http://webtask.future-processing.com:8069/blocked")
        {
        }

        public List<string> GetAll()
        {
            var jsonData = DownloadJson() as RootObject;
            var blockedPesel = jsonData?.Disallowed.Person;

            return blockedPesel?.Select(person => person.Pesel)?.ToList();
        }

        internal class Person
        {
            public string Pesel { get; set; }
        }

        internal class Disallowed
        {
            public string PublicationDate { get; set; }
            public List<Person> Person { get; set; }
        }

        internal class RootObject
        {
            public Disallowed Disallowed { get; set; }
        }
    }
}
