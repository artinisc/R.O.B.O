namespace ROBO.Models.Dominio
{
    public class NovoNomeDTO
    {
        public NovoNomeDTO() 
        {
            RoboBecomex = new RoboBecomex();
            NovoNome = "X";
        }

        public RoboBecomex RoboBecomex { get; set; }
        public string NovoNome { get; set; }
    }
}
