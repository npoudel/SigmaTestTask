using Domain.Model;

namespace DAL
{
    public interface ICandidateRepository
    {
        /// <summary>
        /// find all candidates
        /// </summary>
        /// <returns></returns>
        List<Candidate> GetAllCandidates();
        /// <summary>
        /// get all candidate details by id
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Candidate GetCandidateByEmail(string email);
        /// <summary>
        /// add candidate details
        /// </summary>
        /// <param name="candidate"></param>
        void AddCandidate(Candidate candidate);
        /// <summary>
        /// update candidate
        /// </summary>
        /// <param name="candidate"></param>
        void UpdateCandidate(Candidate candidate);
        void SaveChanges();
    }
}
