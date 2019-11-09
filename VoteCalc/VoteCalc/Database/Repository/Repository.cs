using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteCalc.Database.Repository
{
    public abstract class Repository<T>
    {
        public abstract List<T> GetAll();

        public abstract void AddAll(IList<T> list);
    }
}
