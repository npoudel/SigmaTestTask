using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface ICandidateService
    {
        /// <summary>
        /// add or update candidate
        /// </summary>
        /// <param name="candidate"></param>
        void AddOrUpdateCandidate(Candidate candidate);
        /// <summary>
        /// get all candidates
        /// </summary>
        /// <returns></returns>
        List<Candidate> GetCandidates();
    }
}
