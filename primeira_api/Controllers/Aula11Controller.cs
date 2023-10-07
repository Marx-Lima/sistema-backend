using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using primeira_api.Models;

namespace primeira_api.Controllers
{
    [Route("api/aula11")]
    [ApiController]
    public class Aula11Controller : ControllerBase
    {
        [Route("obterVeiculo")]
        [HttpGet]
        public Veiculo obterVeiculo()
        {
            var meuVeiculo = new Veiculo();

            meuVeiculo.Cor = "Preto";
            meuVeiculo.marca = "Volks";
            meuVeiculo.Placa = "BAV9A93";
            meuVeiculo.Modelo = "Gol";

            meuVeiculo.acelerar();

            return meuVeiculo;
        }
        [Route("obterCarro")]
        [HttpGet]
        public Carro obterCarro()
        {
            var meuCarro = new Carro();

            meuCarro.marca = "Honda";
            meuCarro.Modelo = "Fit";
            meuCarro.Cor = "Branco";
            meuCarro.Placa = "DTR-2352";

            return meuCarro;
        }

        [Route("obterMoto")]
        [HttpGet]
        public Moto obterMoto()
        {
            var minhaMoto = new Moto();

            minhaMoto.marca = "Yamaha";
            minhaMoto.Modelo = "Lander";
            minhaMoto.Cor = "Vermelha";
            minhaMoto.Placa = "EED-3523";

            return minhaMoto;
        }
    }
}
