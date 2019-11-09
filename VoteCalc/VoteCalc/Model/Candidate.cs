using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using VoteCalc.Logic;

namespace VoteCalc.Model
{
    public class Candidate : CryptData
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Party { get; set; }
        public bool Vote { get; set; }
    }


}

