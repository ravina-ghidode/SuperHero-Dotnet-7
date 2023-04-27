using Microsoft.EntityFrameworkCore;

namespace SuperHeroWebApi.Repositories.SuperHeroService
{
    public class SuperHeroService : ISuperHero
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SuperHeroService(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<GetSuperHeroDto>?>> AddHero(AddSuperHeroDto newHero)
        {
            var serviceResponse = new ServiceResponse<List<GetSuperHeroDto>>();
            try
            {
                var hero = _mapper.Map<SuperHero>(newHero);
                _context.SuperHeroes.Add(hero);
                await _context.SaveChangesAsync();
                serviceResponse.Data = await _context.SuperHeroes.
                    Select(h => _mapper.Map<GetSuperHeroDto>(h)).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }
           
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetSuperHeroDto>?>> DeleteHero(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetSuperHeroDto>>();

            var hero = await _context.SuperHeroes.FirstOrDefaultAsync(h => h.Id == id);
            if (hero == null)
            {
                return null;
            }
            else
            {
                _context.SuperHeroes.Remove(hero);
                await _context.SaveChangesAsync();
                serviceResponse.Data =  await _context.SuperHeroes.
                    Select(h => _mapper.Map<GetSuperHeroDto>(h)).ToListAsync();
                
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetSuperHeroDto>>> GetAllHeroes()
        {
            var serviceResponse = new ServiceResponse<List<GetSuperHeroDto>>();
            var heroes = await  _context.SuperHeroes.ToListAsync();
            serviceResponse.Data = heroes.Select(h => _mapper.Map<GetSuperHeroDto>(h)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetSuperHeroDto>?> GetSingleHero(int id)
        {
            var serviceResponse = new ServiceResponse<GetSuperHeroDto>();
            var hero = await _context.SuperHeroes.FirstOrDefaultAsync(h => h.Id == id);
            if (hero == null)
                return null;
            serviceResponse.Data = _mapper.Map<GetSuperHeroDto>(hero);
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<GetSuperHeroDto>?>> UpdateHero(UpdateSuperHeroDto request)
        {
            var serviceResponse = new ServiceResponse<List<GetSuperHeroDto>>();
            try
            {
                var hero = await _context.SuperHeroes.FirstOrDefaultAsync(h => h.Id == request.Id);
                if (hero == null)
                {
                    return null;
                }

                else
                {
                    hero.FirstName = request.FirstName;
                    hero.LastName = request.LastName;
                    hero.Name = request.Name;
                    hero.Place = request.Place;
                    await _context.SaveChangesAsync();
                    serviceResponse.Data = await _context.SuperHeroes.
                        Select(h => _mapper.Map<GetSuperHeroDto>(h)).ToListAsync();

                }

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }


            return serviceResponse;
        }

        
    }
}
