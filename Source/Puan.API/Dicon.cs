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
            string url = "https://cliente.apdata.com.br/dicon/";

            HttpClient _httpClient = new HttpClient();

            var parametro = new Dictionary<string, string>();
            var content = new FormUrlEncodedContent(parametro);
            var request = new HttpRequestMessage();

            request.Method = HttpMethod.Get;
            request.RequestUri = new Uri(url);
            request.Content = content;

            var response = await _httpClient.SendAsync(request);
            var conteudoPagina = await response.Content.ReadAsStringAsync();

            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(conteudoPagina);

        }
    }
}
