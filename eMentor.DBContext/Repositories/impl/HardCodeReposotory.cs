using eMentor.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMentor.DBContext.Repositories.impl
{
    public class HardCodeRepository : BaseRepository<HardCode>, IHardCodeRepository
    {
        public HardCodeRepository(DbContextFactory contextFactory) : base(contextFactory)
        {

        }

        public string GetByName(int id, string name)
        {
            return FirstOrDefault(p => p.Value.Equals(id) & p.ParentId.Equals(name)).Name;
        }

        public IList<HardCode> GetByParent(string parent)
        {
            return GetAll(p => p.ParentId.Equals(parent));
        }

        public HardCode GetHardCode(Type parent, int value)
        {
            var hardCodes = this.GetByParent(parent.Name);
            return hardCodes.FirstOrDefault(p => p.Value == value);
        }
    }
}
