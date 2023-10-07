namespace primeira_api.Models
{
    public class Moto : Veiculo
    {
        public Moto()
        {
            Rodas = 2;
            TanqueCombustivel = 15;
        }
        public int Rodas { get; set; }

        public override void acelerar()
        {
            InjetarCombustivel(1);
        }
        private void InjetarCombustivel(int qtdCombustivel)
        {
            base.TanqueCombustivel = base.TanqueCombustivel - qtdCombustivel;
        }
    }
}
