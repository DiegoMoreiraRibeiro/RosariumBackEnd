namespace RosariumBackEnd.Entities.Entities
{
    public class LiturgiaDto
    {
        public long Id { get; set; }
        public string Data { get; set; }
        public string Cor { get; set; }
        public string Dia { get; set; }
        public string Oferendas { get; set; }
        public string Comunhao { get; set; }
        public string SegundaLeitura { get; set; }


        public long PrimeiraLeituraId { get; set; }
        public PrimeiraLeitura PrimeiraLeitura { get; set; }

        public long SalmoId { get; set; }
        public Salmo Salmo { get; set; }

        public long EvangelhoId { get; set; }
        public Evangelho Evangelho { get; set; }
    }
}
