namespace RoboNotificacoesFirebase.Model.Entidades
{
    public partial class Endereco
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int IdCidade { get; set; }

        public virtual Cidade IdCidadeNavigation { get; set; }
        public virtual Hemocentro Hemocentro { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
