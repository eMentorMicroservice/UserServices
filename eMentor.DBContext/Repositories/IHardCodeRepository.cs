using eMentor.Entities;
using System;
using System.Collections.Generic;

namespace eMentor.DBContext.Repositories
{
    public interface IHardCodeRepository : IBaseRepository<HardCode>
    {
        IList<HardCode> GetByParent(string parent);
        string GetByName(int id, string name);
        HardCode GetHardCode(Type parent, int value);
    }
}
