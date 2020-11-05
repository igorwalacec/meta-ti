using RoboNotificacoesFirebase.Models.Repositorios;
using System;

namespace RoboNotificacoesFirebase
{
    class Program
    {
        static void Main(string[] args)
        {
            CampanhaRepository c = new CampanhaRepository();
            c.BuscarNovasCampanhas();

            FirebaseConexao fb = new FirebaseConexao();
            var x = fb.Conexao("teste", "testest");
        }
    }
}
