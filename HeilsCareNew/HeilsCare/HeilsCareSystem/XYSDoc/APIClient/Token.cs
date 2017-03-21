using System;
using Newtonsoft.Json;
using System.Web;
using System.Web.Caching;
using XYS.Remp.Screening.Public;
using XYS.Remp.Screening.Security;

namespace XYS.Remp.Screening.APIClient
{
    public class Token
    {
        public static string GetAccessToken()
        {
            string token = "";
            const string cachename = "apitoken1";
            if (HttpRuntime.Cache.Get(cachename)==null)
            //if (HttpContext.Current.Cache.Get(cachename) == null)
            {
                var WebClientObj = new System.Net.WebClient();
                var PostVars = new System.Collections.Specialized.NameValueCollection
                {
                    {"scope", "http://www.e24health.com/"}, //有权限的域,多个以空格隔开
                    {"grant_type", "client_credentials"}, //验证方式
                    {"client_id", "xys.sjzx"}, //用户
                    {"client_secret", DES.EncryptDESByKey("szxys.2015", "12webapi")} //密码
                };

                byte[] byRemoteInfo = WebClientObj.UploadValues("http://oauth.e24health.com/issuer", "POST", PostVars); //ConfigHelper.OAuthUrl "http://oauth.e24health.com/issuer"
                    
                string sRemoteInfo = System.Text.Encoding.Default.GetString(byRemoteInfo);
                if (sRemoteInfo.Contains("token"))
                {
                    //var authState = JSON.Deserialize<M_AuthState>(sRemoteInfo);
                    var authState = JsonConvert.DeserializeObject<M_AuthState>(sRemoteInfo);
                    token = authState.access_token;
                    //HttpContext.Current.Cache.Add(cachename, token, null, DateTime.Now.AddSeconds(Convert.ToDouble(authState.expires_in) - 60),
                    //    TimeSpan.Zero, CacheItemPriority.Default, null);
                    HttpRuntime.Cache.Add(cachename, token, null, DateTime.Now.AddSeconds(Convert.ToDouble(authState.expires_in) - 60),
                        TimeSpan.Zero, CacheItemPriority.Default, null);
                }
            }
            else
            {
                //token = HttpContext.Current.Cache.Get(cachename).ToString();
                token = HttpRuntime.Cache.Get(cachename).ToString();
            }

            return token;
        }
    }
}
