namespace primeira_api.Models
{
    public class Carro : Veiculo
    {
        public Carro() 
        {
            Rodas = 4;
        }
        public int Rodas { get; set; }

        public override void acelerar()
        {
            InjetarCombustivel(4);
        }
        private void InjetarCombustivel(int qtdCombustivel)
        {
            base.TanqueCombustivel = base.TanqueCombustivel - qtdCombustivel;
        }
    }
}
