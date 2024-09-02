using ROBO.Models.Dominio;
using Xunit;

namespace ROBO.Testes.Models.Dominio
{
    public class CorpoSemiHumanoideTests
    {
        [Fact]
        public void Resetar_Funcional()
        {
            var corpo = new CorpoSemiHumanoide();

            corpo.Cabeca.InclinaCabeca(EnumSentidoMovimento.Positivo);
            corpo.BracoDireito.MoveCotovelo(EnumSentidoMovimento.Positivo);
            corpo.BracoEsquerdo.MoveCotovelo(EnumSentidoMovimento.Positivo);

            corpo.Resetar();

            Assert.Equal(EnumEstadoCotovelo.Repouso, corpo.BracoDireito.Cotovelo);
            Assert.Equal(EnumEstadoPulso.Repouso, corpo.BracoDireito.Pulso);
            Assert.Equal(EnumEstadoCotovelo.Repouso, corpo.BracoEsquerdo.Cotovelo);
            Assert.Equal(EnumEstadoPulso.Repouso, corpo.BracoEsquerdo.Pulso);
            Assert.Equal(EnumInclinacaoCabeca.Repouso, corpo.Cabeca.Inclinacao);
            Assert.Equal(EnumRotacaoCabeca.Repouso, corpo.Cabeca.Rotacao);
        }
    }
}
