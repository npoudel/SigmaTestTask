using DAL;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.CandidateService
{
    public class CandidateService : ICandidateService
    {
        private readonly ICandidateRepository _repository;

        public CandidateService(ICandidateRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// add or update candidate
        /// </summary>
        /// <param name="candidate"></param>
        public void AddOrUpdateCandidate(Candidate candidate)
        {

            var candidateInfo = _repository.GetCandidateByEmail(candidate.Email);
            if (candidateInfo != null)
            {
                candidateInfo.FirstName = candidate.FirstName;
                candidateInfo.LastName = candidate.LastName;
                candidateInfo.PhoneNumber = candidate.PhoneNumber;
                candidateInfo.BestCallTime = candidate.BestCallTime;
                candidateInfo.LinkedInProfile = candidate.LinkedInProfile;
                candidateInfo.GitHubProfile = candidate.GitHubProfile;
                candidateInfo.Comment = candidate.Comment;
                _repository.UpdateCandidate(candidateInfo);
            }
            else
            {
                _repository.AddCandidate(candidate);
            }
            _repository.SaveChanges();
        }
    }
}
