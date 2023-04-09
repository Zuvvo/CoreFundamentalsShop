using CoreFundamentalsShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreFundamentalsShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IPieRepository _pieRepository;

        public SearchController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_pieRepository.AllPies);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if(_pieRepository.AllPies.Any(p=>p.PieId == id) == false)
            {
                return NotFound();
            }
            else
            {
                return Ok(_pieRepository.AllPies.Where(p=>p.PieId == id));
            }
        }

        [HttpPost]
        public IActionResult SearchPies([FromBody] string searchQuery)
        {
            IEnumerable<Pie> pies = new List<Pie>();

            if (string.IsNullOrEmpty(searchQuery) == false)
            {
                pies = _pieRepository.SearchPies(searchQuery);
            }
            return new JsonResult(pies);
        }
    }
}
