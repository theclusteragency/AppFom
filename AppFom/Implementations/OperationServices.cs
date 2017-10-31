using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppFom.Helpers;
using AppFom.Interfaces;
using AppFom.Models;
using Newtonsoft.Json;

namespace AppFom.Implementations
{
    public class OperationServices : IOperationServices
    {
        public OperationServices() { }

        public async Task<OperResult<bool>> CheckLogin<T>(T generic)
        {
            var responseObj = new OperResult<bool>();
            Debug.WriteLine(JsonConvert.SerializeObject(generic));
            var contentHttp = new StringContent(JsonConvert.SerializeObject(generic), Encoding.UTF8, "application/json");

            try
            {
                var response = await GetCustomHttpClient().PostAsync(Endpoints.loginURI, contentHttp);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine("Content: " + json);
                    //responseObj = JsonConvert.DeserializeObject<OperResult<LoginResponse>>(json);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception Message:" + ex.Message);
                responseObj.message = ex.Message;
                responseObj.code = 100;
                responseObj.data = false;
            }

            return responseObj;
        }


        #region HTTPCLIENTE

        public HttpClient GetCustomHttpClient()
        {

            var _handler = new HttpClientHandler()
            {
                //Credentials = new System.Net.NetworkCredential("x-api-key", Liar.Globals.APIKEY)
            };

            var http = new HttpClient(_handler) { MaxResponseContentBufferSize = 256000 };
            http.DefaultRequestHeaders.Add("x-api-key", Fom.Globals.APIKEY);
            return http;
        }

        #endregion

    }
}
