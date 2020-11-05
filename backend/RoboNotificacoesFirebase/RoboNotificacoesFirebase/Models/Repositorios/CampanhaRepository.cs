using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using RoboNotificacoesFirebase.Model.Entidades;
using scaffold;
using RoboNotificacoesFirebase.DTO;

namespace RoboNotificacoesFirebase.Models.Repositorios
{
    public class CampanhaRepository
    {
        MetaTiBDContext Db = new MetaTiBDContext();

        public void BuscarNovasCampanhas()
        {
            var novasCampanhas = (from c in Db.Campanha
                                  join h in Db.Hemocentro on c.IdHemocentro equals h.Id
                                  join e in Db.Endereco on h.IdEndereco equals e.Id
                                  join cd in Db.Cidade on e.IdCidade equals cd.Id
                                  where c.DataCriacao.Date >= DateTime.Today.AddDays(-1)
                                  select new CampanhaDTO
                                  {
                                      Id = c.Id,
                                      Titulo = c.Titulo,
                                      Descricao = c.Descricao,
                                      DadosHemocentro = new HemocentroDTO
                                      {
                                          Nome = h.Nome,
                                          CNPJ = h.Cnpj,
                                          Logradouro = e.Logradouro,
                                          Complemento = e.Complemento,
                                          Numero = e.Numero,
                                          Cep = e.Cep,
                                          Latitude = e.Latitude,
                                          Longitude = e.Longitude,
                                          Cidade = cd.Nome
                                      }
                                  }).Distinct().GroupBy(x => x.DadosHemocentro.Cidade);

            var x = novasCampanhas;
        }
    }
}
