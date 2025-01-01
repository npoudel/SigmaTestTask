using BLL;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace CandidateInformation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="candidateService"></param>        
        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]", Name = "GetCandidates")]
        public IActionResult GetCandidates()
        {
            try
            {
                return Ok(_candidateService.GetCandidates());
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// add update candidate
        /// </summary>
        /// <param name="candidate"></param>
        /// <returns></returns>

        [HttpPost("[action]",Name = "AddOrUpdateCandidate")]
        public IActionResult AddOrUpdateCandidate([FromBody] Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                _candidateService.AddOrUpdateCandidate(candidate);
                return Ok(new { Message = "Candidate saved successfully." });
            }
            catch(Exception ex)
            {
                return BadRequest();
            }            
        }
    }
}
