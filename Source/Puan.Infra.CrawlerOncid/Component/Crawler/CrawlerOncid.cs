﻿using HtmlAgilityPack;
using Puan.Infra.CrawlerOncid.Component.Interface;
using Puan.Infra.CrawlerOncid.Component.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Puan.Infra.CrawlerOncid.Component.Crawler
{
    public class CrawlerOncid : ICrawlerOncidConector
    {
        private const string Url = "https://cliente.apdata.com.br/dicon/.net/index.ashx/SaveTimmingEvent";

        private WebClient _navegadorInterno = new WebClient();

        private Boolean definirCabecalho()
        {
            try
            {
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

                _navegadorInterno.Headers.Set(HttpRequestHeader.Accept, parametros.Accept);
                _navegadorInterno.Headers.Set(HttpRequestHeader.Referer, parametros.Referer);
                //_navegadorInterno.Headers.Set(HttpRequestHeader.ContentType, parametros.ContentType);
                _navegadorInterno.Headers.Set(HttpRequestHeader.AcceptLanguage, parametros.AcceptLanguage);
                _navegadorInterno.Headers.Set(HttpRequestHeader.UserAgent, parametros.UserAgent);
                _navegadorInterno.Headers.Set(HttpRequestHeader.AcceptEncoding, parametros.AcceptEncoding);
                _navegadorInterno.Headers.Set("Method", parametros.Method);
                _navegadorInterno.Headers.Set("Origin", parametros.Origin);
                _navegadorInterno.Headers.Set(HttpRequestHeader.Cookie, parametros.Cookie);
                _navegadorInterno.Headers.Set("x-microsoftajax", parametros.MicrosoftAjax);
                _navegadorInterno.Headers.Set("x-requested-with", parametros.XRequestedWith);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Task<string> MarkPoint(string nome, string senha)
        {
            return MarkPoint();
        }

        public Task<string> MarkPoint()
        {
            try
            {
                var parametros = definirCabecalho();

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

                var retorno = _navegadorInterno.UploadValues(Url, valores);
                HtmlDocument documento = new HtmlDocument();
                documento.LoadHtml(Encoding.UTF8.GetString(retorno, 0, retorno.Count()));

                Console.WriteLine(documento.DocumentNode);
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
