using ROBO.Models.Dominio;

namespace ROBO.Models.Aplicacao
{
    public interface IAplicControlaRoboBecomex
    {
        RoboBecomex Novo();
        RoboBecomex Reseta(RoboBecomex roboBecomex);
        RoboBecomex NovoNome(NovoNomeDTO novoNomeDTO);
        RoboBecomex InclinaCabeca(MovimentaCabecaDTO movimentaCabecaDTO);
        RoboBecomex RotacionaCabeca(MovimentaCabecaDTO movimentaCabecaDTO);
        RoboBecomex MoveCotovelo(MovimentaBracoDTO movimentaBracoDTO);
        RoboBecomex RotacionaPulso(MovimentaBracoDTO movimentaBracoDTO);
    }
}
