namespace Meta.TI.Domain.Dto
{
    public class EnderecoDto
    {
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Numero { get; set; }
        public string Cep { get; set; }
        public int IdCidade { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
