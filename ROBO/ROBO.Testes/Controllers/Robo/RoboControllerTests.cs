using Xunit;
using Moq;
using ROBO.Controllers;
using ROBO.Models.Aplicacao;
using ROBO.Models.Dominio;
using Microsoft.AspNetCore.Mvc;

namespace ROBO.Testes.Controllers
{
    public class RoboControllerTests
    {
        private readonly Mock<IAplicControlaRoboBecomex> _mockAplicControlaRobo;
        private readonly RoboController _controller;

        public RoboControllerTests()
        {
            _mockAplicControlaRobo = new Mock<IAplicControlaRoboBecomex>();
            _controller = new RoboController(_mockAplicControlaRobo.Object);
        }

        [Fact]
        public void Novo_Consistente()
        {
            var expectedRobo = new RoboBecomex();
            _mockAplicControlaRobo.Setup(x => x.Novo()).Returns(expectedRobo);

            var result = _controller.Novo();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var retorno = Assert.IsType<HttpRetorno>(okResult.Value);
            Assert.True(retorno.Success);
            Assert.Equal(expectedRobo, retorno.Content);
        }

        [Fact]
        public void Reseta_Consistente()
        {
            var roboResetado = new RoboBecomex();
            var roboAlterado = new RoboBecomex()
            { 
                Cabeca = new Cabeca()
                {
                    Inclinacao = EnumInclinacaoCabeca.Cima
                },
                BracoDireito = new Braco()
                {
                    Cotovelo = EnumEstadoCotovelo.Contraido
                }
            };

            _mockAplicControlaRobo.Setup(x => x.Reseta(roboAlterado)).Returns(roboResetado);

            var result = _controller.Reseta(roboAlterado);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var retorno = Assert.IsType<HttpRetorno>(okResult.Value);
            Assert.True(retorno.Success);
            Assert.Equal(roboResetado, retorno.Content);
        }

        [Fact]
        public void NovoNome_Consistente()
        {
            var novoNomeDTO = new NovoNomeDTO { NovoNome = "NovoNome" };
            var roboAtualizado = new RoboBecomex { Nome = "NomeAntigo" };

            _mockAplicControlaRobo.Setup(x => x.NovoNome(novoNomeDTO)).Returns(roboAtualizado);

            var result = _controller.NovoNome(novoNomeDTO);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var retorno = Assert.IsType<HttpRetorno>(okResult.Value);
            Assert.True(retorno.Success);
            Assert.Equal(roboAtualizado, retorno.Content);
        }

        [Fact]
        public void InclinaCabeca_Consistente()
        {
            var roboInclinado = new RoboBecomex();
            var movimentaCabecaDTO = new MovimentaCabecaDTO()
            {
                SentidoMovimento = EnumSentidoMovimento.Positivo
            };

            _mockAplicControlaRobo.Setup(x => x.InclinaCabeca(movimentaCabecaDTO)).Returns(roboInclinado);

            var result = _controller.InclinaCabeca(movimentaCabecaDTO);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var retorno = Assert.IsType<HttpRetorno>(okResult.Value);
            Assert.True(retorno.Success);
            Assert.Equal(roboInclinado, retorno.Content);
        }

        [Fact]
        public void RotacionaCabeca_Consistente()
        {
            var roboRotacionado = new RoboBecomex();
            var movimentaCabecaDTO = new MovimentaCabecaDTO()
            {
                SentidoMovimento = EnumSentidoMovimento.Positivo
            };

            _mockAplicControlaRobo.Setup(x => x.RotacionaCabeca(movimentaCabecaDTO)).Returns(roboRotacionado);

            var result = _controller.RotacionaCabeca(movimentaCabecaDTO);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var retorno = Assert.IsType<HttpRetorno>(okResult.Value);
            Assert.True(retorno.Success);
            Assert.Equal(roboRotacionado, retorno.Content);
        }

        [Fact]
        public void MoveCotovelo_Consistente()
        {
            var roboComCotoveloMovido = new RoboBecomex();
            var movimentaBracoDTO = new MovimentaBracoDTO()
            {
                IdentificaMembro = EnumIdentificacaoMebro.Direito,
                SentidoMovimento = EnumSentidoMovimento.Positivo
            };

            _mockAplicControlaRobo.Setup(x => x.MoveCotovelo(movimentaBracoDTO)).Returns(roboComCotoveloMovido);

            var result = _controller.MoveCotovelo(movimentaBracoDTO);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var retorno = Assert.IsType<HttpRetorno>(okResult.Value);
            Assert.True(retorno.Success);
            Assert.Equal(roboComCotoveloMovido, retorno.Content);
        }

        [Fact]
        public void RotacionaPulso_Consistente()
        {
            var roboComPulsoRotacionado = new RoboBecomex();

            var movimentaBracoDTO = new MovimentaBracoDTO()
            {
                RoboBecomex = new RoboBecomex()
                {
                    BracoDireito = new Braco()
                    {
                        Cotovelo = EnumEstadoCotovelo.FortementeContraido
                    }
                },
                IdentificaMembro = EnumIdentificacaoMebro.Direito,
                SentidoMovimento = EnumSentidoMovimento.Positivo
            };

            _mockAplicControlaRobo.Setup(x => x.RotacionaPulso(movimentaBracoDTO)).Returns(roboComPulsoRotacionado);

            var result = _controller.RotacionaPulso(movimentaBracoDTO);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var retorno = Assert.IsType<HttpRetorno>(okResult.Value);
            Assert.True(retorno.Success);
            Assert.Equal(roboComPulsoRotacionado, retorno.Content);
        }
    }
}
