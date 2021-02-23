using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RPG_dotnet.Models;

namespace RPG_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController: ControllerBase
    {
        //建立一個角色清單，裡面有預設角色與一個自定義角色名為"Sam"
        private static List<Character> characters = new List<Character> {
            new Character(),
            new Character { Id = 1,Name = "Sam"}
        };
        //此處要指定Route，因下面有相同的 IActionResult 類別方法存在，
        //直接呼叫系統會不知道要使用哪個方法，所以定義回傳 List 的方法為[Route("GetAll")],整合成[HttpGet("GetAll")]
        //這樣呼叫Get方法時會執行 GetSingle()，指定GetAll路由時呼叫Get()
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(characters);
        }
        //根據輸入ID回傳角色資料，LINQ語法
        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            return Ok(characters.FirstOrDefault(c => c.Id == id));
        }
    }
}