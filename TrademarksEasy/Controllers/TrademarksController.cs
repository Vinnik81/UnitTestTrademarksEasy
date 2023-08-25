using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TrademarksEasy.Services;

namespace TrademarksEasy.Controllers
{
    [Route("trademark")]
    //Время жизни:
    //Singleton:
    //то экземпляр такого класса будет жить пока живет приложение ASP (DI-контейнер);
    //Scoped: 
    //то экз. класса будет жить пока жив запрос;
    //Transient:
    //то при каждом получении такого класса, будет создан новый экземпляр.
    public class TrademarksController : ControllerBase
    {
        //google true
        //google false
        private readonly TrademarksService _trademarksService;
        public TrademarksController(TrademarksService trademarksService) 
        {
            _trademarksService = trademarksService ?? throw new ArgumentNullException(nameof(trademarksService));   
        }

        [HttpGet("register")]
        public ActionResult<bool> Register(string trademark)
        {
            if (_trademarksService.TryAdd(trademark)) 
            {
                return Ok("ТМ зарегестрированна!");
            }
            else 
            {
                return BadRequest("Такая марка уже зарегистрирована!");
            }
        }
    }
}
