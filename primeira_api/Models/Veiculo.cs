namespace primeira_api.Models
{
    public class Veiculo
    {
        //constutor
        public Veiculo()
        {
            TanqueCombustivel = 40;
        }
        //atributos ou propriedades
        public string Cor { get; set; }
        public string marca { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public int TanqueCombustivel { get; set; }

        //metodos
        public virtual void acelerar()
        {
            injetarCombustivel(1);
        }
        public virtual void frear()
        {

        }
        private void injetarCombustivel(int qtdCombustivel)
        {
            TanqueCombustivel = TanqueCombustivel - qtdCombustivel;
        }
    }
}
