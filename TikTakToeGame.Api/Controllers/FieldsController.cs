using Microsoft.AspNetCore.Mvc;

using TikTakToeGame.Business.Services;
using TikTakToeGame.Entities;
using TikTakToeGame.Repositories;

namespace TikTakToeGame.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class FieldsController : ControllerBase
    {
        private IFieldService _entityServise;

        public FieldsController(IFieldService entityServise)
        {
            _entityServise = entityServise;
        }
        [HttpGet]
        public async Task<IEnumerable<Field>> GetAllFields()
        {
            var result = await _entityServise.GetAllItemsAsync();

            return result;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Field>> GetFieldById(int id)
        {
            var result = await _entityServise.GetItemByIdAsync(id);
            if (result is null)
                return NotFound();
            return result;
        }
        [HttpPost]
        public async Task<ActionResult<Field>> CreateField()
        {
            await _entityServise.CreateItemAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateField(int id, [FromBody] string positions)
        {
            await _entityServise.UpdateItemAsync(positions, id);

            return Ok();
        }
        [HttpPut("{id}/players")]
        public async Task<IActionResult> UpdateFieldPlayers(int id, [FromBody] string players)
        {
            await _entityServise.UpdatePlayersAsync(players, id);

            return Ok();
        }

    }
}
