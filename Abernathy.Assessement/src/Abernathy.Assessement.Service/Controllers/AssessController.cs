using Abernathy.Assessement.Service.Models.Entities;
using Abernathy.Assessement.Service.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abernathy.Assessement.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessController : ControllerBase
    {
        private readonly IAssessementService _assessementService;
        public AssessController(IAssessementService assessementService)
        {
            _assessementService = assessementService;
        }

        [HttpGet("Patient/{patientId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAsync(int patientId)
        {
            if (patientId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(patientId));
            }

            var result = await _assessementService.GenerateDiabetesReport(patientId);
            return Ok(result);
        }       
    }
}
