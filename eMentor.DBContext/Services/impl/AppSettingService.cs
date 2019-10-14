using eMentor.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eMentor.DBContext.Services.impl
{
    public class AppSettingService : IAppSettingService
    {
        private IdentitySettings _identitySetting;

        public AppSettingService(IdentitySettings identitySettings)
        {
            _identitySetting = identitySettings;
        }

        public string ConnectionString => _identitySetting.DefaultConnection;
    }
}
