namespace SuperHeroWebApi
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<SuperHero, GetSuperHeroDto>().ReverseMap();
            CreateMap<SuperHero, AddSuperHeroDto>().ReverseMap();
            CreateMap<SuperHero, UpdateSuperHeroDto>().ReverseMap();
        }
    }
}
