using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DCandidateController : Controller
    {
        private readonly IDCandidateRepository _context;
        public DCandidateController(IDCandidateRepository context)
        {
            _context = context;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Dcandidate>>> Search(string fullName)
        {
            try
            {
                var result = await _context.Search(fullName);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetCandidate()
        {
            try
            {
                return Ok(await _context.GetCandidate());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Dcandidate>> GetCandidateByID(int id)
        {
            try
            {
                var result = await _context.GetCandidateByID(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<Dcandidate>> GetCandidateByEmail(string email)
        {
            try
            {
                var result = await _context.GetCandidateByEmail(email);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Dcandidate>> AddCandidate(Dcandidate dcandidate)
        {
            try
            {
                if (dcandidate == null)
                {
                    return BadRequest();
                }

                var result = await _context.GetCandidateByEmail(dcandidate.eMail);

                if (result != null)
                {
                    ModelState.AddModelError("email", "Employee email already in use");
                    return BadRequest(ModelState);
                }

                var createdCandidate = await _context.AddCandidate(dcandidate);

                return CreatedAtAction(nameof(GetCandidate), new { id = dcandidate.id },
                    createdCandidate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }

        }

        [HttpPut()]
        public async Task<ActionResult<Dcandidate>> UpdateCandidate(Dcandidate dcandidate)
        {
            try
            {
                var dcandidateToUpdate = await _context.GetCandidateByEmail(dcandidate.eMail);

                if (dcandidateToUpdate == null)
                {
                    return NotFound($"Employee with Id = {dcandidate.id} not found");
                }

                return await _context.UpdateCandidate(dcandidate);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Dcandidate>> DeleteCandidate(int id)
        {
            try
            {
                var candidateToDelete = await _context.GetCandidateByID(id);

                if (candidateToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await _context.DeleteCandidate(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}

