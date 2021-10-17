using System;
using System.Threading.Tasks;
using Abernathy.Demographics.Service.Models.DTOs;
using Abernathy.Demographics.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Abernathy.Demographics.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        /// <summary>
        /// Action to see all patients.
        /// </summary>
        /// <returns>Returns a list of all patients</returns>
        /// <response code="200">Returned all the patients present</response>
        /// <response code="400">Returned if the patients couldn't be loaded from Database</response>

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = _patientService.GetAllPatients();
            return Ok(result);
        }


        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var result = _patientService.GetPatientById(Id);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost()]
        public async Task<IActionResult> Add(PatientDTO patientDTO)
        {
            if (patientDTO == null)
            {
                throw new ArgumentNullException();
            }

            var result = _patientService.CreatePatient(patientDTO);

            // return an anonyme object with ID
            return CreatedAtAction(nameof(GetById), new { result.Id }, result);
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update(int Id, PatientDTO patientDTO)
        {
            if (patientDTO == null)
            {
                throw new ArgumentNullException();
            }

            if (Id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _patientService.UpdatePatient(Id, patientDTO);
            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            if (Id <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            await _patientService.DeletePatientById(Id);
            return NoContent();
        }
    }
}