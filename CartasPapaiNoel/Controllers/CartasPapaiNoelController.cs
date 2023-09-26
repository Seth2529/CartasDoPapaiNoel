using CartasPapaiNoel.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CartasPapaiNoel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartasPapaiNoelController : ControllerBase
    {
        string _arquivosCartasNoel = @".\Data\CartasPapaiNoel.json";

        #region Métodos arquivo
        private List<CartasPapaiNoelViewModel> ListarCartas()
        {
            if (!System.IO.File.Exists(_arquivosCartasNoel))
            {
                return new List<CartasPapaiNoelViewModel>();
            }
            Directory.CreateDirectory(_arquivosCartasNoel.Substring(0, _arquivosCartasNoel.LastIndexOf('\\') + 1));
            string Readjson = System.IO.File.ReadAllText(_arquivosCartasNoel);
            return JsonConvert.DeserializeObject<List<CartasPapaiNoelViewModel>>(Readjson);

        }

        private void EscreverCartasNoel(List<CartasPapaiNoelViewModel> Cartas)
        {
            string Readjson = JsonConvert.SerializeObject(Cartas);
            System.IO.File.WriteAllText(_arquivosCartasNoel, Readjson);
        }
        #endregion

        #region Operações CRUD
        [HttpGet]
        public IActionResult ListarTodasAsCartasNoel()
        {
            if (ListarCartas() != null)
            {
                List<CartasPapaiNoelViewModel> Cartas = ListarCartas();
                return Ok(Cartas);
            }
            return BadRequest("Nenhum jogo salvo");

        }

        [HttpPost]
        public IActionResult ReceberCartasNoel([FromBody] CartasPapaiNoelViewModel CartasNoel)
        {
                List<CartasPapaiNoelViewModel> cartas = ListarCartas();
            CartasPapaiNoelViewModel novaCarta = new CartasPapaiNoelViewModel()
            {
                NomeCrianca = CartasNoel.NomeCrianca,
                Rua = CartasNoel.Rua,
                Numero = CartasNoel.Numero,
                Bairro = CartasNoel.Bairro,
                Cidade = CartasNoel.Cidade,
                Estado = CartasNoel.Estado,
                IdadeCriancaEmAnos = CartasNoel.IdadeCriancaEmAnos,
                TextoCartaCrianca = CartasNoel.TextoCartaCrianca
                };

                cartas.Add(novaCarta);
                EscreverCartasNoel(cartas);

                return Ok("Carta Registrada com sucesso!");
            }
            #endregion
        }
}
