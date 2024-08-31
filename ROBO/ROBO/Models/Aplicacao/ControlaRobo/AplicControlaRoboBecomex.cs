using ROBO.Models.Dominio;

namespace ROBO.Models.Aplicacao
{
    public class AplicControlaRoboBecomex
    {
        private readonly IRoboBecomexMapper _iRoboBecomexMapper;
        public AplicControlaRoboBecomex(IRoboBecomexMapper iRoboBecomexMapper)
        {
            _iRoboBecomexMapper = iRoboBecomexMapper;
        }

        #region Geral
        public RoboBecomex Novo()
        {
            var novoRoboBecomex = _iRoboBecomexMapper.Novo();

            return novoRoboBecomex;
        }

        public RoboBecomex Reseta(RoboBecomex roboBecomex)
        {
            roboBecomex.Resetar();

            return roboBecomex;
        }

        public RoboBecomex NovoNome(NovoNomeDTO novoNomeDTO)
        {
            novoNomeDTO.RoboBecomex.Nome = novoNomeDTO.NovoNome;

            return novoNomeDTO.RoboBecomex;
        }
        #endregion

        #region Cabeça
        public RoboBecomex InclinaCabeca(MovimentaCabecaDTO movimentaCabecaDTO)
        {
            movimentaCabecaDTO.RoboBecomex.Cabeca.InclinaCabeca(movimentaCabecaDTO.SentidoMovimento);

            return movimentaCabecaDTO.RoboBecomex;
        }

        public RoboBecomex RotacionaCabeca(MovimentaCabecaDTO movimentaCabecaDTO)
        {
            movimentaCabecaDTO.RoboBecomex.Cabeca.InclinaCabeca(movimentaCabecaDTO.SentidoMovimento);

            return movimentaCabecaDTO.RoboBecomex;
        }
        #endregion

        #region Braços
        public void MoveCotovelo(MovimentaBracoDTO movimentaBracoDTO)
        {
            switch (movimentaBracoDTO.IdentificaMembro)
            {
                case EnumIdentificacaoMebro.Ambos:
                    movimentaBracoDTO.RoboBecomex.BracoDireito.MoveCotovelo(movimentaBracoDTO.SentidoMovimento);
                    movimentaBracoDTO.RoboBecomex.BracoEsquerdo.MoveCotovelo(movimentaBracoDTO.SentidoMovimento);
                    break;
                case EnumIdentificacaoMebro.Direito:
                    movimentaBracoDTO.RoboBecomex.BracoDireito.MoveCotovelo(movimentaBracoDTO.SentidoMovimento);
                    break;
                case EnumIdentificacaoMebro.Esquerdo:
                    movimentaBracoDTO.RoboBecomex.BracoEsquerdo.MoveCotovelo(movimentaBracoDTO.SentidoMovimento);
                    break;
                default:
                    return;
            }
        }

        public void RotacionaPulso(MovimentaBracoDTO movimentaBracoDTO)
        {
            switch (movimentaBracoDTO.IdentificaMembro)
            {
                case EnumIdentificacaoMebro.Ambos:
                    movimentaBracoDTO.RoboBecomex.BracoDireito.RotacionaPulso(movimentaBracoDTO.SentidoMovimento);
                    movimentaBracoDTO.RoboBecomex.BracoEsquerdo.RotacionaPulso(movimentaBracoDTO.SentidoMovimento);
                    break;
                case EnumIdentificacaoMebro.Direito:
                    movimentaBracoDTO.RoboBecomex.BracoDireito.RotacionaPulso(movimentaBracoDTO.SentidoMovimento);
                    break;
                case EnumIdentificacaoMebro.Esquerdo:
                    movimentaBracoDTO.RoboBecomex.BracoEsquerdo.RotacionaPulso(movimentaBracoDTO.SentidoMovimento);
                    break;
                default:
                    return;
            }
        }
        #endregion
    }
}
