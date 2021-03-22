using System.Net.Cache;

namespace Puan.Infra.CrawlerOncid.Component.Model
{
    public class ParametrosRequest
    {
        public string url;
        public string QueryString;
        public string Referer;
        public string Method;
        public string ContentType;
        public string Accept;
        public string UserAgent;
        public string AcceptLanguage;
        public string AcceptEncoding;
        public string CacheControl;
        public string Cookie;
        public string Origin;
        public string UA_CPU;
        public RequestCachePolicy requestCachePolicy;
        public string MicrosoftAjax;
        public string XRequestedWith;
        public string Pragma;
    }
}
