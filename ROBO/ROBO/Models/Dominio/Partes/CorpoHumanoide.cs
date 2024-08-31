namespace ROBO.Models.Dominio
{
    public class CorpoHumanoide
    {
        public CorpoHumanoide() 
        {
            Nome = "X";
            Cabeca = new Cabeca();
            BracoDireito = new Braco();
            BracoEsquerdo = new Braco();
        }

        public string Nome { get; set; }
        public Cabeca Cabeca { get; set; }
        public Braco BracoDireito { get; set; }
        public Braco BracoEsquerdo { get; set; }
    }

    public enum EnumModeloRobo
    {
        Becomex = 1
    }

    public enum EnumIdentificacaoMebro
    {
        Ambos = 0,
        Direito = 1,
        Esquerdo = 2
    }

    public enum EnumSentidoMovimento
    {
        Positivo = 1,
        Negativo = 2
    }
}
