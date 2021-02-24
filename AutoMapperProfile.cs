using AutoMapper;
using RPG_dotnet.Dtos.Character;
using RPG_dotnet.Models;

namespace RPG_dotnet
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
            CreateMap<AddCharacterDto, Character>();
        }
    }
}