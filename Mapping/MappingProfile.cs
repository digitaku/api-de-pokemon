using api_de_pokemon.Dto;
using api_de_pokemon.Entities;
using AutoMapper;

namespace api_de_pokemon.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pokemon, PokemonDto>().ReverseMap();
            CreateMap<Types, TypesDto>().ReverseMap();
            CreateMap<Abilities, AbilitiesDto>().ReverseMap();
        }
    }
}