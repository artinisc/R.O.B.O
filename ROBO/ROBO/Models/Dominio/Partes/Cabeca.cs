namespace ROBO.Models.Dominio
{
    public class Cabeca
    {
        public Cabeca()
        {
            Inclinacao = EnumInclinacaoCabeca.Repouso;
            Rotacao = EnumRotacaoCabeca.Repouso;
        }

        public EnumInclinacaoCabeca Inclinacao { get; set; }
        public EnumRotacaoCabeca Rotacao { get; set; }

        #region Resetar
        public void Resetar()
        {
            while(Inclinacao < EnumInclinacaoCabeca.Repouso)
            {
                Inclinacao++;
            }

            while (Inclinacao > EnumInclinacaoCabeca.Repouso)
            {
                Inclinacao--;
            }

            while (Rotacao < EnumRotacaoCabeca.Repouso)
            {
                Rotacao++;
            }

            while (Rotacao > EnumRotacaoCabeca.Repouso)
            {
                Rotacao--;
            }
        }
        #endregion

        #region Inclinação
        public void InclinaCabeca(EnumSentidoMovimento sentidoMovimento)
        {
            switch (sentidoMovimento)
            {
                case EnumSentidoMovimento.Positivo:

                    if (Inclinacao >= EnumInclinacaoCabeca.Cima)
                    {
                        return;
                    }

                    Inclinacao++;

                    break;
                case EnumSentidoMovimento.Negativo:

                    if (Inclinacao <= EnumInclinacaoCabeca.Baixo)
                    {
                        return;
                    }

                    Inclinacao--;

                    break;
                default:
                    return;
            }
        }
        #endregion

        #region Rotação
        public void RotacionaCabeca(EnumSentidoMovimento sentidoMovimento)
        {
            while (Inclinacao == EnumInclinacaoCabeca.Baixo)
            {
                return;
            }

            switch (sentidoMovimento)
            {
                case EnumSentidoMovimento.Positivo:

                    if (Rotacao >= EnumRotacaoCabeca.Positivo90)
                    {
                        return;
                    }

                    Inclinacao++;

                    break;
                case EnumSentidoMovimento.Negativo:

                    if (Rotacao <= EnumRotacaoCabeca.Negativo90)
                    {
                        return;
                    }

                    Inclinacao--;

                    break;
                default:
                    return;
            }
        }
        #endregion
    }

    public enum EnumInclinacaoCabeca
    {
        Cima = 0,
        Repouso = 1,
        Baixo = 2
    }

    public enum EnumRotacaoCabeca
    {
        Negativo90 = 0,
        Negativo45 = 1,
        Repouso = 2,
        Positivo45 = 3,
        Positivo90 = 4
    }
}
