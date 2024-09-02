using ROBO.Models.Dominio;

namespace ROBO.Testes.Models.Dominio.Partes
{
    public class CabecaTests
    {
        [Fact]
        public void Resetar_Funcional()
        {

            var cabeca = new Cabeca()
            {
                Inclinacao = EnumInclinacaoCabeca.Cima,
                Rotacao = EnumRotacaoCabeca.Positivo90
            };

            cabeca.Resetar();

            Assert.Equal(EnumInclinacaoCabeca.Repouso, cabeca.Inclinacao);
            Assert.Equal(EnumRotacaoCabeca.Repouso, cabeca.Rotacao);
        }

        [Theory]
        [InlineData(EnumSentidoMovimento.Positivo, EnumInclinacaoCabeca.Cima)]
        [InlineData(EnumSentidoMovimento.Negativo, EnumInclinacaoCabeca.Baixo)]
        public void InclinaCabeca_Funcional(EnumSentidoMovimento sentidoMovimento, EnumInclinacaoCabeca expectedInclinacao)
        {
            var cabeca = new Cabeca()
            {
                Inclinacao = EnumInclinacaoCabeca.Repouso
            };

            cabeca.InclinaCabeca(sentidoMovimento);

            Assert.Equal(expectedInclinacao, cabeca.Inclinacao);
        }

        [Theory]
        [InlineData(EnumSentidoMovimento.Positivo, EnumRotacaoCabeca.Positivo45)]
        [InlineData(EnumSentidoMovimento.Negativo, EnumRotacaoCabeca.Negativo45)]
        public void RotacionaCabeca_InclinacaoCorreta(EnumSentidoMovimento sentidoMovimento, EnumRotacaoCabeca expectedRotacao)
        {
            var cabeca = new Cabeca()
            {
                Inclinacao = EnumInclinacaoCabeca.Repouso,
                Rotacao = EnumRotacaoCabeca.Repouso
            };

            cabeca.RotacionaCabeca(sentidoMovimento);

            Assert.Equal(expectedRotacao, cabeca.Rotacao);
        }

        [Fact]
        public void RotacionaCabeca_NaoMecherDependendoDaInclinacao()
        {
            var cabeca = new Cabeca()
            {
                Inclinacao = EnumInclinacaoCabeca.Baixo,
                Rotacao = EnumRotacaoCabeca.Repouso
            };

            var exception = Assert.Throws<Exception>(() => cabeca.RotacionaCabeca(EnumSentidoMovimento.Positivo));

            Assert.Equal("Não é possível rotacionar a cabeça com inclinação para baixo.", exception.Message);
        }
    }
}
