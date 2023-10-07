namespace primeira_api.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public Guid UsuarioGuid { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set;}
        public string Celular { get; set;}
        public string Genero { get; set;}
        public string Email { get; set; }
        public string Senha { get; set;}
    }
}
