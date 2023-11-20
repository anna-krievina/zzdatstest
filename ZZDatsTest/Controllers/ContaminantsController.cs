using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZZDatsTest.Models;

namespace ZZDatsTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaminantsController : Controller
    {
        private readonly ZzdatstestdbContext _context;

        public ContaminantsController(ZzdatstestdbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ListAll")]
        public IEnumerable<Contaminant> ListAll()
        {
            return _context.Contaminants.OrderBy(i => i.Id).ToList();
        }

        [HttpGet]
        [Route("MetalsInSpecies")]
        public IEnumerable<MetalsInSpecy> MetalsInSpecies()
        {
            return _context.MetalsInSpecies.ToList();
        }

        [HttpGet]
        [Route("ParametersInYears")]
        public IEnumerable<ParametersInYear> ParametersInYears()
        {
            return _context.ParametersInYears.ToList();
        }
    }
}
