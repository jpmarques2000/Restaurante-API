using Microsoft.AspNetCore.Mvc;
using RestauranteAPI.DTO;
using RestauranteAPI.Entity;
using RestauranteAPI.Interface;

namespace RestauranteAPI.Controllers
{
    [ApiController]
    [Route("Refeicao")]
    public class RefeicaoController : ControllerBase
    {
        private readonly IRefeicaoRepository _refeicaoRepository;
        //private readonly ILogger<RefeicaoController> _logger;

        public RefeicaoController(IRefeicaoRepository refeicaoRepository)
        {
            _refeicaoRepository = refeicaoRepository;
            //_logger = logger;
        }

        [HttpGet("orders/{id}")]
        public IActionResult GetAllProductOrders(int id)
        {
            return Ok(_refeicaoRepository.GetOrders(id));
        }

        [HttpGet]
        public IActionResult GetAllMeals() 
        { 
            return Ok(_refeicaoRepository.GetAll());
        }


        [HttpGet("get-by-meal-id/{id}")]
        public IActionResult GetByMealId(int id)
        {
            return Ok(_refeicaoRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult NewMeal(CadastrarRefeicaoDTO refeicaoDTO)
        {
             _refeicaoRepository.AddNew(new Refeicao(refeicaoDTO));
            return Ok("Refeição cadastrada com sucesso!");
        }

        [HttpPut]
        public IActionResult UpdateMeal(AlterarRefeicaoDTO refeicaoDTO)
        {
            _refeicaoRepository.Update(new Refeicao(refeicaoDTO));
            return Ok("Refeição alterada com sucesso");
        }

        [HttpDelete]
        public IActionResult DeleteMeal(int id) 
        {
            _refeicaoRepository.Delete(id);
            return Ok("Refeição deletada com sucesso");
        }
    }
}
