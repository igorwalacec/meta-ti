namespace Meta.TI.Application.ViewModels
{
    public class EnderecoViewModel
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public CidadeViewModel Cidade { get; set; }
    }
}
