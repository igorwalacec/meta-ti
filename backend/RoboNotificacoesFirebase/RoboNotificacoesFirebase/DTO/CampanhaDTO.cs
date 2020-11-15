namespace RoboNotificacoesFirebase.DTO
{
    public class CampanhaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public HemocentroDTO DadosHemocentro { get; set; }
    }
}
