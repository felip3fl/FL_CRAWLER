using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Puan.API
{
    public class Dicon
    {
        public async Task loginAsync()
        {
            string url = "https://cliente.apdata.com.br/dicon/.net/index.ashx/SaveTimmingEvent";
            string urlOriginal = "https://cliente.apdata.com.br/dicon/";

            HttpClient _httpClient = new HttpClient();

            var responde = await _httpClient.GetAsync(urlOriginal);
            var cookieRaw = responde.Headers.GetValues("Set-Cookie").FirstOrDefault();
            var cookie = cookieRaw.Substring(0, cookieRaw.IndexOf(';'));

            _httpClient.DefaultRequestHeaders.Add("Cookie", cookie);

            var parametro = new Dictionary<string, string>();

            parametro.Add("deviceID", "8001");
            parametro.Add("eventType", "1");
            parametro.Add("userName", "234234");
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
    }
}
