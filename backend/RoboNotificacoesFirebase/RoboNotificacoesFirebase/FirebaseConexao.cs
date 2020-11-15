using FirebaseAdmin.Messaging;
using RoboNotificacoesFirebase.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RoboNotificacoesFirebase
{
    public class FirebaseConexao
    {
        public async Task<string> Conexao(string titulo, string descricao)
        {
            var token = "AAAAwjGA2Tw:APA91bHEgGdt0Fim3_rFUE91FEzytWKZoyx13wLYwK3GpRYbZG82X0HCi9_k6mhkA8TXBSkJUVIwACa1kIk5tI2h_Tc3eySuR7fUBCGR5WhfCEGejmrXf75s7VJ4A8lVMX6SU1k2SKWk";

            var message = new Message()
            {
            //    Data = new Dictionary<string, string>()
            //    {
            //        {"score", "850" },
            //        {"time", "2:45" },
            //    },
                Token = token,
                Notification = new Notification()
                {
                    Title = titulo,
                    Body = descricao,
                }
            };

            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);

            return response;
        }
    }
}
