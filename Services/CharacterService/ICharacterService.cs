using System.Collections.Generic;
using System.Threading.Tasks;
using RPG_dotnet.Dtos.Character;
using RPG_dotnet.Models;

namespace RPG_dotnet.Services.CharacterService
{
    public interface ICharacterService
    {
        //獲取全部的角色資料
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        //獲取該ID角色資料
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        //新增角色
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        //修改角色資料
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updateCharacter);
        //刪除角色
        Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharater(int id);
    }
}