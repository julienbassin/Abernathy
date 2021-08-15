using Abernathy.history.Service.Models.DTOs;
using Abernathy.history.Service.Models.Entities;
using Abernathy.history.Service.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abernathy.history.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<Note>> GetAsync()
        {
            var items = (await _itemsRepo.GetAllAsync()).Select(item => item.AsDto());
            return items;
        }

        [HttpGet("note/{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Note>> GetByIdAsync(int Id)
        {
            var item = await _historyService.GetNoteById(Id);

            if (item == null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Note>> PostAsync(CreatedNoteDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            var item = new Item
            {
                Name = model.Name,
                Description = model.Description,
                Price = model.Price,
                CreatedDate = DateTimeOffset.UtcNow

            };

            await _itemsRepo.CreateAsync(item);
            return CreatedAtAction(nameof(GetByIdAsync), new { item.Id }, item);
        }

        [HttpPut("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAsync(int Id, NoteDTO updatedModel)
        {
            var existingItem = await _itemsRepo.GetAsync(Id);

            if (existingItem == null)
            {
                return NotFound();
            }            

            
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var existingNote = await _historyService.GetNoteByIdAsync(Id);
            if (existingNote == null)
            {
                return NotFound();
            }

            
            return NoContent();
        }
    }
}
