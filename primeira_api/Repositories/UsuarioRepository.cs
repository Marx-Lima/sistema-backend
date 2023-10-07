using MySql.Data.MySqlClient;
using primeira_api.Entities;

namespace primeira_api.Repositories
{
    public class UsuarioRepository
    {
        private string _connection_string;

        public UsuarioRepository(string connection_string)
        {
            _connection_string = connection_string;
        }

        public int Inserir(Usuario usuario)
        {
            var cnn = new MySqlConnection(_connection_string);

            var cmd = new MySqlCommand();
            cmd.Connection = cnn;

            cmd.CommandText = "INSERT INTO usuario(nome, cpf, celular, genero, email, senha, usuarioGuid) VALUES (@nome, @cpf, @celular, @genero, @email, @senha, @usuarioGuid)";

            cmd.Parameters.AddWithValue("nome", usuario.Nome);
            cmd.Parameters.AddWithValue("cpf", usuario.CPF);
            cmd.Parameters.AddWithValue("celular", usuario.Celular);
            cmd.Parameters.AddWithValue("genero", usuario.Genero);
            cmd.Parameters.AddWithValue("email", usuario.Email);
            cmd.Parameters.AddWithValue("senha", usuario.Senha);
            cmd.Parameters.AddWithValue("usuarioGuid", usuario.UsuarioGuid);

            cnn.Open();

            var affectedRows = cmd.ExecuteNonQuery();

            cnn.Close();

            return affectedRows;
        }
        public Usuario ObterUsuario(string email)
        {
            Usuario usuario = null;
            MySqlConnection cnn = new MySqlConnection(_connection_string);

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = cnn;

            cmd.CommandText = "SELECT * FROM usuario WHERE email = @email";

            cmd.Parameters.AddWithValue("email", email);

            cnn.Open ();

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuario = new Usuario();
                usuario.Nome = reader["nome"].ToString();
                usuario.CPF = reader["cpf"].ToString();
                usuario.Celular = reader["celular"].ToString();
                usuario.Genero = reader["genero"].ToString();
                usuario.Email = reader["email"].ToString();
                usuario.Senha = reader["senha"].ToString();
                usuario.UsuarioGuid = new Guid(reader["usuarioGuid"].ToString());
            }
            return usuario;
        }

        public Usuario ObterPorGuid(Guid usuarioGuid)
        {
            Usuario usuario = null;

            var cnn = new MySqlConnection(_connection_string);

            var cmd = new MySqlCommand();
            cmd.Connection = cnn;
            cmd.CommandText = "SELECT * FROM usuario WHERE usuarioGuid = @usuarioGuid";

            cmd.Parameters.AddWithValue("usuarioGuid", usuarioGuid);

            cnn.Open();

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuario = new Usuario();
                usuario.Nome = reader["nome"].ToString();
                usuario.CPF = reader["cpf"].ToString();
                usuario.Celular = reader["celular"].ToString();
                usuario.Genero = reader["genero"].ToString();
                usuario.Email = reader["email"].ToString();
                usuario.Senha = reader["senha"].ToString();
                usuario.UsuarioGuid = new Guid(reader["usuarioGuid"].ToString());
            }

            cnn.Close();

            return usuario;
        }
    }
}
