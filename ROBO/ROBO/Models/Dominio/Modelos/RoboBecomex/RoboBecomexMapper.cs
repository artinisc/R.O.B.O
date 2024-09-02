using System.Reflection.Metadata;

namespace ROBO.Models.Dominio
{
    public class RoboBecomexMapper : IRoboBecomexMapper
    {
        public RoboBecomex Novo()
        {
            var roboBecomex = new RoboBecomex()
            {
                Ativo = true,
                Codigo = Guid.NewGuid()
            };

            return roboBecomex;
        }

        public RoboBecomex Alterar(RoboBecomex robo)
        {
            var roboBecomex = new RoboBecomex()
            {
                Ativo = robo.Ativo,
                Codigo = robo.Codigo,
                Nome = robo.Nome,
                Cabeca = new Cabeca()
                {
                    Inclinacao = robo.Cabeca.Inclinacao,
                    Rotacao = robo.Cabeca.Rotacao
                },
                BracoDireito = new Braco()
                {
                    Cotovelo = robo.BracoDireito.Cotovelo,
                    Pulso = robo.BracoDireito.Pulso
                },
                BracoEsquerdo = new Braco()
                {
                    Cotovelo = robo.BracoEsquerdo.Cotovelo,
                    Pulso = robo.BracoEsquerdo.Pulso
                }
            };

            return roboBecomex;
        }
    }
}
