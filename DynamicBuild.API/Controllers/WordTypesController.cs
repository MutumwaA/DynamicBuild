using Application.WordTypes;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBuild.API.Controllers
{
    public class WordTypesController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetWordTypes()
        {
            return Ok(await Mediator.Send(new List.Query { }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWordType(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }


        [HttpPost]
        public async Task<IActionResult> CreateWordType(WordType wordType)
        {
            return HandleResult(await Mediator.Send(new Create.Command { WordType = wordType }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, WordType wordType)
        {
            wordType.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { WordType = wordType }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
