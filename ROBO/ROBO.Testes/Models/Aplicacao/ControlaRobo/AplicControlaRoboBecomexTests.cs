using Moq;
using Xunit;
using ROBO.Models.Aplicacao;
using ROBO.Models.Dominio;

namespace ROBO.Testes.Models.Aplicacao
{
    public class AplicControlaRoboBecomexTests
    {
        private readonly Mock<IRoboBecomexMapper> _roboBecomexMapperMock;
        private readonly AplicControlaRoboBecomex _aplicControlaRoboBecomex;

        public AplicControlaRoboBecomexTests()
        {
            _roboBecomexMapperMock = new Mock<IRoboBecomexMapper>();
            _aplicControlaRoboBecomex = new AplicControlaRoboBecomex(_roboBecomexMapperMock.Object);
        }

        [Fact]
        public void Novo_CriaNovoRobo()
        {
            var expectedRobo = new RoboBecomex();
            _roboBecomexMapperMock.Setup(m => m.Novo()).Returns(expectedRobo);

            var result = _aplicControlaRoboBecomex.Novo();

            Assert.Equal(expectedRobo, result);
        }

        [Fact]
        public void Reseta_ResetaPropriedadesDoRobo()
        {
            var robo = new RoboBecomex();
            _roboBecomexMapperMock.Setup(m => m.Novo()).Returns(robo);

            var result = _aplicControlaRoboBecomex.Reseta(robo);

            Assert.Equal(robo, result);
        }

        [Fact]
        public void NovoNome_AlteraNomeDoRobo()
        {
            var novoNomeDTO = new NovoNomeDTO
            {
                RoboBecomex = new RoboBecomex(),
                NovoNome = "Novo Nome"
            };

            var result = _aplicControlaRoboBecomex.NovoNome(novoNomeDTO);

            Assert.Equal("Novo Nome", result.Nome);
        }

        [Fact]
        public void InclinaCabeca_Funcional()
        {
            var movimentaCabecaDTO = new MovimentaCabecaDTO
            {
                SentidoMovimento = EnumSentidoMovimento.Positivo
            };

            var result = _aplicControlaRoboBecomex.InclinaCabeca(movimentaCabecaDTO);

            Assert.Equal(EnumInclinacaoCabeca.Cima, result.Cabeca.Inclinacao);
        }

        [Fact]
        public void RotacionaCabeca_Funcional()
        {
            var movimentaCabecaDTO = new MovimentaCabecaDTO
            {
                SentidoMovimento = EnumSentidoMovimento.Positivo
            };

            var result = _aplicControlaRoboBecomex.RotacionaCabeca(movimentaCabecaDTO);

            Assert.Equal(EnumRotacaoCabeca.Positivo45, result.Cabeca.Rotacao);
        }

        [Fact]
        public void MoveCotovelo_Funcional()
        {
            var movimentaBracoDTO = new MovimentaBracoDTO
            {
                IdentificaMembro = EnumIdentificacaoMebro.Direito,
                SentidoMovimento = EnumSentidoMovimento.Positivo
            };

            var result = _aplicControlaRoboBecomex.MoveCotovelo(movimentaBracoDTO);

            Assert.Equal(EnumEstadoCotovelo.LevementeContraido, result.BracoDireito.Cotovelo);
        }

        [Fact]
        public void RotacionaPulso_Funcional()
        {
            var movimentaBracoDTO = new MovimentaBracoDTO
            {
                RoboBecomex = new RoboBecomex()
                {
                    BracoDireito = new Braco()
                    {
                        Cotovelo = EnumEstadoCotovelo.FortementeContraido
                    },
                },
                IdentificaMembro = EnumIdentificacaoMebro.Direito,
                SentidoMovimento = EnumSentidoMovimento.Positivo
            };

            var result = _aplicControlaRoboBecomex.RotacionaPulso(movimentaBracoDTO);

            Assert.Equal(EnumEstadoPulso.Positivo45, result.BracoDireito.Pulso);
        }
    }
}