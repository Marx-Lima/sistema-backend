using Microsoft.AspNetCore.Mvc;

namespace primeira_api.Controllers
{
    [Route("api/aula8")]
    public class aula8controller : Controller
    {
        [Route("olamundo")]
        [HttpGet]
        public string OlaMundo()
        {
            var mensagem = "Olá mundo via API";
            return mensagem;
        }

        [Route("Olapersonalizado")]
        [HttpGet]
        public string Olapersonalizado(string nome)
        {
            var mensagem = "Olá Mundo via API " + nome;
            return mensagem;
        }

        [Route("calculadora")]
        [HttpGet]

        public string Somar(int valor1, int valor2)
        {
            var Soma = valor1 + valor2;
            var mensagem = "A soma é " + Soma;
            return mensagem;
        }
    }
}
