using MyDLibrary.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyDWeb.Common
{
    public class APIHelper
    {
        public void PostData(Login _login)
        {
            //string URL = "";
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(URL);

            ////client.DefaultRequestHeaders.Accept.Add(
            ////    new MediaTypeWithQualityHeaderValue("application/json"));

           
            ////HttpResponseMessage response = client.PostAsJsonAsync()

            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:1379/");
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = client.PostAsJsonAsync(RequestURI, emp).Result;
            //return response;
        }

        private static string BaseUri= ConfigurationManager.AppSettings["Baseurl"].ToString();
        public static string Post(string requestUri, object model, out bool isSucess)
        {
            string _result = string.Empty;
            var noheadesrList = new[] { "Transportation/VehicleGPSLogCreate", "selfregistration/selfregister" };
            var headercheck = requestUri;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //if (!noheadesrList.Contains(headercheck))
                //    AddHeaders(client);
                var json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(requestUri, stringContent).Result;
                isSucess = response.IsSuccessStatusCode;
                _result = response.ReasonPhrase.ToString();
            }
            return _result;
        }

        public static string Get(string requestUri, object model, bool pos = false)
        {
            try
            {
                var noheadesrList = new[] { "Reports", "Roles/GetUNameWithUserEmail", "Roles/GetUNameWithUserPhone", "Roles/GetUserEmailWithUName", "Roles/GetUserEmailWithUNameforforgotpasswrd", };
                string _result = string.Empty;
                var headercheck = requestUri;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var stringContent = new StringContent(JsonConvert.SerializeObject(model).ToString(), Encoding.UTF8, "application/json");
                    //if (!noheadesrList.Contains(headercheck))
                    //    AddHeaders(client);
                    HttpResponseMessage response = client.PostAsync(requestUri, stringContent).Result;
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        if (pos)
                            _result = "ok";
                        else
                            _result = response.Content.ReadAsStringAsync().Result;

                    }
                    else
                        _result = "";

                }
                return _result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static string GetRouting(string requestUri, out bool isSucess, string id = null)
        {
            string _result = string.Empty;
            string appendUri = !string.IsNullOrEmpty(id) ? string.Format("{0}?id={1}", requestUri, id) : string.Format("{0}", requestUri);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = Task.Run(() => client.GetAsync(appendUri)).Result;
                isSucess = response.IsSuccessStatusCode;
                _result = response.Content.ReadAsStringAsync().Result;
            }
            return _result;
        }

    }
}