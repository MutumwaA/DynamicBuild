using Application.Words;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBuild.API.Controllers
{
    public class WordsController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetWords([FromQuery] WordParams param)
        {
            return Ok(await Mediator.Send(new List.Query { Params = param }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWord(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }


        [HttpPost]
        public async Task<IActionResult> CreateWord(Word word)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Word = word }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, Word word)
        {
            word.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Word = word }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

    }
}
