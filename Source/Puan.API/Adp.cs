using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Puan.API
{
    public class Adp
    {
        public async Task loginAsync()
        {
            try { } catch (Exception ex) { }

            string url = "https://expert.brasil.adp.com/";
            string urlOriginal = "https://expert.brasil.adp.com/";

            HttpClient _httpClient = new HttpClient();

            var responde = await _httpClient.GetAsync(urlOriginal);
            var cookieRaw = responde.Headers?.GetValues("Set-Cookie").FirstOrDefault();
            var cookie = cookieRaw.Substring(0, cookieRaw.IndexOf(';'));

            // _httpClient.DefaultRequestHeaders.set = "";

            _httpClient.DefaultRequestHeaders.Add("Cookie", cookie);

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

        public async Task Oioi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    // Fazer a requisição GET para obter o cookie de sessão
                    HttpResponseMessage response = await client.GetAsync("https://expert.brasil.adp.com/ipclogin/1/loginform.html?TYPE=33554433&REALMOID=06-000a1470-e058-1656-b22f-441e0bf0d04d&GUID=&SMAUTHREASON=0&METHOD=GET&SMAGENTNAME=-SM-WO5eIxD%2b8kIdnTAl%2b0hJ%2be%2f1NKnuhX0pcbFgNGlVHp9VuDW92mCKK4XQjDcqUnWo&TARGET=-SM-https%3a%2f%2fexpert%2ebrasil%2eadp%2ecom%2fexpert%2f");
                    response.EnsureSuccessStatusCode();

                    // Obter o valor do cookie de sessão
                    string sessionCookie = response.Headers.GetValues("Set-Cookie").FirstOrDefault(x => x.StartsWith("JSESSIONID="));
                    sessionCookie = sessionCookie.Substring("JSESSIONID=".Length, sessionCookie.IndexOf(';') - "JSESSIONID=".Length);

                    // Montar o corpo da requisição POST com as credenciais de login
                    var content = new StringContent($"login={Uri.EscapeDataString("seu_email")}&senha={Uri.EscapeDataString("sua_senha")}", Encoding.UTF8, "application/x-www-form-urlencoded");

                    // Adicionar o cookie de sessão ao header da requisição
                    client.DefaultRequestHeaders.Add("Cookie", $"JSESSIONID={sessionCookie}");

                    // Fazer a requisição POST para fazer login
                    response = await client.PostAsync("https://expert.brasil.adp.com/ipclogin/1/loginform.html?TYPE=33554433&REALMOID=06-000a1470-e058-1656-b22f-441e0bf0d04d&GUID=&SMAUTHREASON=0&METHOD=GET&SMAGENTNAME=-SM-WO5eIxD%2b8kIdnTAl%2b0hJ%2be%2f1NKnuhX0pcbFgNGlVHp9VuDW92mCKK4XQjDcqUnWo&TARGET=-SM-https%3a%2f%2fexpert%2ebrasil%2eadp%2ecom%2fexpert%2f", content);
                    response.EnsureSuccessStatusCode();

                    // Verificar se o login foi bem sucedido
                    string responseContent = await response.Content.ReadAsStringAsync();
                    if (responseContent.Contains("Logout"))
                    {
                        Console.WriteLine("Login bem sucedido!");
                    }
                    else
                    {
                        Console.WriteLine("Falha no login.");
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
