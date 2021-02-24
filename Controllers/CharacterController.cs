using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPG_dotnet.Dtos.Character;
using RPG_dotnet.Models;
using RPG_dotnet.Services.CharacterService;

namespace RPG_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        //串接Service類別功能
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            //此處為this.characterService，實務上習慣用_來替代this增加可讀性
            _characterService = characterService;

        }

        //此處要指定Route，因下面有相同的 IActionResult 類別方法存在，
        //直接呼叫系統會不知道要使用哪個方法，所以定義回傳 List 的方法為[Route("GetAll")],整合成[HttpGet("GetAll")]
        //這樣呼叫Get方法時會執行 GetSingle()，指定GetAll路由時呼叫Get()
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }
        //根據輸入ID回傳角色資料，LINQ語法
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }
        //新增角色
        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
    }
}