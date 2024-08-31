namespace ROBO.Models.Dominio
{
    public class RoboBecomexMapper : IRoboBecomexMapper
    {
        public RoboBecomex Novo()
        {
            var roboBecomex = new RoboBecomex()
            {
                Ativo = true,
                Codigo = new Guid()
            };

            return roboBecomex;
        }
    }
}
