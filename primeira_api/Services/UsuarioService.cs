using primeira_api.Common;
using primeira_api.Entities;
using primeira_api.Models;
using primeira_api.Repositories;

namespace primeira_api.Services
{
    public class UsuarioService
    {
        private string _connection_string;
        public UsuarioService(string conection_string) 
        {
            _connection_string = conection_string;
        }
        public LoginResult Login(string email, string senha) 
        {
            var result = new LoginResult(); 

            var usuario_repository = new UsuarioRepository(_connection_string);

            var usuario = usuario_repository.ObterUsuario(email);

            if (usuario != null)
            {
                if(usuario.Senha == senha)
                {
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    result.sucesso = false;
                    result.mensagem = "Usuário ou senha inválidos.";
                }
            }
            else
            {
                result.sucesso = false;
                result.mensagem = "Usuário ou senha inválidos.";
            }

            return result;
        }
        public CadastroResult Cadastro(string nome, string cpf, string genero, string celular, string email,  string senha)
        {
            var result = new CadastroResult();

            var usuario_repository = new UsuarioRepository(_connection_string);

            var usuario = usuario_repository.ObterUsuario(email);

            if (usuario != null)
            {
                result.sucesso = false;
                result.mensagem = "Usuário já existe.";
            }
            else
            {
                usuario = new Usuario();
                usuario.Nome = nome;
                usuario.CPF = cpf;
                usuario.Genero = genero;
                usuario.Celular = celular;
                usuario.Email = email;
                usuario.Senha = senha;
                usuario.UsuarioGuid = Guid.NewGuid();

                var affectedRows = usuario_repository.Inserir(usuario);

                if (affectedRows > 0)
                {
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else 
                { 
                    result.sucesso = false;
                    result.mensagem = "Erro ao cadastrar Usuário. Tente novamente.";
                }
            }

            return result;
        }
        public esqueceu_senhaResult esqueceu_Senha(string email)
        {
            var result = new esqueceu_senhaResult();

            var usuario_repository = new UsuarioRepository(_connection_string);

            var usuario = usuario_repository.ObterUsuario(email);

            if (usuario == null)
            {
                result.sucesso = false;
                result.mensagem = "usuário não existe.";
            }
            else
            {
                var assunto = "Recuperação de senha";
                var corpo = "Sua senha é: " + usuario.Senha;
                var emailSender = new EmailSender();
                emailSender.Enviar(assunto, corpo, usuario.Email);
            }
            return result;
        }

        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepository(_connection_string).ObterPorGuid(usuarioGuid);

            return usuario;
        }
    }
}
