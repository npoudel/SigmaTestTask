using BLL;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

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
        [HttpGet("[action]", Name = "Index")]
        public IActionResult Index()
        {
            return Ok(new { Message = "API called successfully." });
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
            catch
            {
                return BadRequest();
            }            
        }
    }
}
