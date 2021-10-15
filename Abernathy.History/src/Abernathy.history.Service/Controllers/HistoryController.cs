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
        private readonly IHistoryService _historyService;
        private readonly IHttpExternalApiService _externalApiService;

        public HistoryController(IHistoryService historyService,
                                 IHttpExternalApiService externalApiService)
        {
            _historyService = historyService;
            _externalApiService = externalApiService;
        }

        [HttpGet]
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

        [HttpGet("patient/{patientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Note>>> GetNotesByPatientId(int patientId)
        {
            var result = await _historyService.GetNotesByPatientIdAsync(patientId);

            var enumerable = result as Note[] ?? result.ToArray();

            if (!enumerable.Any())
            {
                return NotFound();
            }

            return Ok(enumerable);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Note>> Add(NoteDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            await _historyService.CreateNote(model);
            
            return CreatedAtAction(nameof(GetByIdAsync), new { model.Id }, model);
        }

        [HttpPut("note/{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAsync(int Id, NoteDTO updatedModel)
        {
            if (!await _externalApiService.PatientExists(updatedModel.PatientId))
            {
                return NotFound("Patient not found");
            }

            var existingItem = await _historyService.GetNoteById(Id);

            if (existingItem == null)
            {
                return NotFound();
            }
            
            await _historyService.UpdateNote(updatedModel);
            
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

            _historyService.DeleteNote(Id);

            return NoContent();
        }
    }
}
