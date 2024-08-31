namespace ROBO.Models.Dominio
{
    public class RoboBecomex : CorpoHumanoide
    {
        public readonly EnumModeloRobo Modelo;

        public RoboBecomex() 
        {
            Modelo = EnumModeloRobo.Becomex;
            Nome = "Robo Becomex";
            ModeloAtivo = true;
            Ativo = false;
        }

        public static bool ModeloAtivo { get; set; }
        public bool Ativo { get; set; }
        public Guid Codigo { get; set; }
    }
}
