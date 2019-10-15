using System;
using System.Collections.Generic;
using eMentor.Common.Models;

namespace eMentor.DBContext.Services
{
    public interface IGeneralService
    {
        IList<HardcodeModel> GetHardcodes(string parent);
        string GetHardcodeName(Type parent,int value);
        HardcodeModel GetHardcode(Type parent, int value);
    }
}
