namespace ROBO.Models.Dominio
{
    public class MovimentaBracoDTO
    {
        public MovimentaBracoDTO()
        {
            RoboBecomex = new RoboBecomex();
        }

        public RoboBecomex RoboBecomex { get; set; }
        public EnumIdentificacaoMebro IdentificaMembro { get; set; }
        public EnumSentidoMovimento SentidoMovimento { get; set; }
    }
}
