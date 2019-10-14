using System;
using System.Collections.Generic;
using System.Text;

namespace eMentor.DBContext.Services
{
    public interface IAppSettingService
    {
        string ConnectionString { get; }
    }
}
