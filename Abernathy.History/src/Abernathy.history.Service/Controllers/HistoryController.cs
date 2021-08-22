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
            var notes = await _historyService.GetAllNotes();
            return notes;
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

            return item;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Note>> PostAsync(NoteDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }
            
            return CreatedAtAction(nameof(GetByIdAsync), new { model.Id }, model);
        }

        [HttpPut("note/{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAsync(int Id, NoteDTO updatedModel)
        {
            var existingItem = await _historyService.GetNoteById(Id);

            if (existingItem == null)
            {
                return NotFound();
            }         
            
            return NoContent();
        }

        [HttpDelete("note/{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest();
            }

            var existingNote = await _historyService.GetNoteById(Id);
            if (existingNote == null)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}
