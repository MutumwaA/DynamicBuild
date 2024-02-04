using Application.Sentences;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBuild.API.Controllers
{
    public class SentenceController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetSentences([FromQuery] SentenceParams param)
        {
            return HandlePagedResult(await Mediator.Send(new List.Query { Params = param }));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSentence(Guid id)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSentence(Sentence sentence)
        {
            return HandleResult(await Mediator.Send(new Create.Command { Sentence = sentence }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(Guid id, Sentence sentence)
        {
            sentence.Id = id;
            return HandleResult(await Mediator.Send(new Edit.Command { Sentence = sentence }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
        }

    }
}
