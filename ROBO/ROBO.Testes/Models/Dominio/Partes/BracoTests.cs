using ROBO.Models.Dominio;
using Xunit;

namespace ROBO.Testes.Models.Dominio
{
    public class BracoTests
    {
        [Fact]
        public void Resetar_Funcional()
        {
            var braco = new Braco()
            {
                Cotovelo = EnumEstadoCotovelo.FortementeContraido,
                Pulso = EnumEstadoPulso.Positivo180
            };

            braco.Resetar();

            Assert.Equal(EnumEstadoCotovelo.Repouso, braco.Cotovelo);
            Assert.Equal(EnumEstadoPulso.Repouso, braco.Pulso);
        }

        [Theory]
        [InlineData(EnumSentidoMovimento.Positivo, EnumEstadoCotovelo.Contraido)]
        [InlineData(EnumSentidoMovimento.Negativo, EnumEstadoCotovelo.Repouso)]
        public void MoveCotovelo_Funcional(EnumSentidoMovimento sentidoMovimento, EnumEstadoCotovelo expectedCotovelo)
        {
            var braco = new Braco()
            {
                Cotovelo = EnumEstadoCotovelo.LevementeContraido
            };

            braco.MoveCotovelo(sentidoMovimento);

            Assert.Equal(expectedCotovelo, braco.Cotovelo);
        }

        [Theory]
        [InlineData(EnumSentidoMovimento.Positivo, EnumEstadoPulso.Positivo45)]
        [InlineData(EnumSentidoMovimento.Negativo, EnumEstadoPulso.Negativo45)]
        public void RotacionaPulso_Funcional(EnumSentidoMovimento sentidoMovimento, EnumEstadoPulso expectedPulso)
        {
            var braco = new Braco()
            {
                Cotovelo = EnumEstadoCotovelo.FortementeContraido,
                Pulso = EnumEstadoPulso.Repouso
            };

            braco.RotacionaPulso(sentidoMovimento);

            Assert.Equal(expectedPulso, braco.Pulso);
        }

        [Fact]
        public void RotacionaPulso_NaoMecherDependendoDaContracao()
        {
            var braco = new Braco()
            {
                Cotovelo = EnumEstadoCotovelo.LevementeContraido,
                Pulso = EnumEstadoPulso.Repouso
            };

            braco.RotacionaPulso(EnumSentidoMovimento.Positivo);

            Assert.Equal(EnumEstadoPulso.Repouso, braco.Pulso);
        }
    }
}
