using System;
using System.Collections.Generic;
using System.Text;

namespace eMentor.Common.Utils
{
    public class Constants
    {
        public const string API_KEY = "Hello_2020_eMentor";
        public const string API_ISSUER = "eMentor";
        public const string API_CLIENT = "eMentorClient";

        public const int REPOSITORY_FAILED = 0;
        public const string DATETIME_FORMAT = "dd'/'MM'/'yyyy HH:mm:ss";
        public const string DATE_FORMAT = "dd'/'MM'/'yyyy";
        public const string TTME_FORMAT = "HH:mm:ss";
        public const string DEFAULT_DATEOFBIRTH = "01/01/1990";

        public const string DEFAULT_PASSCODE = "123456x@X";

        public static string UserDataFolderName = "UserData";
        public static string ImageDisplayPrefix = "/userData/images";

        public const string COLOR_YELLOW = "#AD07FA";
        public const string COLOR_RED = "#B60000";
        public const string COLOR_GREEEN = "#12b600";
        public const string COLOR_PURPLE = "#700361";

        public static IList<string> ActionAllowAnonymous = new List<string>()
        {
            "/api/Home/Login",
            "/api/Home/ForgotPassword"
        };
    }
}
