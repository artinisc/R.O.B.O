using ROBO.Models.Dominio;

namespace ROBO.Models.Aplicacao
{
    public class AplicControlaRobo
    {
        #region Cabeça
        public void InclinaCabeca(EnumSentidoMovimento sentidoMovimento)
        {

        }

        public void RotacionaCabeca(EnumSentidoMovimento sentidoMovimento)
        {

        }
        #endregion

        #region Braços
        public void MoveCotovelo(AtivacaoMembroDTO ativacaoMembroDTO)
        {
            var robo = new RoboBecomex();

            switch (ativacaoMembroDTO.IdentificaMembro)
            {
                case EnumIdentificacaoMebro.Ambos:
                    robo.BracoDireito.MoveCotovelo(ativacaoMembroDTO.SentidoMovimento);
                    robo.BracoEsquerdo.MoveCotovelo(ativacaoMembroDTO.SentidoMovimento);
                    break;
                case EnumIdentificacaoMebro.Direito:
                    robo.BracoDireito.MoveCotovelo(ativacaoMembroDTO.SentidoMovimento);
                    break;
                case EnumIdentificacaoMebro.Esquerdo:
                    robo.BracoEsquerdo.MoveCotovelo(ativacaoMembroDTO.SentidoMovimento);
                    break;
                default:
                    return;
            }
        }

        public void RotacionaPulso(AtivacaoMembroDTO ativacaoMembroDTO)
        {

        }
        #endregion
    }
}
