using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using primeira_api.Models;
using primeira_api.Services;
using System.Reflection.Metadata.Ecma335;

namespace primeira_api.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        [Route ("login")]
        [HttpPost]
        public LoginResult Login(LoginRequest request)
        {
            var result = new LoginResult();

            if (request == null)
            {
                result.sucesso = false;
                result.mensagem = "Parametro Request veio nulo.";
            }
            else if (request.email == "")
            {
                result.sucesso = false;
                result.mensagem = "email obrigatório";
            }
            else if (request.senha == "")
            {
                result.sucesso = false;
                result.mensagem = "senha obrigatoria";
            }
            else
            {
                var connection_string = _configuration.GetConnectionString("programacao_zeroDB");
                var usuario_service = new UsuarioService(connection_string);
                result = usuario_service.Login(request.email, request.senha);
            }

            return result;
        }

        [Route ("cadastro")]
        [HttpPost]
        public CadastroResult Cadastro(CadastroRequest request)
        {
            var result = new CadastroResult();

            if (request == null ||
                string.IsNullOrWhiteSpace(request.nome) ||
                string.IsNullOrWhiteSpace(request.cpf) ||
                string.IsNullOrWhiteSpace(request.genero) ||
                string.IsNullOrWhiteSpace(request.celular) ||
                string.IsNullOrWhiteSpace (request.email) ||
                string.IsNullOrWhiteSpace(request.senha))
            {
                result.sucesso = false;
                result.mensagem = "Todos os campos são obrigatórios.";
            }
            else
            {
                var connection_string = _configuration.GetConnectionString("programacao_zeroDB");
                var usuario_service = new UsuarioService(connection_string);

                result = usuario_service.Cadastro(request.nome, request.cpf, request.genero, request.celular, request.email, request.senha);
            }
            return result;
        }

        [Route("esqueceu_senha")]
        [HttpPost]
        public esqueceu_senhaResult Esqueceu_senha(esqueceu_senhaRequest request)
        {
            var result = new esqueceu_senhaResult();

            if (request == null || string.IsNullOrEmpty(request.email))
            {
                result.sucesso = false;
                result.mensagem = "Email obrigatório";
            }
            else
            {
                var connection_string = _configuration.GetConnectionString("programacao_zeroDB");
                var usuario_service = new UsuarioService(connection_string);
                result = usuario_service.esqueceu_Senha(request.email);
            }
            return result;
        }

        [Route("obterUsuario")]
        [HttpGet]
        public ObterUsuarioResult ObterUsuario(Guid usuarioGuid)
        {
            var result = new ObterUsuarioResult();

            if (usuarioGuid == null)
            {
                result.mensagem = "Usuario Guid vazio.";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacao_zeroDB");

                var usuario = new UsuarioService(connectionString).ObterUsuario(usuarioGuid);

                if (usuario == null)
                {
                    result.mensagem = "Usuario não existe.";
                }
                else
                {
                    result.sucesso = true;
                    result.nome = usuario.Nome;
                }
            }

            return result;
        }
    }
}
