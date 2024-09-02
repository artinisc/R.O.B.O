using ROBO.Models.Dominio;
using Xunit;
using System;

namespace ROBO.Testes.Models.Dominio
{
    public class RoboBecomexMapperTests
    {
        [Fact]
        public void Novo_VerificaPropriedades()
        {
            var mapper = new RoboBecomexMapper();

            var roboBecomex = mapper.Novo();

            Assert.NotNull(roboBecomex);
            Assert.True(roboBecomex.Ativo);
        }
    }
}
