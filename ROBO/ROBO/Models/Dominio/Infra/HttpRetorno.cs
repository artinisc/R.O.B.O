namespace ROBO.Models.Dominio
{
    public class HttpRetorno
    {
        public HttpRetorno(bool suscesso, string mensagem, object conteudo)
        {
            Success = suscesso;
            Message = mensagem;
            Content = conteudo;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Content { get; set; }
    }
}
