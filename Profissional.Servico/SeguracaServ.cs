using RestSharp;
using System;
using System.Threading.Tasks;

namespace Profissional.Servico
{
    public class SeguracaServ
    {
        public static async Task<bool> ValidaTokenAsync(string token)
        {

            RestClient client = new RestClient("http://localhost:5300/");
            var url = "/api/token/ValidaToken/" + token;
            RestRequest  request = new RestRequest(url, Method.GET);
            var response = await client.ExecuteTaskAsync(request);

            return Convert.ToBoolean(response.Content);
        }

        public static  bool validaToken(string token)
        {

            RestClient client = new RestClient("http://localhost:5300/");
            var url = "/api/token/ValidaToken/" + token;
            RestRequest request = new RestRequest(url, Method.GET);
            var response =  client.Execute(request);

            return Convert.ToBoolean(response.Content);
        }


    }
}
