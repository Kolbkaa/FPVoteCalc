using System.Collections.Generic;

namespace VoteCalc.Database.Repository
{
    public abstract class Repository<T>
    {
        public abstract List<T> GetAll();
        public abstract void AddAll(IList<T> list);
        public abstract void Save(T model);
    }
}
