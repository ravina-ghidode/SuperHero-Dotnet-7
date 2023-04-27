using SuperHeroWebApi.Entities;

namespace SuperHeroWebApi.Interfaces
{
    public interface ISuperHero
    {
        Task<ServiceResponse<List<GetSuperHeroDto>>> GetAllHeroes();
        Task<ServiceResponse<GetSuperHeroDto?>> GetSingleHero(int id);
        Task<ServiceResponse<List<GetSuperHeroDto>?>> AddHero(AddSuperHeroDto newHero);
        Task<ServiceResponse<List<GetSuperHeroDto>?>> UpdateHero(UpdateSuperHeroDto request);
        Task<ServiceResponse<List<GetSuperHeroDto>?>> DeleteHero(int id);

    }
}
