using Domain.Model;
using Microsoft.EntityFrameworkCore;
namespace DAL
{
    public class CandidateRepository : ICandidateRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CandidateRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Candidate> GetAllCandidates() 
        {
            return  _dbContext.Candidates.ToList();
        }

        /// <summary>
        /// Find all candidate information from email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Candidate? GetCandidateByEmail(string email)
        {
            return _dbContext.Candidates.Find(email);
        }

        /// <summary>
        /// save candidate
        /// </summary>
        /// <param name="candidate"></param>
        public void AddCandidate(Candidate candidate)
        {
            _dbContext.Candidates.Add(candidate);
        }

        /// <summary>
        /// update candidate
        /// </summary>
        /// <param name="candidate"></param>
        public void UpdateCandidate(Candidate candidate)
        {
            _dbContext.Candidates.Attach(candidate);
            _dbContext.Entry(candidate).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
