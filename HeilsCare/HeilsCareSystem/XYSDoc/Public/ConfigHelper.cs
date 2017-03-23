using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace XYS.Remp.Screening.Public
{
    public class ConfigHelper
    {
        public static string GetAppsettings(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        public static string GetConnectionStrings(string key)
        {
            var config = ConfigurationManager.ConnectionStrings[key];
            if (config == null)
                throw new ArgumentNullException("key");

            return config.ConnectionString;
        }

        /// <summary>
        /// 筛查机api站点地址
        /// </summary>
        public static string ScreenWebApiUrl
        {
            get { return GetAppsettings("ScreenWebApiUrl") ?? ""; }
        }
        /// <summary>
        /// OAuth地址
        /// </summary>
        public static string OAuthUrl
        {
            get { return GetAppsettings("OAuthUrl") ?? ""; }
        }
        /// <summary>
        /// 默认小屋Id
        /// </summary>
        public static string DefaultOrgId
        {
            get { return GetAppsettings("DefaultOrgId") ?? ""; }
        }

        /// <summary>
        /// UserApi地址
        /// </summary>
        public static string UserApiUrl
        {
            get { return GetAppsettings("UserApi") ?? ""; }
        }
    }
}
