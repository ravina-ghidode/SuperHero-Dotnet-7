using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace SuperHeroWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHero _superHero;

        public SuperHeroController(ISuperHero superHero)
        {
            _superHero = superHero;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetSuperHeroDto>>>> GetAllHeroes()
        {
           return Ok(await _superHero.GetAllHeroes());    
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetSuperHeroDto>>> GetSingleHero(int id)
        {
            var result =  await _superHero.GetSingleHero(id);
            if (result == null)
            {
                return NotFound("Hero doesnt exist");
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetSuperHeroDto>>>> AddHero(AddSuperHeroDto hero)
        {
            var result = await _superHero.AddHero(hero);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<GetSuperHeroDto>>>> UpdateHero(UpdateSuperHeroDto request)
        {
           var result = await _superHero.UpdateHero(request);
            if(result == null)
            {
                return NotFound("Hero doesnt exist");
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetSuperHeroDto>>>> DeleteHero(int id)
        {
            var result = await _superHero.DeleteHero(id);
            if(result == null)
            {
                return NotFound("Hero not found");
            }
           return Ok(result);
        }
    }
}
