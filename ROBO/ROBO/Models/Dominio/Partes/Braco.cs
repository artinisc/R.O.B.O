namespace ROBO.Models.Dominio
{
    public class Braco
    {
        public Braco()
        {
            Cotovelo = EnumEstadoCotovelo.Repouso;
            Pulso = EnumEstadoPulso.Repouso;
        }

        private EnumEstadoCotovelo Cotovelo { get; set; }
        private EnumEstadoPulso Pulso { get; set; }

        #region Cotovelo
        public void MoveCotovelo(EnumSentidoMovimento sentidoMovimento)
        {
            switch (sentidoMovimento)
            {
                case EnumSentidoMovimento.Positivo:

                    if (Cotovelo >= EnumEstadoCotovelo.FortementeContraido)
                    {
                        return;
                    }

                    Cotovelo++;

                    break;
                case EnumSentidoMovimento.Negativo:

                    if (Cotovelo <= EnumEstadoCotovelo.Repouso)
                    {
                        return;
                    }

                    Cotovelo--;

                    break;
                default:
                    return;
            }
        }
        #endregion

        #region Pulso
        public void RotacionaPulso(EnumSentidoMovimento sentidoMovimento)
        {
            switch (sentidoMovimento)
            {
                case EnumSentidoMovimento.Positivo:

                    if (Pulso >= EnumEstadoPulso.Positivo180)
                    {
                        return;
                    }

                    Pulso++;

                    break;
                case EnumSentidoMovimento.Negativo:

                    if (Pulso <= EnumEstadoPulso.Negativo90)
                    {
                        return;
                    }

                    Pulso--;

                    break;
                default:
                    return;
            }
        }
        #endregion
    }

    public enum EnumEstadoCotovelo
    {
        Repouso = 0,
        LevementeContraido = 1,
        Contraido = 2,
        FortementeContraido = 3
    }

    public enum EnumEstadoPulso
    {
        Negativo90 = 0,
        Negativo45 = 1,
        Repouso = 2,
        Positivo45 = 3,
        Positivo90 = 4,
        Positivo135 = 5,
        Positivo180 = 6
    }
}
