using System;
using System.Collections.Generic;
using System.Linq;
using eMentor.Common.Models;

namespace eMentor.DBContext.Services.impl
{
    public class GeneralService : BaseService, IGeneralService
    {

        public GeneralService(DbContextFactory contextFactory) : base(contextFactory)
        {
        }


        public string GetHardcodeName(Type parent, int value)
        {
            var list = this.GetHardcodes(parent.Name);
            return list.FirstOrDefault(p => p.Value == value).Name;
        }
        public HardcodeModel GetHardcode(Type parent, int value)
        {
            var list = this.GetHardcodes(parent.Name);
            return list.FirstOrDefault(p => p.Value == value);
        }
        public IList<HardcodeModel> GetHardcodes(string parent)
        {
            return _hardCodeRepository.GetByParent(parent).ToListModel();
        }

    }
}
