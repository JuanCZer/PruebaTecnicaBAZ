using Newtonsoft.Json;
using PruebaTecnicaBAZ.Modelos;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaBAZ.Rest
{
    public class RestServicio
    {
        public async Task<string> GetResultAPI()
        {
            string cadenaOrden = "";
            var client = new RestClient("https://api.github.com");
            var request = new RestRequest("users", Method.GET);
            request.AddHeader("Content-Type", "application/json");

            IRestResponse<List<ResponseAPI>> response = client.Execute<List<ResponseAPI>>(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<ResponseAPI> users = response.Data;

                int contadorLimitante = 0;
                foreach (ResponseAPI user in users)
                {
                    if (contadorLimitante > 9) break;
                    cadenaOrden += $"{user.id}|{user.login}\r\n";
                    contadorLimitante++;
                }
            }
            else
            {
                Console.WriteLine("Peticion fallida: " + response.StatusCode);
            }

            return cadenaOrden;
        }
    }
}
