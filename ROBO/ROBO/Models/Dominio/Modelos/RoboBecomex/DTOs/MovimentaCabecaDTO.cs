namespace ROBO.Models.Dominio
{
    public class MovimentaCabecaDTO
    {
        public MovimentaCabecaDTO()
        {
            RoboBecomex = new RoboBecomex();
        }

        public RoboBecomex RoboBecomex { get; set; }
        public EnumSentidoMovimento SentidoMovimento { get; set; }
    }
}
