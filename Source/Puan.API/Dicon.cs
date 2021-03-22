using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Puan.API
{
    public class Dicon
    {
        string url = "https://cliente.apdata.com.br/dicon/.net/index.ashx/SaveTimmingEvent";
        string urlOriginal = "https://cliente.apdata.com.br/dicon/";

        public async Task loginAsync()
        {
            HttpClient _httpClient = new HttpClient();

            //var responde = await _httpClient.GetAsync(urlOriginal);
            //var cookieRaw = responde.Headers?.GetValues("Set-Cookie").FirstOrDefault();
            //var cookie = cookieRaw.Substring(0, cookieRaw.IndexOf(';'));

            //_httpClient.DefaultRequestHeaders.set = "";

            //_httpClient.DefaultRequestHeaders.Add("Cookie", cookie);

            var parametro = new Dictionary<string, string>();

            parametro.Add("deviceID", "8001");
            parametro.Add("eventType", "1");
            parametro.Add("userName", "1234564");
            parametro.Add("password", "345");
            parametro.Add("cracha", "");
            parametro.Add("costCenter", "");
            parametro.Add("leave", "");
            parametro.Add("func", "0");
            parametro.Add("captcha", "");
            parametro.Add("tsc", "");
            parametro.Add("sessionID", "0");
            parametro.Add("selectedEmployee", "0");
            parametro.Add("selectedCandidate", "0");
            parametro.Add("selectedVacancy", "0");
            parametro.Add("dtFmt", "d/m/Y");
            parametro.Add("tmFmt", "H:i:s");
            parametro.Add("shTmFmt", "H:i");
            parametro.Add("dtTmFmt", "d/m/Y H:i:s");
            parametro.Add("language", "0");
            parametro.Add("idEmployeeLogged", "0");

            var content = new FormUrlEncodedContent(parametro);
            var request = new HttpRequestMessage();

            request.Method = HttpMethod.Post;
            request.RequestUri = new Uri(url);
            request.Content = content;

            var response = await _httpClient.SendAsync(request);
            var conteudoPagina = await response.Content.ReadAsStringAsync();

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(conteudoPagina);

        }

        public async Task teste()
        {
            try
            {
                WebClient teste = new WebClient();

                var parametros = new ParametrosRequest
                {
                    Method = "POST",
                    url = "https://cliente.apdata.com.br",
                    Referer = "https://cliente.apdata.com.br/dicon/",
                    Accept = "*/*",
                    AcceptLanguage = "pt-BR",
                    UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; Trident/7.0; rv:11.0) like Gecko",
                    AcceptEncoding = "gzip, deflate, br",
                    ContentType = "application/x-www-form-urlencoded; charset=UTF-8",
                    Cookie = "ts=; SessionID=; dynSID=; authenticated=false; loginOK=false; dashPublicImg=dpi; acceptedRequiredCookies=COOKIEACCEPTED; acceptedOptionalCookies=COOKIEACCEPTED; clockDeviceToken8001=xz/whCf25NSnT3pzGk8LO6bwhr3jGtA8HRHIuM+51bevVmI="
                };

                teste.Headers.Set(HttpRequestHeader.Accept, parametros.Accept);
                teste.Headers.Set(HttpRequestHeader.Referer, parametros.Referer);
                //teste.Headers.Set(HttpRequestHeader.ContentType, parametros.ContentType);
                teste.Headers.Set(HttpRequestHeader.AcceptLanguage, parametros.AcceptLanguage);
                teste.Headers.Set(HttpRequestHeader.UserAgent, parametros.UserAgent);
                teste.Headers.Set(HttpRequestHeader.AcceptEncoding, parametros.AcceptEncoding);
                teste.Headers.Set("Method", parametros.Method);
                teste.Headers.Set("Origin", parametros.Origin);
                teste.Headers.Set(HttpRequestHeader.Cookie, parametros.Cookie);
                teste.Headers.Set("x-microsoftajax", parametros.MicrosoftAjax);
                teste.Headers.Set("x-requested-with", parametros.XRequestedWith);


                var statusCode = HttpStatusCode.OK;
                var valores = new NameValueCollection();
                valores.Add("deviceID", "8001");
                valores.Add("eventType", "1");
                valores.Add("userName", "1234564");
                valores.Add("password", "345");
                valores.Add("cracha", "");
                valores.Add("costCenter", "");
                valores.Add("leave", "");
                valores.Add("func", "0");
                valores.Add("captcha", "");
                valores.Add("tsc", "");
                valores.Add("sessionID", "0");
                valores.Add("selectedEmployee", "0");
                valores.Add("selectedCandidate", "0");
                valores.Add("selectedVacancy", "0");
                valores.Add("dtFmt", "d/m/Y");
                valores.Add("tmFmt", "H:i:s");
                valores.Add("shTmFmt", "H:i");
                valores.Add("dtTmFmt", "d/m/Y H:i:s");
                valores.Add("language", "0");
                valores.Add("idEmployeeLogged", "0");
                
                var retorno = teste.UploadValues(url, valores);
                HtmlDocument documento = new HtmlDocument();
                documento.LoadHtml(Encoding.UTF8.GetString(retorno, 0, retorno.Count()));

                Console.WriteLine(documento.DocumentNode);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public FormUrlEncodedContent parametros()
        {
            var parametro = new Dictionary<string, string>();

            parametro.Add("deviceID", "8001");
            parametro.Add("eventType", "1");
            parametro.Add("userName", "1234564");
            parametro.Add("password", "345");
            parametro.Add("cracha", "");
            parametro.Add("costCenter", "");
            parametro.Add("leave", "");
            parametro.Add("func", "0");
            parametro.Add("captcha", "");
            parametro.Add("tsc", "");
            parametro.Add("sessionID", "0");
            parametro.Add("selectedEmployee", "0");
            parametro.Add("selectedCandidate", "0");
            parametro.Add("selectedVacancy", "0");
            parametro.Add("dtFmt", "d/m/Y");
            parametro.Add("tmFmt", "H:i:s");
            parametro.Add("shTmFmt", "H:i");
            parametro.Add("dtTmFmt", "d/m/Y H:i:s");
            parametro.Add("language", "0");
            parametro.Add("idEmployeeLogged", "0");

            var content = new FormUrlEncodedContent(parametro);
            return content;
        }

        public void Header(ParametrosRequest valores)
        {

        }
            
    }

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
